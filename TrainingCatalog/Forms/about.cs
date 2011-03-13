using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TrainingCatalog.Forms
{
    public partial class about : BaseForm
    {
        public about()
        {
            InitializeComponent();
        }

        private void about_Load(object sender, EventArgs e)
        {
            pbApp.Image = TrainingCatalog.AppResources.AppResources.dumbbells_big;
            pbApp.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void lblAuthor_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:Sergey Aboimov <aboimov@gmail.com>?subject=Training Catalog");
        }

        private void lblAuthor_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void lblAuthor_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lblAuthor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}
