namespace MM_PlaylistEditor
{
    partial class PlaylistEditor
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
            this.btRefreshDrives = new System.Windows.Forms.Button();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPlaylists = new System.Windows.Forms.ComboBox();
            this.btCreatePlst = new System.Windows.Forms.Button();
            this.panelList = new System.Windows.Forms.Panel();
            this.treeAllFiles = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.treePlstFiles = new System.Windows.Forms.TreeView();
            this.btSave = new System.Windows.Forms.Button();
            this.btPlstDelete = new System.Windows.Forms.Button();
            this.panelList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRefreshDrives
            // 
            this.btRefreshDrives.Location = new System.Drawing.Point(290, 30);
            this.btRefreshDrives.Name = "btRefreshDrives";
            this.btRefreshDrives.Size = new System.Drawing.Size(75, 26);
            this.btRefreshDrives.TabIndex = 0;
            this.btRefreshDrives.Text = "Refresh";
            this.btRefreshDrives.UseVisualStyleBackColor = true;
            this.btRefreshDrives.Click += new System.EventHandler(this.btRefreshDrives_Click);
            // 
            // cbDevices
            // 
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(12, 29);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(269, 26);
            this.cbDevices.TabIndex = 1;
            this.cbDevices.SelectedIndexChanged += new System.EventHandler(this.cbDevices_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Removable drives";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Existing playlists";
            // 
            // cbPlaylists
            // 
            this.cbPlaylists.FormattingEnabled = true;
            this.cbPlaylists.Location = new System.Drawing.Point(423, 29);
            this.cbPlaylists.Name = "cbPlaylists";
            this.cbPlaylists.Size = new System.Drawing.Size(268, 26);
            this.cbPlaylists.TabIndex = 4;
            this.cbPlaylists.SelectedIndexChanged += new System.EventHandler(this.cbPlaylists_SelectedIndexChanged);
            // 
            // btCreatePlst
            // 
            this.btCreatePlst.Location = new System.Drawing.Point(697, 29);
            this.btCreatePlst.Name = "btCreatePlst";
            this.btCreatePlst.Size = new System.Drawing.Size(75, 26);
            this.btCreatePlst.TabIndex = 5;
            this.btCreatePlst.Text = "Create";
            this.btCreatePlst.UseVisualStyleBackColor = true;
            this.btCreatePlst.Click += new System.EventHandler(this.btCreatePlst_Click);
            // 
            // panelList
            // 
            this.panelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelList.Controls.Add(this.btPlstDelete);
            this.panelList.Controls.Add(this.btSave);
            this.panelList.Controls.Add(this.label4);
            this.panelList.Controls.Add(this.label3);
            this.panelList.Controls.Add(this.treePlstFiles);
            this.panelList.Controls.Add(this.treeAllFiles);
            this.panelList.Enabled = false;
            this.panelList.Location = new System.Drawing.Point(15, 62);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(757, 451);
            this.panelList.TabIndex = 6;
            // 
            // treeAllFiles
            // 
            this.treeAllFiles.Location = new System.Drawing.Point(6, 31);
            this.treeAllFiles.Name = "treeAllFiles";
            this.treeAllFiles.Size = new System.Drawing.Size(342, 381);
            this.treeAllFiles.TabIndex = 0;
            this.treeAllFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeAllFiles_NodeMouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Availiable files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Playlist files";
            // 
            // treePlstFiles
            // 
            this.treePlstFiles.Location = new System.Drawing.Point(408, 31);
            this.treePlstFiles.Name = "treePlstFiles";
            this.treePlstFiles.Size = new System.Drawing.Size(342, 381);
            this.treePlstFiles.TabIndex = 0;
            this.treePlstFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treePlstFiles_NodeMouseDoubleClick);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(408, 418);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(342, 26);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Save playlist";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btPlstDelete
            // 
            this.btPlstDelete.Location = new System.Drawing.Point(6, 418);
            this.btPlstDelete.Name = "btPlstDelete";
            this.btPlstDelete.Size = new System.Drawing.Size(342, 26);
            this.btPlstDelete.TabIndex = 2;
            this.btPlstDelete.Text = "Delete playlist";
            this.btPlstDelete.UseVisualStyleBackColor = true;
            this.btPlstDelete.Click += new System.EventHandler(this.btPlstDelete_Click);
            // 
            // PlaylistEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 525);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.btCreatePlst);
            this.Controls.Add(this.cbPlaylists);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDevices);
            this.Controls.Add(this.btRefreshDrives);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlaylistEditor";
            this.Text = "MistMusic Playlist Editor";
            this.Shown += new System.EventHandler(this.PlaylistEditor_Shown);
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRefreshDrives;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPlaylists;
        private System.Windows.Forms.Button btCreatePlst;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treePlstFiles;
        private System.Windows.Forms.TreeView treeAllFiles;
        private System.Windows.Forms.Button btPlstDelete;
    }
}

