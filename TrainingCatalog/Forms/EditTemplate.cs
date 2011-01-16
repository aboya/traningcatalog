﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Configuration;
using TrainingCatalog.Forms;


namespace TrainingCatalog
{
    public partial class EditTemplate : BaseForm
    {
        private int _TemplateID;
        SqlCeConnection connection;
        public EditTemplate()
        {
            InitializeComponent();
        }
        public EditTemplate(int templateId)
        {
            InitializeComponent();
            this._TemplateID = templateId;
        }


        private void btnAddExersize_Click(object sender, EventArgs e)
        {
            templateViewerControl.AddNewRow();
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtTemplateName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Имя шаблона не заданно");
                return;

            }
            if (txtTemplateName.Text.Contains('\''))
            {
                MessageBox.Show("Имя не может содержать ковычки");
                return;
            }
            if (_TemplateID > 0)
            {
                SaveTemplate();
            }
            else
            {
                AddNewTemplate();
            }
            this.Close();
        }

        private void EditTemplate_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                if (_TemplateID > 0)
                {
                    List<TemplateExersizesType>  templateExersizes = LoadTemplateExersizesById(_TemplateID);
                    templateViewerControl.LoadTemplateExersizes(templateExersizes);
                    txtTemplateName.Text = GetTemplateName(_TemplateID);
                }
                else
                {
                    templateViewerControl.AddNewRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        private string GetTemplateName(int templateId)
        {
            string res = string.Empty;
            try
            {

                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = string.Format("select Name from Template where ID={0}", templateId);
                    res = Convert.ToString(cmd.ExecuteScalar());
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
        private void AddNewTemplate()
        {
            List<TemplateExersizesType> list = templateViewerControl.GetTemplateExersizes();
            if (list == null || list.Count == 0) return;
            SqlCeTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {
                        cmd.Transaction = transaction;

                        cmd.CommandText = "insert into Template (Name) values(@name)";
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTemplateName.Text.Replace("'", "").Trim();
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT @@Identity";
                        int templateLastId = Convert.ToInt32(cmd.ExecuteScalar());
                        foreach (TemplateExersizesType exersize in list)
                        {
                            cmd.CommandText = string.Format("insert into TrainingTemplate (TemplateID, ExersizeID, Weight, [Count]) values({0}, {1}, {2}, {3}) ",
                                                       templateLastId,
                                                       exersize.ExersizeID,
                                                       exersize.Weight,
                                                       exersize.Count
                                                     );
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
        private void SaveTemplate()
        {
            List<TemplateExersizesType> list = templateViewerControl.GetTemplateExersizes();
            if (list == null || list.Count == 0) return;
            SqlCeTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        cmd.CommandText = string.Format("update Template set Name='{0}' where ID={1}", txtTemplateName.Text.Trim(), _TemplateID);
                        cmd.ExecuteNonQuery();
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}