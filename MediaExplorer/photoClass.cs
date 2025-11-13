
using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MediaExplorer
{
    public class photoClass
    {
        private static readonly HashSet<string> _photoExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".bmp", ".gif"
        };

        public List<string> GetPhotoFiles(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                return new List<string>();
            }

            try
            {
                return Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories)
                    .Where(f => _photoExtensions.Contains(Path.GetExtension(f)))
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

        public void LoadPhotosIntoListBox(string folderPath, ListBox listBox, out List<string> photoPaths)
        {
            photoPaths = GetPhotoFiles(folderPath);
            listBox.Items.Clear();
            foreach (var path in photoPaths)
            {
                listBox.Items.Add(Path.GetFileName(path));
            }
        }

        public void DisplayPhoto(string photoPath, PictureBox pictureBox)
        {
            if (File.Exists(photoPath))
            {
                pictureBox.Image?.Dispose();
                pictureBox.Image = Image.FromFile(photoPath);
            }
        }

        public void RotatePhoto(PictureBox pictureBox, bool rotateLeft)
        {
            if (pictureBox.Image == null)
            {
                return; // No image to rotate
            }

            try
            {
                // Clone the image to avoid modifying the original file
                Image rotatedImage = (Image)pictureBox.Image.Clone();

                // Perform rotation
                RotateFlipType flipType = rotateLeft ? RotateFlipType.Rotate270FlipNone : RotateFlipType.Rotate90FlipNone;
                rotatedImage.RotateFlip(flipType);

                // Dispose the old image and set the new one
                pictureBox.Image.Dispose();
                pictureBox.Image = rotatedImage;
            }
            catch (Exception ex)
            {
                // Log or handle the exception (e.g., show a message box)
                MessageBox.Show($"Error rotating image: {ex.Message}", "Rotation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ResizeMaximizedWindow(Form1 form, PictureBox pictureBox, ListBox lstPhoto)
        {
            int widthBox = 662;
            int heightBox = 381;
            //
            int heightLst = 381;
            if (form.WindowState == FormWindowState.Maximized)
            {
                widthBox = Math.Max(0, form.ClientSize.Width - 270);
                //
                heightLst = form.ClientSize.Height - 64;
                heightBox = heightLst;
            }

            pictureBox.Size = new Size(widthBox, heightBox);
            //
            lstPhoto.Size = new Size(lstPhoto.Width, heightLst);
        }
    }
}
