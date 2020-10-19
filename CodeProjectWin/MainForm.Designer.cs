using System.Windows.Forms;
using System.ComponentModel;
using System;
namespace CodeProjectWin
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NameForAddingStart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.NameForAddingStop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // NameForAddingStart
            // 
            this.NameForAddingStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameForAddingStart.Location = new System.Drawing.Point(116, 6);
            this.NameForAddingStart.MaxLength = 70;
            this.NameForAddingStart.Name = "NameForAddingStart";
            this.NameForAddingStart.Size = new System.Drawing.Size(130, 20);
            this.NameForAddingStart.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Range:";
            // 
            // Add
            // 
            this.Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add.Location = new System.Drawing.Point(3, 71);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(48, 23);
            this.Add.TabIndex = 2;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(123, 32);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(259, 45);
            this.trackBar1.TabIndex = 3;
            // 
            // NameForAddingStop
            // 
            this.NameForAddingStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameForAddingStop.Location = new System.Drawing.Point(252, 6);
            this.NameForAddingStop.MaxLength = 70;
            this.NameForAddingStop.Name = "NameForAddingStop";
            this.NameForAddingStop.Size = new System.Drawing.Size(130, 20);
            this.NameForAddingStop.TabIndex = 4;
            this.NameForAddingStop.TextChanged += new System.EventHandler(this.NameForAddingStop_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Handle thread Count";
            // 
            // MainForm
            // 
            this.AcceptButton = this.Add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 96);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameForAddingStop);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameForAddingStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 135);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameForAddingStart;
        private System.Windows.Forms.TextBox NameForAddingStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Add;
        private TrackBar trackBar1;
        private Label label2;
    }
}