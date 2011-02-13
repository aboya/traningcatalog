using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZedGraph.zForms
{
    public partial class GraphOptions : Form
    {
        GraphPane _pane;
        public GraphOptions()
        {
            InitializeComponent();
            
        }
        public GraphOptions(GraphPane pane)
        {
            InitializeComponent();
            this._pane = pane;

            chkMajorX.Checked = _pane.XAxis.MajorGrid.IsVisible;
            chkMinorX.Checked = _pane.XAxis.MinorGrid.IsVisible;
            chkMajorY.Checked = _pane.YAxis.MajorGrid.IsVisible;
            chkMinorY.Checked = _pane.YAxis.MinorGrid.IsVisible;
            this.StartPosition = FormStartPosition.CenterParent;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _pane.XAxis.MajorGrid.IsVisible = chkMajorX.Checked;
            _pane.XAxis.MinorGrid.IsVisible = chkMinorX.Checked;
            _pane.YAxis.MajorGrid.IsVisible = chkMajorY.Checked;
            _pane.YAxis.MinorGrid.IsVisible = chkMinorY.Checked;
            
            this.Close();
        }
    }
}
