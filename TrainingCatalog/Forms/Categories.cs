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
using TrainingCatalog.BusinessLogic;
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog.Forms
{
    public partial class Categories : BaseForm
    {

        public Categories()
        {
            InitializeComponent();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlCeConnection(dbBusiness.connectionString);
                cmd = connection.CreateCommand();
                LoadCatagories();
                if (lstCategory.Items.Count > 0)
                {
                    lstCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                this.Close();
            }
        }
        private void LoadCatagories()
        {
            try
            {
                connection.Open();
                lstCategory.DataSource = TrainingBusiness.GetCategories(cmd);
                lstCategory.ValueMember = "Id";
                lstCategory.DisplayMember = "Name";

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = lstCategory.SelectedIndex;
            try
            {
                string name = txtName.Text.Trim();

                if (name.Length > 0)
                {

                    connection.Open();
                    CategoryType c = (lstCategory.Items[lstCategory.SelectedIndex] as CategoryType);
                    c.Name = name;
                    TrainingBusiness.UpdateCategory(cmd, c);
                }
                else
                {
                    MessageBox.Show("Имя не может быть пустым");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            LoadCatagories();
            lstCategory.SelectedIndex = index;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                if (name.Length > 0)
                {
                    connection.Open();
                    TrainingBusiness.AddCategory(cmd, name);
                }
                else
                {
                    MessageBox.Show("Имя не может быть пустым");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                if(connection.State == ConnectionState.Open)
                    connection.Close();
            }
            LoadCatagories();

            lstCategory.SelectedIndex = lstCategory.Items.Count - 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                CategoryType c = (lstCategory.Items[lstCategory.SelectedIndex] as CategoryType);
                if (TrainingBusiness.CheckCategory(cmd, c.Id))
                {
                    var dresult = MessageBox.Show(this, "Эта категория уже используется. \t\n Вы действительно хотите её удалить?", "Внимание!", 
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dresult == System.Windows.Forms.DialogResult.Yes)
                    {
                        TrainingBusiness.DeleteCategory(cmd, c.Id);
                    }
                }
                else
                {
                    TrainingBusiness.DeleteCategory(cmd, c.Id);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            LoadCatagories();
            if (lstCategory.Items.Count > 0)
            {
                lstCategory.SelectedIndex = lstCategory.Items.Count - 1;
            }
        }

        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = (lstCategory.Items[lstCategory.SelectedIndex] as CategoryType).Name;
        }
    }
}
