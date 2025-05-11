using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeRush_Final.UI.Minigame
{
    public partial class WordBlastStart : BaseControl
    {

        private SubContainerForm form;
        public WordBlastStart(SubContainerForm form)
        {
            InitializeComponent();
            lblPlay.Parent = pbxBG;
            this.form = form;
        }

        private void lblPlay_MouseHover(object sender, EventArgs e)
        {
            lblPlay.Cursor = Cursors.Hand;
            lblPlay.ForeColor = Color.Orchid; 
            pbxBG.Image = Properties.Resources.wordBlast2;
        }

        private void lblPlay_MouseLeave(object sender, EventArgs e)
        {
            lblPlay.ForeColor = Color.Thistle; 
            pbxBG.Image = Properties.Resources.wordBlast1;

        }

        private void lblPlay_Click(object sender, EventArgs e)
        {
            form.LoadUserControlIntoPanel(new WordBlast(form));
        }
    }
}
