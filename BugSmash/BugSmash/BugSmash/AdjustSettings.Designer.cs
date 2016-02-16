namespace BugSmash
{
    partial class AdjustSettings
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
            this.buttonBrowseEnemy = new System.Windows.Forms.Button();
            this.buttonBrowseObjective = new System.Windows.Forms.Button();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.buttonApplyChanges = new System.Windows.Forms.Button();
            this.labelEnemy = new System.Windows.Forms.Label();
            this.labelObjective = new System.Windows.Forms.Label();
            this.labelBackground = new System.Windows.Forms.Label();
            this.textBoxEnemy = new System.Windows.Forms.TextBox();
            this.textBoxObjective = new System.Windows.Forms.TextBox();
            this.textBoxBackground = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelEnemyName = new System.Windows.Forms.Label();
            this.textBoxGameName = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowseEnemy
            // 
            this.buttonBrowseEnemy.Location = new System.Drawing.Point(416, 37);
            this.buttonBrowseEnemy.Name = "buttonBrowseEnemy";
            this.buttonBrowseEnemy.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseEnemy.TabIndex = 0;
            this.buttonBrowseEnemy.Text = "Browse...";
            this.buttonBrowseEnemy.UseVisualStyleBackColor = true;
            this.buttonBrowseEnemy.Click += new System.EventHandler(this.buttonBrowseEnemy_Click);
            // 
            // buttonBrowseObjective
            // 
            this.buttonBrowseObjective.Location = new System.Drawing.Point(416, 66);
            this.buttonBrowseObjective.Name = "buttonBrowseObjective";
            this.buttonBrowseObjective.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseObjective.TabIndex = 1;
            this.buttonBrowseObjective.Text = "Browse...";
            this.buttonBrowseObjective.UseVisualStyleBackColor = true;
            this.buttonBrowseObjective.Click += new System.EventHandler(this.buttonBrowseObjective_Click);
            // 
            // buttonBackground
            // 
            this.buttonBackground.Location = new System.Drawing.Point(416, 95);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(75, 23);
            this.buttonBackground.TabIndex = 2;
            this.buttonBackground.Text = "Browse...";
            this.buttonBackground.UseVisualStyleBackColor = true;
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // buttonApplyChanges
            // 
            this.buttonApplyChanges.Location = new System.Drawing.Point(120, 149);
            this.buttonApplyChanges.Name = "buttonApplyChanges";
            this.buttonApplyChanges.Size = new System.Drawing.Size(88, 23);
            this.buttonApplyChanges.TabIndex = 3;
            this.buttonApplyChanges.Text = "Apply Changes";
            this.buttonApplyChanges.UseVisualStyleBackColor = true;
            this.buttonApplyChanges.Click += new System.EventHandler(this.buttonApplyChanges_Click);
            // 
            // labelEnemy
            // 
            this.labelEnemy.AutoSize = true;
            this.labelEnemy.Location = new System.Drawing.Point(12, 42);
            this.labelEnemy.Name = "labelEnemy";
            this.labelEnemy.Size = new System.Drawing.Size(74, 13);
            this.labelEnemy.TabIndex = 4;
            this.labelEnemy.Text = "Enemy Image:";
            // 
            // labelObjective
            // 
            this.labelObjective.AutoSize = true;
            this.labelObjective.Location = new System.Drawing.Point(12, 71);
            this.labelObjective.Name = "labelObjective";
            this.labelObjective.Size = new System.Drawing.Size(87, 13);
            this.labelObjective.TabIndex = 5;
            this.labelObjective.Text = "Objective Image:";
            // 
            // labelBackground
            // 
            this.labelBackground.AutoSize = true;
            this.labelBackground.Location = new System.Drawing.Point(12, 100);
            this.labelBackground.Name = "labelBackground";
            this.labelBackground.Size = new System.Drawing.Size(100, 13);
            this.labelBackground.TabIndex = 6;
            this.labelBackground.Text = "Background Image:";
            // 
            // textBoxEnemy
            // 
            this.textBoxEnemy.Location = new System.Drawing.Point(120, 39);
            this.textBoxEnemy.Name = "textBoxEnemy";
            this.textBoxEnemy.Size = new System.Drawing.Size(263, 20);
            this.textBoxEnemy.TabIndex = 7;
            // 
            // textBoxObjective
            // 
            this.textBoxObjective.Location = new System.Drawing.Point(120, 68);
            this.textBoxObjective.Name = "textBoxObjective";
            this.textBoxObjective.Size = new System.Drawing.Size(263, 20);
            this.textBoxObjective.TabIndex = 8;
            // 
            // textBoxBackground
            // 
            this.textBoxBackground.Location = new System.Drawing.Point(120, 97);
            this.textBoxBackground.Name = "textBoxBackground";
            this.textBoxBackground.Size = new System.Drawing.Size(263, 20);
            this.textBoxBackground.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(517, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // labelEnemyName
            // 
            this.labelEnemyName.AutoSize = true;
            this.labelEnemyName.Location = new System.Drawing.Point(12, 126);
            this.labelEnemyName.Name = "labelEnemyName";
            this.labelEnemyName.Size = new System.Drawing.Size(73, 13);
            this.labelEnemyName.TabIndex = 11;
            this.labelEnemyName.Text = "Enemy Name:";
            // 
            // textBoxGameName
            // 
            this.textBoxGameName.Location = new System.Drawing.Point(120, 123);
            this.textBoxGameName.Name = "textBoxGameName";
            this.textBoxGameName.Size = new System.Drawing.Size(263, 20);
            this.textBoxGameName.TabIndex = 12;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(295, 149);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(88, 23);
            this.buttonReset.TabIndex = 13;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // AdjustSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 180);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxGameName);
            this.Controls.Add(this.labelEnemyName);
            this.Controls.Add(this.textBoxBackground);
            this.Controls.Add(this.textBoxObjective);
            this.Controls.Add(this.textBoxEnemy);
            this.Controls.Add(this.labelBackground);
            this.Controls.Add(this.labelObjective);
            this.Controls.Add(this.labelEnemy);
            this.Controls.Add(this.buttonApplyChanges);
            this.Controls.Add(this.buttonBackground);
            this.Controls.Add(this.buttonBrowseObjective);
            this.Controls.Add(this.buttonBrowseEnemy);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdjustSettings";
            this.Text = "Adjust Game Settings";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowseEnemy;
        private System.Windows.Forms.Button buttonBrowseObjective;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.Button buttonApplyChanges;
        private System.Windows.Forms.Label labelEnemy;
        private System.Windows.Forms.Label labelObjective;
        private System.Windows.Forms.Label labelBackground;
        private System.Windows.Forms.TextBox textBoxEnemy;
        private System.Windows.Forms.TextBox textBoxObjective;
        private System.Windows.Forms.TextBox textBoxBackground;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label labelEnemyName;
        private System.Windows.Forms.TextBox textBoxGameName;
        private System.Windows.Forms.Button buttonReset;
    }
}