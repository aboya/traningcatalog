using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZedGraph.zForms
{
    /// <summary>
    /// Some Options for Graph Context Menu
    /// </summary>
    public partial class GraphOptions : Form
    {
        GraphPane _pane;
        /// <summary>
        /// Create Default Form Options
        /// </summary>
        public GraphOptions()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Create Default Form Options
        /// </summary>
        /// <param name="pane"></param>
        public GraphOptions(GraphPane pane)
        {
            InitializeComponent();
            this._pane = pane;

            chkLegend.Checked = _pane.Legend.IsVisible &&
                                _pane.XAxis.Title.IsVisible &&
                                _pane.YAxis.Title.IsVisible &&
                                _pane.Title.IsVisible;
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
            _pane.YAxis.Title.IsVisible = 
                _pane.XAxis.Title.IsVisible = 
                    _pane.Legend.IsVisible = 
                        _pane.Title.IsVisible =  chkLegend.Checked;
            
            
            this.Close();
        }
    }
}
