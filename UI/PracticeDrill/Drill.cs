using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TypeRush_Final.Data;
using Microsoft.VisualBasic.ApplicationServices;

namespace TypeRush_Final
{
    public partial class Drill : UserControl
    {
        private bool spacePressed = false;
        private int categoryID;
        private List<string> chosenDrill;
        private int drillExerciseID;

        private int correctTypedCharacters = 0;
        private int totalTypedCharacters = 0;
        private TypingPerformanceCalculator performanceCalculator;
        private DateTime startTime;
        private DateTime endTime;
        private int durationSeconds = 0;
        private FormContainer fcontainer;  
        private SubContainerForm subContainerForm;

        private System.Media.SoundPlayer typing = new System.Media.SoundPlayer();

        public Drill(FormContainer fcontainer, int categoryID, int drillExerciseID, SubContainerForm form)
        {
            InitializeComponent();
            typing.SoundLocation = "typing.wav"; 
            this.categoryID = categoryID;
            this.drillExerciseID = drillExerciseID;
            this.fcontainer = fcontainer; 
            subContainerForm = form; 
            SetElements();
            FetchPracticeDrill();
            this.Focus();
            startTime = DateTime.Now;
            UpdateKeyboardAndGuideBasedOnCursor();
        }

        private void SetElements()
        {
            this.TabStop = true;
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(Drill_PreviewKeyDown);
            rtbxOutput.ReadOnly = true;
            rtbxOutput.SelectionStart = 0;
            rtbxOutput.KeyDown += RTBX_KeyDown;
        }

        private void Drill_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }
        private void RTBX_KeyDown(object sender, KeyEventArgs e)
        {
            typing.Play();
            int cursorPos = rtbxOutput.SelectionStart;
            
            if (cursorPos == rtbxOutput.Text.Length)
            {
                endTime = DateTime.Now;
                durationSeconds = (int)(endTime - startTime).TotalSeconds;
                SaveAndShowPerformance();
                return;
            }

            if (spacePressed)
            {
                if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }

                if (e.KeyCode == Keys.Space)
                {
                    cursorPos = rtbxOutput.SelectionStart;
                    rtbxOutput.SelectionStart = cursorPos + 1;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    UpdateKeyboardAndGuideBasedOnCursor();
                    return;
                }
            }

            if (cursorPos < rtbxOutput.TextLength)
            {
                char expectedChar = rtbxOutput.Text[cursorPos];

                bool matchFound = false;

                if (IsMatchingKeyForSymbol(e.KeyCode, e.Shift, expectedChar))
                {
                    matchFound = true;
                }
                else if (e.KeyCode.ToString().Length == 1)
                {
                    char enteredChar = e.KeyCode.ToString()[0];
                    matchFound = (char.ToLower(enteredChar) == char.ToLower(expectedChar));
                }

                if (matchFound)
                {
                    rtbxOutput.SelectionStart = cursorPos;
                    rtbxOutput.SelectionLength = 1;
                    rtbxOutput.SelectionColor = System.Drawing.Color.Green;
                    correctTypedCharacters++;
                    rtbxOutput.SelectionStart = cursorPos + 1;
                    totalTypedCharacters++;
                }
                else
                {
                    rtbxOutput.SelectionStart = cursorPos;
                    rtbxOutput.SelectionLength = 1;
                    rtbxOutput.SelectionColor = System.Drawing.Color.White;
                    rtbxOutput.SelectionStart = cursorPos;
                    totalTypedCharacters++;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Space)
            {
                spacePressed = true;
                e.Handled = true;
                e.SuppressKeyPress = true;
                UpdateKeyboardAndGuideBasedOnCursor();
                return;
            }
        }

        private bool IsMatchingKeyForSymbol(Keys keyCode, bool shift, char expectedChar)
        {
            switch (expectedChar)
            {
                case '.':
                    return keyCode == Keys.OemPeriod && !shift;
                case ',':
                    return keyCode == Keys.Oemcomma && !shift;
                case '/':
                    return keyCode == Keys.OemQuestion && !shift;
                case '?':
                    return keyCode == Keys.OemQuestion && shift;
                case ';':
                    return keyCode == Keys.OemSemicolon && !shift;
                case ':':
                    return keyCode == Keys.OemSemicolon && shift;
                case '\'':
                    return keyCode == Keys.OemQuotes && !shift;
                case '"':
                    return keyCode == Keys.OemQuotes && shift;
                case '[':
                    return keyCode == Keys.OemOpenBrackets && !shift;
                case '{':
                    return keyCode == Keys.OemOpenBrackets && shift;
                case ']':
                    return keyCode == Keys.OemCloseBrackets && !shift;
                case '}':
                    return keyCode == Keys.OemCloseBrackets && shift;
                case '\\':
                    return keyCode == Keys.OemBackslash && !shift;
                case '|':
                    return keyCode == Keys.OemBackslash && shift;
                case '-':
                    return keyCode == Keys.OemMinus && !shift;
                case '_':
                    return keyCode == Keys.OemMinus && shift;
                case '=':
                    return keyCode == Keys.Oemplus && !shift;
                case '+':
                    return keyCode == Keys.Oemplus && shift;
                case '`':
                    return keyCode == Keys.Oemtilde && !shift;
                case '~':
                    return keyCode == Keys.Oemtilde && shift;
                case '1':
                    return keyCode == Keys.D1 && !shift;
                case '!':
                    return keyCode == Keys.D1 && shift;
                case '2':
                    return keyCode == Keys.D2 && !shift;
                case '@':
                    return keyCode == Keys.D2 && shift;
                case '3':
                    return keyCode == Keys.D3 && !shift;
                case '#':
                    return keyCode == Keys.D3 && shift;
                case '4':
                    return keyCode == Keys.D4 && !shift;
                case '$':
                    return keyCode == Keys.D4 && shift;
                case '5':
                    return keyCode == Keys.D5 && !shift;
                case '%':
                    return keyCode == Keys.D5 && shift;
                case '6':
                    return keyCode == Keys.D6 && !shift;
                case '^':
                    return keyCode == Keys.D6 && shift;
                case '7':
                    return keyCode == Keys.D7 && !shift;
                case '&':
                    return keyCode == Keys.D7 && shift;
                case '8':
                    return keyCode == Keys.D8 && !shift;
                case '*':
                    return keyCode == Keys.D8 && shift;
                case '9':
                    return keyCode == Keys.D9 && !shift;
                case '(':
                    return keyCode == Keys.D9 && shift;
                case '0':
                    return keyCode == Keys.D0 && !shift;
                case ')':
                    return keyCode == Keys.D0 && shift;
                default:
                    return false;
            }
        }
        private void SaveAndShowPerformance()
        {
            DBPracticeDrill dbHandler = new DBPracticeDrill();

            int wpm;
            int accuracy;
            int starsGained;
            int xpGained;

            dbHandler.CalculateAndSavePerformance(
                CurrentUser.UserID,
                drillExerciseID,
                durationSeconds,
                correctTypedCharacters,
                totalTypedCharacters,
                out wpm,
                out accuracy,
                out starsGained,
                out xpGained
            );


            subContainerForm.LoadUserControlIntoPanel(new DrilLResult(fcontainer, wpm, accuracy, starsGained, xpGained, subContainerForm)); 

        }

        private double CalculateWPM()
        {
            double totalTimeInMinutes = 60;
            double wpm = (totalTypedCharacters / 5) / totalTimeInMinutes;
            return wpm;
        }

        private double CalculateAccuracy()
        {
            double accuracy = ((double)correctTypedCharacters / totalTypedCharacters) * 100;
            return accuracy;
        }

        private void FetchPracticeDrill()
        {
            DBPracticeDrill dbHandler = new DBPracticeDrill();
            chosenDrill = dbHandler.FetchPracticeWords(categoryID, drillExerciseID);

            if (chosenDrill != null && chosenDrill.Count > 0)
            {
                rtbxOutput.Clear();

                string wordsJoined = string.Join(" ", chosenDrill);

                rtbxOutput.AppendText(wordsJoined);
                rtbxOutput.SelectionStart = 0;
                rtbxOutput.SelectionLength = 0;
                rtbxOutput.SelectionColor = System.Drawing.Color.Black;
            }
            else
            {
                rtbxOutput.AppendText("No words found for this drill category.");
            }
        }

        private void Drill_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void UpdateKeyboardAndGuideBasedOnCursor()
        {
            int cursorPos = rtbxOutput.SelectionStart;

            if (cursorPos < rtbxOutput.TextLength)
            {
                char currentChar = rtbxOutput.Text[cursorPos];

                UpdateKeyPressImages(currentChar);
            }
        }

        private void UpdateKeyPressImages(char currentChar)
        {
            string leftFingerResource = "";
            string rightFingerResource = "";

            leftHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("L_NEUTRAL");
            rightHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("R_NEUTRAL");

            switch (char.ToLower(currentChar))
            {
                case 'f':
                case 'g':
                case 'r':
                case 't':
                case 'v':
                case 'b':
                case '4':
                case '$':
                    leftFingerResource = "L_POINTING";
                    leftHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(leftFingerResource);
                    break;
                case 'd':
                case 'e':
                case 'c':
                case '3':
                case '#':
                    leftFingerResource = "L_MIDDLE";
                    leftHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(leftFingerResource);
                    break;
                case 's':
                case 'w':
                case 'x':
                case '2':
                case '@':
                    leftFingerResource = "L_RING";
                    leftHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(leftFingerResource);
                    break;
                case 'a':
                case 'z':
                case 'q':
                case '`':
                case '~':
                    leftFingerResource = "L_PINKY";
                    leftHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(leftFingerResource);
                    break;
                case ' ':
                    leftFingerResource = "L_THUMB";
                    leftHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(leftFingerResource);
                    rightFingerResource = "R_THUMB";
                    rightHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(rightFingerResource);
                    break;
                case 'j':
                case 'h':
                case 'u':
                case 'y':
                case 'n':
                case 'm':
                    rightFingerResource = "R_POINTING";
                    rightHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(rightFingerResource);
                    break;
                case 'k':
                case 'i':
                case ',':
                    rightFingerResource = "R_MIDDLE";
                    rightHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(rightFingerResource);
                    break;
                case 'l':
                case '.':
                case 'o':

                    rightFingerResource = "R_RING";
                    rightHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(rightFingerResource);
                    break;
                case ';':
                case ':':
                case 'p':
                case '/':
                case '?':
                case '\'':
                case '"':
                case '[':
                case ']':
                case '{':
                case '}':
                case '\\':
                case '|':
                case '-':
                case '_':
                case '=':
                case '+':
                case '0':
                case '9':
                case '8':
                case '7':
                case '6':
                    rightFingerResource = "R_PINKY";
                    rightHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(rightFingerResource);
                    break;
                default:
                    leftHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("L_NEUTRAL");
                    rightHandGuide.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("R_NEUTRAL");
                    break;
            }

            string resourceName;
            switch (currentChar)
            {
                case ' ':
                    resourceName = "keyboard_SPACE";
                    break;
                case '.':
                    resourceName = "keyboard_period";
                    break;
                case ',':
                    resourceName = "keyboard_comma";
                    break;
                case '/':
                    resourceName = "keyboard_slash";
                    break;
                case '\\':
                    resourceName = "keyboard_BKSP";
                    break;
                case ';':
                    resourceName = "keyboard_semicolon";
                    break;
                case '\'':
                    resourceName = "keyboard_qmark";
                    break;
                case '[':
                    resourceName = "keyboard_openbracket";
                    break;
                case ']':
                    resourceName = "keyboard_closebracket";
                    break;
                case '-':
                    resourceName = "keyboard_underscore";
                    break;
                case '=':
                    resourceName = "keyboard_plus";
                    break;
                case '`':
                    resourceName = "keyboard_tilde";
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    resourceName = "keyboard_" + currentChar;
                    break;
                default:
                    resourceName = "keyboard_" + currentChar.ToString().ToUpper();
                    break;
            }

            var image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourceName);

            if (image != null)
            {
                keyboard.Image = image;
            }
        }

        private void rtbxOutput_SelectionChanged(object sender, EventArgs e)
        {
            UpdateKeyboardAndGuideBasedOnCursor();
        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }
    }


}



