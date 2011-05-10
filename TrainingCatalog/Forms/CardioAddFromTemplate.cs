using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainingCatalog.BusinessLogic;
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog.Forms
{
    public partial class CardioAddFromTemplate : BaseForm
    {
        CardioSessionType session;
        List<CardioIntervalType> resultList;
        public CardioAddFromTemplate()
        {
            InitializeComponent();
        }
        public CardioAddFromTemplate(CardioSessionType _session, out List<CardioIntervalType> res)
        {
            InitializeComponent();
            session = _session;
            resultList = new List<CardioIntervalType>();
            res = resultList;
        }

        private void CardioAddFromTemplate_Load(object sender, EventArgs e)
        {
            List<TemplateType> templateList = new List<TemplateType>();
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    templateList = TrainingBusiness.GetCardioTemplates(cmd);
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
            cbTemplates.ValueMember = "Id";
            cbTemplates.DisplayMember = "Name";
            cbTemplates.DataSource = templateList;
            if (templateList.Count > 0)
            {
                cbTemplates.SelectedIndex = 0;
                cbTemplates_SelectionChangeCommitted(cbTemplates, null);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IList<CardioIntervalType> list = new List<CardioIntervalType>();
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                   list = cardioExersizesControl.GetCardioExersizes();
                   foreach (CardioIntervalType i in list)
                   {
                       i.Id = 0;
                   }
                   resultList.AddRange(list);
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
            this.Close();
        }

        private void btnAddSave_Click(object sender, EventArgs e)
        {
            IList<CardioIntervalType> list = new List<CardioIntervalType>();
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    TrainingBusiness.SaveCardioTemplatesExersizes(cmd, (TemplateType)cbTemplates.SelectedItem, cardioExersizesControl.GetCardioExersizes());
                    list = cardioExersizesControl.GetCardioExersizes();
                    foreach (CardioIntervalType i in list)
                    {
                        i.Id = 0;
                    }
                    resultList.AddRange(list);
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
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IList<CardioIntervalType> list = new List<CardioIntervalType>();
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    TrainingBusiness.SaveCardioTemplatesExersizes(cmd, (TemplateType)cbTemplates.SelectedItem, cardioExersizesControl.GetCardioExersizes());
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
        }


        private void cbTemplates_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int TemplateId = Convert.ToInt32(cbTemplates.SelectedValue);
            List<CardioIntervalType> cardioExersizes = new List<CardioIntervalType>();
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    cardioExersizes = TrainingBusiness.GetCardioTemplateExersizes(cmd, new TemplateType() { Id = TemplateId });
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
            cardioExersizesControl.LoadCardioExersizes(cardioExersizes);
        }
    }
}
