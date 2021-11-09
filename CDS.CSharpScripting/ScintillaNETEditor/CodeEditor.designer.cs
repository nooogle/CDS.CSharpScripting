namespace CDS.CSharpScripting.ScintillaNETEditor
{
    partial class CodeEditor
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.editor = new ScintillaNET.Scintilla();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(647, 390);
            this.editor.TabIndex = 0;
            this.editor.Text = "";
            this.editor.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.editor_UpdateUI);
            this.editor.TextChanged += new System.EventHandler(this.Editor_TextChanged);
            // 
            // CodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editor);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CodeEditor";
            this.Size = new System.Drawing.Size(647, 390);
            this.Load += new System.EventHandler(this.CodeEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ScintillaNET.Scintilla editor;
    }
}
