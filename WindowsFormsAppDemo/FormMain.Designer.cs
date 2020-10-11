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
            this.SuspendLayout();
            // 
            // btnBasicDemo
            // 
            this.btnBasicDemo.Location = new System.Drawing.Point(29, 30);
            this.btnBasicDemo.Name = "btnBasicDemo";
            this.btnBasicDemo.Size = new System.Drawing.Size(92, 59);
            this.btnBasicDemo.TabIndex = 3;
            this.btnBasicDemo.Text = "Basic demo";
            this.btnBasicDemo.UseVisualStyleBackColor = true;
            this.btnBasicDemo.Click += new System.EventHandler(this.btnBasicDemo_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 276);
            this.ControlBox = false;
            this.Controls.Add(this.btnBasicDemo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBasicDemo;
    }
}