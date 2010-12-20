﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace TrainingCatalog
{
    public partial class TemplateAdd : Form
    {
        OleDbConnection connection;
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
                connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
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
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select * from Template";
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
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
            OleDbTransaction transaction = null;

            try
            {
                int _TemplateID = Convert.ToInt32(ddlTemplates.SelectedValue);
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    using (OleDbCommand cmd = connection.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        foreach (TemplateExersizesType exersize in list)
                        {
                            if (exersize.ID == 0)
                            {
                                cmd.CommandText = string.Format("insert into TrainingTemplate (TemplateID, ExersizeID, Weight, Count1) values({0}, {1}, {2}, {3}) ",
                                                           _TemplateID,
                                                           exersize.ExersizeID,
                                                           exersize.Weight,
                                                           exersize.Count
                                                         );
                            }
                            else
                            {
                                cmd.CommandText = string.Format("update TrainingTemplate set ExersizeID={1}, Weight={2}, Count1={3} where ID={0}",
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
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = string.Format("select * from TrainingTemplate where TemplateID={0}", templateId);
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        for (int i = 0; dr.Read(); i++)
                        {

                            res.Add(new TemplateExersizesType()
                            {
                                ID = Convert.ToInt32(dr["ID"]),
                                Count = Convert.ToInt32(dr["Count1"]),
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
        private int GetTrainingDayId(string date, OleDbCommand cmd)
        {
            int trainingdayId;
            cmd.CommandText = string.Format("select ID from Training where Day = DateValue(\"{0}\")", date);
            object o = cmd.ExecuteScalar();
            if (o == null || o is DBNull)
            {
                int maxTrainingDayId = 0;
                cmd.CommandText = "select max(ID) from Training";
                o = cmd.ExecuteScalar();
                if (o is int)
                {
                    maxTrainingDayId = Convert.ToInt32(o);
                }
                cmd.CommandText = string.Format("insert into Training  values({0},DateValue(\"{1}\"), \'\',{2})", maxTrainingDayId + 1, date, 0);
                cmd.ExecuteNonQuery();
                trainingdayId = maxTrainingDayId + 1;

            }
            else
            {
                trainingdayId = Convert.ToInt32(o);
            }
            return trainingdayId;
        }
        private void AddToTrainingDay(DateTime _date)
        {
            try
            {
                connection.Open();
                OleDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (OleDbCommand cmd = connection.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        string strDate = _date.ToString("dd/MM/yyyy");
                        List<TemplateExersizesType> list =  ucTemplate.GetTemplateExersizes();
                        int trainingDayId = this.GetTrainingDayId(strDate, cmd);

                        int lastLinkId = 0;
                        cmd.CommandText = "select max(ID) from Link";
                        object o = cmd.ExecuteScalar();
                        if (o is int)
                            lastLinkId = Convert.ToInt32(o);

                        foreach (TemplateExersizesType exersize in list)
                        {
                            
                            cmd.CommandText = String.Format("insert into Link values({0},{1},{2},{3},{4})",
                                                                lastLinkId + 1, 
                                                                trainingDayId, 
                                                                exersize.ExersizeID,
                                                                exersize.Weight, 
                                                                exersize.Count);
                            cmd.ExecuteNonQuery();
                            lastLinkId++;
          
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
