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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnBasicDemo = new System.Windows.Forms.Button();
            this.btnReturnListDemo = new System.Windows.Forms.Button();
            this.btnGlobalsDemo = new System.Windows.Forms.Button();
            this.btnNonDefaultTypes = new System.Windows.Forms.Button();
            this.btnRunMany = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelScriptDemo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnReuseEditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBasicDemo
            // 
            this.btnBasicDemo.Location = new System.Drawing.Point(12, 12);
            this.btnBasicDemo.Name = "btnBasicDemo";
            this.btnBasicDemo.Size = new System.Drawing.Size(92, 59);
            this.btnBasicDemo.TabIndex = 3;
            this.btnBasicDemo.Text = "Basic";
            this.btnBasicDemo.UseVisualStyleBackColor = true;
            this.btnBasicDemo.Click += new System.EventHandler(this.btnBasicDemo_Click);
            // 
            // btnReturnListDemo
            // 
            this.btnReturnListDemo.Location = new System.Drawing.Point(12, 77);
            this.btnReturnListDemo.Name = "btnReturnListDemo";
            this.btnReturnListDemo.Size = new System.Drawing.Size(92, 59);
            this.btnReturnListDemo.TabIndex = 4;
            this.btnReturnListDemo.Text = "Return list";
            this.btnReturnListDemo.UseVisualStyleBackColor = true;
            this.btnReturnListDemo.Click += new System.EventHandler(this.btnReturnListDemo_Click);
            // 
            // btnGlobalsDemo
            // 
            this.btnGlobalsDemo.Location = new System.Drawing.Point(12, 142);
            this.btnGlobalsDemo.Name = "btnGlobalsDemo";
            this.btnGlobalsDemo.Size = new System.Drawing.Size(92, 59);
            this.btnGlobalsDemo.TabIndex = 5;
            this.btnGlobalsDemo.Text = "Globals";
            this.btnGlobalsDemo.UseVisualStyleBackColor = true;
            this.btnGlobalsDemo.Click += new System.EventHandler(this.btnGlobalsDemo_Click);
            // 
            // btnNonDefaultTypes
            // 
            this.btnNonDefaultTypes.Location = new System.Drawing.Point(12, 207);
            this.btnNonDefaultTypes.Name = "btnNonDefaultTypes";
            this.btnNonDefaultTypes.Size = new System.Drawing.Size(92, 59);
            this.btnNonDefaultTypes.TabIndex = 6;
            this.btnNonDefaultTypes.Text = "Non-default types";
            this.btnNonDefaultTypes.UseVisualStyleBackColor = true;
            this.btnNonDefaultTypes.Click += new System.EventHandler(this.btnbtnNonDefaultTypes_Click);
            // 
            // btnRunMany
            // 
            this.btnRunMany.Location = new System.Drawing.Point(12, 272);
            this.btnRunMany.Name = "btnRunMany";
            this.btnRunMany.Size = new System.Drawing.Size(92, 59);
            this.btnRunMany.TabIndex = 7;
            this.btnRunMany.Text = "Run many";
            this.btnRunMany.UseVisualStyleBackColor = true;
            this.btnRunMany.Click += new System.EventHandler(this.btnRunMany_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(110, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 59);
            this.label1.TabIndex = 8;
            this.label1.Text = "Simple demo. ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(110, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 59);
            this.label2.TabIndex = 9;
            this.label2.Text = "The host expects to get data back fro the script of a specific data type.";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(110, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(376, 59);
            this.label3.TabIndex = 10;
            this.label3.Text = "The host shares an instance of a class with the script. Both the script and the h" +
    "ost can access the same shared data.";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(110, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(376, 59);
            this.label4.TabIndex = 11;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(110, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(376, 59);
            this.label5.TabIndex = 12;
            this.label5.Text = "Splits compilation from execution. Also shows the use of static data which is per" +
    "sisted between executions of the script (but is reset after recompiling).";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(110, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(376, 59);
            this.label6.TabIndex = 14;
            this.label6.Text = "Demonstrates how run run a script asynchronously and use a global variable to sig" +
    "nal cancellation";
            // 
            // btnCancelScriptDemo
            // 
            this.btnCancelScriptDemo.Location = new System.Drawing.Point(12, 337);
            this.btnCancelScriptDemo.Name = "btnCancelScriptDemo";
            this.btnCancelScriptDemo.Size = new System.Drawing.Size(92, 59);
            this.btnCancelScriptDemo.TabIndex = 13;
            this.btnCancelScriptDemo.Text = "Async run with cancel";
            this.btnCancelScriptDemo.UseVisualStyleBackColor = true;
            this.btnCancelScriptDemo.Click += new System.EventHandler(this.btnCancelScriptDemo_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(110, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(376, 59);
            this.label7.TabIndex = 16;
            this.label7.Text = "Reuse a previously created editor to avoid leaking";
            // 
            // btnReuseEditor
            // 
            this.btnReuseEditor.Location = new System.Drawing.Point(12, 402);
            this.btnReuseEditor.Name = "btnReuseEditor";
            this.btnReuseEditor.Size = new System.Drawing.Size(92, 59);
            this.btnReuseEditor.TabIndex = 15;
            this.btnReuseEditor.Text = "Reuse editor";
            this.btnReuseEditor.UseVisualStyleBackColor = true;
            this.btnReuseEditor.Click += new System.EventHandler(this.btnReuseEditor_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 541);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnReuseEditor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancelScriptDemo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRunMany);
            this.Controls.Add(this.btnNonDefaultTypes);
            this.Controls.Add(this.btnGlobalsDemo);
            this.Controls.Add(this.btnReturnListDemo);
            this.Controls.Add(this.btnBasicDemo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBasicDemo;
        private System.Windows.Forms.Button btnReturnListDemo;
        private System.Windows.Forms.Button btnGlobalsDemo;
        private System.Windows.Forms.Button btnNonDefaultTypes;
        private System.Windows.Forms.Button btnRunMany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelScriptDemo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnReuseEditor;
    }
}