namespace Client
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
            this.btnGetMessageWithoutAnyProtection = new System.Windows.Forms.Button();
            this.btnGetSignedMessageWithoutEncryption = new System.Windows.Forms.Button();
            this.btnGetSignedMessageWithEncryption = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetMessageWithoutAnyProtection
            // 
            this.btnGetMessageWithoutAnyProtection.Location = new System.Drawing.Point(51, 21);
            this.btnGetMessageWithoutAnyProtection.Name = "btnGetMessageWithoutAnyProtection";
            this.btnGetMessageWithoutAnyProtection.Size = new System.Drawing.Size(238, 23);
            this.btnGetMessageWithoutAnyProtection.TabIndex = 0;
            this.btnGetMessageWithoutAnyProtection.Text = "Get Message Without Protection";
            this.btnGetMessageWithoutAnyProtection.UseVisualStyleBackColor = true;
            this.btnGetMessageWithoutAnyProtection.Click += new System.EventHandler(this.btnGetMessage_Click);
            // 
            // btnGetSignedMessageWithoutEncryption
            // 
            this.btnGetSignedMessageWithoutEncryption.Location = new System.Drawing.Point(51, 50);
            this.btnGetSignedMessageWithoutEncryption.Name = "btnGetSignedMessageWithoutEncryption";
            this.btnGetSignedMessageWithoutEncryption.Size = new System.Drawing.Size(238, 23);
            this.btnGetSignedMessageWithoutEncryption.TabIndex = 2;
            this.btnGetSignedMessageWithoutEncryption.Text = "Get Signed Message Without Encryption";
            this.btnGetSignedMessageWithoutEncryption.UseVisualStyleBackColor = true;
            this.btnGetSignedMessageWithoutEncryption.Click += new System.EventHandler(this.btnGetSignedMessageWithoutEncryption_Click);
            // 
            // btnGetSignedMessageWithEncryption
            // 
            this.btnGetSignedMessageWithEncryption.Location = new System.Drawing.Point(51, 79);
            this.btnGetSignedMessageWithEncryption.Name = "btnGetSignedMessageWithEncryption";
            this.btnGetSignedMessageWithEncryption.Size = new System.Drawing.Size(238, 23);
            this.btnGetSignedMessageWithEncryption.TabIndex = 3;
            this.btnGetSignedMessageWithEncryption.Text = "Get Signed Message With Encryption";
            this.btnGetSignedMessageWithEncryption.UseVisualStyleBackColor = true;
            this.btnGetSignedMessageWithEncryption.Click += new System.EventHandler(this.btnGetSignedMessageWithEncryption_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 296);
            this.Controls.Add(this.btnGetSignedMessageWithEncryption);
            this.Controls.Add(this.btnGetSignedMessageWithoutEncryption);
            this.Controls.Add(this.btnGetMessageWithoutAnyProtection);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetMessageWithoutAnyProtection;
        private System.Windows.Forms.Button btnGetSignedMessageWithoutEncryption;
        private System.Windows.Forms.Button btnGetSignedMessageWithEncryption;
    }
}

