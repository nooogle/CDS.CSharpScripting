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
            this.panelSetupControls = new System.Windows.Forms.Panel();
            this.btnInitialise = new System.Windows.Forms.Button();
            this.checkNamespaceSystem = new System.Windows.Forms.CheckBox();
            this.checkRequireStringListResultType = new System.Windows.Forms.CheckBox();
            this.btnUninitialise = new System.Windows.Forms.Button();
            this.btnDemo2 = new System.Windows.Forms.Button();
            this.btnDemo1 = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.tableLayoutControls = new System.Windows.Forms.TableLayoutPanel();
            this.panelLiveControls = new System.Windows.Forms.Panel();
            this.csharpEditorWindow = new CDS.RoslynPadScripting.CSharpEditorWindow();
            this.outputWindow = new CDS.RoslynPadScripting.OutputWindow();
            this.btnDemo3 = new System.Windows.Forms.Button();
            this.checkNamespaceLinq = new System.Windows.Forms.CheckBox();
            this.panelSetupControls.SuspendLayout();
            this.tableLayoutControls.SuspendLayout();
            this.panelLiveControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSetupControls
            // 
            this.panelSetupControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSetupControls.Controls.Add(this.checkNamespaceLinq);
            this.panelSetupControls.Controls.Add(this.btnInitialise);
            this.panelSetupControls.Controls.Add(this.checkNamespaceSystem);
            this.panelSetupControls.Controls.Add(this.checkRequireStringListResultType);
            this.panelSetupControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetupControls.Location = new System.Drawing.Point(3, 3);
            this.panelSetupControls.Name = "panelSetupControls";
            this.panelSetupControls.Size = new System.Drawing.Size(309, 94);
            this.panelSetupControls.TabIndex = 1;
            // 
            // btnInitialise
            // 
            this.btnInitialise.Location = new System.Drawing.Point(8, 9);
            this.btnInitialise.Name = "btnInitialise";
            this.btnInitialise.Size = new System.Drawing.Size(75, 23);
            this.btnInitialise.TabIndex = 8;
            this.btnInitialise.Text = "Initialise";
            this.btnInitialise.UseVisualStyleBackColor = true;
            this.btnInitialise.Click += new System.EventHandler(this.btnInitialise_Click);
            // 
            // checkNamespaceSystem
            // 
            this.checkNamespaceSystem.AutoSize = true;
            this.checkNamespaceSystem.Checked = true;
            this.checkNamespaceSystem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNamespaceSystem.Location = new System.Drawing.Point(99, 38);
            this.checkNamespaceSystem.Name = "checkNamespaceSystem";
            this.checkNamespaceSystem.Size = new System.Drawing.Size(90, 17);
            this.checkNamespaceSystem.TabIndex = 6;
            this.checkNamespaceSystem.Text = "Using System";
            this.checkNamespaceSystem.UseVisualStyleBackColor = true;
            // 
            // checkRequireStringListResultType
            // 
            this.checkRequireStringListResultType.AutoSize = true;
            this.checkRequireStringListResultType.Location = new System.Drawing.Point(99, 15);
            this.checkRequireStringListResultType.Name = "checkRequireStringListResultType";
            this.checkRequireStringListResultType.Size = new System.Drawing.Size(178, 17);
            this.checkRequireStringListResultType.TabIndex = 4;
            this.checkRequireStringListResultType.Text = "Require List<string> return value";
            this.checkRequireStringListResultType.UseVisualStyleBackColor = true;
            // 
            // btnUninitialise
            // 
            this.btnUninitialise.Location = new System.Drawing.Point(259, 45);
            this.btnUninitialise.Name = "btnUninitialise";
            this.btnUninitialise.Size = new System.Drawing.Size(75, 23);
            this.btnUninitialise.TabIndex = 9;
            this.btnUninitialise.Text = "Uninitialise";
            this.btnUninitialise.UseVisualStyleBackColor = true;
            this.btnUninitialise.Click += new System.EventHandler(this.btnUninitialise_Click);
            // 
            // btnDemo2
            // 
            this.btnDemo2.Location = new System.Drawing.Point(178, 45);
            this.btnDemo2.Name = "btnDemo2";
            this.btnDemo2.Size = new System.Drawing.Size(75, 23);
            this.btnDemo2.TabIndex = 7;
            this.btnDemo2.Text = "Demo 2";
            this.btnDemo2.UseVisualStyleBackColor = true;
            this.btnDemo2.Click += new System.EventHandler(this.btnDemo2_Click);
            // 
            // btnDemo1
            // 
            this.btnDemo1.Location = new System.Drawing.Point(178, 16);
            this.btnDemo1.Name = "btnDemo1";
            this.btnDemo1.Size = new System.Drawing.Size(75, 23);
            this.btnDemo1.TabIndex = 5;
            this.btnDemo1.Text = "Demo 1";
            this.btnDemo1.UseVisualStyleBackColor = true;
            this.btnDemo1.Click += new System.EventHandler(this.btnDemo1_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(97, 16);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(16, 45);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(97, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(16, 16);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(75, 23);
            this.btnCompile.TabIndex = 0;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // tableLayoutControls
            // 
            this.tableLayoutControls.ColumnCount = 2;
            this.tableLayoutControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.tableLayoutControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutControls.Controls.Add(this.panelSetupControls, 0, 0);
            this.tableLayoutControls.Controls.Add(this.panelLiveControls, 1, 0);
            this.tableLayoutControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutControls.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutControls.Name = "tableLayoutControls";
            this.tableLayoutControls.RowCount = 1;
            this.tableLayoutControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutControls.Size = new System.Drawing.Size(833, 100);
            this.tableLayoutControls.TabIndex = 10;
            // 
            // panelLiveControls
            // 
            this.panelLiveControls.Controls.Add(this.btnDemo3);
            this.panelLiveControls.Controls.Add(this.btnUninitialise);
            this.panelLiveControls.Controls.Add(this.btnCompile);
            this.panelLiveControls.Controls.Add(this.btnSave);
            this.panelLiveControls.Controls.Add(this.btnDemo2);
            this.panelLiveControls.Controls.Add(this.btnLoad);
            this.panelLiveControls.Controls.Add(this.btnRun);
            this.panelLiveControls.Controls.Add(this.btnDemo1);
            this.panelLiveControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLiveControls.Enabled = false;
            this.panelLiveControls.Location = new System.Drawing.Point(318, 3);
            this.panelLiveControls.Name = "panelLiveControls";
            this.panelLiveControls.Size = new System.Drawing.Size(512, 94);
            this.panelLiveControls.TabIndex = 2;
            // 
            // csharpEditorWindow
            // 
            this.csharpEditorWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.csharpEditorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csharpEditorWindow.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csharpEditorWindow.Location = new System.Drawing.Point(0, 100);
            this.csharpEditorWindow.Margin = new System.Windows.Forms.Padding(6);
            this.csharpEditorWindow.Name = "csharpEditorWindow";
            this.csharpEditorWindow.Size = new System.Drawing.Size(833, 207);
            this.csharpEditorWindow.TabIndex = 0;
            // 
            // outputWindow
            // 
            this.outputWindow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outputWindow.Location = new System.Drawing.Point(0, 307);
            this.outputWindow.Margin = new System.Windows.Forms.Padding(6);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(833, 143);
            this.outputWindow.TabIndex = 2;
            // 
            // btnDemo3
            // 
            this.btnDemo3.Location = new System.Drawing.Point(259, 16);
            this.btnDemo3.Name = "btnDemo3";
            this.btnDemo3.Size = new System.Drawing.Size(75, 23);
            this.btnDemo3.TabIndex = 10;
            this.btnDemo3.Text = "Demo 3";
            this.btnDemo3.UseVisualStyleBackColor = true;
            this.btnDemo3.Click += new System.EventHandler(this.btnDemo3_Click);
            // 
            // checkNamespaceLinq
            // 
            this.checkNamespaceLinq.AutoSize = true;
            this.checkNamespaceLinq.Checked = true;
            this.checkNamespaceLinq.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNamespaceLinq.Location = new System.Drawing.Point(99, 61);
            this.checkNamespaceLinq.Name = "checkNamespaceLinq";
            this.checkNamespaceLinq.Size = new System.Drawing.Size(113, 17);
            this.checkNamespaceLinq.TabIndex = 9;
            this.checkNamespaceLinq.Text = "Using System.Linq";
            this.checkNamespaceLinq.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 450);
            this.Controls.Add(this.csharpEditorWindow);
            this.Controls.Add(this.tableLayoutControls);
            this.Controls.Add(this.outputWindow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSetupControls.ResumeLayout(false);
            this.panelSetupControls.PerformLayout();
            this.tableLayoutControls.ResumeLayout(false);
            this.panelLiveControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CDS.RoslynPadScripting.CSharpEditorWindow csharpEditorWindow;
        private System.Windows.Forms.Panel panelSetupControls;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCompile;
        private CDS.RoslynPadScripting.OutputWindow outputWindow;
        private System.Windows.Forms.CheckBox checkRequireStringListResultType;
        private System.Windows.Forms.Button btnDemo1;
        private System.Windows.Forms.CheckBox checkNamespaceSystem;
        private System.Windows.Forms.Button btnDemo2;
        private System.Windows.Forms.Button btnUninitialise;
        private System.Windows.Forms.Button btnInitialise;
        private System.Windows.Forms.TableLayoutPanel tableLayoutControls;
        private System.Windows.Forms.Panel panelLiveControls;
        private System.Windows.Forms.Button btnDemo3;
        private System.Windows.Forms.CheckBox checkNamespaceLinq;
    }
}

