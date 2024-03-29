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
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog
{
    public partial class ExersizesList : BaseForm
    {

        SqlCeDataAdapter table = new SqlCeDataAdapter();
        DataSet Exersizes = new DataSet();
        DataSet categories = new DataSet();
        public ExersizesList()
        {

            connection = new SqlCeConnection(dbBusiness.connectionString);
            InitializeComponent();
        }

        private void ExersizesList_Load(object sender, EventArgs e)
        {
            LoadPage();
            this.MinimumSize = new Size(404, 278);

        }
        private void LoadPage()
        {
            ClearAll();
            LoadExersizeCategories();
            ExersizeLoad(); 
        }
        private void ClearAll()
        {
            Exersizes.Clear();
            categories.Clear();
            txtDescription.Text = string.Empty;
            txtExersizeName.Text = string.Empty;
            TrainingList.Items.Clear();
            chkLstExersizeCategories.Items.Clear();

 
        }
        public void ExersizeLoad()
        {
            bool ok = true;
            try
            {
                connection.Open();

                using (cmd = new SqlCeCommand("select ID as ExersizeID, ShortName, Description from Exersize order by ShortName asc", connection))
                {
                    cmd.Connection = connection;
                    //SqlCeDataReader reader = cmd.ExecuteReader();

                    table.SelectCommand = cmd;
                    table.Fill(Exersizes);
                    for (int i = 0; i < Exersizes.Tables[0].Rows.Count; i++)
                    {
                        TrainingList.Items.Add(Exersizes.Tables[0].Rows[i]["ShortName"]);
                    }
                    TrainingList.DropDownStyle = ComboBoxStyle.DropDownList;
                }

            }
            catch (Exception ee)
            {
                ok = false;
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            
            if(ok && Exersizes.Tables[0].Rows.Count > 0) TrainingList.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if (Exersizes.Tables[0].Rows.Count == 0) return;
            try
            {

                connection.Open();
                int exersizeId = Convert.ToInt32(Exersizes.Tables[0].Rows[TrainingList.SelectedIndex]["ExersizeID"]);
                // processing categories
                for (int i = 0; i < chkLstExersizeCategories.Items.Count; i++)
                {
                    int categoryId = Convert.ToInt32(categories.Tables[0].Rows[i]["ID"]);
                    bool check = chkLstExersizeCategories.GetItemChecked(i);
                    if (check)
                    {
                        if (isExistLink(exersizeId, categoryId)) continue;
                        addLink(exersizeId, categoryId);
                    }
                    else
                    {
                        if (!isExistLink(exersizeId, categoryId)) continue;
                        deleteLink(exersizeId, categoryId);
                    }

                }
                //saving name & description
                using (cmd = connection.CreateCommand())
                {
                    string shortName = txtExersizeName.Text.Trim().Replace("\"", "").Replace(@"'", "").Replace(";", "");
                    string description = txtDescription.Text.Trim().Replace("\"", "").Replace(@"'", "").Replace(";", "");
                    cmd.Connection = connection;
                    cmd.CommandText = string.Format(@"update Exersize
                                                                set ShortName = '{0}',
                                                                Description = '{1}'
                                                                where ID = {2}", shortName, description, exersizeId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ee)
            {
                ok = false;
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            LoadPage();
            if (ok) MessageBox.Show("Упражнение успешно сохраненно");
        }
        private void deleteLink(int exersizeId, int exersizeCategoryId)
        {
            using (cmd = connection.CreateCommand())
            {
                cmd.Connection = connection;


                cmd.CommandText = string.Format(@"delete from ExersizeCategoryLink
                                              where ExersizeID={0} and ExersizeCategoryID={1} ", exersizeId, exersizeCategoryId);
                cmd.ExecuteNonQuery();
            }
        }
        private void addLink(int exersizeId, int exersizeCategoryId)
        {
            // assume connection is open & do Not close
            using (cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"insert into ExersizeCategoryLink (ExersizeId, ExersizeCategoryId)
                               values( @exersizeId, @exersizeCategoryId)";
                cmd.Parameters.Add("@exersizeId", SqlDbType.Int).Value = exersizeId;
                cmd.Parameters.Add("@exersizeCategoryId", SqlDbType.Int).Value = exersizeCategoryId;
                cmd.ExecuteNonQuery();
            }
        }

        private bool isExistLink(int exersizeId, int exersizeCategoryId)
        {
            // assume connection is open & do Not close
            using (cmd = connection.CreateCommand())
            {
                cmd.CommandText = string.Format(@"select count(*) from ExersizeCategoryLink inner join 
                                                ExersizeCategory on
                                                ExersizeCategoryLink.ExersizeCategoryID = ExersizeCategory.ID
                                                where ExersizeID = {0} and ExersizeCategory.ID = {1}", exersizeId, exersizeCategoryId);

                return Convert.ToBoolean(cmd.ExecuteScalar());
            }

        }
        private void TrainingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = TrainingList.SelectedIndex;
                if (TrainingList.SelectedIndex < 0) return;
                foreach (int i in chkLstExersizeCategories.CheckedIndices)
                {
                    chkLstExersizeCategories.SetItemChecked(i, false);
                }
                connection.Open();
                txtExersizeName.Text = Convert.ToString(Exersizes.Tables[0].Rows[index]["ShortName"]);
                txtDescription.Text = Convert.ToString(Exersizes.Tables[0].Rows[index]["Description"]);

                int exersizeId = Convert.ToInt32(Exersizes.Tables[0].Rows[index]["ExersizeID"]);
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = string.Format(@"select * from ExersizeCategoryLink inner join 
                                                ExersizeCategory on
                                                ExersizeCategoryLink.ExersizeCategoryID = ExersizeCategory.ID
                                                where ExersizeID = {0}", exersizeId);
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int categoryId = Convert.ToInt32(dataReader["ExersizeCategoryID"]);
                        int k = 0;
                        foreach (DataRow dr in categories.Tables[0].Rows)
                        {
                            if (Convert.ToInt32(dr["ID"]) == categoryId)
                            {
                                chkLstExersizeCategories.SetItemChecked(k, true);
                            }
                            k++;
                        }
                    }
                }

            }
            catch (Exception rr)
            {
                MessageBox.Show(rr.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void LoadExersizeCategories()
        {
            SqlCeCommand cmd = new SqlCeCommand();
            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = "select * from ExersizeCategory order by Name";
                using (SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter())
                {
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(categories);
                }
                foreach (DataRow dr in categories.Tables[0].Rows)
                {
                    chkLstExersizeCategories.Items.Add(dr["Name"], false);
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
            cmd = null;
        }
 
    }
}
