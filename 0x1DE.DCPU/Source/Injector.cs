using System;
using System.Text;
using System.Runtime.InteropServices;
using OxIDE.DCPU.Source;

namespace OxIDE.DCPU
{
    public class Injector
    {
        private delegate bool EnumWindowsProc(IntPtr hWnd, ref SearchData data);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, ref SearchData data);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(
           IntPtr hProcess,
           IntPtr lpBaseAddress,
           byte[] lpBuffer,
           Int32 nSize,
           out IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(
           IntPtr hProcess,
           IntPtr lpBaseAddress,
           short[] lpBuffer,
           Int32 nSize,
           out IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(
           IntPtr hProcess,
           IntPtr lpBaseAddress,
           out short lpBuffer,
           Int32 nSize,
           out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(
          IntPtr hProcess,
          IntPtr lpBaseAddress,
          ushort[] lpBuffer,
          Int32 nSize,
          out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(
             ProcessAccessFlags processAccess,
             bool bInheritHandle,
             int processId
        );

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        public SearchData s;

        private CachedValue<int> _regsAddr = null;
        private CachedValue<int> _memAddr = null;

        public int memAddr
        {
            get
            {
                if (_memAddr != null)
                {
                    if (!_memAddr.expired)
                        return _memAddr.value;
                }

                int value = SendMessage(s.hWnd, 0x0400, 2, 0); // mem address
                _memAddr = new CachedValue<int>()
                {
                    value = value
                };
                return _memAddr.value;
            }
        }

        public int regsAddr
        {
            get
            {
                if (_regsAddr != null)
                {
                    if (!_regsAddr.expired)
                        return _regsAddr.value;
                }

                int value = SendMessage(s.hWnd, 0x0400, 3, 0); // registers address
                _regsAddr = new CachedValue<int>()
                {
                    value = value
                };
                return _regsAddr.value;
            }
        }

        IntPtr proc;

        public short offset = 0x0000;

        private static Injector _instance;

        public bool Loaded => proc != IntPtr.Zero;

        public static Injector Instance()
        {
            var instance = new Injector();
            if (_instance == null)
            {
                if (instance.s.pId != 0)
                {
                    _instance = instance;
                    return _instance;
                }
            }

            return instance;
        }

        private Injector()
        {
            s = SearchForWindow("GTA: Vice City");
            if (s.pId == 0)
            {
                return;
            }
            proc = OpenProcess(ProcessAccessFlags.All, false, (int)s.pId);
        }

        public static SearchData SearchForWindow(string title)
        {
            SearchData sd = new SearchData { Title = title };
            EnumWindows(new EnumWindowsProc(EnumProc), ref sd);
            return sd;
        }

        public static bool EnumProc(IntPtr hWnd, ref SearchData data)
        {
            var sb = new StringBuilder(1024);
            GetWindowText(hWnd, sb, sb.Capacity);
            if (sb.ToString().StartsWith(data.Title))
            {
                data.hWnd = hWnd;
                data.Title = sb.ToString();

                GetWindowThreadProcessId(hWnd, out data.pId);

                return false;    // Found the wnd, halt enumeration
            }
            return true;
        }

        public short[] ReadRegs()
        {
            var regs = new short[24];
            IntPtr o;
            ReadProcessMemory(proc, new IntPtr(regsAddr), regs, 24, out o);
            return regs;
        }

        public short[] ReadMem()
        {
            var memBytes = new short[2000];
            IntPtr o;
            ReadProcessMemory(proc, new IntPtr(memAddr + offset), memBytes, 8 * 16, out o);

            return memBytes;
        }

        public void InjectByteCode(ushort[] data)
        {
            IntPtr o;
            WriteProcessMemory(proc,
                new IntPtr(memAddr),
                new ushort[0x10000],
                0x10000,
                out o);
            WriteProcessMemory(proc,
                new IntPtr(memAddr),
                data,
                data.Length * 2,
                out o);
        }
    }

    public class CachedValue<T>
    {
        public T value;
        readonly DateTime expires;

        public CachedValue()
        {
            expires = DateTime.Now.AddSeconds(30);
        }

        public bool expired => DateTime.Now > expires;
    }
}
