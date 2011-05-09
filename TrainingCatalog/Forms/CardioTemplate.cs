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
        TemplateType template;
        public CardioTemplate()
        {
            InitializeComponent();
        }
        public CardioTemplate(int templdateId)
        {
            TemplateId = templdateId;
            
            InitializeComponent();
        }



        private void lstExersizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstExersizes.SelectedItem != null)
            {
                cardioExersizeControl.DefaultCardioType = (CardioExersizeType)lstExersizes.SelectedItem;
            }
        }

        private void CardioTemplate_Load(object sender, EventArgs e)
        {
            this.btnAdd.Image = TrainingCatalog.AppResources.AppResources.Plus_green_32x32;
            this.btnOk.Image = TrainingCatalog.AppResources.AppResources.save_48x48;
 
            lstExersizes.DisplayMember = "Name";
            lstExersizes.ValueMember = "Id";
            lstExersizes.DataSource = GetExersizes();
            if (lstExersizes.Items.Count == 0)
            {
                MessageBox.Show("Необходимо добавить хотя бы 1 кардио упражнение");
                this.Close();
            }
            if (TemplateId > 0)
            {
                template = GetTemplate(TemplateId);
                txtName.Text = template.Name;
                cardioExersizeControl.LoadCardioExersizes(GetCardioTemplates(template));
            }
            else
            {
                template = new TemplateType();
            }

         }
        private TemplateType GetTemplate(int TemplateId)
        {
            TemplateType res = null;
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    res = TrainingBusiness.GetTemplate(cmd, TemplateId);
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
            return res;
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
        private List<CardioIntervalType> GetCardioTemplates(TemplateType template)
        {
            List<CardioIntervalType> res = new List<CardioIntervalType>();
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    res = TrainingBusiness.GetCardioTemplateExersizes(cmd, template);
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
            return res;

        }

        private void SaveCardioTemplate(IList<CardioIntervalType> intervals, TemplateType template)
        {
            try
            {
              
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    TrainingBusiness.SaveCardioTemplatesExersizes(cmd, template, intervals); 
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CardioExersizeType i = (CardioExersizeType)lstExersizes.SelectedItem;
            if (i != null)
            {
                cardioExersizeControl.AddRow(i);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            name = name.Replace("'", string.Empty).Replace(";", string.Empty).Trim();
            template.Name = name;
            if (template.Name.Length > 0)
            {
                SaveCardioTemplate(cardioExersizeControl.GetCardioExersizes(), template);
            }
            else
            {
                txtName.Text = template.Name;
                MessageBox.Show("Имя не может быть пустым");
            }

        }

        
    }
}
