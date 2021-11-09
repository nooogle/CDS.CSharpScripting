
namespace WindowsFormsAppDemo.Prototyping
{
    partial class FormScin2
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
            this.editor = new CDS.CSharpScripting.ScintillaNETEditor.CodeEditor();
            this.textInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.Dock = System.Windows.Forms.DockStyle.Left;
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(453, 478);
            this.editor.TabIndex = 0;
            this.editor.CDSScriptChanged += new System.EventHandler(this.editor_TextChanged);
            // 
            // textInfo
            // 
            this.textInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInfo.Location = new System.Drawing.Point(453, 0);
            this.textInfo.Multiline = true;
            this.textInfo.Name = "textInfo";
            this.textInfo.ReadOnly = true;
            this.textInfo.Size = new System.Drawing.Size(417, 478);
            this.textInfo.TabIndex = 1;
            // 
            // FormScin2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 478);
            this.Controls.Add(this.textInfo);
            this.Controls.Add(this.editor);
            this.Name = "FormScin2";
            this.Text = "FormScin2";
            this.Load += new System.EventHandler(this.FormScin2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CDS.CSharpScripting.ScintillaNETEditor.CodeEditor editor;
        private System.Windows.Forms.TextBox textInfo;
    }
}