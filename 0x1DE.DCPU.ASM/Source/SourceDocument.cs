using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using WeifenLuo.WinFormsUI.Docking;
using FastColoredTextBoxNS;

using Irony.Parsing;
using Irony.Highlighter.Highlighter;

using OxIDE.Support;
using Organic;

namespace OxIDE.DCPU.ASM
{
    /// <summary>
    /// Represents a document used for editing assembly code.
    /// </summary>
    public partial class SourceDocument : DockContent, ISavableDocument
    {
        #region Constructors

        /// <summary>
        /// Creates and initializes a new source document with the given compiler.
        /// </summary>
        public SourceDocument(ASMCompiler compiler)
        {
            this.Compiler = compiler;

            InitializeComponent();
            Font = new Font(Font.FontFamily.Name, 30f);

            // Setup the highlighter.
            m_highlighter = new FastColoredTextBoxHighlighter(this.ContentEditor, this.Compiler.Language);
            m_highlighter.TextBox.PaintLine += TextBox_PaintLine; ;
        }

        private void TextBox_PaintLine(object sender, PaintLineEventArgs e)
        {
            if (!Injector.Instance().Loaded)
            {
                return;
            }
            var PC = Injector.Instance().ReadRegs()[0x09];

            if (!mapping.ContainsKey((ushort)PC))
            {
                return;
            }

            var line = mapping[(ushort)PC];

            if (line == e.LineIndex)
            {
                var b = new SolidBrush(Color.Red);
                e.Graphics.FillRectangle(b, e.LineRect);
            }
        }

        #endregion

        #region Fields

        public FastColoredTextBoxHighlighter m_highlighter;
        private string m_originalText;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the compiler responsible for this source document.
        /// </summary>
        public ASMCompiler Compiler
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the path of the file currently edited.
        /// </summary>
        public string FilePath
        {
            get;
            private set;
        }

        public List<LineOffsetMapping> loMapping = new List<LineOffsetMapping>();
        public Dictionary<ushort, int> mapping = new Dictionary<ushort, int>();

        #endregion

        #region Methods

        /// <summary>
        /// Loads the given file.
        /// </summary>
        /// <param name="filePath">The file to load.</param>
        public void LoadFile(string filePath)
        {
            this.FilePath = filePath;

            // Prepare the content editor with the contents of the file.
            var content = File.ReadAllText(filePath);
            this.ContentEditor.Text = content;
            this.ContentEditor.ClearUndo();

            // Store the original text.
            m_originalText = this.ContentEditor.Text;

            // Set the title.
            this.Text = Path.GetFileName(filePath);
        }

        private void CheckDirty()
        {
            if (this.IsDirty == true && this.Text.EndsWith("*") == false)
            {
                this.Text += "*";
            }
            else if (this.IsDirty == false && this.Text.EndsWith("*") == true)
            {
                this.Text = this.Text.Remove(this.Text.Length - 1);
            }
        }

        #endregion

        #region Event methods

        private void ContentEditor_Enter(object sender, EventArgs e)
        {
            m_highlighter.Adapter.Activate();
        }

        private void ContentEditor_Leave(object sender, EventArgs e)
        {
            m_highlighter.Adapter.Stop();
        }

        private void ContentEditor_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            CheckDirty();
            CompileInMemory();
        }

        #endregion

        #region ISavableDocument Members

        public bool IsDirty
        {
            get { return m_originalText != this.ContentEditor.Text; }
        }

        public void Save()
        {
            if (this.IsDirty == true)
            {
                // Write all the contents to the file.
                var contents = this.ContentEditor.Text;
                File.WriteAllText(this.FilePath, contents);

                // Reset the dirty state.
                m_originalText = contents;
                CheckDirty();
            }
        }

        public void Compile()
        {
            if (this.IsDirty == true)
            {
                this.Save();
            }
            var contents = this.ContentEditor.Text;
            var p = this.Compiler.CompileProgram(contents, FilePath);
        }
        #endregion

        public void CompileInMemory()
        {
            Assembler assembler = new Assembler();
            var savableDocument = this.DockPanel.ActiveDocument as SourceDocument;
            var contents = savableDocument.ContentEditor.Text;
            var output = assembler.Assemble(contents);
            ushort currentAddress = 0;
            List<ushort> data = new List<ushort>();
            foreach (var entry in output)
            {
                loMapping.Add(new LineOffsetMapping
                {
                    LineNumber = entry.LineNumber,
                    Address = entry.Address
                });

                if (mapping.ContainsKey(entry.Address))
                {
                    mapping.Remove(entry.Address);
                }

                mapping.Add(entry.Address, entry.LineNumber);

                if (entry.Output != null)
                {
                    foreach (ushort value in entry.Output)
                    {
                        currentAddress++;
                        data.Add(value);
                    }
                }
            }

            var arr = data.ToArray();
        }

        private void ContentEditor_Load(object sender, EventArgs e)
        {

        }
    }

    public class LineOffsetMapping
    {
        public int LineNumber;
        public ushort Address;
    }
}
