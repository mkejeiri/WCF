namespace WindowsClient
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnRequestReplyOperation = new System.Windows.Forms.Button();
            this.BtnRequestReplyOperationThrowsException = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOneWayOperationThrowsException = new System.Windows.Forms.Button();
            this.btnOneWayOperation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(417, 277);
            this.listBox1.TabIndex = 0;
            // 
            // BtnRequestReplyOperation
            // 
            this.BtnRequestReplyOperation.Location = new System.Drawing.Point(12, 295);
            this.BtnRequestReplyOperation.Name = "BtnRequestReplyOperation";
            this.BtnRequestReplyOperation.Size = new System.Drawing.Size(417, 23);
            this.BtnRequestReplyOperation.TabIndex = 1;
            this.BtnRequestReplyOperation.Text = "Request Reply Operation";
            this.BtnRequestReplyOperation.UseVisualStyleBackColor = true;
            this.BtnRequestReplyOperation.Click += new System.EventHandler(this.BtnRequestReplyOperation_Click);
            // 
            // BtnRequestReplyOperationThrowsException
            // 
            this.BtnRequestReplyOperationThrowsException.Location = new System.Drawing.Point(12, 324);
            this.BtnRequestReplyOperationThrowsException.Name = "BtnRequestReplyOperationThrowsException";
            this.BtnRequestReplyOperationThrowsException.Size = new System.Drawing.Size(417, 23);
            this.BtnRequestReplyOperationThrowsException.TabIndex = 2;
            this.BtnRequestReplyOperationThrowsException.Text = "Request Reply Operation ThrowsException";
            this.BtnRequestReplyOperationThrowsException.UseVisualStyleBackColor = true;
            this.BtnRequestReplyOperationThrowsException.Click += new System.EventHandler(this.BtnRequestReplyOperationThrowsException_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 411);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(417, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOneWayOperationThrowsException
            // 
            this.btnOneWayOperationThrowsException.Location = new System.Drawing.Point(12, 382);
            this.btnOneWayOperationThrowsException.Name = "btnOneWayOperationThrowsException";
            this.btnOneWayOperationThrowsException.Size = new System.Drawing.Size(417, 23);
            this.btnOneWayOperationThrowsException.TabIndex = 5;
            this.btnOneWayOperationThrowsException.Text = "One Way Operation ThrowsException";
            this.btnOneWayOperationThrowsException.UseVisualStyleBackColor = true;
            this.btnOneWayOperationThrowsException.Click += new System.EventHandler(this.btnOneWayOperationThrowsException_Click);
            // 
            // btnOneWayOperation
            // 
            this.btnOneWayOperation.Location = new System.Drawing.Point(12, 353);
            this.btnOneWayOperation.Name = "btnOneWayOperation";
            this.btnOneWayOperation.Size = new System.Drawing.Size(417, 23);
            this.btnOneWayOperation.TabIndex = 4;
            this.btnOneWayOperation.Text = "One Way Operation";
            this.btnOneWayOperation.UseVisualStyleBackColor = true;
            this.btnOneWayOperation.Click += new System.EventHandler(this.btnOneWayOperation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 441);
            this.Controls.Add(this.btnOneWayOperationThrowsException);
            this.Controls.Add(this.btnOneWayOperation);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.BtnRequestReplyOperationThrowsException);
            this.Controls.Add(this.BtnRequestReplyOperation);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnRequestReplyOperation;
        private System.Windows.Forms.Button BtnRequestReplyOperationThrowsException;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOneWayOperationThrowsException;
        private System.Windows.Forms.Button btnOneWayOperation;
    }
}

