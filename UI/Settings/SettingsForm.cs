using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeRush_Final.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TypeRush_Final
{
    public partial class SettingsForm : BaseControl
    {
        private bool passwordShown = false;
        private bool isInitializing = false;
        private int currentAvatarIndex = -1;
        private List<Image> avatar = new List<Image>();
        public SettingsForm(FormContainer form)
        {
            InitializeComponent();
            showOrHideButtons(false);
            SetElements();
        }
        private void SetElements()
        {
            ActiveControl = pbxBackground;
            tbxPassword.PasswordChar = '•';
            btnResetPassword.MouseHover += Button_MouseHover;
            btnCancel.MouseHover += Button_MouseHover;
            btnSaveChanges.MouseHover += Button_MouseHover;
            btnChange.MouseHover += Button_MouseHover;
            btnResetPassword.MouseLeave += Button_MouseLeave;
            btnCancel.MouseLeave += Button_MouseLeave;
            btnSaveChanges.MouseLeave += Button_MouseLeave;
            btnChange.MouseLeave += Button_MouseLeave;
            btnDeleteAccount.MouseHover += Button_MouseHover;
            btnDeleteAccount.MouseLeave += Button_MouseLeave;
            tbxUsername.TextChanged += Textbox_Changed;
            tbxDisplayName.TextChanged += Textbox_Changed;
            tbxEmailAddress.TextChanged += Textbox_Changed;
            btnResetPassword.MouseClick += Button_MouseClick;
            btnCancel.MouseClick += Button_MouseClick;
            btnSaveChanges.MouseClick += Button_MouseClick;
            btnChange.MouseClick += Button_MouseClick;
            btnPassword.MouseClick += Button_MouseClick;
            btnPassword.MouseHover += Button_MouseHover;
            btnDeleteAccount.MouseClick += Button_MouseClick;
            btnNext.MouseClick += Button_MouseClick;
            btnPrevious.MouseClick += Button_MouseClick;
            pbxDisplayPicture.MouseClick += Button_MouseClick;

            avatar.Add((Bitmap)Properties.Resources.ResourceManager.GetObject("NULL_PROFILE"));
            avatar.Add((Bitmap)Properties.Resources.ResourceManager.GetObject("UploadYourOwn"));

            for (int i = 1; i <= 9; i++)
                avatar.Add((Bitmap)Properties.Resources.ResourceManager.GetObject($"Avatar{i}"));
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnResetPassword) btnResetPassword.BackgroundImage = Properties.Resources.S_H_BTNRESETPASSWORD;
                else if (btn == btnChange) btnChange.BackgroundImage = Properties.Resources.S_H_CHANGE;
                else if (btn == btnSaveChanges) btnSaveChanges.BackgroundImage = Properties.Resources.S_H_SAVECHANGES;
                else if (btn == btnCancel) btnCancel.BackgroundImage = Properties.Resources.S_H_CANCEL;
                else if (btn == btnDeleteAccount) btnDeleteAccount.BackgroundImage = Properties.Resources.S_H_DELETEACCOUNT;

            }
        }
        private void Textbox_Changed(object sender, EventArgs e)
        {
            if (isInitializing) return;
            RichTextBox rtbx = sender as RichTextBox;


            if (rtbx != null)
            {
                if (rtbx == tbxDisplayName || rtbx == tbxEmailAddress || tbxUsername == rtbx)
                {
                    showOrHideButtons(true);
                }


            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnResetPassword) btnResetPassword.BackgroundImage = Properties.Resources.S_NH_BTNRESETPASSWORD;
                else if (btn == btnChange) btnChange.BackgroundImage = Properties.Resources.S_NH_CHANGE;
                else if (btn == btnSaveChanges) btnSaveChanges.BackgroundImage = Properties.Resources.S_NH_SAVECHANGES;
                else if (btn == btnCancel) btnCancel.BackgroundImage = Properties.Resources.S_NH_CANCEL;
                else if (btn == btnDeleteAccount) btnDeleteAccount.BackgroundImage = Properties.Resources.S_NH_DELETEACCOUNT;
            }
        }
        private async void Button_MouseClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Panel pnl = sender as Panel;
            PictureBox pbx = sender as PictureBox;

            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnResetPassword)
                {
                    showOrHideButtons(true);
                    btnResetPassword.Visible = false;
                    pnlSettings.BackgroundImage = Properties.Resources.settingspnl2;
                    tbxPassword.Visible = true;
                    btnPassword.Visible = true;
                }
                else if (btn == btnChange)
                {
                    showOrHideButtons(true);
                }
                else if (btn == btnSaveChanges)
                {
                    DBUserInformation dbUser = new DBUserInformation();
                    dbUser.UserID = CurrentUser.UserID;

                    var result = await dbUser.UpdateUserInformation(tbxUsername.Text.Trim(), tbxDisplayName.Text.Trim(), tbxEmailAddress.Text.Trim(), currentAvatarIndex, pbxDisplayPicture);

                    if (result == AuthenticationError.successfulOperation)
                    {
                        MessageBox.Show("Changes saved successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to save changes.");
                    }
                    showOrHideButtons(false);

                }
                else if (btn == btnCancel)
                {
                    pnlSettings.BackgroundImage = Properties.Resources.settingspnl1;

                    tbxDisplayName.Text = CurrentUser.DisplayName;
                    tbxEmailAddress.Text = CurrentUser.EmailAddress;
                    tbxUsername.Text = CurrentUser.Username;
                    btnPassword.Visible = false;
                    tbxPassword.Visible = false;
                    btnResetPassword.Visible = true;

                    if (CurrentUser.AvatarIndex != -1)
                    {
                        switch (CurrentUser.AvatarIndex)
                        {
                            case 2:
                                pbxDisplayPicture.Image = Properties.Resources.Avatar1;
                                break;
                            case 3:
                                pbxDisplayPicture.Image = Properties.Resources.Avatar2;
                                break;
                            case 4:
                                pbxDisplayPicture.Image = Properties.Resources.Avatar3;
                                break;
                            case 5:
                                pbxDisplayPicture.Image = Properties.Resources.Avatar4;
                                break;
                            case 6:
                                pbxDisplayPicture.Image = Properties.Resources.Avatar5;
                                break;
                            case 7:
                                pbxDisplayPicture.Image = Properties.Resources.Avatar6;
                                break;
                            case 8:
                                pbxDisplayPicture.Image = Properties.Resources.Avatar7;
                                break;
                            case 9:
                                pbxDisplayPicture.Image = Properties.Resources.Avatar8;
                                break;
                            case 10:
                                pbxDisplayPicture.Image = Properties.Resources.Avatar9;
                                break;
                        }
                    }
                    else if (CurrentUser.DisplayPicturePath != "NO_PICTURE_UPLOADED" && File.Exists(CurrentUser.DisplayPicturePath))
                    {
                        pbxDisplayPicture.Image = Image.FromFile(CurrentUser.DisplayPicturePath);
                    }
                    else
                    {
                        pbxDisplayPicture.Image = Properties.Resources.NULL_PROFILE;
                    }

                    showOrHideButtons(false);
                }

                else if (btn == btnDeleteAccount)
                {
                    var confirmResult = MessageBox.Show("Are you sure you want to delete your account? This action cannot be undone.",
                                                        "Confirm Delete",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        DBUserInformation dbUser = new DBUserInformation();
                        dbUser.UserID = CurrentUser.UserID;

                        var result = await dbUser.DeleteAccount();

                        if (result == AuthenticationError.successfulOperation)
                        {
                            MessageBox.Show("Your account has been deleted successfully.");

                            Application.Restart();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete account. Please try again later.");
                        }
                    }
                }
                else if (btn == btnNext)
                {
                    ShiftAvatar("NEXT");
                }
                else if (btn == btnPrevious)
                {
                    ShiftAvatar("PREVIOUS");

                }

                else if (btn == btnPassword)
                {
                    passwordShown = !passwordShown;

                    if (passwordShown)
                    {
                        tbxPassword.PasswordChar = '\0';
                        btnPassword.BackgroundImage = Properties.Resources.RevealPassword;
                    }
                    else
                    {
                        tbxPassword.PasswordChar = '•';
                        btnPassword.BackgroundImage = Properties.Resources.HidePassword;
                    }
                }

            }
            else if (pbx != null)
            {
                pbx.Cursor = Cursors.Hand;
                if (pbx == pbxDisplayPicture)
                {
                    if (currentAvatarIndex == 1)
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                pbxDisplayPicture.Image = Image.FromFile(openFileDialog.FileName);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error loading image: " + ex.Message);
                            }
                        }
                    }
                    currentAvatarIndex = -1;
                }
            }

        }
        private void showOrHideButtons(bool showOrHide)
        {
            btnSaveChanges.Visible = showOrHide;
            btnCancel.Visible = showOrHide;
            btnNext.Visible = showOrHide;
            btnPrevious.Visible = showOrHide;

        }
        private void ShiftAvatar(string PreviousOrNext)
        {
            if (PreviousOrNext == "NEXT")
            {
                currentAvatarIndex++;
                if (currentAvatarIndex >= avatar.Count)
                    currentAvatarIndex = 0;
                pbxDisplayPicture.Image = avatar[currentAvatarIndex];
            }
            else if (PreviousOrNext == "PREVIOUS")
            {
                currentAvatarIndex--;
                if (currentAvatarIndex < 0)
                    currentAvatarIndex = avatar.Count - 1;
                pbxDisplayPicture.Image = avatar[currentAvatarIndex];

            }

        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            isInitializing = true;

            showOrHideButtons(false);
            tbxDisplayName.Text = CurrentUser.DisplayName;
            tbxEmailAddress.Text = CurrentUser.EmailAddress;
            tbxUsername.Text = CurrentUser.Username;


            isInitializing = false;
            if (CurrentUser.AvatarIndex != -1)
            {
                switch (CurrentUser.AvatarIndex)
                {
                    case 2:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar1;
                        break;
                    case 3:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar2;
                        break;
                    case 4:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar3;
                        break;
                    case 5:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar4;
                        break;
                    case 6:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar5;
                        break;
                    case 7:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar6;
                        break;
                    case 8:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar7;
                        break;
                    case 9:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar8;
                        break;
                    case 10:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar9;
                        break;
                }
            }
            else if (CurrentUser.DisplayPicturePath != "NO_PICTURE_UPLOADED" && File.Exists(CurrentUser.DisplayPicturePath))
            {
                using (var img = Image.FromFile(CurrentUser.DisplayPicturePath))
                {
                    pbxDisplayPicture.Image = new Bitmap(img);
                }

            }
            else
            {
                pbxDisplayPicture.Image = Properties.Resources.NULL_PROFILE;
            }
        }

    }
}
