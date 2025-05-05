using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeRush_Final
{
    public partial class TypingTestSelection : UserControl
    {
        private int chosenDuration = 0;
        private int difficultyCounter1 = 0, difficultyCounter2 = 0;
        private SubContainerForm subContainerForm;
        private string difficultyLevel = "easy";
        private FormContainer fcontainer; 
        public TypingTestSelection(FormContainer fcontainer, SubContainerForm form)
        {
            InitializeComponent();
            this.fcontainer = fcontainer; 
            subContainerForm = form; 
            SetElements(); 
            
        }
        public TypingTestSelection(SubContainerForm form)
        {
            InitializeComponent();
            subContainerForm = form; 
            SetElements();

        }

        private void SetElements()
        {
            btnSelectTest1.MouseClick += Button_MouseClick;
            btnSelectTest2.MouseClick += Button_MouseClick;
            btnSelectTest1.MouseHover += Button_MouseHover;
            btnSelectTest2.MouseHover += Button_MouseHover;
            btnSelectTest1.MouseLeave += Button_MouseLeave;
            btnSelectTest2.MouseLeave += Button_MouseLeave;
            btn10Sec.MouseClick += Button_MouseClick; 
            btn1Minute.MouseClick += Button_MouseClick;
            btn3Minutes.MouseClick += Button_MouseClick;
            btn5Minutes.MouseClick += Button_MouseClick;
            btnNext1.MouseClick += Button_MouseClick;
            btnNext2.MouseClick += Button_MouseClick;
            btnPrevious1.MouseClick += Button_MouseClick;
            btnPrevious2.MouseClick += Button_MouseClick;
            
        }

        private void Btn10Sec_MouseClick(object? sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button; 
            
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand; 

                if (btn == btnSelectTest1)
                {
                    btnSelectTest1.BackgroundImage = Properties.Resources.T_H_SELECTTEST; 
                }
                else if (btn == btnSelectTest2)
                {
                    btnSelectTest2.BackgroundImage = Properties.Resources.T_H_SELECTTEST;
                }

            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;

                if (btn == btnSelectTest1)
                {
                    btnSelectTest1.BackgroundImage = Properties.Resources.T_NH_SELECTTEST;
                }
                else if (btn == btnSelectTest2)
                {
                    btnSelectTest2.BackgroundImage = Properties.Resources.T_NH_SELECTTEST;
                }

            }
        }

        private void Button_MouseClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                SetButtonsToNeutral(); 
                if (btn == btn10Sec)
                {
                    btn10Sec.BackgroundImage = Properties.Resources.T_H_BUTTON;
                    chosenDuration = 10;

                }
                else if (btn == btn1Minute)
                {
                    btn1Minute.BackgroundImage = Properties.Resources.T_H_BUTTON;
                    chosenDuration = 60;

                }
                else if (btn == btn3Minutes)
                {
                    btn3Minutes.BackgroundImage = Properties.Resources.T_H_BUTTON;
                    chosenDuration = 180;

                }
                else if (btn == btn5Minutes)
                {
                    btn5Minutes.BackgroundImage = Properties.Resources.T_H_BUTTON;
                    chosenDuration = 300; 

                }
                else if (btn == btnNext1)
                {
                    difficultyCounter1++; 
                    if (difficultyCounter1 > 2)
                    {
                        difficultyCounter1 = 0; 
                    }
                    SetDifficultyLevel(true);
                }
                else if (btn == btnPrevious1)
                {
                    difficultyCounter1--;
                    if (difficultyCounter1 < 0)
                    {
                        difficultyCounter1 = 2; 
                    }
                    SetDifficultyLevel(true);
                }
                else if (btn == btnNext2)
                {
                    difficultyCounter2++;
                    if (difficultyCounter2 > 2)
                    {
                        difficultyCounter2 = 0;
                    }
                    SetDifficultyLevel(false);
                }
                else if (btn == btnPrevious2)
                {
                    difficultyCounter2--;
                    if (difficultyCounter2 < 0)
                    {
                        difficultyCounter2 = 2;
                    }
                    SetDifficultyLevel(false);
                }
                else if (btn == btnSelectTest1)
                {
                    if (difficultyCounter1 == 0) difficultyLevel = "easy";
                    else if (difficultyCounter1 == 1) difficultyLevel = "intermediate";
                    else difficultyLevel = "hard";

                    if (chosenDuration != 0)
                        subContainerForm.LoadUserControlIntoPanel(new TypingTest(subContainerForm, chosenDuration, difficultyLevel, CurrentUser.UserID));
                    else
                        MessageBox.Show("Please choose a duration first!"); 
                }
                else if (btn == btnSelectTest2)
                {
                    if (difficultyCounter1 == 0) difficultyLevel = "easy";
                    else if (difficultyCounter1 == 1) difficultyLevel = "intermediate";
                    else difficultyLevel = "hard";

                    subContainerForm.LoadUserControlIntoPanel(new TypingTest(subContainerForm, 0, difficultyLevel,CurrentUser.UserID));
                }
            }
        }

        private void SetButtonsToNeutral()
        {
            btn10Sec.BackgroundImage = btn1Minute.BackgroundImage = btn3Minutes.BackgroundImage = btn5Minutes.BackgroundImage = Properties.Resources.T_NH_BUTTON;
        }
        private void SetDifficultyLevel(bool timedOrNot)
        {
            if (difficultyCounter1 == 0 && timedOrNot) pbxSelection1.Image = Properties.Resources.easySelection;
            else if (difficultyCounter1 == 1 && timedOrNot) pbxSelection1.Image = Properties.Resources.intermediateSelection;
            else if (difficultyCounter1 == 2 && timedOrNot) pbxSelection1.Image = Properties.Resources.hardSelection;

            if (difficultyCounter2 == 0 && !timedOrNot) pbxSelection2.Image = Properties.Resources.easySelection;
            else if (difficultyCounter2 == 1 && !timedOrNot) pbxSelection2.Image = Properties.Resources.intermediateSelection;
            else if (difficultyCounter2 == 2 && !timedOrNot) pbxSelection2.Image = Properties.Resources.hardSelection;
        }
    }
}
