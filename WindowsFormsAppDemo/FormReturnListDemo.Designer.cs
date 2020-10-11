namespace WindowsFormsAppDemo
{
    partial class FormReturnListDemo
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
            this.csharpEditorWindow = new CDS.RoslynPadScripting.CSharpEditorWindow();
            this.compilationOutput = new CDS.RoslynPadScripting.OutputWindow();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.runtimeOutput = new CDS.RoslynPadScripting.OutputWindow();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(24, 23);
            this.btnRun.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(150, 44);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // csharpEditorWindow
            // 
            this.csharpEditorWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.csharpEditorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csharpEditorWindow.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csharpEditorWindow.Location = new System.Drawing.Point(12, 50);
            this.csharpEditorWindow.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.csharpEditorWindow.Name = "csharpEditorWindow";
            this.csharpEditorWindow.Size = new System.Drawing.Size(1528, 174);
            this.csharpEditorWindow.TabIndex = 3;
            // 
            // compilationOutput
            // 
            this.compilationOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compilationOutput.Location = new System.Drawing.Point(12, 286);
            this.compilationOutput.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.compilationOutput.Name = "compilationOutput";
            this.compilationOutput.Size = new System.Drawing.Size(1528, 174);
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
            this.tableLayoutPanel1.Controls.Add(this.csharpEditorWindow, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.compilationOutput, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 133);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1552, 710);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // runtimeOutput
            // 
            this.runtimeOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runtimeOutput.Location = new System.Drawing.Point(12, 522);
            this.runtimeOutput.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.runtimeOutput.Name = "runtimeOutput";
            this.runtimeOutput.Size = new System.Drawing.Size(1528, 176);
            this.runtimeOutput.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 472);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Runtime output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 236);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Compilation output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Code editor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1054, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Basic demo: the System namespace is automatically referenced and the core .Net as" +
    "semblies are referenced";
            // 
            // FormReturnListDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnRun);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormReturnListDemo";
            this.Text = "FormReturnListDemo";
            this.Load += new System.EventHandler(this.FormReturnListDemo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private CDS.RoslynPadScripting.CSharpEditorWindow csharpEditorWindow;
        private CDS.RoslynPadScripting.OutputWindow compilationOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private CDS.RoslynPadScripting.OutputWindow runtimeOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}