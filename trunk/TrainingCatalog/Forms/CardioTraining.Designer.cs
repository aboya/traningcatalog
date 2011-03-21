namespace TrainingCatalog.Forms
{
    partial class CardioTraining
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardioTraining));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.viewSelectorItem5 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem6 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem7 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem8 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorRibbonPage2 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPage();
            this.viewSelectorRibbonPageGroup2 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.viewSelectorRibbonPage1 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPage();
            this.viewSelectorRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup();
            this.viewSelectorItem4 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem3 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem2 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem1 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.ribbonViewSelector1 = new DevExpress.XtraScheduler.UI.RibbonViewSelector(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector1)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.schedulerControl1.Location = new System.Drawing.Point(12, 129);
            this.schedulerControl1.LookAndFeel.SkinName = "Blue";
            this.schedulerControl1.MenuManager = this.ribbonControl1;
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(789, 472);
            this.schedulerControl1.Start = new System.DateTime(2011, 3, 19, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage1;
            this.schedulerControl1.TabIndex = 1;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.DayView.TimeScale = System.TimeSpan.Parse("01:00:00");
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.WorkWeekView.TimeScale = System.TimeSpan.Parse("01:00:00");
            this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonText = null;
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.viewSelectorItem5,
            this.viewSelectorItem6,
            this.viewSelectorItem7,
            this.viewSelectorItem8});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 17;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.viewSelectorRibbonPage2});
            this.ribbonControl1.SelectedPage = this.viewSelectorRibbonPage2;
            this.ribbonControl1.Size = new System.Drawing.Size(814, 143);
            // 
            // viewSelectorItem5
            // 
            this.viewSelectorItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem5.Glyph")));
            this.viewSelectorItem5.GroupIndex = 1;
            this.viewSelectorItem5.Id = 12;
            this.viewSelectorItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem5.LargeGlyph")));
            this.viewSelectorItem5.Name = "viewSelectorItem5";
            this.viewSelectorItem5.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Day;
            // 
            // viewSelectorItem6
            // 
            this.viewSelectorItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem6.Glyph")));
            this.viewSelectorItem6.GroupIndex = 1;
            this.viewSelectorItem6.Id = 13;
            this.viewSelectorItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem6.LargeGlyph")));
            this.viewSelectorItem6.Name = "viewSelectorItem6";
            this.viewSelectorItem6.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            // 
            // viewSelectorItem7
            // 
            this.viewSelectorItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem7.Glyph")));
            this.viewSelectorItem7.GroupIndex = 1;
            this.viewSelectorItem7.Id = 14;
            this.viewSelectorItem7.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem7.LargeGlyph")));
            this.viewSelectorItem7.Name = "viewSelectorItem7";
            this.viewSelectorItem7.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Week;
            // 
            // viewSelectorItem8
            // 
            this.viewSelectorItem8.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem8.Glyph")));
            this.viewSelectorItem8.GroupIndex = 1;
            this.viewSelectorItem8.Id = 15;
            this.viewSelectorItem8.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem8.LargeGlyph")));
            this.viewSelectorItem8.Name = "viewSelectorItem8";
            this.viewSelectorItem8.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            // 
            // viewSelectorRibbonPage2
            // 
            this.viewSelectorRibbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.viewSelectorRibbonPageGroup2});
            this.viewSelectorRibbonPage2.Name = "viewSelectorRibbonPage2";
            // 
            // viewSelectorRibbonPageGroup2
            // 
            this.viewSelectorRibbonPageGroup2.ItemLinks.Add(this.viewSelectorItem5);
            this.viewSelectorRibbonPageGroup2.ItemLinks.Add(this.viewSelectorItem6);
            this.viewSelectorRibbonPageGroup2.ItemLinks.Add(this.viewSelectorItem7);
            this.viewSelectorRibbonPageGroup2.ItemLinks.Add(this.viewSelectorItem8);
            this.viewSelectorRibbonPageGroup2.Name = "viewSelectorRibbonPageGroup2";
            // 
            // viewSelectorRibbonPage1
            // 
            this.viewSelectorRibbonPage1.Name = "viewSelectorRibbonPage1";
            this.viewSelectorRibbonPage1.Text = "";
            // 
            // viewSelectorRibbonPageGroup1
            // 
            this.viewSelectorRibbonPageGroup1.Name = "viewSelectorRibbonPageGroup1";
            this.viewSelectorRibbonPageGroup1.Text = "";
            // 
            // viewSelectorItem4
            // 
            this.viewSelectorItem4.Caption = "Month";
            this.viewSelectorItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem4.Glyph")));
            this.viewSelectorItem4.GroupIndex = 1;
            this.viewSelectorItem4.Id = 9;
            this.viewSelectorItem4.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D4));
            this.viewSelectorItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem4.LargeGlyph")));
            this.viewSelectorItem4.Name = "viewSelectorItem4";
            this.viewSelectorItem4.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            toolTipTitleItem1.Text = "Month Calendar (Ctrl+Alt+4)";
            toolTipItem1.Text = "Switches to Month (Multi-Week) view. Calendar view useful for long-term plans.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.viewSelectorItem4.SuperTip = superToolTip1;
            // 
            // viewSelectorItem3
            // 
            this.viewSelectorItem3.Caption = "Week";
            this.viewSelectorItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem3.Glyph")));
            this.viewSelectorItem3.GroupIndex = 1;
            this.viewSelectorItem3.Id = 8;
            this.viewSelectorItem3.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D3));
            this.viewSelectorItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem3.LargeGlyph")));
            this.viewSelectorItem3.Name = "viewSelectorItem3";
            this.viewSelectorItem3.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Week;
            toolTipTitleItem2.Text = "Week Calendar (Ctrl+Alt+3)";
            toolTipItem2.Text = "Switches to Week view. Arranges appointments for a particular week in a compact f" +
                "orm.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.viewSelectorItem3.SuperTip = superToolTip2;
            // 
            // viewSelectorItem2
            // 
            this.viewSelectorItem2.Caption = "Work Week";
            this.viewSelectorItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem2.Glyph")));
            this.viewSelectorItem2.GroupIndex = 1;
            this.viewSelectorItem2.Id = 7;
            this.viewSelectorItem2.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D2));
            this.viewSelectorItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem2.LargeGlyph")));
            this.viewSelectorItem2.Name = "viewSelectorItem2";
            this.viewSelectorItem2.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            toolTipTitleItem3.Text = "Work Week Calendar (Ctrl+Alt+2)";
            toolTipItem3.Text = "Switches to Work Week view. Detailed view for the working days in a certain week." +
                "";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.viewSelectorItem2.SuperTip = superToolTip3;
            // 
            // viewSelectorItem1
            // 
            this.viewSelectorItem1.Caption = "Day";
            this.viewSelectorItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem1.Glyph")));
            this.viewSelectorItem1.GroupIndex = 1;
            this.viewSelectorItem1.Id = 6;
            this.viewSelectorItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D1));
            this.viewSelectorItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem1.LargeGlyph")));
            this.viewSelectorItem1.Name = "viewSelectorItem1";
            this.viewSelectorItem1.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Day;
            toolTipTitleItem4.Text = "Day Calendar (Ctrl+Alt+1)";
            toolTipItem4.Text = "Switches to Day view. The most detailed view of appointments for a specific day(s" +
                ").";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.viewSelectorItem1.SuperTip = superToolTip4;
            // 
            // ribbonViewSelector1
            // 
            this.ribbonViewSelector1.RibbonControl = this.ribbonControl1;
            this.ribbonViewSelector1.SchedulerControl = this.schedulerControl1;
            this.ribbonViewSelector1.TargetRibbonPageName = null;
            // 
            // CardioTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 613);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.schedulerControl1);
            this.Name = "CardioTraining";
            this.Text = "Cardio";
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem5;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem6;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem7;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem8;
        private DevExpress.XtraScheduler.UI.ViewSelectorRibbonPage viewSelectorRibbonPage2;
        private DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup viewSelectorRibbonPageGroup2;
        private DevExpress.XtraScheduler.UI.ViewSelectorRibbonPage viewSelectorRibbonPage1;
        private DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup viewSelectorRibbonPageGroup1;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem4;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem3;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem2;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem1;
        private DevExpress.XtraScheduler.UI.RibbonViewSelector ribbonViewSelector1;
    }
}