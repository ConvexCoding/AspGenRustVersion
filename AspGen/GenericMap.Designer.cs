
namespace AspGen
{
    partial class GenericMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericMap));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts = new System.Windows.Forms.ToolStripStatusLabel();
            this.pb = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.copyDataToClip = new System.Windows.Forms.ToolStripButton();
            this.copyImageToClip = new System.Windows.Forms.ToolStripButton();
            this.copyForm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pb);
            this.toolStripContainer1.ContentPanel.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(662, 472);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(662, 525);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(662, 26);
            this.statusStrip1.TabIndex = 0;
            // 
            // ts
            // 
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(21, 20);
            this.ts.Text = "ss";
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(10, 10);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(642, 452);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyDataToClip,
            this.toolStripSeparator1,
            this.copyImageToClip,
            this.toolStripSeparator2,
            this.copyForm});
            this.toolStrip1.Location = new System.Drawing.Point(4, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(384, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // copyDataToClip
            // 
            this.copyDataToClip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.copyDataToClip.Image = ((System.Drawing.Image)(resources.GetObject("copyDataToClip.Image")));
            this.copyDataToClip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyDataToClip.Name = "copyDataToClip";
            this.copyDataToClip.Size = new System.Drawing.Size(133, 24);
            this.copyDataToClip.Text = "Copy Data To Clip";
            this.copyDataToClip.Click += new System.EventHandler(this.copyDataToClip_Click);
            // 
            // copyImageToClip
            // 
            this.copyImageToClip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.copyImageToClip.Image = ((System.Drawing.Image)(resources.GetObject("copyImageToClip.Image")));
            this.copyImageToClip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyImageToClip.Name = "copyImageToClip";
            this.copyImageToClip.Size = new System.Drawing.Size(93, 24);
            this.copyImageToClip.Text = "Copy Image";
            this.copyImageToClip.Click += new System.EventHandler(this.copyImageToClip_Click);
            // 
            // copyForm
            // 
            this.copyForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.copyForm.Image = ((System.Drawing.Image)(resources.GetObject("copyForm.Image")));
            this.copyForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyForm.Name = "copyForm";
            this.copyForm.Size = new System.Drawing.Size(133, 24);
            this.copyForm.Text = "Copy Form to Clip";
            this.copyForm.Click += new System.EventHandler(this.copyFormButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // GenericMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 525);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "GenericMap";
            this.Text = "GenericMap";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton copyDataToClip;
        private System.Windows.Forms.ToolStripButton copyImageToClip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton copyForm;
    }
}