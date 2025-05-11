using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RandomGenerator;
using TypeRush_Final.Data;
using TypeRush_Final.UI.TypingTest;
using Bogus;
using System.Media;

namespace TypeRush_Final
{
    public partial class TypingTest : BaseControl
    {
        private bool spacePressed = false;
        private int correctTypedCharacters;
        private int totalTypedCharacters;
        private int totalWords;
        private List<string> linesList = new List<string>();
        private TimeSpan remainingTime;
        private string difficultyLevel;
        private Dictionary<char, int> mistypedCharacters = new Dictionary<char, int>();
        private bool isTimerStarted = false;
        private DateTime startTime;
        private int userID;
        private string testMode;
        private bool isUntimedMode = false;
        private Button btnFinishTest;
        private SubContainerForm form;
        public TypingTest(SubContainerForm form, int duration, string difficultyLevel, int userID)
        {
            InitializeComponent();
            rtbxOutput.KeyDown += RTBX_KeyDown;
            this.difficultyLevel = difficultyLevel;
            this.userID = userID;
            this.form = form;
            FetchRandomWordsAndDisplay(difficultyLevel);
            SetDuration(duration);
            rtbxOutput.Focus();

            if (duration == 0)
            {
                lblTimer.Visible = false;
                testMode = "untimed";
                isUntimedMode = true;

                btnFinishTest = new Button();
                btnFinishTest.Text = "Finish Test";
                btnFinishTest.Size = new Size(100, 30);
                btnFinishTest.Location = new Point(lblTimer.Location.X, lblTimer.Location.Y);
                btnFinishTest.Click += BtnFinishTest_Click;
                this.Controls.Add(btnFinishTest);
            }
            else
            {
                testMode = "timed";
                isUntimedMode = false;
            }
        }

        private void BtnFinishTest_Click(object sender, EventArgs e)
        {
            if (isUntimedMode)
            {
                isTimerStarted = false;
                CalculateMetrics();
            }
        }

        private void SetDuration(int duration)
        {
            switch (duration)
            {
                case 10:
                    remainingTime = TimeSpan.FromSeconds(10);
                    break;
                case 60:
                    remainingTime = TimeSpan.FromMinutes(1);
                    break;
                case 180:
                    remainingTime = TimeSpan.FromMinutes(3);
                    break;
                case 300:
                    remainingTime = TimeSpan.FromMinutes(5);
                    break;
                default:
                    remainingTime = TimeSpan.Zero;
                    break;
            }

            lblTimer.Text = remainingTime.ToString(@"mm\:ss");
        }

        private void FetchRandomWordsAndDisplay(string difficultyLevel)
        {
            var faker = new Bogus.Faker();
            int totalWords, minLength, maxLength;
            bool useCommonWords = false;

            switch (difficultyLevel)
            {
                case "easy":
                    totalWords = 50;
                    minLength = 3;
                    maxLength = 5;
                    useCommonWords = true;
                    break;
                case "intermediate":
                    totalWords = 100;
                    minLength = 5;
                    maxLength = 8;
                    break;
                case "hard":
                    totalWords = 200;
                    minLength = 7;
                    maxLength = 15;
                    break;
                default:
                    throw new ArgumentException("Invalid difficulty level");
            }

            var words = new List<string>();
            while (words.Count < totalWords)
            {
                string word = GenerateWord(faker, useCommonWords);
                if (word.Length >= minLength && word.Length <= maxLength)
                    words.Add(word);
            }

            string text = InsertPunctuation(words, difficultyLevel);
            rtbxOutput.Text = text;
        }

        private string GenerateWord(Faker faker, bool useCommonWords)
        {
            if (useCommonWords)
            {
                return faker.PickRandom(new Func<string>[] {
            () => faker.Lorem.Word(),
            () => faker.Commerce.ProductAdjective(),
            () => faker.Commerce.Color()
        }).Invoke();
            }
            return faker.PickRandom(new Func<string>[] {
        () => faker.Lorem.Word(),
        () => faker.Hacker.Noun(),
        () => faker.Hacker.Verb(),
        () => faker.Commerce.ProductMaterial()
    }).Invoke();
        }

        private string InsertPunctuation(List<string> words, string difficultyLevel)
        {
            var rnd = new Random();
            var punctuated = new List<string>();
            char[] sentenceEnders = { '.', '?', '!' };
            char[] midSentencePunct = { ',', ';', ':' };

            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];

                if (difficultyLevel != "Easy")
                {
                    if (i > 0 && i < words.Count - 1 && rnd.Next(0, 20) == 0)
                    {
                        word += sentenceEnders[rnd.Next(0, 3)];
                        if (i + 1 < words.Count)
                            words[i + 1] = CapitalizeFirst(words[i + 1]);
                    }
                    else if (difficultyLevel == "Hard" && rnd.Next(0, 15) == 0)
                    {
                        word += midSentencePunct[rnd.Next(0, 3)];
                    }
                }

                if (difficultyLevel == "Hard" && rnd.Next(0, 30) == 0)
                {
                    if (word.Length > 2)
                        word = word.Insert(rnd.Next(1, word.Length - 1), "'");
                }

                punctuated.Add(word);
            }

            if (!punctuated.Last().EndsWith(".") && !punctuated.Last().EndsWith("?"))
                punctuated[punctuated.Count - 1] += ".";

            return string.Join(" ", punctuated);
        }

        private string CapitalizeFirst(string word)
        {
            if (string.IsNullOrEmpty(word))
                return word;
            return char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }

        private void RTBX_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isTimerStarted)
            {
                isTimerStarted = true;
                startTime = DateTime.Now;
                if (!isUntimedMode)
                {
                    timer.Start();
                }
            }

            int cursorPos = rtbxOutput.SelectionStart;

            if (cursorPos < rtbxOutput.Text.Length)
            {
                char expectedChar = rtbxOutput.Text[cursorPos];
                char? enteredChar = null;

                if (e.KeyCode == Keys.Space)
                {
                    enteredChar = ' ';
                }
                else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                {
                    enteredChar = e.KeyCode.ToString()[0];
                }
                else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                {
                    enteredChar = e.KeyCode.ToString()[1];
                }
                else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                {
                    enteredChar = (char)('0' + (e.KeyCode - Keys.NumPad0));
                }
                else
                {
                    switch (e.KeyCode)
                    {
                        case Keys.OemMinus:
                            enteredChar = e.Shift ? '_' : '-';
                            break;
                        case Keys.Oemplus:
                            enteredChar = e.Shift ? '+' : '=';
                            break;
                        case Keys.OemOpenBrackets:
                            enteredChar = e.Shift ? '{' : '[';
                            break;
                        case Keys.OemCloseBrackets:
                            enteredChar = e.Shift ? '}' : ']';
                            break;
                        case Keys.OemPipe:
                            enteredChar = e.Shift ? '|' : '\\';
                            break;
                        case Keys.OemSemicolon:
                            enteredChar = e.Shift ? ':' : ';';
                            break;
                        case Keys.OemQuotes:
                            enteredChar = e.Shift ? '"' : '\'';
                            break;
                        case Keys.Oemcomma:
                            enteredChar = e.Shift ? '<' : ',';
                            break;
                        case Keys.OemPeriod:
                            enteredChar = e.Shift ? '>' : '.';
                            break;
                        case Keys.OemQuestion:
                            enteredChar = e.Shift ? '?' : '/';
                            break;
                        case Keys.Oemtilde:
                            enteredChar = e.Shift ? '~' : '`';
                            break;
                        case Keys.D1:
                            enteredChar = e.Shift ? '!' : '1';
                            break;
                        case Keys.D2:
                            enteredChar = e.Shift ? '@' : '2';
                            break;
                        case Keys.D3:
                            enteredChar = e.Shift ? '#' : '3';
                            break;
                        case Keys.D4:
                            enteredChar = e.Shift ? '$' : '4';
                            break;
                        case Keys.D5:
                            enteredChar = e.Shift ? '%' : '5';
                            break;
                        case Keys.D6:
                            enteredChar = e.Shift ? '^' : '6';
                            break;
                        case Keys.D7:
                            enteredChar = e.Shift ? '&' : '7';
                            break;
                        case Keys.D8:
                            enteredChar = e.Shift ? '*' : '8';
                            break;
                        case Keys.D9:
                            enteredChar = e.Shift ? '(' : '9';
                            break;
                        case Keys.D0:
                            enteredChar = e.Shift ? ')' : '0';
                            break;
                    }
                }

                if (enteredChar.HasValue)
                {
                    if (char.ToLower(enteredChar.Value) == char.ToLower(expectedChar))
                    {
                        rtbxOutput.SelectionStart = cursorPos;
                        rtbxOutput.SelectionLength = 1;
                        rtbxOutput.SelectionColor = Color.Green;
                        correctTypedCharacters++;
                    }
                    else
                    {
                        if (mistypedCharacters.ContainsKey(expectedChar))
                        {
                            mistypedCharacters[expectedChar]++;
                        }
                        else
                        {
                            mistypedCharacters[expectedChar] = 1;
                        }

                        rtbxOutput.SelectionStart = cursorPos;
                        rtbxOutput.SelectionLength = 1;
                        rtbxOutput.SelectionColor = Color.Red;
                    }

                    rtbxOutput.SelectionStart = cursorPos + 1;
                    totalTypedCharacters++;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

            if (cursorPos == rtbxOutput.Text.Length)
            {
                totalWords++;

                FetchRandomWordsAndDisplay(difficultyLevel);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (remainingTime.TotalSeconds > 0)
            {
                remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                lblTimer.Text = remainingTime.ToString(@"mm\:ss");
            }
            else
            {
                timer.Stop();
                CalculateMetrics();
            }
        }

        private void CalculateMetrics()
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;

            if (elapsedTime.TotalMinutes > 0)
            {
                DBTypingTest dbTypingTest = new DBTypingTest();

                int wpm = 0;
                int accuracy = 0;

                if (elapsedTime.TotalMinutes > 0)
                {
                    wpm = (int)Math.Round((correctTypedCharacters / 5.0) / elapsedTime.TotalMinutes);
                    accuracy = totalTypedCharacters > 0 ? (int)Math.Round((double)correctTypedCharacters / totalTypedCharacters * 100) : 0;
                }

                dbTypingTest.SaveTypingTestResults(
                    userID,
                    testMode,
                    difficultyLevel,
                    (int)elapsedTime.TotalSeconds,
                    correctTypedCharacters,
                    totalTypedCharacters,
                    elapsedTime,
                    mistypedCharacters
                );

                form.LoadUserControlIntoPanel(new TypingTestResult(
                    form,
                    userID,
                    wpm,
                    accuracy,
                    elapsedTime,
                    mistypedCharacters,
                    testMode,
                    difficultyLevel
                ));
            }
            else
            {
                MessageBox.Show("Error: Time elapsed is too short to calculate WPM.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            form.LoadUserControlIntoPanel(new TypingTestSelection(form));
        }
    }
}

