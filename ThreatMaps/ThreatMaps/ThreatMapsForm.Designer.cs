﻿using System.Drawing;
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
            this.debugText = new Label();
            this.findPathButton = new Button();
            this.randomWalls = new Button();
            this.SuspendLayout();
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertiesPanel.Location = new System.Drawing.Point(10, 10);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(200, gridYSize + 10);
            this.propertiesPanel.TabIndex = 0;
            this.propertiesPanel.Controls.Add(debugText);
            this.propertiesPanel.Controls.Add(findPathButton);
            this.propertiesPanel.Controls.Add(randomWalls);
            //
            //DebugLable
            //
            this.debugText.AutoSize = true;
            this.debugText.Text = "0, 0";
            this.debugText.Location = new Point(20, 20);
            this.debugText.Name = "debugText";
            //
            // ContextMenu
            //
            ContextMenu cm = new ContextMenu();
            MenuItem mStartPoint = new MenuItem("Start Point");
            MenuItem mEndPoint = new MenuItem("End Point");
            MenuItem mSetRemWall = new MenuItem("Set/Remove Wall");
            mStartPoint.Click += new System.EventHandler(cm_setStartPointEvent);
            mEndPoint.Click += new System.EventHandler(cm_setEndPointEvent);
            mSetRemWall.Click += new System.EventHandler(cm_setRemWall);
            cm.MenuItems.Add(mStartPoint);
            cm.MenuItems.Add(mEndPoint);
            cm.MenuItems.Add(mSetRemWall);
            //
            //findPathButton
            //
            this.findPathButton.Location = new System.Drawing.Point(60, 400);
            this.findPathButton.AutoSize = true;
            this.findPathButton.Text = "Find Path";
            this.findPathButton.Click += new System.EventHandler(findPathButton_Click);
            this.findPathButton.Enabled = false;
            //
            //randomWallsButton
            //
            this.randomWalls.Location = new System.Drawing.Point(55, 300);
            this.randomWalls.AutoSize = true;
            this.randomWalls.Text = "Random Walls";
            this.randomWalls.Click += new System.EventHandler(randomWalls_Click);
            this.randomWalls.Enabled = true;
            // 
            // gridPanel
            //
            this.gridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridPanel.Location = new System.Drawing.Point(220, 10);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(gridXSize + 10, gridYSize + 10);
            this.gridPanel.TabIndex = 1;
            this.gridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gridPanel_Paint);
            this.gridPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridPanel_Click);
            this.gridPanel.ContextMenu = cm;
            // 
            // ThreatMapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 521);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.propertiesPanel);
            this.MaximumSize = new System.Drawing.Size(gridXSize + 250, gridYSize + 65);
            this.MinimumSize = new System.Drawing.Size(gridXSize + 250, gridYSize + 65);
            this.Name = "ThreatMapsForm";
            this.Text = "ThreatMaps";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel propertiesPanel;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Label debugText;
        private System.Windows.Forms.Button findPathButton;
        private System.Windows.Forms.Button randomWalls;

        
    }
}

