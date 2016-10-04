namespace LiveSplit.Fez
{
    partial class FezSettings
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Village");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Bell Tower");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Waterfall");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Arch");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Tree");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Zu Ruins");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Lighthouse");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("End");
            this.chkStartTimer = new System.Windows.Forms.CheckBox();
            this.chkSelectFile = new System.Windows.Forms.CheckBox();
            this.chkAutoReset = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.treeView1 = new LiveSplit.Fez.NewTreeView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkStartTimer
            // 
            this.chkStartTimer.AutoSize = true;
            this.chkStartTimer.Location = new System.Drawing.Point(6, 19);
            this.chkStartTimer.Name = "chkStartTimer";
            this.chkStartTimer.Size = new System.Drawing.Size(238, 17);
            this.chkStartTimer.TabIndex = 14;
            this.chkStartTimer.TabStop = false;
            this.chkStartTimer.Text = "Automatically start timer when starting the run";
            this.chkStartTimer.UseVisualStyleBackColor = true;
            this.chkStartTimer.CheckedChanged += new System.EventHandler(this.checkStartTimer_CheckedChanged);
            // 
            // chkSelectFile
            // 
            this.chkSelectFile.AutoSize = true;
            this.chkSelectFile.Enabled = false;
            this.chkSelectFile.Location = new System.Drawing.Point(6, 65);
            this.chkSelectFile.Name = "chkSelectFile";
            this.chkSelectFile.Size = new System.Drawing.Size(226, 17);
            this.chkSelectFile.TabIndex = 15;
            this.chkSelectFile.TabStop = false;
            this.chkSelectFile.Text = "Automatically select file when starting timer";
            this.chkSelectFile.UseVisualStyleBackColor = true;
            this.chkSelectFile.CheckedChanged += new System.EventHandler(this.checkSelectFile_CheckedChanged);
            // 
            // chkAutoReset
            // 
            this.chkAutoReset.AutoSize = true;
            this.chkAutoReset.Location = new System.Drawing.Point(6, 42);
            this.chkAutoReset.Name = "chkAutoReset";
            this.chkAutoReset.Size = new System.Drawing.Size(247, 17);
            this.chkAutoReset.TabIndex = 16;
            this.chkAutoReset.TabStop = false;
            this.chkAutoReset.Text = "Automatically reset timer when resetting the run";
            this.chkAutoReset.UseVisualStyleBackColor = true;
            this.chkAutoReset.CheckedChanged += new System.EventHandler(this.checkAutoReset_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkStartTimer);
            this.groupBox2.Controls.Add(this.chkSelectFile);
            this.groupBox2.Controls.Add(this.chkAutoReset);
            this.groupBox2.Location = new System.Drawing.Point(10, 413);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 90);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 397);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select the splits you would like the autosplitter to split for:";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblVersion.Location = new System.Drawing.Point(440, 1);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(37, 13);
            this.lblVersion.TabIndex = 21;
            this.lblVersion.Text = "v0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 16);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "node_Village";
            treeNode1.Text = "Village";
            treeNode2.Name = "node_BellTower";
            treeNode2.Text = "Bell Tower";
            treeNode3.Name = "node_Waterfall";
            treeNode3.Text = "Waterfall";
            treeNode4.Name = "node_Arch";
            treeNode4.Text = "Arch";
            treeNode5.Name = "node_Tree";
            treeNode5.Text = "Tree";
            treeNode6.Name = "node_ZuRuins";
            treeNode6.Text = "Zu Ruins";
            treeNode7.Name = "node_Lighthouse";
            treeNode7.Text = "Lighthouse";
            treeNode8.Name = "node_End";
            treeNode8.Text = "End";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(458, 378);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // FezSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FezSettings";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(484, 513);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkStartTimer;
        private System.Windows.Forms.CheckBox chkSelectFile;
        private System.Windows.Forms.CheckBox chkAutoReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private LiveSplit.Fez.NewTreeView treeView1;
        private System.Windows.Forms.Label lblVersion;
    }
}
