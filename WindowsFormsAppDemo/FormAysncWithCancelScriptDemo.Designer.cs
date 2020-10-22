namespace WindowsFormsAppDemo
{
    partial class FormAysncWithCancelScriptDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAysncWithCancelScriptDemo));
            this.btnRunAsync = new System.Windows.Forms.Button();
            this.csharpEditor = new CDS.CSharpScripting.CodeEditor();
            this.output = new CDS.CSharpScripting.OutputPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCompile = new System.Windows.Forms.Button();
            this.btnStopScript = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRunAsync
            // 
            this.btnRunAsync.Location = new System.Drawing.Point(88, 8);
            this.btnRunAsync.Name = "btnRunAsync";
            this.btnRunAsync.Size = new System.Drawing.Size(75, 23);
            this.btnRunAsync.TabIndex = 2;
            this.btnRunAsync.Text = "Run async";
            this.btnRunAsync.UseVisualStyleBackColor = true;
            this.btnRunAsync.Click += new System.EventHandler(this.btnRunAsync_Click);
            // 
            // csharpEditor
            // 
            this.csharpEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.csharpEditor.CDSScript = resources.GetString("csharpEditor.CDSScript");
            this.csharpEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csharpEditor.Font = new System.Drawing.Font("Consolas", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csharpEditor.Location = new System.Drawing.Point(6, 26);
            this.csharpEditor.Margin = new System.Windows.Forms.Padding(6);
            this.csharpEditor.Name = "csharpEditor";
            this.csharpEditor.Size = new System.Drawing.Size(764, 226);
            this.csharpEditor.TabIndex = 3;
            this.csharpEditor.CDSScriptChanged += new System.EventHandler(this.csharpEditor_CDSScriptChanged);
            // 
            // output
            // 
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Location = new System.Drawing.Point(6, 284);
            this.output.Margin = new System.Windows.Forms.Padding(6);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(764, 107);
            this.output.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.csharpEditor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.output, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 397);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output";
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
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(8, 8);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(75, 23);
            this.btnCompile.TabIndex = 6;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // btnStopScript
            // 
            this.btnStopScript.Location = new System.Drawing.Point(169, 8);
            this.btnStopScript.Name = "btnStopScript";
            this.btnStopScript.Size = new System.Drawing.Size(75, 23);
            this.btnStopScript.TabIndex = 7;
            this.btnStopScript.Text = "Stop script";
            this.btnStopScript.UseVisualStyleBackColor = true;
            this.btnStopScript.Click += new System.EventHandler(this.btnStopScript_Click);
            // 
            // FormCancelScriptDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStopScript);
            this.Controls.Add(this.btnCompile);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnRunAsync);
            this.Name = "FormAysncWithCancelScriptDemo";
            this.Text = "FormAysncWithCancelScriptDemo";
            this.Load += new System.EventHandler(this.FormAysncWithCancelScriptDemo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRunAsync;
        private CDS.CSharpScripting.CodeEditor csharpEditor;
        private CDS.CSharpScripting.OutputPanel output;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Button btnStopScript;
    }
}