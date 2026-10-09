using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace MM_PlaylistEditor
{
    internal class Logic
    {
        #region Additional classes
        public class UsbDevice
        {
            public string Name { get; set; }
            public string DriveLetter { get; set; }
            public decimal Size { get; set; } = 0;
        }
        public class UsbPlayList
        {
            public string Name { get; set; }
            public List<string> EspFiles { get; set; } = new List<string>();
            public List<string> WinFiles { get; set; } = new List<string>();
        }
        #endregion
        public Form Form { get; set; }
        public List<UsbDevice> UsbDevices { get; set; } = new List<UsbDevice>();
        public List<UsbPlayList> UsbPlayLists { get; set; } = new List<UsbPlayList>();
        public UsbPlayList CurrentPlaylist { get; set; } = null;
        public UsbDevice CurrentDevice { get; set; } = null;
        public bool PlstHaveInvalidFiles { get; set; } = false;
        public Logic(Form form)
        {
            Form = form;
        }
        public void LoadUsbDevices()
        {
            UsbDevices = new List<UsbDevice>();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    UsbDevices.Add(new UsbDevice
                    {
                        Name = string.IsNullOrEmpty(drive.VolumeLabel.Trim()) ? "No label" : drive.VolumeLabel,
                        DriveLetter = drive.Name.Remove(drive.Name.IndexOf(':') + 1),
                        Size = Math.Round((decimal)drive.TotalSize / (1024 * 1024 * 1024), 2) // Size in GB
                    });
                }
            }
        }
        public void LoadUsbPlayLists(int index)
        {
            UsbDevice device = UsbDevices[index];
            if (device == null)
            {
                MessageBox.Show("Selected USB device is not available.");
                return;
            }
            UsbPlayLists = new List<UsbPlayList>();
            foreach (var file in Directory.GetFiles(device.DriveLetter, "*.plst"))
            {
                var playlist = new UsbPlayList
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    EspFiles = new List<string>(File.ReadAllLines(file))
                };
                playlist.WinFiles = playlist.EspFiles.ConvertAll(espFile => ConvertToWinPath(espFile));
                UsbPlayLists.Add(playlist);
            }
        }
        private string ConvertToEspPath(string winPath)
        {
            if (CurrentDevice == null)
                return string.Empty;
            return winPath.Replace(CurrentDevice.DriveLetter, "/usb").Replace('\\', '/');
        }
        private string ConvertToWinPath(string espPath)
        {
            if (CurrentDevice == null)
                return string.Empty;
            return espPath.Replace("/usb", CurrentDevice.DriveLetter).Replace('/', '\\');
        }
        public List<string> GetAllUsbFiles()
        {
            if (CurrentDevice == null)
            {
                MessageBox.Show("Selected USB device is not available.");
                return new List<string>();
            }
            List<string> allFiles = new List<string>();
            foreach (var file in Directory.GetFiles(CurrentDevice.DriveLetter + @"\", "*.mp3", SearchOption.AllDirectories))
                allFiles.Add(file);
            return allFiles;
        }
        public string ProcessPlaylistFile(string file)
        {
            if (!File.Exists(file))
            {
                PlstHaveInvalidFiles = true;
                return string.Empty;
            }
            return file;
        }
        public void SaveCurrentPlaylist()
        {
            if (CurrentPlaylist == null || CurrentDevice == null)
            {
                MessageBox.Show("No playlist or device selected.");
                return;
            }
            string plstPath = Path.Combine(CurrentDevice.DriveLetter + @"/", CurrentPlaylist.Name + ".plst");
            CurrentPlaylist.EspFiles = CurrentPlaylist.WinFiles.ConvertAll(winFile => ConvertToEspPath(winFile));
            File.WriteAllLines(plstPath, CurrentPlaylist.EspFiles);
        }
        public void DeleteCurrentPlaylist()
        {
            if (CurrentPlaylist == null || CurrentDevice == null)
            {
                MessageBox.Show("No playlist or device selected.");
                return;
            }
            string plstPath = Path.Combine(CurrentDevice.DriveLetter, CurrentPlaylist.Name + ".plst");
            string plstIdxPath = Path.Combine(CurrentDevice.DriveLetter, CurrentPlaylist.Name + ".idx");
            if (File.Exists(plstPath))
                File.Delete(plstPath);
            if (File.Exists(plstIdxPath))
                File.Delete(plstIdxPath);
        }
    }
}
