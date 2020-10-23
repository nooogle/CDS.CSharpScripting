namespace WindowsFormsAppDemo
{
    partial class FormGlobalsDemo
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
            this.btnRun = new System.Windows.Forms.Button();
            this.csharpEditor = new CDS.CSharpScripting.CodeEditor();
            this.compilationOutput = new CDS.CSharpScripting.OutputPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.runtimeOutput = new CDS.CSharpScripting.OutputPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 12);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // csharpEditor
            // 
            this.csharpEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.csharpEditor.CDSScript = "// The public methods and properties of the Global class instance are\r\n// directl" +
    "y available in this script\r\nConsole.WriteLine(Animal);\r\nAnimal = \"Shark\";\r\nConso" +
    "le.WriteLine(Animal);";
            this.csharpEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csharpEditor.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.csharpEditor.Location = new System.Drawing.Point(6, 26);
            this.csharpEditor.Margin = new System.Windows.Forms.Padding(6);
            this.csharpEditor.Name = "csharpEditor";
            this.csharpEditor.Size = new System.Drawing.Size(764, 156);
            this.csharpEditor.TabIndex = 3;
            // 
            // compilationOutput
            // 
            this.compilationOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compilationOutput.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.compilationOutput.Location = new System.Drawing.Point(6, 214);
            this.compilationOutput.Margin = new System.Windows.Forms.Padding(6);
            this.compilationOutput.Name = "compilationOutput";
            this.compilationOutput.Size = new System.Drawing.Size(764, 72);
            this.compilationOutput.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.runtimeOutput, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.csharpEditor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.compilationOutput, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 397);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // runtimeOutput
            // 
            this.runtimeOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runtimeOutput.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.runtimeOutput.Location = new System.Drawing.Point(6, 318);
            this.runtimeOutput.Margin = new System.Windows.Forms.Padding(6);
            this.runtimeOutput.Name = "runtimeOutput";
            this.runtimeOutput.Size = new System.Drawing.Size(764, 73);
            this.runtimeOutput.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Runtime output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Compilation output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Code editor";
            // 
            // FormGlobalsDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnRun);
            this.Name = "FormGlobalsDemo";
            this.Text = "FormGlobalsDemo";
            this.Load += new System.EventHandler(this.FormGlobalsDemo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private CDS.CSharpScripting.CodeEditor csharpEditor;
        private CDS.CSharpScripting.OutputPanel compilationOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private CDS.CSharpScripting.OutputPanel runtimeOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}