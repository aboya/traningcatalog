using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using TrainingCatalog.BusinessLogic;
using System.Configuration;
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog.Forms
{
    public partial class EditCardio : BaseForm
    {
        SqlCeConnection connection;
        SqlCeCommand cmd;
        public EditCardio()
        {
            InitializeComponent();
            connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            cmd = connection.CreateCommand();
        }
        private bool CheckName(string str)
        {
            if (str == null) return false;
            if (str.Trim().Length == 0) return false;
            if (str.Contains('\'')) return false;
            return true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!CheckName(txtName.Text))
            {
                MessageBox.Show("Неверное имя");
                return;
            }
            List<CardioExersizeType> exersizes = null;
            int index = lstExersizes.SelectedIndex;
            try
            {
                connection.Open();
                CardioExersizeType exersize = new CardioExersizeType();
                exersize.Name = txtName.Text;
                exersize.Id = Convert.ToInt32(lstExersizes.SelectedValue);
                Dictionary<int, bool> cardioTypes = new Dictionary<int, bool>();
                for (int i = 1; i <= 5; i++)
                {
                    cardioTypes[i] = lstProperties.GetItemChecked(i - 1);
                }

                TrainingBusiness.SaveCardioExersize(cmd, exersize, cardioTypes);
                exersizes = TrainingBusiness.GetCardioExersizes(cmd);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            lstExersizes.DataSource = exersizes;
            lstExersizes.SelectedIndex = index;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckName(txtName.Text))
            {
                MessageBox.Show("Неверное имя");
                return;
            }
            List<CardioExersizeType> exersizes = null; 
            try
            {
                connection.Open();
                CardioExersizeType exersize = new CardioExersizeType();
                exersize.Name = txtName.Text;
                Dictionary<int, bool> cardioTypes = new Dictionary<int, bool>();
                for (int i = 1; i <= 5; i++)
                {
                    cardioTypes[i] = lstProperties.GetItemChecked(i - 1);
                }

                TrainingBusiness.SaveCardioExersize(cmd, exersize, cardioTypes);
                exersizes = TrainingBusiness.GetCardioExersizes(cmd);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            lstExersizes.DataSource = exersizes;
            if (exersizes != null && exersizes.Count > 0)
            {
                lstExersizes.SelectedIndex = exersizes.Count - 1;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<CardioExersizeType> exersizes = null;
            try
            {
                connection.Open();
                CardioExersizeType exersize = new CardioExersizeType();
                exersize.Name = txtName.Text;
                             
                TrainingBusiness.DeleteCardioExersize(cmd, Convert.ToInt32(lstExersizes.SelectedValue));
                exersizes = TrainingBusiness.GetCardioExersizes(cmd); ;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            lstExersizes.DataSource = exersizes;
            if (exersizes != null && exersizes.Count > 0)
            {

                lstExersizes.SelectedIndex = exersizes.Count - 1;
            }
        }

        private void EditCardio_Load(object sender, EventArgs e)
        {
            List<CardioExersizeType> exersizes = null;
           
            try
            {
                connection.Open();
                exersizes = TrainingBusiness.GetCardioExersizes(cmd); 
                
                lstExersizes.ValueMember = "Id";
                lstExersizes.DisplayMember = "Name";
                Dictionary<int, string> types = TrainingBusiness.GetCardioTypes();
                lstProperties.Items.Clear();
                for (int i = 1; i <= 5; i++)
                {
                    lstProperties.Items.Add(types[i], false);
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
            lstExersizes.DataSource = exersizes;
            
        }

        private void lstExersizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsShown) return;
            try
            {
                connection.Open();
                int exersizeId = Convert.ToInt32(lstExersizes.SelectedValue);
                Dictionary<int, bool> types = TrainingBusiness.GetCardioTypesForExersize(cmd, exersizeId);

                for (int i = 1; i <= 5; i++)
                {
                    lstProperties.SetItemChecked(i - 1, types[i]);
                }
                txtName.Text = lstExersizes.Text;
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


        private void EditCardio_Shown(object sender, EventArgs e)
        {
            if (lstExersizes.Items.Count > 0)
            {
                lstExersizes.SelectedIndex = 0;
            }
        }

    }
}
