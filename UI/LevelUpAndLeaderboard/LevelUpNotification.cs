using Microsoft.Identity.Client;
using System;
using System.Windows.Forms;

namespace TypeRush_Final.UI.AchievementsAndLeaderboard
{
    public partial class LevelUpNotification : Form
    {
        private string[] messages = {
        "CONGRATULATIONS! YOU LEVELED UP!",
        $"LEVEL  - TYPIST"
        };

        private int currentMessageIndex = 0;
        private int charIndex = 0;
        

        public LevelUpNotification(int newLevel, string levelName)
        {
            InitializeComponent();
            lblCongrats.Text = "";
            lblLevel.Text = ""; 

            timer.Interval = 50;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (currentMessageIndex == 0)
            {
                if (charIndex < messages[0].Length)
                {
                    lblCongrats.Text += messages[0][charIndex];
                    charIndex++;
                }
                else
                {
                    currentMessageIndex = 1;
                    charIndex = 0;
                }
            }
            else if (currentMessageIndex == 1)
            {
                if (charIndex < messages[1].Length)
                {
                    lblLevel.Text += messages[1][charIndex];
                    charIndex++;
                }
                else
                {
                    timer.Stop();
                }
            }
        }
    }

}