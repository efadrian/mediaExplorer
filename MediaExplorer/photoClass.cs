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
            // center photo
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            //
            try
            {
                using (Image originalImage = Image.FromFile(photoPath))
                {
                   Image resizedImage = ResizeImageToFit(originalImage, pictureBox.ClientSize);
                    if (resizedImage != null)
                    {
                        pictureBox.Image?.Dispose();

                        pictureBox.Image = resizedImage;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox.Image = null;
            }

        }

        private Image ResizeImageToFit(Image originalImage, Size maxSize)
        {
            // calculate  to fit within 
            float scaleWidth = (float)maxSize.Width / originalImage.Width;
            float scaleHeight = (float)maxSize.Height / originalImage.Height;
            float scale = Math.Min(scaleWidth, scaleHeight);

            if (scale >= 1.0f)
            {
                return (Image)originalImage.Clone();
            }

            int newWidth = Math.Max(1, (int)Math.Round(originalImage.Width * scale));
            int newHeight = Math.Max(1, (int)Math.Round(originalImage.Height * scale));

            Bitmap resizedImage = new Bitmap(newWidth, newHeight, originalImage.PixelFormat);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        public void RotatePhoto(PictureBox pictureBox, bool rotateLeft)
        {
            if (pictureBox.Image == null)
            {
                return;
            }

            try
            {
                Image rotatedImage = (Image)pictureBox.Image.Clone();

                // rotate
                RotateFlipType flipType = rotateLeft ? RotateFlipType.Rotate270FlipNone : RotateFlipType.Rotate90FlipNone;
                rotatedImage.RotateFlip(flipType);

                pictureBox.Image.Dispose();
                pictureBox.Image = rotatedImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error rotating image: {ex.Message}", "Rotation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ResizeMaximizedWindow(Form1 form, PictureBox pictureBox, ListBox lstPhoto, StatusStrip statusBar)
        {
            globalClass.resizeMaximizedWindowCommon(form, pictureBox, lstPhoto, statusBar);
        }
    }
}
