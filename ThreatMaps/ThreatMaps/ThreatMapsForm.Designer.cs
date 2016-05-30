using System.Drawing;
using System.Windows.Forms;
namespace ThreatMaps
{
    partial class ThreatMapsForm
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
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertiesPanel.Location = new System.Drawing.Point(12, 12);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(200, 579);
            this.propertiesPanel.TabIndex = 0;
            // 
            // gridPanel
            // 
            this.gridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridPanel.Location = new System.Drawing.Point(219, 12);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(593, 579);
            this.gridPanel.TabIndex = 1;
            this.gridPanel.Paint += new PaintEventHandler(gridPanel_Paint);
            // 
            // ThreatMapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 603);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.propertiesPanel);
            this.Name = "ThreatMapsForm";
            this.Text = "ThreatMaps";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel propertiesPanel;
        private System.Windows.Forms.Panel gridPanel;

        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {
            Pen blackpen = new Pen(Color.Black, 3);
            Graphics g = e.Graphics;
            g.DrawLine(blackpen, 0, 0, 200, 200);
            g.Dispose();
        }
    }
}

