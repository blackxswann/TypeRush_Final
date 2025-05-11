using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Input;
using RandomGenerator;
using CrypticWizard.RandomWordGenerator;
using TypeRush_Final.Data;
namespace TypeRush_Final.UI.Minigame
{
    public partial class WordBlast : BaseControl
    {

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        System.Media.SoundPlayer player2 = new System.Media.SoundPlayer();

        int currentPosition;
        int counter, counter2 = 0;
        int previousY;
        private int score; 
        private PictureBox activeBeam = null;
        private Dictionary<PictureBox, int> asteroidSpeeds = new Dictionary<PictureBox, int>();
        private Dictionary<PictureBox, bool> asteroidAlive = new Dictionary<PictureBox, bool>();
        private Dictionary<PictureBox, int> originalYPositions = new Dictionary<PictureBox, int>();
        System.Windows.Forms.Timer respawnTimer = new System.Windows.Forms.Timer();

        private WordGenerator wordGenerator = new WordGenerator();

        private bool isGameOver = false;
        private SubContainerForm form; 
        public WordBlast(SubContainerForm form)
        {
            InitializeComponent();
            this.form = form; 
            player2.SoundLocation = "shoot.wav";
            
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;

            this.SetStyle(ControlStyles.UserMouse, true);
            this.SetStyle(ControlStyles.UseTextForAccessibility, false);

            rtbx1.SelectAll();
            rtbx1.SelectionAlignment = HorizontalAlignment.Center;
            rtbx1.DeselectAll();
            rtbx2.SelectAll();
            rtbx2.SelectionAlignment = HorizontalAlignment.Center;
            rtbx2.DeselectAll();
            rtbx3.SelectAll();
            rtbx3.SelectionAlignment = HorizontalAlignment.Center;
            rtbx3.DeselectAll();
            rtbx4.SelectAll();
            rtbx4.SelectionAlignment = HorizontalAlignment.Center;
            rtbx4.DeselectAll();
            rtbx5.SelectAll();
            rtbx5.SelectionAlignment = HorizontalAlignment.Center;
            rtbx5.DeselectAll();
            rtbx6.SelectAll();
            rtbx6.SelectionAlignment = HorizontalAlignment.Center;
            rtbx6.DeselectAll();
            rtbx7.SelectAll();
            rtbx7.SelectionAlignment = HorizontalAlignment.Center;
            rtbx7.DeselectAll();


            asteroidFallTimer.Start();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            for (int i = 1; i <= 7; i++)
            {
                string controlName = "rtbx" + i;
                RichTextBox rtb = this.Controls.Find(controlName, true).FirstOrDefault() as RichTextBox;

                if (rtb != null)
                {
                    rtb.ReadOnly = true;           
                    rtb.TabStop = false;          
                    rtb.Enabled = true;            
                    rtb.GotFocus += Rtb_GotFocus;  

                    rtb.Text = GenerateRandomWord();
                }
            }

            this.Focus();
        }

        private string GenerateRandomWord()
        {
            Random random = new Random();

            WordGenerator.PartOfSpeech[] parts = new[]
            {
                WordGenerator.PartOfSpeech.adv,
                WordGenerator.PartOfSpeech.noun,
                WordGenerator.PartOfSpeech.art
            };

            var randomPart = parts[random.Next(parts.Length)];

            return wordGenerator.GetWord(randomPart);
        }


        private void Rtb_GotFocus(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void WordBlast_Load(object sender, EventArgs e)
        {
            this.Focus();
            Random rand = new Random();
            asteroidSpeeds[asteroid1] = rand.Next(2, 6);
            asteroidSpeeds[asteroid2] = rand.Next(2, 6);
            asteroidSpeeds[asteroid3] = rand.Next(2, 6);
            asteroidSpeeds[asteroid4] = rand.Next(2, 6);
            asteroidSpeeds[asteroid5] = rand.Next(2, 6);
            asteroidSpeeds[asteroid6] = rand.Next(2, 6);
            asteroidSpeeds[asteroid7] = rand.Next(2, 6);

            asteroidAlive[asteroid1] = true;
            asteroidAlive[asteroid2] = true;
            asteroidAlive[asteroid3] = true;
            asteroidAlive[asteroid4] = true;
            asteroidAlive[asteroid5] = true;
            asteroidAlive[asteroid6] = true;
            asteroidAlive[asteroid7] = true;

            originalYPositions[asteroid1] = asteroid1.Top;
            originalYPositions[asteroid2] = asteroid2.Top;
            originalYPositions[asteroid3] = asteroid3.Top;
            originalYPositions[asteroid4] = asteroid4.Top;
            originalYPositions[asteroid5] = asteroid5.Top;
            originalYPositions[asteroid6] = asteroid6.Top;
            originalYPositions[asteroid7] = asteroid7.Top;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right)
                return true;
            return base.IsInputKey(keyData);
        }

        private void WordBlast_KeyDown(object sender, KeyEventArgs e)
        {
            if (isGameOver) return;

            this.Focus();

            if (e.KeyCode == Keys.Left)
            {
                ResetWords();
                Move("LEFT");
                return;
            }
            else if (e.KeyCode == Keys.Right)
            {
                ResetWords();
                Move("RIGHT"); 
                return;
            }
            CompareText(e.KeyCode);
            e.SuppressKeyPress = true;
        }

        private void Move(string direction)
        {
            ResetAllWordColors();
            if (direction == "LEFT")
            {
                if (pbxShip.Location.X == 1424) pbxShip.Location = new Point(1204, pbxShip.Location.Y);
                else if (pbxShip.Location.X == 1204) pbxShip.Location = new Point(984, pbxShip.Location.Y);
                else if (pbxShip.Location.X == 984) pbxShip.Location = new Point(756, pbxShip.Location.Y);
                else if (pbxShip.Location.X == 756) pbxShip.Location = new Point(536, pbxShip.Location.Y);
                else if (pbxShip.Location.X == 536) pbxShip.Location = new Point(306, pbxShip.Location.Y);
                else if (pbxShip.Location.X == 306) pbxShip.Location = new Point(70, pbxShip.Location.Y);
            }
            else
            {
                if (pbxShip.Location.X == 70) pbxShip.Location = new Point(306, pbxShip.Location.Y);
                else if (pbxShip.Location.X == 306) pbxShip.Location = new Point(536, pbxShip.Location.Y);
                else if (pbxShip.Location.X == 536) pbxShip.Location = new Point(756, pbxShip.Location.Y);
                else if (pbxShip.Location.X == 756) pbxShip.Location = new Point(984, pbxShip.Location.Y);
                else if (pbxShip.Location.X == 984) pbxShip.Location = new Point(1204, pbxShip.Location.Y);
                else if (pbxShip.Location.X == 1204) pbxShip.Location = new Point(1424, pbxShip.Location.Y);
            }
        }

        private void CompareText(Keys character)
        {
            char typedChar = KeyToChar(character);
            if (typedChar == '\0') return;

            RichTextBox currentRtb = null;

            if (pbxShip.Location.X == 70)
                currentRtb = rtbx1;
            else if (pbxShip.Location.X == 306)
                currentRtb = rtbx2;
            else if (pbxShip.Location.X == 536)
                currentRtb = rtbx3;
            else if (pbxShip.Location.X == 756)
                currentRtb = rtbx4;
            else if (pbxShip.Location.X == 984)
                currentRtb = rtbx5;
            else if (pbxShip.Location.X == 1204)
                currentRtb = rtbx6;
            else if (pbxShip.Location.X == 1424)
                currentRtb = rtbx7;

            if (currentRtb != null && !string.IsNullOrEmpty(currentRtb.Text))
            {
                string targetText = currentRtb.Text.Trim();

                if (counter < targetText.Length)
                {
                    char expectedChar = targetText[counter];

                    if (typedChar == expectedChar)
                    {
                        currentRtb.Select(counter, 1);
                        currentRtb.SelectionColor = Color.Green;
                        counter++;

                        if (counter >= targetText.Length)
                        {
                            score += 100;
                            lbLScore.Text = "Score: " + score.ToString();
                            player2.Play();
                            asteroidTimer.Start();
                        }
                    }
                    else
                    {
                        currentRtb.SelectAll();
                        currentRtb.SelectionColor = Color.White;
                        counter = 0;
                    }
                }
            }
        }

        private void ResetWords()
        {
            counter = 0;
        }

        private void ResetAllWordColors()
        {
            for (int i = 1; i <= 7; i++)
            {
                string controlName = "rtbx" + i;
                RichTextBox rtb = this.Controls.Find(controlName, true).FirstOrDefault() as RichTextBox;

                if (rtb != null)
                {
                    rtb.SelectAll();
                    rtb.SelectionColor = Color.White;
                    rtb.DeselectAll();
                }
            }
        }

        private char KeyToChar(Keys key)
        {
            if (key >= Keys.A && key <= Keys.Z)
                return key.ToString().ToLower()[0];
            return '\0';
        }


        private void asteroidTimer_Tick(object sender, EventArgs e)
        {
            asteroidTimer.Stop();
            RichTextBox currentRtb = null;
            PictureBox beamToUse = null;

            if (pbxShip.Location.X == 70)
            {
                currentRtb = rtbx1;
                beamToUse = beam1;
            }
            else if (pbxShip.Location.X == 306)
            {
                currentRtb = rtbx2;
                beamToUse = beam2;
            }
            else if (pbxShip.Location.X == 536)
            {
                currentRtb = rtbx3;
                beamToUse = beam3;
            }
            else if (pbxShip.Location.X == 756)
            {
                currentRtb = rtbx4;
                beamToUse = beam4;
            }
            else if (pbxShip.Location.X == 984)
            {
                currentRtb = rtbx5;
                beamToUse = beam5;
            }
            else if (pbxShip.Location.X == 1204)
            {
                currentRtb = rtbx6;
                beamToUse = beam6;
            }
            else if (pbxShip.Location.X == 1424)
            {
                currentRtb = rtbx7;
                beamToUse = beam7;
            }

            if (currentRtb != null)
            {
                int shipXCenter = pbxShip.Location.X + pbxShip.Width / 2 - beam1.Width / 2;
                int beamStartY = pbxShip.Location.Y;
                int beamEndY = currentRtb.Location.Y + currentRtb.Height / 2;

                int beamHeight = beamStartY - beamEndY;

                beamToUse.Location = new Point(shipXCenter, beamEndY);
                beamToUse.Height = beamHeight;
                beamToUse.Visible = true;

                activeBeam = beamToUse;

                beam.Start();

                PictureBox asteroid = GetAsteroidByBeam(beamToUse);
                if (asteroid != null && asteroidAlive[asteroid])
                {
                    asteroid.Visible = false;
                    currentRtb.Visible = false;
                    asteroidAlive[asteroid] = false;

                    System.Windows.Forms.Timer specificRespawnTimer = new System.Windows.Forms.Timer();
                    specificRespawnTimer.Interval = 2000; 
                    specificRespawnTimer.Tick += (s, args) =>
                    {
                        specificRespawnTimer.Stop();
                        if (!isGameOver)
                        {
                            currentRtb.Text = GenerateRandomWord();

                            asteroid.Top = originalYPositions[asteroid];
                            currentRtb.Top = asteroid.Bottom + 5;
                            asteroid.Visible = true;
                            currentRtb.Visible = true;
                            asteroidAlive[asteroid] = true;

                            currentRtb.SelectAll();
                            currentRtb.SelectionColor = Color.White;
                            currentRtb.DeselectAll();
                        }
                        specificRespawnTimer.Dispose();
                    };
                    specificRespawnTimer.Start();
                }
            }
        }

        private void beam_Tick(object sender, EventArgs e)
        {
            if (activeBeam != null)
            {
                activeBeam.Visible = false;
                activeBeam = null;
            }
            beam.Stop();
        }

        private PictureBox GetAsteroidByBeam(PictureBox beam)
        {
            if (beam == beam1) return asteroid1;
            if (beam == beam2) return asteroid2;
            if (beam == beam3) return asteroid3;
            if (beam == beam4) return asteroid4;
            if (beam == beam5) return asteroid5;
            if (beam == beam6) return asteroid6;
            if (beam == beam7) return asteroid7;
            return null;
        }

        void asteroidFallTimer_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            MoveAsteroidDown(asteroid1, rtbx1, asteroidSpeeds[asteroid1]);
            MoveAsteroidDown(asteroid2, rtbx2, asteroidSpeeds[asteroid2]);
            MoveAsteroidDown(asteroid3, rtbx3, asteroidSpeeds[asteroid3]);
            MoveAsteroidDown(asteroid4, rtbx4, asteroidSpeeds[asteroid4]);
            MoveAsteroidDown(asteroid5, rtbx5, asteroidSpeeds[asteroid5]);
            MoveAsteroidDown(asteroid6, rtbx6, asteroidSpeeds[asteroid6]);
            MoveAsteroidDown(asteroid7, rtbx7, asteroidSpeeds[asteroid7]);
        }
        private async void MoveAsteroidDown(PictureBox asteroid, RichTextBox textbox, int speed)
        {
            if (!asteroidAlive[asteroid]) return;

            asteroid.Top += speed;
            textbox.Top = asteroid.Bottom + 5;

            if (textbox.Top >= 773 && !isGameOver)
            {
                isGameOver = true;
                asteroidFallTimer.Stop();

                bool success = await DBMinigameSession.SaveGameSession(
                    CurrentUser.UserID,  
                    score                
                );

                if (!success)
                {
                    MessageBox.Show("There was an issue saving your game progress.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                int xpGained = (int)(score * 0.1); 

                MessageBox.Show($"Game Over!\nScore: {score}\nXP Gained: {xpGained}",
                    "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
        }
       
    }
}