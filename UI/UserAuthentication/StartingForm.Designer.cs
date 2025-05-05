namespace TypeRush_Final
{
    partial class StartingForm
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
            pbxBackground = new PictureBox();
            backgroundTimer = new System.Windows.Forms.Timer(components);
            text = new PictureBox();
            blinkingCursor = new PictureBox();
            textTimer = new System.Windows.Forms.Timer(components);
            loadingTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)text).BeginInit();
            ((System.ComponentModel.ISupportInitialize)blinkingCursor).BeginInit();
            SuspendLayout();
            // 
            // pbxBackground
            // 
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.StartingFormBG1;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(1920, 991);
            pbxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxBackground.TabIndex = 0;
            pbxBackground.TabStop = false;
            // 
            // backgroundTimer
            // 
            backgroundTimer.Interval = 120;
            backgroundTimer.Tick += backgroundTimer_Tick;
            // 
            // text
            // 
            text.Image = Properties.Resources.StartingFormText1;
            text.Location = new Point(815, 763);
            text.Name = "text";
            text.Size = new Size(326, 77);
            text.SizeMode = PictureBoxSizeMode.StretchImage;
            text.TabIndex = 1;
            text.TabStop = false;
            text.Visible = false;
            // 
            // blinkingCursor
            // 
            blinkingCursor.BackColor = Color.FromArgb(147, 123, 156);
            blinkingCursor.Image = Properties.Resources.blinkingCursor;
            blinkingCursor.Location = new Point(1111, 770);
            blinkingCursor.Name = "blinkingCursor";
            blinkingCursor.Size = new Size(30, 65);
            blinkingCursor.SizeMode = PictureBoxSizeMode.StretchImage;
            blinkingCursor.TabIndex = 2;
            blinkingCursor.TabStop = false;
            blinkingCursor.Visible = false;
            // 
            // textTimer
            // 
            textTimer.Interval = 200;
            textTimer.Tick += textTimer_Tick;
            // 
            // loadingTimer
            // 
            loadingTimer.Interval = 300;
            loadingTimer.Tick += loadingTimer_Tick;
            // 
            // StartingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(blinkingCursor);
            Controls.Add(text);
            Controls.Add(pbxBackground);
            DoubleBuffered = true;
            Name = "StartingForm";
            Size = new Size(1920, 991);
            KeyDown += StartingForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)text).EndInit();
            ((System.ComponentModel.ISupportInitialize)blinkingCursor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxBackground;
        private System.Windows.Forms.Timer backgroundTimer;
        private PictureBox text;
        private PictureBox blinkingCursor;
        private System.Windows.Forms.Timer textTimer;
        private System.Windows.Forms.Timer loadingTimer;
    }
}
