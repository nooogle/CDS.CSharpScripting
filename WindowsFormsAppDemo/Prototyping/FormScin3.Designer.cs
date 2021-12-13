
namespace WindowsFormsAppDemo.Prototyping
{
    partial class FormScin3
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
            this.codeEditor1 = new CDS.CSharpScript.ScintillaEditor.CodeEditor();
            this.SuspendLayout();
            // 
            // codeEditor1
            // 
            this.codeEditor1.CDSScript = "";
            this.codeEditor1.CDSSelectionStart = 0;
            this.codeEditor1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEditor1.Location = new System.Drawing.Point(12, 12);
            this.codeEditor1.Name = "codeEditor1";
            this.codeEditor1.Size = new System.Drawing.Size(651, 299);
            this.codeEditor1.TabIndex = 0;
            // 
            // FormScin3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.codeEditor1);
            this.Name = "FormScin3";
            this.Text = "FormScin3";
            this.ResumeLayout(false);

        }

        #endregion

        private CDS.CSharpScript.ScintillaEditor.CodeEditor codeEditor1;
    }
}