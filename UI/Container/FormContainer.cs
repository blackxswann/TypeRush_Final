namespace TypeRush_Final
{
    public partial class FormContainer : Form
    {
        public FormContainer()
        {
            InitializeComponent();
            LoadUserControlIntoPanel(new LogInForm(this));
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }
        public void LoadUserControlIntoPanel(UserControl form)
        {
            pnlContainer.SuspendLayout();
            pnlContainer.Visible = false;
            pnlContainer.Controls.Clear();
            form.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(form);
            pnlContainer.ResumeLayout();
            pnlContainer.Visible = true;
        }

    }
    

}
