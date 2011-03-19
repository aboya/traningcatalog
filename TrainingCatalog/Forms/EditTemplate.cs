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
            templateViewerControl.AddRowByUser();
            
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
