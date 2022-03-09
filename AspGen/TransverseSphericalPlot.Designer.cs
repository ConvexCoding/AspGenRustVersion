﻿
namespace AspGen
{
    partial class TransverseSphericalPlot
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToClipboardAsPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDataToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToPNGFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoScaleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.setHorizontalScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setVerticalScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.cms.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 613);
            this.panel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(828, 613);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title2";
            this.chart1.Titles.Add(title1);
            this.chart1.Titles.Add(title2);
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // cms
            // 
            this.cms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardAsPNGToolStripMenuItem,
            this.copyDataToClipboardToolStripMenuItem,
            this.saveToPNGFileToolStripMenuItem,
            this.autoScaleButton,
            this.setHorizontalScaleToolStripMenuItem,
            this.setVerticalScaleToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(307, 148);
            // 
            // copyToClipboardAsPNGToolStripMenuItem
            // 
            this.copyToClipboardAsPNGToolStripMenuItem.Name = "copyToClipboardAsPNGToolStripMenuItem";
            this.copyToClipboardAsPNGToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.copyToClipboardAsPNGToolStripMenuItem.Text = "Copy Graphic to Clipboard as PNG";
            this.copyToClipboardAsPNGToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardAsPNGToolStripMenuItem_Click);
            // 
            // copyDataToClipboardToolStripMenuItem
            // 
            this.copyDataToClipboardToolStripMenuItem.Name = "copyDataToClipboardToolStripMenuItem";
            this.copyDataToClipboardToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.copyDataToClipboardToolStripMenuItem.Text = "Copy Data to Clipboard";
            this.copyDataToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyDataToClipboardToolStripMenuItem_Click);
            // 
            // saveToPNGFileToolStripMenuItem
            // 
            this.saveToPNGFileToolStripMenuItem.Name = "saveToPNGFileToolStripMenuItem";
            this.saveToPNGFileToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.saveToPNGFileToolStripMenuItem.Text = "Save to PNG File";
            this.saveToPNGFileToolStripMenuItem.Click += new System.EventHandler(this.saveToPNGFileToolStripMenuItem_Click);
            // 
            // autoScaleButton
            // 
            this.autoScaleButton.Name = "autoScaleButton";
            this.autoScaleButton.Size = new System.Drawing.Size(306, 24);
            this.autoScaleButton.Text = "Auto Scale";
            this.autoScaleButton.Click += new System.EventHandler(this.autoScaleButton_Click);
            // 
            // setHorizontalScaleToolStripMenuItem
            // 
            this.setHorizontalScaleToolStripMenuItem.Name = "setHorizontalScaleToolStripMenuItem";
            this.setHorizontalScaleToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.setHorizontalScaleToolStripMenuItem.Text = "Set Horizontal Scale";
            this.setHorizontalScaleToolStripMenuItem.Click += new System.EventHandler(this.setHorizontalScaleToolStripMenuItem_Click);
            // 
            // setVerticalScaleToolStripMenuItem
            // 
            this.setVerticalScaleToolStripMenuItem.Name = "setVerticalScaleToolStripMenuItem";
            this.setVerticalScaleToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.setVerticalScaleToolStripMenuItem.Text = "Set Vertical Scale";
            this.setVerticalScaleToolStripMenuItem.Click += new System.EventHandler(this.setVerticalScaleToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(828, 613);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(828, 664);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(4, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(266, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(253, 22);
            this.toolStripLabel1.Text = "Mouse Click Brings Up Options Menu";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(828, 26);
            this.statusStrip1.TabIndex = 0;
            // 
            // statLabel
            // 
            this.statLabel.Name = "statLabel";
            this.statLabel.Size = new System.Drawing.Size(151, 20);
            this.statLabel.Text = "toolStripStatusLabel1";
            // 
            // TransverseSphericalPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 664);
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TransverseSphericalPlot";
            this.Text = "TransverseSphericalPlot";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.cms.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardAsPNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToPNGFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ToolStripMenuItem copyDataToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem setVerticalScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setHorizontalScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoScaleButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statLabel;
    }
}