using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace MediaExplorer
{
    public static class globalClass
    {
        // load media
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
    }
}
