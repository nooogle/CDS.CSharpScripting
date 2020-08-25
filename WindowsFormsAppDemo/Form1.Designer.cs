namespace WindowsFormsAppDemo
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDemo2 = new System.Windows.Forms.Button();
            this.checkUseCommonNamespaces = new System.Windows.Forms.CheckBox();
            this.btnDemo1 = new System.Windows.Forms.Button();
            this.checkRequireStringListResultType = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.csharpEditorWindow = new CDS.RoslynPadScripting.CSharpEditorWindow();
            this.outputWindow1 = new CDS.RoslynPadScripting.OutputWindow();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDemo2);
            this.panel1.Controls.Add(this.checkUseCommonNamespaces);
            this.panel1.Controls.Add(this.btnDemo1);
            this.panel1.Controls.Add(this.checkRequireStringListResultType);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCompile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 189);
            this.panel1.TabIndex = 1;
            // 
            // btnDemo2
            // 
            this.btnDemo2.Location = new System.Drawing.Point(184, 77);
            this.btnDemo2.Margin = new System.Windows.Forms.Padding(6);
            this.btnDemo2.Name = "btnDemo2";
            this.btnDemo2.Size = new System.Drawing.Size(150, 44);
            this.btnDemo2.TabIndex = 7;
            this.btnDemo2.Text = "Demo 2";
            this.btnDemo2.UseVisualStyleBackColor = true;
            this.btnDemo2.Click += new System.EventHandler(this.btnDemo2_Click);
            // 
            // checkUseCommonNamespaces
            // 
            this.checkUseCommonNamespaces.AutoSize = true;
            this.checkUseCommonNamespaces.Checked = true;
            this.checkUseCommonNamespaces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUseCommonNamespaces.Location = new System.Drawing.Point(670, 73);
            this.checkUseCommonNamespaces.Margin = new System.Windows.Forms.Padding(6);
            this.checkUseCommonNamespaces.Name = "checkUseCommonNamespaces";
            this.checkUseCommonNamespaces.Size = new System.Drawing.Size(297, 29);
            this.checkUseCommonNamespaces.TabIndex = 6;
            this.checkUseCommonNamespaces.Text = "Use common namespaces";
            this.checkUseCommonNamespaces.UseVisualStyleBackColor = true;
            // 
            // btnDemo1
            // 
            this.btnDemo1.Location = new System.Drawing.Point(22, 77);
            this.btnDemo1.Margin = new System.Windows.Forms.Padding(6);
            this.btnDemo1.Name = "btnDemo1";
            this.btnDemo1.Size = new System.Drawing.Size(150, 44);
            this.btnDemo1.TabIndex = 5;
            this.btnDemo1.Text = "Demo 1";
            this.btnDemo1.UseVisualStyleBackColor = true;
            this.btnDemo1.Click += new System.EventHandler(this.btnDemo1_Click);
            // 
            // checkRequireStringListResultType
            // 
            this.checkRequireStringListResultType.AutoSize = true;
            this.checkRequireStringListResultType.Location = new System.Drawing.Point(670, 29);
            this.checkRequireStringListResultType.Margin = new System.Windows.Forms.Padding(6);
            this.checkRequireStringListResultType.Name = "checkRequireStringListResultType";
            this.checkRequireStringListResultType.Size = new System.Drawing.Size(356, 29);
            this.checkRequireStringListResultType.TabIndex = 4;
            this.checkRequireStringListResultType.Text = "Require List<string> return value";
            this.checkRequireStringListResultType.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(184, 21);
            this.btnRun.Margin = new System.Windows.Forms.Padding(6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(150, 44);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(346, 21);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(6);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(150, 44);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(508, 21);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 44);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(22, 21);
            this.btnCompile.Margin = new System.Windows.Forms.Padding(6);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(150, 44);
            this.btnCompile.TabIndex = 0;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // csharpEditorWindow
            // 
            this.csharpEditorWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.csharpEditorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csharpEditorWindow.Location = new System.Drawing.Point(0, 189);
            this.csharpEditorWindow.Margin = new System.Windows.Forms.Padding(12);
            this.csharpEditorWindow.Name = "csharpEditorWindow";
            this.csharpEditorWindow.Size = new System.Drawing.Size(1600, 401);
            this.csharpEditorWindow.TabIndex = 0;
            this.csharpEditorWindow.Text = null;
            // 
            // outputWindow1
            // 
            this.outputWindow1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outputWindow1.Location = new System.Drawing.Point(0, 590);
            this.outputWindow1.Margin = new System.Windows.Forms.Padding(12);
            this.outputWindow1.Name = "outputWindow1";
            this.outputWindow1.Size = new System.Drawing.Size(1600, 275);
            this.outputWindow1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.csharpEditorWindow);
            this.Controls.Add(this.outputWindow1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CDS.RoslynPadScripting.CSharpEditorWindow csharpEditorWindow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCompile;
        private CDS.RoslynPadScripting.OutputWindow outputWindow1;
        private System.Windows.Forms.CheckBox checkRequireStringListResultType;
        private System.Windows.Forms.Button btnDemo1;
        private System.Windows.Forms.CheckBox checkUseCommonNamespaces;
        private System.Windows.Forms.Button btnDemo2;
    }
}

