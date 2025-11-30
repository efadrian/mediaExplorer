using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace MediaExplorer
{
    /* todo
     * zoom photo
     * gallery slideshow left right / full screen
     * save and saveAs
     * meta data details txt
     * drag and drop path
    */

    public partial class Form1 : Form
    {
        private photoClass photoHandler = new photoClass();
        private List<string> photoPaths = new List<string>();
        private VideoClass videoHandler = new VideoClass();
        private List<string> videoPaths = new List<string>();

        public Form1()
        {
            InitializeComponent();
            //
            this.lstPhotos.SelectedIndexChanged += new EventHandler(this.lstPhotos_SelectedIndexChanged);
            this.lstVideo.SelectedIndexChanged += new EventHandler(this.lstVideo_SelectedIndexChanged);
            //
            CheckDefaultFolder();
        }

        // loads the last opened folder
        private void CheckDefaultFolder()
        {
            string lastPath = globalClass.GetLastFolderPath();
            if (!string.IsNullOrEmpty(lastPath))
            {
                try
                {
                    loadAllMedia(lastPath, showNoMediaMessages: false);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error loading last folder on startup: {ex.Message}");
                }
            }
        }

        private void btnPhotos_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = globalClass.GetLastFolderPath();
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        loadAllMedia(folderDialog.SelectedPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading media files: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lstPhotos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPhotos.SelectedIndex >= 0 && lstPhotos.SelectedIndex < photoPaths.Count)
            {
                photoHandler.DisplayPhoto(photoPaths[lstPhotos.SelectedIndex], picBox);
                btnSaveImg.Enabled = true;
                btnRLeft.Enabled = true;
                btnRRight.Enabled = true;
                btnDeImg.Enabled = true;
            }
        }

        private void lstVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVideo.SelectedIndex >= 0 && lstVideo.SelectedIndex < videoPaths.Count)
            {
                try
                {
                    videoHandler.PlayVideo(videoPaths[lstVideo.SelectedIndex], mPlayer);
                    btnDelVideo.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error playing video: {ex.Message}", "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // rotate photo
        private void button1_Click(object sender, EventArgs e)
        {
            photoHandler.RotatePhoto(picBox, true);
        }

        private void tRight_Click(object sender, EventArgs e)
        {
            photoHandler.RotatePhoto(picBox, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp|GIF Image|*.gif";
                saveDialog.Title = "Save Image";
                saveDialog.FileName = "image.jpg";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImageFormat format = ImageFormat.Jpeg;
                        string extension = Path.GetExtension(saveDialog.FileName).ToLowerInvariant();

                        switch (extension)
                        {
                            case ".png":
                                format = ImageFormat.Png;
                                break;
                            case ".bmp":
                                format = ImageFormat.Bmp;
                                break;
                            case ".gif":
                                format = ImageFormat.Gif;
                                break;
                        }

                        picBox.Image.Save(saveDialog.FileName, format);

                        MessageBox.Show("Image saved successfully.", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving image: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = globalClass.GetLastFolderPath();
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        loadAllMedia(folderDialog.SelectedPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading video files: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void loadAllMedia(string folderPath, bool showNoMediaMessages = true)
        {
            // load media
            globalClass.LoadMedia(folderPath, photoHandler, videoHandler, lstPhotos, lstVideo, out photoPaths, out videoPaths, statusPath);

            // save the last opened folder path
            globalClass.SaveLastFolderPath(folderPath);

            // show message if no photos or videos found
            if (showNoMediaMessages)
            {
                List<string> missingMediaTypes = new List<string>();
                if (photoPaths.Count == 0)
                {
                    missingMediaTypes.Add("photos");
                }
                if (videoPaths.Count == 0)
                {
                    missingMediaTypes.Add("videos");
                }

                if (missingMediaTypes.Count > 0)
                {
                    string types = string.Join(" or ", missingMediaTypes);
                    MessageBox.Show($"No {types} found in the selected folder.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //
            photoHandler.ResizeMaximizedWindow(this, picBox, lstPhotos, statusBar);
            //
            videoHandler.ResizeMaximizedWindow(this, mPlayer, lstVideo, statusBar);
        }

        private void btnDeImg_Click(object sender, EventArgs e)
        {
            // delete the selected image
            if (lstPhotos.SelectedIndex >= 0)
            {
                string selectedPath = photoPaths[lstPhotos.SelectedIndex];
                DialogResult result = MessageBox.Show("Are you sure you want to delete this image ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (picBox.Image != null)
                        {
                            picBox.Image.Dispose();
                            picBox.Image = null;
                        }
                        // image is deleted but moved to recycle bin
                        FileSystem.DeleteFile(selectedPath, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);

                        photoPaths.RemoveAt(lstPhotos.SelectedIndex);
                        lstPhotos.Items.RemoveAt(lstPhotos.SelectedIndex);
                        btnSaveImg.Enabled = false;
                        btnRLeft.Enabled = false;
                        btnRRight.Enabled = false;
                        btnDeImg.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        try
                        {
                            photoHandler.DisplayPhoto(selectedPath, picBox);
                        }
                        catch {}
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an image to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // delete the video
            if (lstVideo.SelectedIndex >= 0 )
            {
                string selectedPath = videoPaths[lstVideo.SelectedIndex];
                DialogResult result = MessageBox.Show("Are you sure you want to delete this video?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // stop the video player
                        if (mPlayer.URL == selectedPath)
                        {
                            mPlayer.Ctlcontrols.stop();
                            mPlayer.URL = string.Empty;
                        }

                        //
                        FileSystem.DeleteFile(selectedPath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

                        videoPaths.RemoveAt(lstVideo.SelectedIndex);
                        lstVideo.Items.RemoveAt(lstVideo.SelectedIndex);

                        if (videoPaths.Count == 0)
                        {
                            btnDelVideo.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting video: {ex.Message}", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        try
                        {
                            videoHandler.PlayVideo(selectedPath, mPlayer);
                        }
                        catch { }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a video to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
