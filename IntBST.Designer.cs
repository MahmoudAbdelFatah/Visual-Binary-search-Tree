namespace DS_project
{
    partial class IntBST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntBST));
            this.Save = new System.Windows.Forms.Button();
            this.SaveAs = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.DelBox = new System.Windows.Forms.TextBox();
            this.Delete = new System.Windows.Forms.Button();
            this.AppBox = new System.Windows.Forms.TextBox();
            this.Append = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.Seacrh = new System.Windows.Forms.Button();
            this.Merge = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(1276, 40);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 16;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Location = new System.Drawing.Point(1276, 68);
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(75, 23);
            this.SaveAs.TabIndex = 15;
            this.SaveAs.Text = "Save as";
            this.SaveAs.UseVisualStyleBackColor = true;
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // Undo
            // 
            this.Undo.Location = new System.Drawing.Point(8, 99);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(75, 23);
            this.Undo.TabIndex = 14;
            this.Undo.Text = "Undo";
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(8, 128);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(75, 23);
            this.Restart.TabIndex = 13;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // DelBox
            // 
            this.DelBox.Location = new System.Drawing.Point(90, 43);
            this.DelBox.Name = "DelBox";
            this.DelBox.Size = new System.Drawing.Size(88, 20);
            this.DelBox.TabIndex = 12;
            this.DelBox.Text = " Delete from BST";
            this.DelBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DelBox_MouseClick);
            this.DelBox.TextChanged += new System.EventHandler(this.DelBox_TextChanged);
            this.DelBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelBox_KeyDown);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(8, 41);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 11;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // AppBox
            // 
            this.AppBox.Location = new System.Drawing.Point(90, 14);
            this.AppBox.Name = "AppBox";
            this.AppBox.Size = new System.Drawing.Size(88, 20);
            this.AppBox.TabIndex = 10;
            this.AppBox.Text = " append to BST";
            this.AppBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AppBox_MouseClick);
            this.AppBox.TextChanged += new System.EventHandler(this.AppBox_TextChanged);
            this.AppBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AppBox_KeyDown);
            // 
            // Append
            // 
            this.Append.Location = new System.Drawing.Point(8, 12);
            this.Append.Name = "Append";
            this.Append.Size = new System.Drawing.Size(75, 23);
            this.Append.TabIndex = 9;
            this.Append.Text = "append";
            this.Append.UseVisualStyleBackColor = true;
            this.Append.Click += new System.EventHandler(this.Append_Click);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(1276, 14);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(75, 23);
            this.Open.TabIndex = 17;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(90, 71);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(88, 20);
            this.searchBox.TabIndex = 19;
            this.searchBox.Text = " Search ...";
            this.searchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.searchBox_MouseClick);
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
            // 
            // Seacrh
            // 
            this.Seacrh.Location = new System.Drawing.Point(8, 70);
            this.Seacrh.Name = "Seacrh";
            this.Seacrh.Size = new System.Drawing.Size(75, 23);
            this.Seacrh.TabIndex = 20;
            this.Seacrh.Text = "Search";
            this.Seacrh.UseVisualStyleBackColor = true;
            this.Seacrh.Click += new System.EventHandler(this.Seacrh_Click);
            // 
            // Merge
            // 
            this.Merge.Location = new System.Drawing.Point(1195, 14);
            this.Merge.Name = "Merge";
            this.Merge.Size = new System.Drawing.Size(75, 23);
            this.Merge.TabIndex = 21;
            this.Merge.Text = "Merge";
            this.Merge.UseVisualStyleBackColor = true;
            this.Merge.Click += new System.EventHandler(this.Merge_Click);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(1195, 43);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(75, 23);
            this.Refresh.TabIndex = 22;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // IntBST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.Merge);
            this.Controls.Add(this.Seacrh);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.SaveAs);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.DelBox);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.AppBox);
            this.Controls.Add(this.Append);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IntBST";
            this.Text = "IntBST";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button SaveAs;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.TextBox DelBox;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.TextBox AppBox;
        private System.Windows.Forms.Button Append;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button Seacrh;
        private System.Windows.Forms.Button Merge;
        private System.Windows.Forms.Button Refresh;
    }
}

