
namespace FaceRecognition
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imgCamUser = new Emgu.CV.UI.ImageBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTrainedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fromMultiPicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recognizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromPictureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fromVideoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgCamUser
            // 
            this.imgCamUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imgCamUser.Location = new System.Drawing.Point(12, 27);
            this.imgCamUser.Name = "imgCamUser";
            this.imgCamUser.Size = new System.Drawing.Size(400, 310);
            this.imgCamUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCamUser.TabIndex = 2;
            this.imgCamUser.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.trainToolStripMenuItem,
            this.recognizeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(424, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearTrainedDataToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // clearTrainedDataToolStripMenuItem
            // 
            this.clearTrainedDataToolStripMenuItem.Name = "clearTrainedDataToolStripMenuItem";
            this.clearTrainedDataToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.clearTrainedDataToolStripMenuItem.Text = "Clear Trained Data...";
            this.clearTrainedDataToolStripMenuItem.Click += new System.EventHandler(this.clearTrainedDataToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // trainToolStripMenuItem
            // 
            this.trainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromPictureToolStripMenuItem,
            this.fromVideoToolStripMenuItem,
            this.toolStripSeparator1,
            this.fromMultiPicturesToolStripMenuItem});
            this.trainToolStripMenuItem.Name = "trainToolStripMenuItem";
            this.trainToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.trainToolStripMenuItem.Text = "&Train";
            // 
            // fromPictureToolStripMenuItem
            // 
            this.fromPictureToolStripMenuItem.Name = "fromPictureToolStripMenuItem";
            this.fromPictureToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.fromPictureToolStripMenuItem.Text = "From &Picture";
            this.fromPictureToolStripMenuItem.Click += new System.EventHandler(this.fromPictureToolStripMenuItem_Click);
            // 
            // fromVideoToolStripMenuItem
            // 
            this.fromVideoToolStripMenuItem.Name = "fromVideoToolStripMenuItem";
            this.fromVideoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.fromVideoToolStripMenuItem.Text = "From &Video";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // fromMultiPicturesToolStripMenuItem
            // 
            this.fromMultiPicturesToolStripMenuItem.Name = "fromMultiPicturesToolStripMenuItem";
            this.fromMultiPicturesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.fromMultiPicturesToolStripMenuItem.Text = "From Multi Pictures";
            this.fromMultiPicturesToolStripMenuItem.Click += new System.EventHandler(this.fromMultiPicturesToolStripMenuItem_Click);
            // 
            // recognizeToolStripMenuItem
            // 
            this.recognizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromPictureToolStripMenuItem1,
            this.fromVideoToolStripMenuItem1});
            this.recognizeToolStripMenuItem.Name = "recognizeToolStripMenuItem";
            this.recognizeToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.recognizeToolStripMenuItem.Text = "&Recognize";
            // 
            // fromPictureToolStripMenuItem1
            // 
            this.fromPictureToolStripMenuItem1.Name = "fromPictureToolStripMenuItem1";
            this.fromPictureToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.fromPictureToolStripMenuItem1.Text = "From &Picture";
            this.fromPictureToolStripMenuItem1.Click += new System.EventHandler(this.fromPictureToolStripMenuItem1_Click);
            // 
            // fromVideoToolStripMenuItem1
            // 
            this.fromVideoToolStripMenuItem1.Name = "fromVideoToolStripMenuItem1";
            this.fromVideoToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.fromVideoToolStripMenuItem1.Text = "From &Video";
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsername.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUsername.Location = new System.Drawing.Point(12, 348);
            this.lblUsername.MaximumSize = new System.Drawing.Size(9000, 9000);
            this.lblUsername.MinimumSize = new System.Drawing.Size(10, 10);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(400, 31);
            this.lblUsername.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 388);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.imgCamUser);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Face Recognition";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private Emgu.CV.UI.ImageBox imgCamUser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recognizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromPictureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fromVideoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fromMultiPicturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTrainedDataToolStripMenuItem;
        private System.Windows.Forms.Label lblUsername;
    }
}

