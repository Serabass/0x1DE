﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using WeifenLuo.WinFormsUI.Docking;
using OxIDE.DCPU.ASM;
using OxIDE.Support;
using Organic;
using OxIDE.DCPU;

namespace OxIDE.IDE
{
	/// <summary>
	/// The main window off the application.
	/// </summary>
	public partial class MainWindow : Form
    {
        Injector injector;
        public List<LineOffsetMapping> loMapping = new List<LineOffsetMapping>();
        public Dictionary<ushort, int> mapping = new Dictionary<ushort, int>();

        #region Constructors

        /// <summary>
        /// Initializes the main window.
        /// </summary>
        public MainWindow()
		{
			InitializeComponent();

			// TODO: make the document types, compiler modular.
			m_compiler = new ASMCompiler();
            injector = Injector.Instance();
        }

		#endregion

		#region Fields

		private ASMCompiler m_compiler;

		#endregion

		#region Event methods

		private void AddNewItemBtn_Click(object sender, EventArgs e)
		{

		}

		private void MenuNewASMFileBtn_Click(object sender, EventArgs e)
		{
			this.SaveFileDialog.Filter = "ASM file|*.asm";
			this.SaveFileDialog.DefaultExt = ".ext";

			if (this.SaveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					var filePath = this.SaveFileDialog.FileName;

					// Create an empty file and load it.
					File.CreateText(filePath).Close();

					var sourceDoc = new SourceDocument(m_compiler);
					sourceDoc.LoadFile(filePath);
					sourceDoc.Show(this.DockPanel, DockState.Document);

				}
				catch (Exception ex)
				{
					MessageBox.Show(this, "An error has occurred:" + Environment.NewLine + ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void OpenFileBtn_Click(object sender, EventArgs e)
		{
			// Let the user choose a file to open.
			if (this.OpenFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					var filePath = this.OpenFileDialog.FileName;

					// Check the extension.
					var extension = Path.GetExtension(filePath).ToLower();
					switch (extension)
					{
						case ".asm":
							{
								var sourceDoc = new SourceDocument(m_compiler);
								sourceDoc.LoadFile(filePath);
								sourceDoc.Show(this.DockPanel, DockState.Document);
							}
							break;

						case ".hex":
						case ".bin":
							{
								// The file is a program. Load it and show the disassembler.
								var program = OxIDE.DCPU.Program.LoadFrom(filePath);

								var disassembler = new DisassemblerDocument();
								disassembler.Text = Path.GetFileName(filePath);
								disassembler.LoadProgram(program);
								disassembler.Show(this.DockPanel, DockState.Document);
							}
							break;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, "An error has occurred:" + Environment.NewLine + ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void SaveBtn_Click(object sender, EventArgs e)
		{
			// Save the current active document if possible.
			var savableDocument = this.DockPanel.ActiveDocument as ISavableDocument;
			if (savableDocument != null)
			{
				savableDocument.Save();
			}
		}

		private void SaveAllBtn_Click(object sender, EventArgs ea)
		{
			// Save all open documents which can be saved.
			foreach (ISavableDocument savableDocument in this.DockPanel.Documents.Where(e => e is ISavableDocument))
			{
				savableDocument.Save();
			}
		}

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Save the current active document if possible.
            var savableDocument = this.DockPanel.ActiveDocument as ISavableDocument;
            if (savableDocument != null)
            {
                savableDocument.Compile();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            var sourceDoc = new SourceDocument(m_compiler);
            sourceDoc.LoadFile(@"D:\Program Files (x86)\Grand Theft Auto Vice City\test.asm");
            sourceDoc.Show(this.DockPanel, DockState.Document);

            // Save the current active document if possible.
            var savableDocument = this.DockPanel.ActiveDocument as ISavableDocument;
            if (savableDocument != null)
            {
                // savableDocument.Compile();
            }

        }

        private void bonBuildAndInject_Click(object sender, EventArgs e)
        {
            Assembler assembler = new Assembler();
            var savableDocument = this.DockPanel.ActiveDocument as SourceDocument;
            var contents = savableDocument.ContentEditor.Text;
            var output = assembler.Assemble(contents, "[piped input]");
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

                var l = entry.LineNumber;
                var o = entry.Address;
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
            injector.InjectByteCode(arr);

            var df = new DebugForm();
            df.Show(this);
        }

        private void DockPanel_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        private void StandardToolbar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
