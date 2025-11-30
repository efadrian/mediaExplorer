using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MediaExplorer
{
    public static class globalClass
    {
        private static readonly string IniFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.ini");

        public static void LoadMedia(string folderPath, photoClass photoHandler, VideoClass videoHandler, ListBox lstPhotos, ListBox lstVideo, out List<string> photoPaths, out List<string> videoPaths, ToolStripStatusLabel statusPath)
        {
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"The directory '{folderPath}' does not exist.");
            }

            // load photos and videos
            photoHandler.LoadPhotosIntoListBox(folderPath, lstPhotos, out photoPaths);
            videoHandler.LoadVideosIntoListBox(folderPath, lstVideo, out videoPaths);

            // update status
            statusPath.Text = $"Path: {folderPath}";
        }

        // resize maximized window common
        public static void resizeMaximizedWindowCommon(Form form, Control mediaControl, ListBox listBox, StatusStrip statusBar)
        {
            int defaultWidth = 662;
            int defaultHeight = 355;

            if (form.WindowState == FormWindowState.Maximized)
            {
                int mediaWidth = Math.Max(0, form.ClientSize.Width - 270);
                int listHeight = form.ClientSize.Height - statusBar.Height - 64;
                int mediaHeight = listHeight - 4;
                mediaControl.Size = new Size(mediaWidth, mediaHeight);
                listBox.Size = new Size(listBox.Width, listHeight);
            }
            else
            {
                mediaControl.Size = new Size(defaultWidth, defaultHeight);
                listBox.Size = new Size(listBox.Width, defaultHeight);
            }
        }

        //  get the last opened folder
        public static string GetLastFolderPath()
        {
            try
            {
                if (!File.Exists(IniFilePath))
                {
                    return string.Empty;
                }

                string[] lines = File.ReadAllLines(IniFilePath);
                foreach (string line in lines)
                {
                    if (line.TrimStart().StartsWith("LastFolderPath=", StringComparison.OrdinalIgnoreCase))
                    {
                        string path = line.Substring(line.IndexOf('=') + 1).Trim();
                        if (Directory.Exists(path))
                        {
                            return path;
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error reading INI file: {ex.Message}");
            }
            return string.Empty;
        }

        // save the last opened folder path
        public static void SaveLastFolderPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                return; 
            }
            try
            {
                List<string> lines = new List<string>();
                bool updated = false;

                if (File.Exists(IniFilePath))
                {
                    lines = File.ReadAllLines(IniFilePath).ToList();
                    for (int i = 0; i < lines.Count; i++)
                    {
                        if (lines[i].TrimStart().StartsWith("LastFolderPath=", StringComparison.OrdinalIgnoreCase))
                        {
                            lines[i] = $"LastFolderPath={path}";
                            updated = true;
                            break;
                        }
                    }
                }

                if (!updated)
                {
                    lines.Add($"LastFolderPath={path}");
                }

                File.WriteAllLines(IniFilePath, lines);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error writing to INI file: {ex.Message}");
            }
        }
    }
}
