using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using OxIDE.DCPU;

namespace OxIDE.IDE
{
    public partial class DebugForm : Form
    {
        Injector injector;

        public DebugForm()
        {
            InitializeComponent();
            MouseWheel += DebugForm_MouseWheel;
        }

        private void DebugForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                injector.offset += 0x10;
            }
            else if (e.Delta > 0)
            {
                injector.offset -= 0x10;
            }

            injector.offset = Math.Max(injector.offset, (short)0);

            this.Refresh();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            injector = Injector.Instance();
            if (!injector.Loaded)
            {
                this.Hide();
            }
        }

        private void DebugForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Owner.Refresh();
            if ((int)injector.s.hWnd == 0)
            {
                return;
            }

            var memBytes = injector.ReadMem();
            var regs = injector.ReadRegs();

            short A = regs[0x00];
            short B = regs[0x01];
            short C = regs[0x02];
            short X = regs[0x03];
            short Y = regs[0x04];
            short Z = regs[0x05];
            short I = regs[0x06];
            short J = regs[0x07];
            short SP = regs[0x08];
            short PC = regs[0x09];
            short EX = regs[0x0a];
            short IA = regs[0x0b];

            regA.Text = string.Format("{0:X4}", A);
            regB.Text = string.Format("{0:X4}", B);
            regC.Text = string.Format("{0:X4}", C);
            regX.Text = string.Format("{0:X4}", X);
            regY.Text = string.Format("{0:X4}", Y);
            regZ.Text = string.Format("{0:X4}", Z);
            regI.Text = string.Format("{0:X4}", I);
            regJ.Text = string.Format("{0:X4}", J);
            regSP.Text = string.Format("{0:X4}", SP);
            regPC.Text = string.Format("{0:X4}", PC);
            regEX.Text = string.Format("{0:X4}", EX);
            regIA.Text = string.Format("{0:X4}", IA);

            StringBuilder m = new StringBuilder();
            for (short y = 0; y < 8 * 16; y += 8)
            {
                lblOffsets.Text += string.Format("{0:X4}:\n", injector.offset + y);

                for (short x = 0; x < 8; x += 1)
                {
                    var a = injector.offset + y + x;
                    short v = memBytes[a];

                    if (a == PC)
                    {
                        m.Append(string.Format("[{0:X4}]", v));
                    }
                    else
                    {
                        m.Append(string.Format(" {0:X4} ", v));
                    }
                }
                m.Append("\n");
            }
            lblMemory.Text = m.ToString();
        }

        private void lblMemory_Click(object sender, EventArgs e)
        {

        }
    }

}
