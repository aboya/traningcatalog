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
using TrainingCatalog.Forms;
using TrainingCatalog.BusinessLogic;


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
                    List<TemplateExersizesType>  templateExersizes = TrainingBusiness.GetTemplate(connection,_TemplateID);
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
            TrainingBusiness.SaveTemplate(connection, templateViewerControl.GetTemplateExersizes(), _TemplateID, txtTemplateName.Text);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
