using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using TrainingCatalog.BusinessLogic;
using TrainingCatalog.BusinessLogic.Types;
using System.Data.SqlServerCe;

namespace TrainingCatalog.Forms
{
    public partial class CardioTemplateSelector : BaseForm
    {
        BindingSource bs;
        public CardioTemplateSelector()
        {
            InitializeComponent();
        }

        private void lstTemplates_DoubleClick(object sender, EventArgs e)
        {
            if (lstTemplates.SelectedValue != null)
            {
                new CardioTemplate(Convert.ToInt32(lstTemplates.SelectedValue)).ShowDialog(this);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new CardioTemplate().ShowDialog(this);
            bs.DataSource = GetTemplates();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTemplates.SelectedValue != null)
            {
                DeleteCardioTemplate(new CardioTemplateType()
                {
                    Id = Convert.ToInt32(lstTemplates.SelectedValue)
                });
            }
        }

        private void CardioTemplateSelector_Load(object sender, EventArgs e)
        {
            connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            bs = new BindingSource();
            lstTemplates.DisplayMember = "Name";
            lstTemplates.ValueMember = "Id";
            bs.DataSource = GetTemplates();
            lstTemplates.DataSource = bs;
        }
        private List<CardioTemplateType> GetTemplates()
        {
            List<CardioTemplateType> list = new List<CardioTemplateType>();
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    list = TrainingBusiness.GetCardioTemplates(cmd);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            list.Find(delegate(CardioTemplateType a) {
                TrainingBusiness.SaveBodyWeight(cmd, DateTime.Now, 0);
                return true; });
            return list;
            
        }
        private void SaveCardioTemplate(CardioTemplateType i)
        {
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    TrainingBusiness.SaveCardioTemplates(cmd, i);
 
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
 
        }
        private void DeleteCardioTemplate(CardioTemplateType i)
        {
          
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    TrainingBusiness.DeleteCardioTemplate(cmd, i);
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
        }

        private void lstTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstTemplates.SelectedValue != null)
                txtName.Text = ((CardioTemplateType)lstTemplates.SelectedValue).Name;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstTemplates.SelectedValue != null)
            {
                CardioTemplateType i = (CardioTemplateType)lstTemplates.SelectedValue;
                i.Name = txtName.Text.Replace("'", string.Empty).Replace(";", string.Empty).Trim();
                if (i.Name.Length > 0)
                {
                    SaveCardioTemplate(i);
                }
            }
        }

    }
}
