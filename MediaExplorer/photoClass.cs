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

        private Image _currentOriginalImage;
        private float _zoomFactor = 1.0f;
        //
        const float ZoomStep = 0.1f;
        const float MinZoom = 0.5f;
        const float MaxZoom = 7.0f;
        //


        #region Photo
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

            try
            {
                using (Image originalImage = Image.FromFile(photoPath))
                {
                    _currentOriginalImage?.Dispose();
                    _currentOriginalImage = (Image)originalImage.Clone();

                    // zoom factor 
                    _zoomFactor = 1.0f;

                    UpdateDisplay(pictureBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox.Image = null;
                _currentOriginalImage?.Dispose();
                _currentOriginalImage = null;
            }
        }

        private Image GetScaledImage(Image originalImage, Size containerSize, float zoomFactor)
        {
            //  scale to fit 
            float scaleWidth = (float)containerSize.Width / originalImage.Width;
            float scaleHeight = (float)containerSize.Height / originalImage.Height;
            float fitScale = Math.Min(scaleWidth, scaleHeight);
            float totalScale = fitScale * zoomFactor;

            // if not needed add original
            if (Math.Abs(totalScale - 1.0f) < 0.001f)
            {
                return (Image)originalImage.Clone();
            }

            int newWidth = Math.Max(1, (int)Math.Round(originalImage.Width * totalScale));
            int newHeight = Math.Max(1, (int)Math.Round(originalImage.Height * totalScale));

            Bitmap scaledImage = new Bitmap(newWidth, newHeight, originalImage.PixelFormat);

            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return scaledImage;
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

                // rotate the image
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

        private void UpdateDisplay(PictureBox pictureBox)
        {
            if (_currentOriginalImage == null)
            {
                return;
            }

            try
            {
                Image scaledImage = GetScaledImage(_currentOriginalImage, pictureBox.ClientSize, _zoomFactor);
                pictureBox.Image?.Dispose();
                pictureBox.Image = scaledImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating display: {ex.Message}", "Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {

            if (e.Delta > 0)
            {
                _zoomFactor = Math.Min(_zoomFactor * (1 + ZoomStep), MaxZoom);
            }
            else
            {
                _zoomFactor = Math.Max(_zoomFactor / (1 + ZoomStep), MinZoom);
            }

            UpdateDisplay(sender as PictureBox);
        }

        public void SetupZoomEvents(PictureBox pictureBox)
        {
            pictureBox.MouseWheel += PictureBox_MouseWheel;
        }

        #endregion

        public void ResizeMaximizedWindow(Form1 form, PictureBox pictureBox, ListBox lstPhoto, StatusStrip statusBar)
        {
            globalClass.resizeMaximizedWindowCommon(form, pictureBox, lstPhoto, statusBar);
        }
    }
}
