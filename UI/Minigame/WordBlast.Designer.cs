namespace TypeRush_Final.UI.Minigame
{
    partial class WordBlast
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            rtbx1 = new RichTextBox();
            pbxShip = new PictureBox();
            boundary = new PictureBox();
            beam4 = new PictureBox();
            asteroid1 = new PictureBox();
            asteroid2 = new PictureBox();
            asteroid3 = new PictureBox();
            asteroid4 = new PictureBox();
            asteroid5 = new PictureBox();
            asteroid6 = new PictureBox();
            asteroid7 = new PictureBox();
            rtbx2 = new RichTextBox();
            rtbx3 = new RichTextBox();
            rtbx4 = new RichTextBox();
            rtbx5 = new RichTextBox();
            rtbx6 = new RichTextBox();
            rtbx7 = new RichTextBox();
            beam3 = new PictureBox();
            beam2 = new PictureBox();
            beam1 = new PictureBox();
            beam5 = new PictureBox();
            beam6 = new PictureBox();
            beam7 = new PictureBox();
            asteroidTimer = new System.Windows.Forms.Timer(components);
            beam = new System.Windows.Forms.Timer(components);
            asteroidFallTimer = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            lbLScore = new Label();
            ((System.ComponentModel.ISupportInitialize)pbxShip).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boundary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beam4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beam3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beam2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beam1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beam5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beam6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beam7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // rtbx1
            // 
            rtbx1.BackColor = SystemColors.Desktop;
            rtbx1.BorderStyle = BorderStyle.None;
            rtbx1.Font = new Font("monogram", 22F, FontStyle.Bold);
            rtbx1.ForeColor = SystemColors.MenuBar;
            rtbx1.Location = new Point(0, 14);
            rtbx1.Name = "rtbx1";
            rtbx1.ReadOnly = true;
            rtbx1.Size = new Size(214, 34);
            rtbx1.TabIndex = 19;
            rtbx1.TabStop = false;
            rtbx1.Text = "testing";
            // 
            // pbxShip
            // 
            pbxShip.BackColor = Color.Transparent;
            pbxShip.Image = Properties.Resources.ship;
            pbxShip.Location = new Point(756, 789);
            pbxShip.Name = "pbxShip";
            pbxShip.Size = new Size(79, 182);
            pbxShip.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxShip.TabIndex = 23;
            pbxShip.TabStop = false;
            // 
            // boundary
            // 
            boundary.BackColor = SystemColors.ButtonHighlight;
            boundary.Location = new Point(0, 773);
            boundary.Name = "boundary";
            boundary.Size = new Size(1540, 10);
            boundary.TabIndex = 24;
            boundary.TabStop = false;
            // 
            // beam4
            // 
            beam4.BackColor = Color.Khaki;
            beam4.Location = new Point(789, 192);
            beam4.Name = "beam4";
            beam4.Size = new Size(16, 605);
            beam4.TabIndex = 25;
            beam4.TabStop = false;
            beam4.Visible = false;
            // 
            // asteroid1
            // 
            asteroid1.BackColor = Color.Transparent;
            asteroid1.Image = Properties.Resources.ASTEROIDVERYFINAL;
            asteroid1.Location = new Point(34, -150);
            asteroid1.Name = "asteroid1";
            asteroid1.Size = new Size(158, 158);
            asteroid1.SizeMode = PictureBoxSizeMode.StretchImage;
            asteroid1.TabIndex = 26;
            asteroid1.TabStop = false;
            // 
            // asteroid2
            // 
            asteroid2.BackColor = Color.Transparent;
            asteroid2.Image = Properties.Resources.ASTEROIDVERYFINAL;
            asteroid2.Location = new Point(261, -150);
            asteroid2.Name = "asteroid2";
            asteroid2.Size = new Size(158, 158);
            asteroid2.SizeMode = PictureBoxSizeMode.StretchImage;
            asteroid2.TabIndex = 27;
            asteroid2.TabStop = false;
            // 
            // asteroid3
            // 
            asteroid3.BackColor = Color.Transparent;
            asteroid3.Image = Properties.Resources.ASTEROIDVERYFINAL;
            asteroid3.Location = new Point(493, -150);
            asteroid3.Name = "asteroid3";
            asteroid3.Size = new Size(158, 158);
            asteroid3.SizeMode = PictureBoxSizeMode.StretchImage;
            asteroid3.TabIndex = 28;
            asteroid3.TabStop = false;
            // 
            // asteroid4
            // 
            asteroid4.BackColor = Color.Transparent;
            asteroid4.Image = Properties.Resources.ASTEROIDVERYFINAL;
            asteroid4.Location = new Point(713, -150);
            asteroid4.Name = "asteroid4";
            asteroid4.Size = new Size(158, 158);
            asteroid4.SizeMode = PictureBoxSizeMode.StretchImage;
            asteroid4.TabIndex = 29;
            asteroid4.TabStop = false;
            // 
            // asteroid5
            // 
            asteroid5.BackColor = Color.Transparent;
            asteroid5.Image = Properties.Resources.ASTEROIDVERYFINAL;
            asteroid5.Location = new Point(943, -150);
            asteroid5.Name = "asteroid5";
            asteroid5.Size = new Size(158, 158);
            asteroid5.SizeMode = PictureBoxSizeMode.StretchImage;
            asteroid5.TabIndex = 30;
            asteroid5.TabStop = false;
            // 
            // asteroid6
            // 
            asteroid6.BackColor = Color.Transparent;
            asteroid6.Image = Properties.Resources.ASTEROIDVERYFINAL;
            asteroid6.Location = new Point(1161, -150);
            asteroid6.Name = "asteroid6";
            asteroid6.Size = new Size(158, 158);
            asteroid6.SizeMode = PictureBoxSizeMode.StretchImage;
            asteroid6.TabIndex = 31;
            asteroid6.TabStop = false;
            // 
            // asteroid7
            // 
            asteroid7.BackColor = Color.Transparent;
            asteroid7.Image = Properties.Resources.ASTEROIDVERYFINAL;
            asteroid7.Location = new Point(1373, -150);
            asteroid7.Name = "asteroid7";
            asteroid7.Size = new Size(158, 158);
            asteroid7.SizeMode = PictureBoxSizeMode.StretchImage;
            asteroid7.TabIndex = 32;
            asteroid7.TabStop = false;
            // 
            // rtbx2
            // 
            rtbx2.BackColor = SystemColors.InactiveCaptionText;
            rtbx2.BorderStyle = BorderStyle.None;
            rtbx2.Font = new Font("monogram", 22F, FontStyle.Bold);
            rtbx2.ForeColor = SystemColors.MenuBar;
            rtbx2.Location = new Point(220, 14);
            rtbx2.Name = "rtbx2";
            rtbx2.ReadOnly = true;
            rtbx2.Size = new Size(226, 34);
            rtbx2.TabIndex = 33;
            rtbx2.TabStop = false;
            rtbx2.Text = "testing";
            // 
            // rtbx3
            // 
            rtbx3.BackColor = SystemColors.InactiveCaptionText;
            rtbx3.BorderStyle = BorderStyle.None;
            rtbx3.Font = new Font("monogram", 22F, FontStyle.Bold);
            rtbx3.ForeColor = SystemColors.MenuBar;
            rtbx3.Location = new Point(452, 14);
            rtbx3.Name = "rtbx3";
            rtbx3.ReadOnly = true;
            rtbx3.Size = new Size(219, 34);
            rtbx3.TabIndex = 34;
            rtbx3.TabStop = false;
            rtbx3.Text = "testing";
            // 
            // rtbx4
            // 
            rtbx4.BackColor = SystemColors.InactiveCaptionText;
            rtbx4.BorderStyle = BorderStyle.None;
            rtbx4.Font = new Font("monogram", 22F, FontStyle.Bold);
            rtbx4.ForeColor = SystemColors.MenuBar;
            rtbx4.Location = new Point(677, 14);
            rtbx4.Name = "rtbx4";
            rtbx4.ReadOnly = true;
            rtbx4.Size = new Size(219, 34);
            rtbx4.TabIndex = 35;
            rtbx4.TabStop = false;
            rtbx4.Text = "testing";
            // 
            // rtbx5
            // 
            rtbx5.BackColor = SystemColors.InactiveCaptionText;
            rtbx5.BorderStyle = BorderStyle.None;
            rtbx5.Font = new Font("monogram", 22F, FontStyle.Bold);
            rtbx5.ForeColor = SystemColors.MenuBar;
            rtbx5.Location = new Point(902, 14);
            rtbx5.Name = "rtbx5";
            rtbx5.ReadOnly = true;
            rtbx5.Size = new Size(219, 34);
            rtbx5.TabIndex = 36;
            rtbx5.TabStop = false;
            rtbx5.Text = "testing";
            // 
            // rtbx6
            // 
            rtbx6.BackColor = SystemColors.InactiveCaptionText;
            rtbx6.BorderStyle = BorderStyle.None;
            rtbx6.Font = new Font("monogram", 22F, FontStyle.Bold);
            rtbx6.ForeColor = SystemColors.MenuBar;
            rtbx6.Location = new Point(1127, 14);
            rtbx6.Name = "rtbx6";
            rtbx6.ReadOnly = true;
            rtbx6.Size = new Size(213, 34);
            rtbx6.TabIndex = 37;
            rtbx6.TabStop = false;
            rtbx6.Text = "testing";
            // 
            // rtbx7
            // 
            rtbx7.BackColor = SystemColors.InactiveCaptionText;
            rtbx7.BorderStyle = BorderStyle.None;
            rtbx7.Font = new Font("monogram", 22F, FontStyle.Bold);
            rtbx7.ForeColor = SystemColors.MenuBar;
            rtbx7.Location = new Point(1346, 14);
            rtbx7.Name = "rtbx7";
            rtbx7.ReadOnly = true;
            rtbx7.Size = new Size(197, 34);
            rtbx7.TabIndex = 38;
            rtbx7.TabStop = false;
            rtbx7.Text = "testing";
            // 
            // beam3
            // 
            beam3.BackColor = Color.Khaki;
            beam3.Location = new Point(569, 160);
            beam3.Name = "beam3";
            beam3.Size = new Size(14, 637);
            beam3.TabIndex = 39;
            beam3.TabStop = false;
            beam3.Visible = false;
            // 
            // beam2
            // 
            beam2.BackColor = Color.Khaki;
            beam2.Location = new Point(336, 222);
            beam2.Name = "beam2";
            beam2.Size = new Size(14, 575);
            beam2.TabIndex = 40;
            beam2.TabStop = false;
            beam2.Visible = false;
            // 
            // beam1
            // 
            beam1.BackColor = Color.Khaki;
            beam1.Location = new Point(102, 175);
            beam1.Name = "beam1";
            beam1.Size = new Size(15, 622);
            beam1.TabIndex = 41;
            beam1.TabStop = false;
            beam1.Visible = false;
            // 
            // beam5
            // 
            beam5.BackColor = Color.Khaki;
            beam5.Location = new Point(1015, 192);
            beam5.Name = "beam5";
            beam5.Size = new Size(17, 605);
            beam5.TabIndex = 42;
            beam5.TabStop = false;
            beam5.Visible = false;
            // 
            // beam6
            // 
            beam6.BackColor = Color.Khaki;
            beam6.Location = new Point(1235, 192);
            beam6.Name = "beam6";
            beam6.Size = new Size(14, 605);
            beam6.TabIndex = 43;
            beam6.TabStop = false;
            beam6.Visible = false;
            // 
            // beam7
            // 
            beam7.BackColor = Color.Khaki;
            beam7.Location = new Point(1454, 192);
            beam7.Name = "beam7";
            beam7.Size = new Size(13, 605);
            beam7.TabIndex = 44;
            beam7.TabStop = false;
            beam7.Visible = false;
            // 
            // asteroidTimer
            // 
            asteroidTimer.Tick += asteroidTimer_Tick;
            // 
            // beam
            // 
            beam.Interval = 50;
            beam.Tick += beam_Tick;
            // 
            // asteroidFallTimer
            // 
            asteroidFallTimer.Tick += asteroidFallTimer_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(224, 187, 210);
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1543, 48);
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            // 
            // lbLScore
            // 
            lbLScore.AutoSize = true;
            lbLScore.BackColor = Color.FromArgb(240, 210, 229);
            lbLScore.Font = new Font("monogram", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLScore.Location = new Point(3, 11);
            lbLScore.Name = "lbLScore";
            lbLScore.Size = new Size(94, 23);
            lbLScore.TabIndex = 47;
            lbLScore.Text = "SCORE: ";
            // 
            // WordBlast
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.finalBG;
            BackgroundImageLayout = ImageLayout.None;
            Controls.Add(lbLScore);
            Controls.Add(pictureBox1);
            Controls.Add(beam7);
            Controls.Add(beam6);
            Controls.Add(beam5);
            Controls.Add(beam1);
            Controls.Add(beam2);
            Controls.Add(beam3);
            Controls.Add(rtbx7);
            Controls.Add(rtbx6);
            Controls.Add(rtbx5);
            Controls.Add(rtbx4);
            Controls.Add(rtbx3);
            Controls.Add(rtbx2);
            Controls.Add(asteroid7);
            Controls.Add(asteroid6);
            Controls.Add(asteroid5);
            Controls.Add(asteroid4);
            Controls.Add(asteroid3);
            Controls.Add(asteroid2);
            Controls.Add(asteroid1);
            Controls.Add(beam4);
            Controls.Add(boundary);
            Controls.Add(pbxShip);
            Controls.Add(rtbx1);
            DoubleBuffered = true;
            Name = "WordBlast";
            Size = new Size(1543, 991);
            Load += WordBlast_Load;
            KeyDown += WordBlast_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pbxShip).EndInit();
            ((System.ComponentModel.ISupportInitialize)boundary).EndInit();
            ((System.ComponentModel.ISupportInitialize)beam4).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid2).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid3).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid4).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid5).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid6).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid7).EndInit();
            ((System.ComponentModel.ISupportInitialize)beam3).EndInit();
            ((System.ComponentModel.ISupportInitialize)beam2).EndInit();
            ((System.ComponentModel.ISupportInitialize)beam1).EndInit();
            ((System.ComponentModel.ISupportInitialize)beam5).EndInit();
            ((System.ComponentModel.ISupportInitialize)beam6).EndInit();
            ((System.ComponentModel.ISupportInitialize)beam7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox rtbx1;
        private PictureBox pbxShip;
        private PictureBox boundary;
        private PictureBox beam4;
        private PictureBox asteroid1;
        private PictureBox asteroid2;
        private PictureBox asteroid3;
        private PictureBox asteroid4;
        private PictureBox asteroid5;
        private PictureBox asteroid6;
        private PictureBox asteroid7;
        private RichTextBox rtbx2;
        private RichTextBox rtbx3;
        private RichTextBox rtbx4;
        private RichTextBox rtbx5;
        private RichTextBox rtbx6;
        private RichTextBox rtbx7;
        private PictureBox beam3;
        private PictureBox beam2;
        private PictureBox beam1;
        private PictureBox beam5;
        private PictureBox beam6;
        private PictureBox beam7;
        private System.Windows.Forms.Timer asteroidTimer;
        private System.Windows.Forms.Timer beam;
        private System.Windows.Forms.Timer asteroidFallTimer;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lbLScore;
    }
}
