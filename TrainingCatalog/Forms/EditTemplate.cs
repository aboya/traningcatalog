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

        public EditTemplate()
        {
            InitializeComponent();
            templateViewerControl1.IsNewTemplate = true;
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
            SaveTemplate();
            this.Close();
        }

        private void EditTemplate_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTemplateName.Text.Trim().Length == 0 )
            {
                MessageBox.Show("Имя шаблона не заданно");
                return;

            }
            if(txtTemplateName.Text.Contains('\''))
            {
                MessageBox.Show("Имя не может содержать ковычки");
                return;
            }
            SaveTemplate();

        }
        private void SaveTemplate()
        {
            List<TemplateExersizesType> list = templateViewerControl1.GetTemplateExersizes();
            if (list == null || list.Count == 0) return;
            OleDbTransaction transaction = null;
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    try
                    {
                        using (OleDbCommand cmd = connection.CreateCommand())
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandText = "select max(ID) from Template";
                            object o = cmd.ExecuteScalar();
                            int templateLastId = 0;
                            if (!(o is DBNull)) templateLastId = Convert.ToInt32(o) + 1;

                            cmd.CommandText = string.Format("insert into Template (ID, Name) values({0}, '{1}')", templateLastId, txtTemplateName.Text.Trim());
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "select max(ID) from TrainingTemplate";
                            o = cmd.ExecuteScalar();
                            int trainingTemplateLastId = 0;
                            if (!(o is DBNull)) trainingTemplateLastId = Convert.ToInt32(o) + 1;
                            foreach (TemplateExersizesType exersize in list)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = string.Format("insert into TrainingTemplate (TemplateID, ExersizeID, Weight, Count) values({0}, {1}, {2}, {3}) ",
                                                      //  trainingTemplateLastId,
                                                         templateLastId,
                                                          exersize.ExersizeID,
                                                         exersize.Weight,
                                                         exersize.Count
                                                         );
                                cmd.ExecuteNonQuery();
                                trainingTemplateLastId++;

                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        transaction.Rollback();
 
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
