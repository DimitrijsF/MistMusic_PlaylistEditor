using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MM_PlaylistEditor
{
    public partial class PlaylistEditor : Form
    {
        private Logic logic;
        private bool isChanged = false;
        #region Form events
        public PlaylistEditor()
        {
            InitializeComponent();
            logic = new Logic(this);
        }
        private void PlaylistEditor_Shown(object sender, EventArgs e)
        {
            UpdateDriveList();
        }
        private void btRefreshDrives_Click(object sender, EventArgs e)
        {
            UpdateDriveList();
        }
        private void btCreatePlst_Click(object sender, EventArgs e)
        {
            if (isChanged &&
                MessageBox.Show("You have unsaved changes. Do you want to continue?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            Form newPlstDialog = new NewPlstDialog();
            newPlstDialog.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = newPlstDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string newName = ((NewPlstDialog)newPlstDialog).GetResult();          
                logic.UsbPlayLists.Add(new Logic.UsbPlayList()
                {
                    Name = newName,
                    EspFiles = new List<string>(),
                    WinFiles = new List<string>()
                });
                treePlstFiles.Nodes.Clear();
                int newIndex = cbPlaylists.Items.Add(newName);
                cbPlaylists.SelectedIndex = newIndex;
            }
            newPlstDialog.Close();
            isChanged = true;
        }
        private void treeAllFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AddToPlayList();
        }
        private void treePlstFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RemoveFromPlayList();
        }
        private void cbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.CurrentDevice = logic.UsbDevices[cbDevices.SelectedIndex];
            LoadUsbFiles();
            LoadPlayLists();
        }
        private void cbPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.CurrentPlaylist = logic.UsbPlayLists[cbPlaylists.SelectedIndex];
            LoadPlaylistFiles();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            ProcessSave();
            isChanged = false;
        }
        private void btPlstDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this playlist?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cbPlaylists.Items.RemoveAt(cbPlaylists.SelectedIndex);
                logic.DeleteCurrentPlaylist();
                isChanged = false;
                MessageBox.Show("Playlist deleted successfully.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        private void UpdateDriveList()
        {
            if (isChanged &&
                MessageBox.Show("You have unsaved changes. Do you want to continue?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            cbDevices.Items.Clear();
            logic.LoadUsbDevices();
            foreach (var device in logic.UsbDevices)
                cbDevices.Items.Add($"({device.DriveLetter}) {device.Name} - {device.Size} GB");
            if (cbDevices.Items.Count > 0)
            {
                cbDevices.SelectedIndex = 0;
                LoadUsbFiles();
                panelList.Enabled = true;
                isChanged = false;
            }
        }
        private void LoadPlayLists()
        {
            cbPlaylists.Items.Clear();
            logic.LoadUsbPlayLists(cbDevices.SelectedIndex);
            foreach (var playlist in logic.UsbPlayLists)
                cbPlaylists.Items.Add(playlist.Name);        
        }
        private void LoadUsbFiles()
        {
            if (isChanged &&
               MessageBox.Show("You have unsaved changes. Do you want to continue?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            treeAllFiles.Nodes.Clear();
            foreach (var file in logic.GetAllUsbFiles())
                treeAllFiles.Nodes.Add(file);
            isChanged = false;
        }
        private void LoadPlaylistFiles()
        {
            if (logic.CurrentPlaylist == null)
                return;
            if (isChanged &&
                MessageBox.Show("You have unsaved changes. Do you want to continue?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            treePlstFiles.Nodes.Clear();
            foreach (var file in logic.CurrentPlaylist.WinFiles)
            {
                string winFile = logic.ProcessPlaylistFile(file);
                if (!string.IsNullOrEmpty(winFile))
                    treePlstFiles.Nodes.Add(winFile);
                if(treeAllFiles.Nodes.ContainsKey(winFile))
                    treeAllFiles.Nodes.RemoveByKey(winFile);
            }
            if (logic.PlstHaveInvalidFiles)
            {
                MessageBox.Show("Some files in the playlist are invalid or missing.", "Invalid Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isChanged = true;
                logic.PlstHaveInvalidFiles = false;
            }
        }
        private void ProcessSave()
        {
            if (logic.CurrentPlaylist == null)
                return;
            logic.CurrentPlaylist.WinFiles.Clear();
            foreach (var file in treePlstFiles.Nodes)
            {
                if (file is TreeNode node)
                    logic.CurrentPlaylist.WinFiles.Add(node.Text);
            }
            logic.SaveCurrentPlaylist();
            isChanged = false;
            MessageBox.Show("Playlist saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AddToPlayList()
        {
            if(logic.CurrentPlaylist == null)
            {
                MessageBox.Show("Please select or create a playlist first.", "No Playlist Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (treeAllFiles.SelectedNode == null)
                return;        
            treePlstFiles.Nodes.Add(treeAllFiles.SelectedNode.Text);
            treeAllFiles.Nodes.Remove(treeAllFiles.SelectedNode);
            isChanged = true;
        }
        private void RemoveFromPlayList()
        {
            if(treePlstFiles.SelectedNode == null)
                return;
            treeAllFiles.Nodes.Add(treePlstFiles.SelectedNode.Text);
            treePlstFiles.Nodes.Remove(treePlstFiles.SelectedNode);           
            isChanged = true;
        }
    }
}
