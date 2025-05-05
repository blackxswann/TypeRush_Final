namespace TypeRush_Final.UI.Minigame
{
    partial class WordBlastStart
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
            pbxBG = new PictureBox();
            lblPlay = new Label();
            ((System.ComponentModel.ISupportInitialize)pbxBG).BeginInit();
            SuspendLayout();
            // 
            // pbxBG
            // 
            pbxBG.Dock = DockStyle.Fill;
            pbxBG.Image = Properties.Resources.wordBlast1;
            pbxBG.Location = new Point(0, 0);
            pbxBG.Name = "pbxBG";
            pbxBG.Size = new Size(1543, 991);
            pbxBG.TabIndex = 0;
            pbxBG.TabStop = false;
            // 
            // lblPlay
            // 
            lblPlay.AutoSize = true;
            lblPlay.BackColor = Color.Transparent;
            lblPlay.Font = new Font("Vaticanus", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlay.ForeColor = Color.Thistle;
            lblPlay.Location = new Point(638, 533);
            lblPlay.Name = "lblPlay";
            lblPlay.Size = new Size(230, 37);
            lblPlay.TabIndex = 2;
            lblPlay.Text = "START GAME";
            lblPlay.Click += lblPlay_Click;
            lblPlay.MouseLeave += lblPlay_MouseLeave;
            lblPlay.MouseHover += lblPlay_MouseHover;
            // 
            // WordBlastStart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPlay);
            Controls.Add(pbxBG);
            Name = "WordBlastStart";
            Size = new Size(1543, 991);
            ((System.ComponentModel.ISupportInitialize)pbxBG).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxBG;
        private Label lblPlay;
    }
}
