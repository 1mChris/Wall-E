namespace Wall_E.Bot
{
    partial class WinFormWall_E
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinFormWall_E));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ping = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LinkUBGE = new System.Windows.Forms.LinkLabel();
            this.LinkGitHub = new System.Windows.Forms.LinkLabel();
            this.BoolIRC = new System.Windows.Forms.Label();
            this.IRC = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PingBot = new System.Windows.Forms.Label();
            this.ConsoleForm = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 211);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wall-E da Ética";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ping:";
            // 
            // Ping
            // 
            this.Ping.AutoSize = true;
            this.Ping.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ping.Location = new System.Drawing.Point(40, 255);
            this.Ping.Name = "Ping";
            this.Ping.Size = new System.Drawing.Size(0, 18);
            this.Ping.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LinkUBGE);
            this.groupBox1.Controls.Add(this.LinkGitHub);
            this.groupBox1.Controls.Add(this.BoolIRC);
            this.groupBox1.Controls.Add(this.IRC);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PingBot);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(1078, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 248);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do Bot";
            // 
            // LinkUBGE
            // 
            this.LinkUBGE.AutoSize = true;
            this.LinkUBGE.Location = new System.Drawing.Point(4, 228);
            this.LinkUBGE.Name = "LinkUBGE";
            this.LinkUBGE.Size = new System.Drawing.Size(37, 13);
            this.LinkUBGE.TabIndex = 11;
            this.LinkUBGE.TabStop = true;
            this.LinkUBGE.Text = "UBGE";
            this.LinkUBGE.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // LinkGitHub
            // 
            this.LinkGitHub.AutoSize = true;
            this.LinkGitHub.BackColor = System.Drawing.SystemColors.Control;
            this.LinkGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LinkGitHub.Location = new System.Drawing.Point(106, 228);
            this.LinkGitHub.Name = "LinkGitHub";
            this.LinkGitHub.Size = new System.Drawing.Size(40, 13);
            this.LinkGitHub.TabIndex = 10;
            this.LinkGitHub.TabStop = true;
            this.LinkGitHub.Text = "GitHub";
            this.LinkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkGitHub_LinkClicked);
            // 
            // BoolIRC
            // 
            this.BoolIRC.AutoSize = true;
            this.BoolIRC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoolIRC.Location = new System.Drawing.Point(40, 55);
            this.BoolIRC.Name = "BoolIRC";
            this.BoolIRC.Size = new System.Drawing.Size(0, 18);
            this.BoolIRC.TabIndex = 9;
            // 
            // IRC
            // 
            this.IRC.AutoSize = true;
            this.IRC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IRC.Location = new System.Drawing.Point(8, 55);
            this.IRC.Name = "IRC";
            this.IRC.Size = new System.Drawing.Size(37, 18);
            this.IRC.TabIndex = 8;
            this.IRC.Text = "IRC:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 18);
            this.label5.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Versão:";
            // 
            // PingBot
            // 
            this.PingBot.AutoSize = true;
            this.PingBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PingBot.Location = new System.Drawing.Point(41, 16);
            this.PingBot.Name = "PingBot";
            this.PingBot.Size = new System.Drawing.Size(0, 18);
            this.PingBot.TabIndex = 5;
            // 
            // ConsoleForm
            // 
            this.ConsoleForm.BackColor = System.Drawing.SystemColors.WindowText;
            this.ConsoleForm.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleForm.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ConsoleForm.Location = new System.Drawing.Point(206, 2);
            this.ConsoleForm.Name = "ConsoleForm";
            this.ConsoleForm.ReadOnly = true;
            this.ConsoleForm.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ConsoleForm.Size = new System.Drawing.Size(869, 248);
            this.ConsoleForm.TabIndex = 8;
            this.ConsoleForm.Text = "";
            // 
            // WinFormWall_E
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 251);
            this.Controls.Add(this.ConsoleForm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Ping);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WinFormWall_E";
            this.Text = "Wall-E da Ética online!";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Ping;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label PingBot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label BoolIRC;
        private System.Windows.Forms.Label IRC;
        private System.Windows.Forms.LinkLabel LinkGitHub;
        private System.Windows.Forms.LinkLabel LinkUBGE;
        private System.Windows.Forms.RichTextBox ConsoleForm;
    }
}