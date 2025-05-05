namespace TypeRush_Final
{
    partial class ConfirmationCodeForm
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
            panel = new PictureBox();
            btnVerify = new Button();
            btnBack = new Button();
            tbx1 = new TextBox();
            tbx2 = new TextBox();
            tbx3 = new TextBox();
            tbx4 = new TextBox();
            tbx5 = new TextBox();
            timer = new System.Windows.Forms.Timer(components);
            pbxLoadingBar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxLoadingBar).BeginInit();
            SuspendLayout();
            // 
            // pbxBackground
            // 
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.LogInSignUpBG;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(1920, 991);
            pbxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxBackground.TabIndex = 0;
            pbxBackground.TabStop = false;
            // 
            // panel
            // 
            panel.BackColor = Color.Transparent;
            panel.Image = Properties.Resources.EmailVerificationPanel1;
            panel.Location = new Point(507, 255);
            panel.Name = "panel";
            panel.Size = new Size(904, 486);
            panel.SizeMode = PictureBoxSizeMode.Zoom;
            panel.TabIndex = 1;
            panel.TabStop = false;
            // 
            // btnVerify
            // 
            btnVerify.BackgroundImage = Properties.Resources.V_NH_VERIFY;
            btnVerify.BackgroundImageLayout = ImageLayout.Stretch;
            btnVerify.FlatAppearance.BorderSize = 0;
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.Location = new Point(669, 610);
            btnVerify.Margin = new Padding(0);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(240, 52);
            btnVerify.TabIndex = 18;
            btnVerify.TabStop = false;
            btnVerify.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackgroundImage = Properties.Resources.V_NH_BACK;
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Location = new Point(1006, 610);
            btnBack.Margin = new Padding(0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(240, 52);
            btnBack.TabIndex = 19;
            btnBack.TabStop = false;
            btnBack.UseVisualStyleBackColor = false;
            // 
            // tbx1
            // 
            tbx1.BackColor = Color.FromArgb(242, 187, 221);
            tbx1.BorderStyle = BorderStyle.None;
            tbx1.Font = new Font("Vaticanus", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbx1.ForeColor = Color.Gray;
            tbx1.Location = new Point(625, 458);
            tbx1.Name = "tbx1";
            tbx1.Size = new Size(50, 60);
            tbx1.TabIndex = 20;
            tbx1.TextAlign = HorizontalAlignment.Center;
            // 
            // tbx2
            // 
            tbx2.BackColor = Color.FromArgb(242, 187, 221);
            tbx2.BorderStyle = BorderStyle.None;
            tbx2.Font = new Font("Vaticanus", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbx2.ForeColor = Color.Gray;
            tbx2.Location = new Point(780, 458);
            tbx2.Name = "tbx2";
            tbx2.Size = new Size(50, 60);
            tbx2.TabIndex = 21;
            tbx2.TextAlign = HorizontalAlignment.Center;
            // 
            // tbx3
            // 
            tbx3.BackColor = Color.FromArgb(242, 187, 221);
            tbx3.BorderStyle = BorderStyle.None;
            tbx3.Font = new Font("Vaticanus", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbx3.ForeColor = Color.Gray;
            tbx3.Location = new Point(935, 458);
            tbx3.Name = "tbx3";
            tbx3.Size = new Size(50, 60);
            tbx3.TabIndex = 22;
            tbx3.TextAlign = HorizontalAlignment.Center;
            // 
            // tbx4
            // 
            tbx4.BackColor = Color.FromArgb(242, 187, 221);
            tbx4.BorderStyle = BorderStyle.None;
            tbx4.Font = new Font("Vaticanus", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbx4.ForeColor = Color.Gray;
            tbx4.Location = new Point(1091, 458);
            tbx4.Name = "tbx4";
            tbx4.Size = new Size(50, 60);
            tbx4.TabIndex = 23;
            tbx4.TextAlign = HorizontalAlignment.Center;
            // 
            // tbx5
            // 
            tbx5.BackColor = Color.FromArgb(242, 187, 221);
            tbx5.BorderStyle = BorderStyle.None;
            tbx5.Font = new Font("Vaticanus", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbx5.ForeColor = Color.Gray;
            tbx5.Location = new Point(1245, 458);
            tbx5.Name = "tbx5";
            tbx5.Size = new Size(50, 60);
            tbx5.TabIndex = 24;
            tbx5.TabStop = false;
            tbx5.TextAlign = HorizontalAlignment.Center;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // pbxLoadingBar
            // 
            pbxLoadingBar.BackColor = Color.Transparent;
            pbxLoadingBar.Image = Properties.Resources.loadGIF;
            pbxLoadingBar.Location = new Point(933, 548);
            pbxLoadingBar.Name = "pbxLoadingBar";
            pbxLoadingBar.Size = new Size(48, 47);
            pbxLoadingBar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxLoadingBar.TabIndex = 26;
            pbxLoadingBar.TabStop = false;
            // 
            // ConfirmationCodeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbx5);
            Controls.Add(tbx4);
            Controls.Add(tbx3);
            Controls.Add(tbx2);
            Controls.Add(tbx1);
            Controls.Add(btnBack);
            Controls.Add(btnVerify);
            Controls.Add(panel);
            Controls.Add(pbxLoadingBar);
            Controls.Add(pbxBackground);
            DoubleBuffered = true;
            Name = "ConfirmationCodeForm";
            Size = new Size(1920, 991);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)panel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxLoadingBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxBackground;
        private PictureBox panel;
        private Button btnVerify;
        private Button btnBack;
        private TextBox tbx1;
        private TextBox tbx2;
        private TextBox tbx3;
        private TextBox tbx4;
        private TextBox tbx5;
        private System.Windows.Forms.Timer timer;
        private PictureBox pbxLoadingBar;
    }
}
