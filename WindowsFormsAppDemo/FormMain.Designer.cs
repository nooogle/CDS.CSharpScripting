namespace WindowsFormsAppDemo
{
    partial class FormMain
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
            this.btnBasicDemo = new System.Windows.Forms.Button();
            this.btnReturnListDemo = new System.Windows.Forms.Button();
            this.btnGlobalsDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBasicDemo
            // 
            this.btnBasicDemo.Location = new System.Drawing.Point(58, 58);
            this.btnBasicDemo.Margin = new System.Windows.Forms.Padding(6);
            this.btnBasicDemo.Name = "btnBasicDemo";
            this.btnBasicDemo.Size = new System.Drawing.Size(184, 113);
            this.btnBasicDemo.TabIndex = 3;
            this.btnBasicDemo.Text = "Basic";
            this.btnBasicDemo.UseVisualStyleBackColor = true;
            this.btnBasicDemo.Click += new System.EventHandler(this.btnBasicDemo_Click);
            // 
            // btnReturnListDemo
            // 
            this.btnReturnListDemo.Location = new System.Drawing.Point(58, 205);
            this.btnReturnListDemo.Margin = new System.Windows.Forms.Padding(6);
            this.btnReturnListDemo.Name = "btnReturnListDemo";
            this.btnReturnListDemo.Size = new System.Drawing.Size(184, 113);
            this.btnReturnListDemo.TabIndex = 4;
            this.btnReturnListDemo.Text = "Return list";
            this.btnReturnListDemo.UseVisualStyleBackColor = true;
            this.btnReturnListDemo.Click += new System.EventHandler(this.btnReturnListDemo_Click);
            // 
            // btnGlobalsDemo
            // 
            this.btnGlobalsDemo.Location = new System.Drawing.Point(58, 347);
            this.btnGlobalsDemo.Margin = new System.Windows.Forms.Padding(6);
            this.btnGlobalsDemo.Name = "btnGlobalsDemo";
            this.btnGlobalsDemo.Size = new System.Drawing.Size(184, 113);
            this.btnGlobalsDemo.TabIndex = 5;
            this.btnGlobalsDemo.Text = "Globals";
            this.btnGlobalsDemo.UseVisualStyleBackColor = true;
            this.btnGlobalsDemo.Click += new System.EventHandler(this.btnGlobalsDemo_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 531);
            this.ControlBox = false;
            this.Controls.Add(this.btnGlobalsDemo);
            this.Controls.Add(this.btnReturnListDemo);
            this.Controls.Add(this.btnBasicDemo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBasicDemo;
        private System.Windows.Forms.Button btnReturnListDemo;
        private System.Windows.Forms.Button btnGlobalsDemo;
    }
}