using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Configuration;
using TrainingCatalog.Forms;
using TrainingCatalog.BusinessLogic.Types;
using System.Collections.Generic;
using TrainingCatalog.BusinessLogic;

namespace TrainingCatalog
{
    public partial class Templates : BaseForm
    {
        List<TemplateType> templates;

        public Templates()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new EditTemplate().ShowDialog(this);
            FillData();
            GridBind();
        }

        private void Templates_Load(object sender, EventArgs e)
        {
            try
            {
                templates = new List<TemplateType>();
                FillData();
                GridBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        private void GridBind()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            foreach (var t in templates)
            {
                dataGridView1.Rows.Add(new[] { t.Name });
                dataGridView1.Rows[i].Cells[1].Value = "Remove";
                dataGridView1.Rows[i].Tag = t.Id;
                i++;
            }
 
        }
        private void FillData()
        {
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    templates = TrainingBusiness.GetWeightLigtingTemplates(cmd);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex < dataGridView1.Rows.Count)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Tag);
                RemoveById(id);
                FillData();
                GridBind();
            }
        }
        private void RemoveById(int id)
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
                        cmd.CommandText = string.Format("delete from TrainingTemplate where TemplateID={0}", id);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("delete from Template where ID={0}", id);
                        cmd.ExecuteNonQuery();
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < dataGridView1.Rows.Count)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Tag);
                new EditTemplate(id).ShowDialog(this);
                FillData();
                GridBind();
            }
        }
    }
}
