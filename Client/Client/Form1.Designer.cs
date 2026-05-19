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
            this.Logs = new System.Windows.Forms.ListBox();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.Connect = new System.Windows.Forms.Button();
            this.ChooseFile = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Logs
            // 
            this.Logs.FormattingEnabled = true;
            this.Logs.Location = new System.Drawing.Point(25, 143);
            this.Logs.Name = "Logs";
            this.Logs.Size = new System.Drawing.Size(403, 264);
            this.Logs.TabIndex = 0;
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(460, 145);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(316, 262);
            this.textBoxSend.TabIndex = 1;
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(27, 46);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(136, 58);
            this.Connect.TabIndex = 2;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // ChooseFile
            // 
            this.ChooseFile.Location = new System.Drawing.Point(336, 46);
            this.ChooseFile.Name = "ChooseFile";
            this.ChooseFile.Size = new System.Drawing.Size(136, 58);
            this.ChooseFile.TabIndex = 3;
            this.ChooseFile.Text = "Choose File";
            this.ChooseFile.UseVisualStyleBackColor = true;
            this.ChooseFile.Click += new System.EventHandler(this.ChooseFile_Click);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(640, 46);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(136, 58);
            this.Send.TabIndex = 4;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.ChooseFile);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.Logs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Logs;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button ChooseFile;
        private System.Windows.Forms.Button Send;
    }
}

