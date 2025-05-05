namespace TypeRush_Final
{
    partial class Drill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Drill));
            keyboard = new PictureBox();
            leftHandGuide = new PictureBox();
            rightHandGuide = new PictureBox();
            rtbxOutput = new RichTextBox();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)keyboard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leftHandGuide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightHandGuide).BeginInit();
            SuspendLayout();
            // 
            // keyboard
            // 
            keyboard.BackColor = Color.Transparent;
            keyboard.Image = (Image)resources.GetObject("keyboard.Image");
            keyboard.Location = new Point(292, 603);
            keyboard.Name = "keyboard";
            keyboard.Size = new Size(959, 361);
            keyboard.SizeMode = PictureBoxSizeMode.StretchImage;
            keyboard.TabIndex = 2;
            keyboard.TabStop = false;
            // 
            // leftHandGuide
            // 
            leftHandGuide.BackColor = Color.Transparent;
            leftHandGuide.Image = Properties.Resources.L_NEUTRAL;
            leftHandGuide.Location = new Point(0, 639);
            leftHandGuide.Name = "leftHandGuide";
            leftHandGuide.Size = new Size(286, 352);
            leftHandGuide.SizeMode = PictureBoxSizeMode.StretchImage;
            leftHandGuide.TabIndex = 3;
            leftHandGuide.TabStop = false;
            // 
            // rightHandGuide
            // 
            rightHandGuide.BackColor = Color.Transparent;
            rightHandGuide.Image = Properties.Resources.R_NEUTRAL;
            rightHandGuide.Location = new Point(1257, 639);
            rightHandGuide.Name = "rightHandGuide";
            rightHandGuide.Size = new Size(286, 352);
            rightHandGuide.SizeMode = PictureBoxSizeMode.StretchImage;
            rightHandGuide.TabIndex = 5;
            rightHandGuide.TabStop = false;
            // 
            // rtbxOutput
            // 
            rtbxOutput.BackColor = SystemColors.ActiveCaptionText;
            rtbxOutput.BorderStyle = BorderStyle.None;
            rtbxOutput.Font = new Font("monogram", 30F, FontStyle.Bold);
            rtbxOutput.ForeColor = SystemColors.Info;
            rtbxOutput.Location = new Point(237, 227);
            rtbxOutput.Name = "rtbxOutput";
            rtbxOutput.ReadOnly = true;
            rtbxOutput.Size = new Size(1069, 312);
            rtbxOutput.TabIndex = 7;
            rtbxOutput.Text = "Testing lord";
            rtbxOutput.SelectionChanged += rtbxOutput_SelectionChanged;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // Drill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.PDRILL_DRILLBG;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(rtbxOutput);
            Controls.Add(rightHandGuide);
            Controls.Add(leftHandGuide);
            Controls.Add(keyboard);
            DoubleBuffered = true;
            Name = "Drill";
            Size = new Size(1543, 991);
            ((System.ComponentModel.ISupportInitialize)keyboard).EndInit();
            ((System.ComponentModel.ISupportInitialize)leftHandGuide).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightHandGuide).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox keyboard;
        private PictureBox leftHandGuide;
        private PictureBox rightHandGuide;
        private RichTextBox rtbxOutput;
        private System.Windows.Forms.Timer timer;
    }
}
