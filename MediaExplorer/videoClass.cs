using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AxWMPLib;

namespace MediaExplorer
{
    public class VideoClass
    {
        private static readonly HashSet<string> _videoExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm", ".m4v", ".3gp"
        };

        public List<string> GetVideoFiles(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                return new List<string>();
            }

            try
            {
                return Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories)
                    .Where(f => _videoExtensions.Contains(Path.GetExtension(f)))
                    .ToList();
            }
            catch (DirectoryNotFoundException)
            {
                return new List<string>();
            }
            catch (IOException)
            {
                // Other IO errors, return empty
                return new List<string>();
            }
        }

        public void LoadVideosIntoListBox(string folderPath, ListBox listBox, out List<string> videoPaths)
        {
            if (listBox == null)
            {
                throw new ArgumentNullException(nameof(listBox));
            }

            videoPaths = GetVideoFiles(folderPath);
            listBox.Items.Clear();
            foreach (var path in videoPaths)
            {
                listBox.Items.Add(Path.GetFileName(path));
            }
        }

       public void PlayVideo(string videoPath, AxWindowsMediaPlayer player)
        {
            try
            {
                player.Ctlcontrols.stop();

                player.URL = videoPath;

                player.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading video: {ex.Message}", "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ResizeMaximizedWindow(Form form, AxWindowsMediaPlayer player, ListBox lstVideo, StatusStrip statusBar)
        {
            globalClass.resizeMaximizedWindowCommon(form, player, lstVideo, statusBar);
        }
    }
}
