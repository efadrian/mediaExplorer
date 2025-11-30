
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeImg = new System.Windows.Forms.Button();
            this.btnPhotos = new System.Windows.Forms.Button();
            this.btnSaveImg = new System.Windows.Forms.Button();
            this.btnRRight = new System.Windows.Forms.Button();
            this.btnRLeft = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lstPhotos = new System.Windows.Forms.ListBox();
            this.tabVideo = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelVideo = new System.Windows.Forms.Button();
            this.btn_lv = new System.Windows.Forms.Button();
            this.mPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.lstVideo = new System.Windows.Forms.ListBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.path = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.tab.SuspendLayout();
            this.tabPhotos.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.tabVideo.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabPhotos);
            this.tab.Controls.Add(this.tabVideo);
            this.tab.Controls.Add(this.tabSettings);
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(933, 425);
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
            this.tabPhotos.Size = new System.Drawing.Size(925, 399);
            this.tabPhotos.TabIndex = 0;
            this.tabPhotos.Text = "PhotoList";
            this.tabPhotos.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeImg);
            this.panel1.Controls.Add(this.btnPhotos);
            this.panel1.Controls.Add(this.btnSaveImg);
            this.panel1.Controls.Add(this.btnRRight);
            this.panel1.Controls.Add(this.btnRLeft);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 365);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 31);
            this.panel1.TabIndex = 6;
            // 
            // btnDeImg
            // 
            this.btnDeImg.Enabled = false;
            this.btnDeImg.Location = new System.Drawing.Point(633, 3);
            this.btnDeImg.Name = "btnDeImg";
            this.btnDeImg.Size = new System.Drawing.Size(111, 23);
            this.btnDeImg.TabIndex = 6;
            this.btnDeImg.Text = "Delete";
            this.btnDeImg.UseVisualStyleBackColor = true;
            this.btnDeImg.Click += new System.EventHandler(this.btnDeImg_Click);
            // 
            // btnPhotos
            // 
            this.btnPhotos.Location = new System.Drawing.Point(-1, 3);
            this.btnPhotos.Name = "btnPhotos";
            this.btnPhotos.Size = new System.Drawing.Size(250, 23);
            this.btnPhotos.TabIndex = 2;
            this.btnPhotos.Text = "Load Photos";
            this.btnPhotos.UseVisualStyleBackColor = true;
            this.btnPhotos.Click += new System.EventHandler(this.btnPhotos_Click);
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
            this.picBox.Size = new System.Drawing.Size(662, 355);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // lstPhotos
            // 
            this.lstPhotos.FormattingEnabled = true;
            this.lstPhotos.Location = new System.Drawing.Point(3, 3);
            this.lstPhotos.Name = "lstPhotos";
            this.lstPhotos.Size = new System.Drawing.Size(250, 355);
            this.lstPhotos.TabIndex = 0;
            // 
            // tabVideo
            // 
            this.tabVideo.Controls.Add(this.panel2);
            this.tabVideo.Controls.Add(this.mPlayer);
            this.tabVideo.Controls.Add(this.lstVideo);
            this.tabVideo.Location = new System.Drawing.Point(4, 22);
            this.tabVideo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabVideo.Name = "tabVideo";
            this.tabVideo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabVideo.Size = new System.Drawing.Size(925, 399);
            this.tabVideo.TabIndex = 1;
            this.tabVideo.Text = "VideoList";
            this.tabVideo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelVideo);
            this.panel2.Controls.Add(this.btn_lv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(4, 365);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(917, 31);
            this.panel2.TabIndex = 7;
            // 
            // btnDelVideo
            // 
            this.btnDelVideo.Enabled = false;
            this.btnDelVideo.Location = new System.Drawing.Point(255, 3);
            this.btnDelVideo.Name = "btnDelVideo";
            this.btnDelVideo.Size = new System.Drawing.Size(111, 23);
            this.btnDelVideo.TabIndex = 6;
            this.btnDelVideo.Text = "Delete";
            this.btnDelVideo.UseVisualStyleBackColor = true;
            this.btnDelVideo.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btn_lv
            // 
            this.btn_lv.Location = new System.Drawing.Point(-1, 3);
            this.btn_lv.Name = "btn_lv";
            this.btn_lv.Size = new System.Drawing.Size(250, 23);
            this.btn_lv.TabIndex = 2;
            this.btn_lv.Text = "Load Videos";
            this.btn_lv.UseVisualStyleBackColor = true;
            this.btn_lv.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // mPlayer
            // 
            this.mPlayer.Enabled = true;
            this.mPlayer.Location = new System.Drawing.Point(259, 4);
            this.mPlayer.Name = "mPlayer";
            this.mPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mPlayer.OcxState")));
            this.mPlayer.Size = new System.Drawing.Size(657, 355);
            this.mPlayer.TabIndex = 3;
            // 
            // lstVideo
            // 
            this.lstVideo.FormattingEnabled = true;
            this.lstVideo.Location = new System.Drawing.Point(3, 3);
            this.lstVideo.Name = "lstVideo";
            this.lstVideo.Size = new System.Drawing.Size(250, 355);
            this.lstVideo.TabIndex = 1;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(925, 399);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(8, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delete Files";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(161, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Delete File Permanently";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 33);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(139, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Move file to Recycle";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.path,
            this.statusPath});
            this.statusBar.Location = new System.Drawing.Point(0, 428);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(933, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "status";
            // 
            // path
            // 
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(0, 17);
            // 
            // statusPath
            // 
            this.statusPath.Name = "statusPath";
            this.statusPath.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 450);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tab);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "MediaExplorer v0.5";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tab.ResumeLayout(false);
            this.tabPhotos.ResumeLayout(false);
            this.tabPhotos.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.tabVideo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnDeImg;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel path;
        private System.Windows.Forms.ToolStripStatusLabel statusPath;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelVideo;
    }
}