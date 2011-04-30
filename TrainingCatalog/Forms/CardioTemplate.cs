using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainingCatalog.BusinessLogic.Types;
using TrainingCatalog.BusinessLogic;

namespace TrainingCatalog.Forms
{
    public partial class CardioTemplate : BaseForm
    {
        int TemplateId;
        BindingSource bs;
        public CardioTemplate()
        {
            InitializeComponent();
        }
        public CardioTemplate(int templdateId)
        {
            TemplateId = templdateId;
            InitializeComponent();
        }

        private void Добавить_Click(object sender, EventArgs e)
        {
            
        }

        private void lstExersizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstExersizes.SelectedItem != null)
            {
                cardioExersizeControl.DefaultCardioType = (CardioIntervalType)lstExersizes.SelectedItem;
            }
        }

        private void CardioTemplate_Load(object sender, EventArgs e)
        {
            bs = new BindingSource();
            lstExersizes.DisplayMember = "Name";
            lstExersizes.ValueMember = "Id";
            lstExersizes.DataSource = GetExersizes(); 
            bs.DataSource = GetExersizes();
        }
        private List<CardioExersizeType> GetExersizes()
        {
            List<CardioExersizeType> list = new List<CardioExersizeType>();
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    list = TrainingBusiness.GetCardioExersizes(cmd);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
    }
}
