using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;


namespace TrainingCatalog
{
    public partial class EditTemplate : Form
    {
        private int _TemplateID;
        OleDbConnection connection;
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
            templateViewerControl1.AddNewRow();
            
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
                connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                if (_TemplateID > 0)
                {
                    List<TemplateExersizesType>  templateExersizes = LoadTemplateExersizesById(_TemplateID);
                    templateViewerControl1.LoadTemplateExersizes(templateExersizes);
                    txtTemplateName.Text = GetTemplateName(_TemplateID);
                }
                else
                {
                    templateViewerControl1.AddNewRow();
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
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = string.Format("select Name from Template where ID={0}", templateId);
                    res = Convert.ToString(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();
            return res;
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
            connection.Close();
            return res;
        }
        private void AddNewTemplate()
        {
            List<TemplateExersizesType> list = templateViewerControl1.GetTemplateExersizes();
            if (list == null || list.Count == 0) return;
            OleDbTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    using (OleDbCommand cmd = connection.CreateCommand())
                    {
                        cmd.Transaction = transaction;

                        cmd.CommandText = string.Format("insert into Template (Name) values('{0}')", txtTemplateName.Text.Trim());
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT @@Identity";
                        int templateLastId = Convert.ToInt32(cmd.ExecuteScalar());
                        foreach (TemplateExersizesType exersize in list)
                        {
                            cmd.CommandText = string.Format("insert into TrainingTemplate (TemplateID, ExersizeID, Weight, Count1) values({0}, {1}, {2}, {3}) ",
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
            connection.Close();
        }
        private void SaveTemplate()
        {
            List<TemplateExersizesType> list = templateViewerControl1.GetTemplateExersizes();
            if (list == null || list.Count == 0) return;
            OleDbTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    using (OleDbCommand cmd = connection.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        cmd.CommandText = string.Format("update Template set Name='{0}' where ID={1}",txtTemplateName.Text.Trim(), _TemplateID);
                        cmd.ExecuteNonQuery();
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
                        if(_TemplateID > 0) {
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
            connection.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
