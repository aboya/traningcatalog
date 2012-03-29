using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Configuration;
using TrainingCatalog.BusinessLogic;
using TrainingCatalog.Forms;
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog
{
    public partial class TemplateAdd : BaseForm
    {

        DataSet templates;
        DateTime _trainingDay;
        public TemplateAdd(DateTime trainingDay)
        {
            InitializeComponent();
            _trainingDay = trainingDay;
        }

        private void TemplateAdd_Load(object sender, EventArgs e)
        {
            try {
                connection = new SqlCeConnection(dbBusiness.connectionString);
                templates = new DataSet();
                LoadData();
                ddlBind();
                

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadData()
        {
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select * from Template";
                    using (SqlCeDataAdapter da = new SqlCeDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(templates);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
 
        }
        private void ddlBind()
        {
            ddlTemplates.DisplayMember = "Name";
            ddlTemplates.ValueMember = "ID";
            ddlTemplates.DataSource = templates.Tables[0];

            if (templates.Tables[0].Rows.Count > 0)
                ddlTemplates.SelectedIndex = 0;
            else
            {
                MessageBox.Show("Вы не создали неодного шаблона");
                this.Close();
            }
        }
        private void SaveTemplate()
        {
            TrainingBusiness.SaveTemplate(connection, ucTemplate.GetTemplateExersizes(), Convert.ToInt32(ddlTemplates.SelectedValue), null);
        }

        private void ddlTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlTemplates.SelectedValue);
            ucTemplate.LoadTemplateExersizes(TrainingBusiness.GetTemplateExersizes(connection, id));
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveTemplate();
        }

        private void AddToTrainingDay(DateTime _date)
        {
            try
            {
                connection.Open();
                using (SqlCeTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCeCommand cmd = connection.CreateCommand())
                        {
                            cmd.Transaction = transaction;
                            string strDate = _date.ToString("dd/MM/yyyy");
                            List<TemplateExersizesType> list = ucTemplate.GetTemplateExersizes();
                            int trainingDayId = TrainingBusiness.GetTrainingDayId(cmd,_date);

                            foreach (TemplateExersizesType exersize in list)
                            {
                                TrainingBusiness.AddExersize(cmd, trainingDayId, exersize.ExersizeID, exersize.Weight, exersize.Count);
                            }

                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddToTrainingDay(_trainingDay);
            this.Close();
        }

        private void btnSaveTemplateAndAdd_Click(object sender, EventArgs e)
        {
            SaveTemplate();
            AddToTrainingDay(_trainingDay);
            this.Close();
        }

        private void btnTemplateAdd_Click(object sender, EventArgs e)
        {
            ucTemplate.AddRowByUser();
        }
    }
}
