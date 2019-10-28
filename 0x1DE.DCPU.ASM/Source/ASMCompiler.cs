using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using Irony.Parsing;
using Organic;
using OxIDE.DCPU;

namespace OxIDE.DCPU.ASM
{
    /// <summary>
    /// Used for compiling assembly code to a program.
    /// </summary>
    public class ASMCompiler
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of the compiler and initializes it.
        /// </summary>
        public ASMCompiler()
        {
            this.Grammar = new ASMGrammar();
            this.Language = new LanguageData(this.Grammar);
            this.Parser = new Parser(this.Language);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the grammar.
        /// </summary>
        public Grammar Grammar
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public LanguageData Language
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public Parser Parser
        {
            get;
            private set;
        }

        public List<string> labels = new List<string>();

        #endregion

        #region Methods

        /// <summary>
        /// Compiles the given source into a program.
        /// </summary>
        /// <param name="source">The source code.</param>
        /// <param name="fileName">An optional file name to use for debugging.</param>
        /// <returns>The compiled program.</returns>
        public Program CompileProgram(string source, string fileName = "<source>")
        {
            // Create an empty program if no source given.
            if (string.IsNullOrWhiteSpace(source) == true)
            {
                return new Program(new ushort[0]);
            }

            // Parse the given source.
            var parseTree = this.Parser.Parse(source, fileName);

            Assembler assembler = new Assembler();
            var output = assembler.Assemble(source, "[piped input]");

            ushort currentAddress = 0;
            bool bigEndian = true;
            
            string outputFile = Path.GetDirectoryName(fileName) + "\\"
                + Path.GetFileNameWithoutExtension(fileName) + ".bin";

            Stream binStream = File.Open(outputFile, FileMode.Create);
            foreach (var entry in output)
            {
                if (entry.Output != null)
                {
                    foreach (ushort value in entry.Output)
                    {
                        currentAddress++;
                        byte[] buffer = BitConverter.GetBytes(value);
                        if (bigEndian)
                            Array.Reverse(buffer);
                        binStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }

            binStream.Close();

            return new Program(new ushort[0]);
        }

        #endregion
    }
}
