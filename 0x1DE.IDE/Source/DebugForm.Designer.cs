namespace OxIDE.IDE
{
    partial class DebugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpRegisters = new System.Windows.Forms.GroupBox();
            this.regEX = new System.Windows.Forms.Label();
            this.regZ = new System.Windows.Forms.Label();
            this.regC = new System.Windows.Forms.Label();
            this.regJ = new System.Windows.Forms.Label();
            this.regY = new System.Windows.Forms.Label();
            this.regB = new System.Windows.Forms.Label();
            this.regSP = new System.Windows.Forms.Label();
            this.regI = new System.Windows.Forms.Label();
            this.regX = new System.Windows.Forms.Label();
            this.regA = new System.Windows.Forms.Label();
            this.regPC = new System.Windows.Forms.Label();
            this.regIA = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOffsets = new System.Windows.Forms.Label();
            this.lblMemory = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpRegisters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRegisters
            // 
            this.grpRegisters.Controls.Add(this.regEX);
            this.grpRegisters.Controls.Add(this.regZ);
            this.grpRegisters.Controls.Add(this.regC);
            this.grpRegisters.Controls.Add(this.regJ);
            this.grpRegisters.Controls.Add(this.regY);
            this.grpRegisters.Controls.Add(this.regB);
            this.grpRegisters.Controls.Add(this.regSP);
            this.grpRegisters.Controls.Add(this.regI);
            this.grpRegisters.Controls.Add(this.regX);
            this.grpRegisters.Controls.Add(this.regA);
            this.grpRegisters.Controls.Add(this.regPC);
            this.grpRegisters.Controls.Add(this.regIA);
            this.grpRegisters.Controls.Add(this.label11);
            this.grpRegisters.Controls.Add(this.label12);
            this.grpRegisters.Controls.Add(this.label5);
            this.grpRegisters.Controls.Add(this.label9);
            this.grpRegisters.Controls.Add(this.label10);
            this.grpRegisters.Controls.Add(this.label6);
            this.grpRegisters.Controls.Add(this.label7);
            this.grpRegisters.Controls.Add(this.label8);
            this.grpRegisters.Controls.Add(this.label4);
            this.grpRegisters.Controls.Add(this.label3);
            this.grpRegisters.Controls.Add(this.label2);
            this.grpRegisters.Controls.Add(this.label1);
            this.grpRegisters.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRegisters.Location = new System.Drawing.Point(0, 0);
            this.grpRegisters.Name = "grpRegisters";
            this.grpRegisters.Size = new System.Drawing.Size(776, 151);
            this.grpRegisters.TabIndex = 1;
            this.grpRegisters.TabStop = false;
            this.grpRegisters.Text = "Registers";
            // 
            // regEX
            // 
            this.regEX.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regEX.Location = new System.Drawing.Point(443, 20);
            this.regEX.Name = "regEX";
            this.regEX.Size = new System.Drawing.Size(63, 30);
            this.regEX.TabIndex = 23;
            this.regEX.Text = "0000";
            // 
            // regZ
            // 
            this.regZ.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regZ.Location = new System.Drawing.Point(318, 80);
            this.regZ.Name = "regZ";
            this.regZ.Size = new System.Drawing.Size(63, 30);
            this.regZ.TabIndex = 22;
            this.regZ.Text = "0000";
            // 
            // regC
            // 
            this.regC.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regC.Location = new System.Drawing.Point(318, 50);
            this.regC.Name = "regC";
            this.regC.Size = new System.Drawing.Size(63, 30);
            this.regC.TabIndex = 21;
            this.regC.Text = "0000";
            // 
            // regJ
            // 
            this.regJ.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regJ.Location = new System.Drawing.Point(193, 110);
            this.regJ.Name = "regJ";
            this.regJ.Size = new System.Drawing.Size(68, 30);
            this.regJ.TabIndex = 20;
            this.regJ.Text = "0000";
            // 
            // regY
            // 
            this.regY.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regY.Location = new System.Drawing.Point(193, 80);
            this.regY.Name = "regY";
            this.regY.Size = new System.Drawing.Size(68, 30);
            this.regY.TabIndex = 19;
            this.regY.Text = "0000";
            // 
            // regB
            // 
            this.regB.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regB.Location = new System.Drawing.Point(193, 50);
            this.regB.Name = "regB";
            this.regB.Size = new System.Drawing.Size(68, 30);
            this.regB.TabIndex = 18;
            this.regB.Text = "0000";
            // 
            // regSP
            // 
            this.regSP.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regSP.Location = new System.Drawing.Point(193, 20);
            this.regSP.Name = "regSP";
            this.regSP.Size = new System.Drawing.Size(68, 30);
            this.regSP.TabIndex = 17;
            this.regSP.Text = "0000";
            // 
            // regI
            // 
            this.regI.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regI.Location = new System.Drawing.Point(63, 110);
            this.regI.Name = "regI";
            this.regI.Size = new System.Drawing.Size(68, 30);
            this.regI.TabIndex = 16;
            this.regI.Text = "0000";
            // 
            // regX
            // 
            this.regX.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regX.Location = new System.Drawing.Point(63, 80);
            this.regX.Name = "regX";
            this.regX.Size = new System.Drawing.Size(68, 30);
            this.regX.TabIndex = 15;
            this.regX.Text = "0000";
            // 
            // regA
            // 
            this.regA.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regA.Location = new System.Drawing.Point(63, 50);
            this.regA.Name = "regA";
            this.regA.Size = new System.Drawing.Size(68, 30);
            this.regA.TabIndex = 14;
            this.regA.Text = "0000";
            // 
            // regPC
            // 
            this.regPC.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regPC.Location = new System.Drawing.Point(63, 20);
            this.regPC.Name = "regPC";
            this.regPC.Size = new System.Drawing.Size(68, 30);
            this.regPC.TabIndex = 13;
            this.regPC.Text = "0000";
            // 
            // regIA
            // 
            this.regIA.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regIA.Location = new System.Drawing.Point(318, 20);
            this.regIA.Name = "regIA";
            this.regIA.Size = new System.Drawing.Size(63, 30);
            this.regIA.TabIndex = 12;
            this.regIA.Text = "0000";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(137, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 30);
            this.label11.TabIndex = 11;
            this.label11.Text = "J:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(7, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 30);
            this.label12.TabIndex = 10;
            this.label12.Text = "I:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(267, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "Z:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(137, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 30);
            this.label9.TabIndex = 8;
            this.label9.Text = "Y:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(7, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 30);
            this.label10.TabIndex = 7;
            this.label10.Text = "X:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(267, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 30);
            this.label6.TabIndex = 6;
            this.label6.Text = "C:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(137, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "B:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(7, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 30);
            this.label8.TabIndex = 4;
            this.label8.Text = "A:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(387, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "EX:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(267, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "IA:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(137, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "SP:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "PC:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOffsets);
            this.groupBox1.Controls.Add(this.lblMemory);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 433);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Memory";
            // 
            // lblOffsets
            // 
            this.lblOffsets.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOffsets.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOffsets.Location = new System.Drawing.Point(3, 16);
            this.lblOffsets.Name = "lblOffsets";
            this.lblOffsets.Size = new System.Drawing.Size(78, 414);
            this.lblOffsets.TabIndex = 1;
            // 
            // lblMemory
            // 
            this.lblMemory.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMemory.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMemory.Location = new System.Drawing.Point(87, 16);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(686, 414);
            this.lblMemory.TabIndex = 0;
            this.lblMemory.Click += new System.EventHandler(this.lblMemory_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 590);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpRegisters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DebugForm";
            this.Text = "DebugForm";
            this.Load += new System.EventHandler(this.DebugForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DebugForm_Paint);
            this.grpRegisters.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRegisters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label regIA;
        private System.Windows.Forms.Label regSP;
        private System.Windows.Forms.Label regI;
        private System.Windows.Forms.Label regX;
        private System.Windows.Forms.Label regA;
        private System.Windows.Forms.Label regPC;
        private System.Windows.Forms.Label regJ;
        private System.Windows.Forms.Label regY;
        private System.Windows.Forms.Label regB;
        private System.Windows.Forms.Label regEX;
        private System.Windows.Forms.Label regZ;
        private System.Windows.Forms.Label regC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.Label lblOffsets;
        private System.Windows.Forms.Timer timer1;
    }
}