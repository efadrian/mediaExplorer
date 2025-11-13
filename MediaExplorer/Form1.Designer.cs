
namespace MediaExplorer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPhotos = new System.Windows.Forms.TabPage();
            this.btnSaveImg = new System.Windows.Forms.Button();
            this.btnRRight = new System.Windows.Forms.Button();
            this.btnRLeft = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lstPhotos = new System.Windows.Forms.ListBox();
            this.btnPhotos = new System.Windows.Forms.Button();
            this.tabVideo = new System.Windows.Forms.TabPage();
            this.mPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.btn_lv = new System.Windows.Forms.Button();
            this.lstVideo = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tab.SuspendLayout();
            this.tabPhotos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.tabVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPhotos);
            this.tab.Controls.Add(this.tabVideo);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(933, 450);
            this.tab.TabIndex = 0;
            // 
            // tabPhotos
            // 
            this.tabPhotos.Controls.Add(this.panel1);
            this.tabPhotos.Controls.Add(this.picBox);
            this.tabPhotos.Controls.Add(this.lstPhotos);
            this.tabPhotos.Location = new System.Drawing.Point(4, 22);
            this.tabPhotos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPhotos.Name = "tabPhotos";
            this.tabPhotos.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPhotos.Size = new System.Drawing.Size(925, 424);
            this.tabPhotos.TabIndex = 0;
            this.tabPhotos.Text = "PhotoList";
            this.tabPhotos.UseVisualStyleBackColor = true;
            // 
            // btnSaveImg
            // 
            this.btnSaveImg.Enabled = false;
            this.btnSaveImg.Location = new System.Drawing.Point(507, 3);
            this.btnSaveImg.Name = "btnSaveImg";
            this.btnSaveImg.Size = new System.Drawing.Size(120, 23);
            this.btnSaveImg.TabIndex = 5;
            this.btnSaveImg.Text = "Save Image";
            this.btnSaveImg.UseVisualStyleBackColor = true;
            this.btnSaveImg.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRRight
            // 
            this.btnRRight.Enabled = false;
            this.btnRRight.Location = new System.Drawing.Point(381, 3);
            this.btnRRight.Name = "btnRRight";
            this.btnRRight.Size = new System.Drawing.Size(120, 23);
            this.btnRRight.TabIndex = 4;
            this.btnRRight.Text = "Rotate Right";
            this.btnRRight.UseVisualStyleBackColor = true;
            this.btnRRight.Click += new System.EventHandler(this.tRight_Click);
            // 
            // btnRLeft
            // 
            this.btnRLeft.Enabled = false;
            this.btnRLeft.Location = new System.Drawing.Point(255, 3);
            this.btnRLeft.Name = "btnRLeft";
            this.btnRLeft.Size = new System.Drawing.Size(120, 23);
            this.btnRLeft.TabIndex = 3;
            this.btnRLeft.Text = "Rotate Left";
            this.btnRLeft.UseVisualStyleBackColor = true;
            this.btnRLeft.Click += new System.EventHandler(this.button1_Click);
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.Transparent;
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(259, 3);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(662, 381);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // lstPhotos
            // 
            this.lstPhotos.FormattingEnabled = true;
            this.lstPhotos.Location = new System.Drawing.Point(3, 3);
            this.lstPhotos.Name = "lstPhotos";
            this.lstPhotos.Size = new System.Drawing.Size(250, 381);
            this.lstPhotos.TabIndex = 0;
            // 
            // btnPhotos
            // 
            this.btnPhotos.Location = new System.Drawing.Point(-1, 3);
            this.btnPhotos.Name = "btnPhotos";
            this.btnPhotos.Size = new System.Drawing.Size(250, 23);
            this.btnPhotos.TabIndex = 2;
            this.btnPhotos.Text = "Load Photos";
            this.btnPhotos.UseVisualStyleBackColor = true;
            // 
            // tabVideo
            // 
            this.tabVideo.Controls.Add(this.mPlayer);
            this.tabVideo.Controls.Add(this.btn_lv);
            this.tabVideo.Controls.Add(this.lstVideo);
            this.tabVideo.Location = new System.Drawing.Point(4, 22);
            this.tabVideo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabVideo.Name = "tabVideo";
            this.tabVideo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabVideo.Size = new System.Drawing.Size(925, 424);
            this.tabVideo.TabIndex = 1;
            this.tabVideo.Text = "VideoList";
            this.tabVideo.UseVisualStyleBackColor = true;
            // 
            // mPlayer
            // 
            this.mPlayer.Enabled = true;
            this.mPlayer.Location = new System.Drawing.Point(259, 4);
            this.mPlayer.Name = "mPlayer";
            this.mPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mPlayer.OcxState")));
            this.mPlayer.Size = new System.Drawing.Size(657, 410);
            this.mPlayer.TabIndex = 3;
            // 
            // btn_lv
            // 
            this.btn_lv.Location = new System.Drawing.Point(3, 393);
            this.btn_lv.Name = "btn_lv";
            this.btn_lv.Size = new System.Drawing.Size(250, 23);
            this.btn_lv.TabIndex = 2;
            this.btn_lv.Text = "Load Videos";
            this.btn_lv.UseVisualStyleBackColor = true;
            this.btn_lv.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lstVideo
            // 
            this.lstVideo.FormattingEnabled = true;
            this.lstVideo.Location = new System.Drawing.Point(3, 3);
            this.lstVideo.Name = "lstVideo";
            this.lstVideo.Size = new System.Drawing.Size(250, 381);
            this.lstVideo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPhotos);
            this.panel1.Controls.Add(this.btnSaveImg);
            this.panel1.Controls.Add(this.btnRRight);
            this.panel1.Controls.Add(this.btnRLeft);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 31);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 450);
            this.Controls.Add(this.tab);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "MediaExplorer v0.2";
            this.tab.ResumeLayout(false);
            this.tabPhotos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.tabVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPhotos;
        private System.Windows.Forms.TabPage tabVideo;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.ListBox lstPhotos;
        private System.Windows.Forms.Button btnPhotos;
        private System.Windows.Forms.Button btnRRight;
        private System.Windows.Forms.Button btnRLeft;
        private System.Windows.Forms.Button btnSaveImg;
        private System.Windows.Forms.ListBox lstVideo;
        private System.Windows.Forms.Button btn_lv;
        private AxWMPLib.AxWindowsMediaPlayer mPlayer;
        private System.Windows.Forms.Panel panel1;
    }
}