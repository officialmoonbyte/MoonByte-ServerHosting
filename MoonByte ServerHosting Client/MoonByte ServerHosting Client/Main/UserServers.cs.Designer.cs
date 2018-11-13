namespace MoonByte.ClientSoftware.ServerHostingClient.Main
{
    partial class UserServers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserServers));
            this.usrServers = new System.Windows.Forms.Panel();
            this.flatButton1 = new IndieGoat.MaterialFramework.Controls.FlatButton();
            this.flatButton2 = new IndieGoat.MaterialFramework.Controls.FlatButton();
            this.SuspendLayout();
            // 
            // usrServers
            // 
            this.usrServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrServers.AutoScroll = true;
            this.usrServers.Location = new System.Drawing.Point(12, 81);
            this.usrServers.Name = "usrServers";
            this.usrServers.Size = new System.Drawing.Size(836, 537);
            this.usrServers.TabIndex = 2;
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.flatButton1.BackgroundColorClicked = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.flatButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.flatButton1.BorderWidth = 0;
            this.flatButton1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.flatButton1.Location = new System.Drawing.Point(1, 40);
            this.flatButton1.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Opacity = 100;
            this.flatButton1.Size = new System.Drawing.Size(123, 35);
            this.flatButton1.TabIndex = 3;
            this.flatButton1.text = "Back";
            this.flatButton1.TextColor = System.Drawing.Color.Black;
            this.flatButton1.WaveColor = System.Drawing.Color.Black;
            this.flatButton1.Click += new System.EventHandler(this.flatButton1_Click);
            // 
            // flatButton2
            // 
            this.flatButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.flatButton2.BackgroundColorClicked = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.flatButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.flatButton2.BorderWidth = 0;
            this.flatButton2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.flatButton2.Location = new System.Drawing.Point(736, 40);
            this.flatButton2.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Opacity = 100;
            this.flatButton2.Size = new System.Drawing.Size(123, 35);
            this.flatButton2.TabIndex = 4;
            this.flatButton2.text = "Refresh";
            this.flatButton2.TextColor = System.Drawing.Color.Black;
            this.flatButton2.WaveColor = System.Drawing.Color.Black;
            this.flatButton2.Click += new System.EventHandler(this.flatButton2_Click);
            // 
            // UserServers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(220)))));
            this.BorderSize = 2;
            this.ClientSize = new System.Drawing.Size(860, 630);
            this.Controls.Add(this.flatButton2);
            this.Controls.Add(this.flatButton1);
            this.Controls.Add(this.usrServers);
            this.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(220)))));
            this.HeaderHeight = 2;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserServers";
            this.Showicon = false;
            this.ShowMaxButton = false;
            this.ShowMinButton = false;
            this.ShowTitleLabel = false;
            this.Sizeable = false;
            this.Text = "UserServers";
            this.Load += new System.EventHandler(this.UserServers_Load);
            this.ResizeEnd += new System.EventHandler(this.UserServers_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel usrServers;
        private IndieGoat.MaterialFramework.Controls.FlatButton flatButton1;
        private IndieGoat.MaterialFramework.Controls.FlatButton flatButton2;
    }
}