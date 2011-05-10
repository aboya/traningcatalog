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
        public CardioTemplateSelector()
        {
            InitializeComponent();
        }

        private void lstTemplates_DoubleClick(object sender, EventArgs e)
        {
            if (lstTemplates.SelectedValue != null)
            {
                new CardioTemplate(Convert.ToInt32(lstTemplates.SelectedValue)).ShowDialog(this);
                BindTemplates();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
         
            new CardioTemplate().ShowDialog(this);
            BindTemplates();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTemplates.SelectedValue != null)
            {
                DeleteCardioTemplate(new TemplateType()
                {
                    Id = Convert.ToInt32(lstTemplates.SelectedValue)
                });
                BindTemplates();
            }
        }

        private void CardioTemplateSelector_Load(object sender, EventArgs e)
        {
            connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            lstTemplates.DisplayMember = "Name";
            lstTemplates.ValueMember = "Id";
            lstTemplates.DataSource = GetTemplates();

        }
        private void BindTemplates()
        {
            int index = lstTemplates.SelectedIndex;
            lstTemplates.DataSource = GetTemplates();
            lstTemplates.SelectedIndex = index;
        }
        private List<TemplateType> GetTemplates()
        {
            List<TemplateType> list = new List<TemplateType>();
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
            return list;
            
        }
        private void SaveCardioTemplate(TemplateType i)
        {
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    TrainingBusiness.SaveCardioTemplatesExersizes(cmd, i, null);
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
        private void DeleteCardioTemplate(TemplateType i)
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
            if(lstTemplates.SelectedItem != null)
                txtName.Text = ((TemplateType)lstTemplates.SelectedItem).Name;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstTemplates.SelectedValue != null)
            {
                TemplateType i = (TemplateType)lstTemplates.SelectedItem;
                i.Name = txtName.Text.Replace("'", string.Empty).Replace(";", string.Empty).Trim();
                if (i.Name.Length > 0)
                {
                    SaveCardioTemplate(i);
                }
                else
                {
                    txtName.Name = i.Name;
                    MessageBox.Show("Имя не может быть пустым");
                }
            }
        }

    }
}
