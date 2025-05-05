using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Data.SqlClient; 

namespace TypeRush_Final
{
    public partial class StartingForm : BaseControl
    {
        private FormContainer formContainer;
        private List<Image> startingFormBG = new List<Image>(), startingFormBG2 = new List<Image>(), startingFormText = new List<Image>(), typedCorrectly = new List<Image>(), loadingText = new List<Image>();
        private bool isBGDone = false, textTimerStarted = false;
        private string targetWord = "start", userInput = "";
        private int frameIndex = 0, startTextIndex = 0, characterTypedCounter = 0, loadingTextIndex = 0;
        public StartingForm(FormContainer form)
        {
            InitializeComponent();
            formContainer = form;
            StoreResources();
            backgroundTimer.Start();
        }
        
        private void StoreResources()
        {
            for (int i = 1; i <= 5; i++)
                startingFormBG.Add((Bitmap)Properties.Resources.ResourceManager.GetObject($"StartingFormBG{i}"));
            for (int i = 6; i <= 9; i++)
                startingFormBG2.Add((Bitmap)Properties.Resources.ResourceManager.GetObject($"StartingFormBG{i}"));
            for (int i = 9; i >= 6; i--)
                startingFormBG2.Add((Bitmap)Properties.Resources.ResourceManager.GetObject($"StartingFormBG{i}"));
            for (int i = 1; i <= 12; i++)
                startingFormText.Add((Bitmap)Properties.Resources.ResourceManager.GetObject($"StartingFormText{i}"));
            for (int i = 13; i <= 17; i++)
                typedCorrectly.Add((Bitmap)Properties.Resources.ResourceManager.GetObject($"StartingFormText{i}"));
            for (int i = 18; i <= 21; i++)
                loadingText.Add((Bitmap)Properties.Resources.ResourceManager.GetObject($"StartingFormText{i}"));
        }

        private void backgroundTimer_Tick(object sender, EventArgs e)
        {
            if (!isBGDone)
            {
                pbxBackground.Image = startingFormBG[frameIndex];
                frameIndex++;

                if (frameIndex == startingFormBG.Count)
                {
                    isBGDone = true;
                    frameIndex = 0;
                }
            }
            else
            {
                pbxBackground.Image = startingFormBG2[frameIndex % startingFormBG2.Count];
                frameIndex++;
                if (!textTimerStarted)
                {
                    text.Visible = true;
                    textTimer.Start();
                    textTimerStarted = true;
                }
            }
        }

        private void textTimer_Tick(object sender, EventArgs e)
        {
            if (startTextIndex < startingFormText.Count)
            {
                text.Image = startingFormText[startTextIndex];
                startTextIndex++;
            }
            else
            {
                textTimer.Stop();
                startTextIndex = 0;
                text.Image = startingFormText.Last();
                blinkingCursor.BringToFront();
                blinkingCursor.Visible = true;
            }
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            text.Image = loadingText[loadingTextIndex % loadingText.Count];
            loadingTextIndex++;
            if (loadingTextIndex == 12)
            {
                loadingTimer.Stop();
                formContainer.LoadUserControlIntoPanel(new LandingForm(formContainer));
            }
        }

        private void StartingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                char keyPressed = char.ToLower(e.KeyCode.ToString()[0]);

                if (characterTypedCounter < targetWord.Length && keyPressed == targetWord[characterTypedCounter])
                {
                    userInput += keyPressed;
                    text.Image = typedCorrectly[characterTypedCounter];
                    characterTypedCounter++;

                    if (characterTypedCounter == targetWord.Length)
                    {
                        blinkingCursor.Visible = false;
                        loadingTimer.Start();
                    }
                }
                else
                {
                    text.Image = startingFormText.Last();
                    characterTypedCounter = 0;
                    userInput = "";
                   
                }
            }
        }

        
    }
}
