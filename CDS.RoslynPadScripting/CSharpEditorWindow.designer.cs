namespace CDS.RoslynPadScripting
{
    partial class CSharpEditorWindow
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
            this.wpfEditorHost = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // wpfEditorHost
            // 
            this.wpfEditorHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpfEditorHost.Location = new System.Drawing.Point(0, 0);
            this.wpfEditorHost.Name = "wpfEditorHost";
            this.wpfEditorHost.Size = new System.Drawing.Size(800, 450);
            this.wpfEditorHost.TabIndex = 0;
            this.wpfEditorHost.Text = "elementHost1";
            this.wpfEditorHost.Child = null;
            // 
            // CSharpEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wpfEditorHost);
            this.Name = "CSharpEditorWindow";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.CSEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost wpfEditorHost;
    }
}
