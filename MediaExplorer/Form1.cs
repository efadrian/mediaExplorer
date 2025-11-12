using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MediaExplorer
{
    public partial class Form1 : Form
    {
        private photoClass photoHandler = new photoClass();
        private List<string> photoPaths = new List<string>();

        public Form1()
        {
            InitializeComponent();
            this.btnPhotos.Click += new EventHandler(this.btnPhotos_Click);
            this.lstPhotos.SelectedIndexChanged += new EventHandler(this.lstPhotos_SelectedIndexChanged);
        }

        private void btnPhotos_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    photoHandler.LoadPhotosIntoListBox(folderDialog.SelectedPath, lstPhotos, out photoPaths);
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
            }
        }


        #region Rotate
        private void button1_Click(object sender, EventArgs e)
        {
            photoHandler.RotatePhoto(picBox, true);
        }

        private void tRight_Click(object sender, EventArgs e)
        {
            photoHandler.RotatePhoto(picBox, false);
        }
        #endregion

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
    }
}
