﻿namespace Client
{
    partial class Form1
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
            this.btnCallService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCallService
            // 
            this.btnCallService.Location = new System.Drawing.Point(75, 21);
            this.btnCallService.Name = "btnCallService";
            this.btnCallService.Size = new System.Drawing.Size(107, 23);
            this.btnCallService.TabIndex = 0;
            this.btnCallService.Text = "Call service";
            this.btnCallService.UseVisualStyleBackColor = true;
            this.btnCallService.Click += new System.EventHandler(this.btnCallService_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 80);
            this.Controls.Add(this.btnCallService);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCallService;
    }
}
