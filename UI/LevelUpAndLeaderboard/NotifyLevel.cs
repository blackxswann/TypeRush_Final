using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeRush_Final.UI.LevelUpAndLeaderboard
{
    public partial class NotifyLevel : UserControl
    {
        private int currentMessageIndex = 0, newLevel; 
        private int charIndex = 0;
        private string levelName;
        private string[] messages = {
        "CONGRATULATIONS! YOU LEVELED UP!",
        $"LEVEL 1 - TYPIST" };


        public NotifyLevel(int newLevel, string levelName)
        {
            InitializeComponent();
            this.newLevel = newLevel;
            this.levelName = levelName; 
            lblCongrats.Text = "";
            lblLevel.Text = "";
            messages = new string[] {
                        "CONGRATULATIONS! YOU LEVELED UP!",
                $"LEVEL {newLevel} - {levelName}"};
                    
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
