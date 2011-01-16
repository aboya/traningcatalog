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

namespace TrainingCatalog
{
    public partial class TemplateAdd : BaseForm
    {
        SqlCeConnection connection;
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
                connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
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
            List<TemplateExersizesType> list = ucTemplate.GetTemplateExersizes();
            if (list == null || list.Count == 0) return;
            SqlCeTransaction transaction = null;

            try
            {
                int _TemplateID = Convert.ToInt32(ddlTemplates.SelectedValue);
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        foreach (TemplateExersizesType exersize in list)
                        {
                            if (exersize.ID == 0)
                            {
                                cmd.CommandText = string.Format("insert into TrainingTemplate (TemplateID, ExersizeID, Weight, [Count]) values({0}, {1}, {2}, {3}) ",
                                                           _TemplateID,
                                                           exersize.ExersizeID,
                                                           exersize.Weight,
                                                           exersize.Count
                                                         );
                            }
                            else
                            {
                                cmd.CommandText = string.Format("update TrainingTemplate set ExersizeID={1}, Weight={2}, [Count]={3} where ID={0}",
                                                           exersize.ID,
                                                           exersize.ExersizeID,
                                                           exersize.Weight,
                                                           exersize.Count
                                                         );
                            }
                            cmd.ExecuteNonQuery();
                            if (exersize.ID == 0)
                            {
                                cmd.CommandText = "select @@Identity";
                                exersize.ID = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }
                        // deleting exersizes witch user delete
                        if (_TemplateID > 0)
                        {
                            string existsid = string.Join(",", (from ex in list select ex.ID.ToString()).ToArray());
                            cmd.CommandText = string.Format("delete from TrainingTemplate where TemplateID={0} and ID not in({1})", _TemplateID, existsid);
                            cmd.ExecuteNonQuery();
                        }

                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    MessageBox.Show(e.Message);
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

        private void ddlTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlTemplates.SelectedValue);
            ucTemplate.LoadTemplateExersizes(LoadTemplateExersizesById(id));
        }
        public List<TemplateExersizesType> LoadTemplateExersizesById(int templateId)
        {
            List<TemplateExersizesType> res = new List<TemplateExersizesType>();
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = string.Format("select * from TrainingTemplate where TemplateID={0}", templateId);
                    using (SqlCeDataReader dr = cmd.ExecuteReader())
                    {
                        for (int i = 0; dr.Read(); i++)
                        {

                            res.Add(new TemplateExersizesType()
                            {
                                ID = Convert.ToInt32(dr["ID"]),
                                Count = Convert.ToInt32(dr["Count"]),
                                Weight = Convert.ToInt32(dr["Weight"]),
                                ExersizeID = Convert.ToInt32(dr["ExersizeID"]),
                            });
                        }
                    }
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

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveTemplate();
        }

        private void AddToTrainingDay(DateTime _date)
        {
            try
            {
                connection.Open();
                SqlCeTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        string strDate = _date.ToString("dd/MM/yyyy");
                        List<TemplateExersizesType> list =  ucTemplate.GetTemplateExersizes();
                        int trainingDayId = TrainingBusiness.GetTrainingDayId(_date, cmd);

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
            ucTemplate.AddNewRow();
        }
    }
}
