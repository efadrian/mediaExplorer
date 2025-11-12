using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                throw new ArgumentException("Folder path cannot be null or empty.", nameof(folderPath));
            }

            if (!Directory.Exists(folderPath))
            {
                return new List<string>();
            }

            try
            {
                return Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories)
                    .Where(f => _videoExtensions.Contains(Path.GetExtension(f)))
                    .ToList();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO Error: {ex.Message}");
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

      public void PlayVideo(string videoPath, AxWMPLib.AxWindowsMediaPlayer player)
        {
            if (string.IsNullOrWhiteSpace(videoPath))
            {
                throw new ArgumentException("Video path cannot be null or empty.", nameof(videoPath));
            }

            if (player == null)
            {
                throw new ArgumentNullException(nameof(player), "Media player control cannot be null.");
            }

            if (!File.Exists(videoPath))
            {
                throw new FileNotFoundException("Video file not found.", videoPath);
            }

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
    }
}
