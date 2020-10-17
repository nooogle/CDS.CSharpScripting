namespace CDS.CSharpScripting
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
            this.wpfEditorHost = new System.Windows.Forms.Integration.ElementHost();
            this.labelNotInitialisedMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wpfEditorHost
            // 
            this.wpfEditorHost.BackColor = System.Drawing.SystemColors.Control;
            this.wpfEditorHost.Location = new System.Drawing.Point(3, 3);
            this.wpfEditorHost.Name = "wpfEditorHost";
            this.wpfEditorHost.Size = new System.Drawing.Size(200, 107);
            this.wpfEditorHost.TabIndex = 0;
            this.wpfEditorHost.Text = "elementHost1";
            this.wpfEditorHost.Visible = false;
            this.wpfEditorHost.Child = null;
            // 
            // labelNotInitialisedMsg
            // 
            this.labelNotInitialisedMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNotInitialisedMsg.Location = new System.Drawing.Point(0, 0);
            this.labelNotInitialisedMsg.Name = "labelNotInitialisedMsg";
            this.labelNotInitialisedMsg.Size = new System.Drawing.Size(800, 450);
            this.labelNotInitialisedMsg.TabIndex = 1;
            this.labelNotInitialisedMsg.Text = "Code editor: not initialised";
            this.labelNotInitialisedMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CSharpEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wpfEditorHost);
            this.Controls.Add(this.labelNotInitialisedMsg);
            this.Name = "CSharpEditorWindow";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost wpfEditorHost;
        private System.Windows.Forms.Label labelNotInitialisedMsg;
    }
}
