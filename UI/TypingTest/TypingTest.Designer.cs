namespace TypeRush_Final
{
    partial class TypingTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypingTest));
            lblTimer = new Label();
            rtbxOutput = new RichTextBox();
            timer = new System.Windows.Forms.Timer(components);
            btnGoBack = new Button();
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = Color.FromArgb(251, 209, 236);
            lblTimer.Font = new Font("monogram", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.ForeColor = Color.DimGray;
            lblTimer.Location = new Point(1065, 384);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(151, 63);
            lblTimer.TabIndex = 8;
            lblTimer.Text = "3:00";
            // 
            // rtbxOutput
            // 
            rtbxOutput.BackColor = Color.FromArgb(242, 239, 235);
            rtbxOutput.Font = new Font("monogram", 30F, FontStyle.Bold);
            rtbxOutput.ForeColor = Color.DimGray;
            rtbxOutput.Location = new Point(235, 244);
            rtbxOutput.Name = "rtbxOutput";
            rtbxOutput.ReadOnly = true;
            rtbxOutput.Size = new Size(713, 585);
            rtbxOutput.TabIndex = 9;
            rtbxOutput.Text = "Hello world";
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // btnGoBack
            // 
            btnGoBack.BackgroundImage = Properties.Resources.t_nh_back2;
            btnGoBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnGoBack.FlatAppearance.BorderSize = 0;
            btnGoBack.FlatStyle = FlatStyle.Flat;
            btnGoBack.Location = new Point(1040, 682);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(176, 48);
            btnGoBack.TabIndex = 17;
            btnGoBack.UseVisualStyleBackColor = true;
            btnGoBack.Click += btnGoBack_Click;
            // 
            // TypingTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(btnGoBack);
            Controls.Add(rtbxOutput);
            Controls.Add(lblTimer);
            DoubleBuffered = true;
            Name = "TypingTest";
            Size = new Size(1543, 991);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTimer;
        private RichTextBox rtbxOutput;
        private System.Windows.Forms.Timer timer;
        private Button btnGoBack;
    }
}
