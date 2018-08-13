namespace MoonByte.ClientSoftware.ServerHostingClient.MessageBox
{
    partial class MaterialMessageBox
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
            this.flatButton1 = new IndieGoat.MaterialFramework.Controls.FlatButton();
            this.materialLabel1 = new IndieGoat.MaterialFramework.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.flatButton1.BackgroundColorClicked = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.flatButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.flatButton1.BorderWidth = 0;
            this.flatButton1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.flatButton1.Location = new System.Drawing.Point(306, 146);
            this.flatButton1.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Opacity = 100;
            this.flatButton1.Size = new System.Drawing.Size(105, 42);
            this.flatButton1.TabIndex = 2;
            this.flatButton1.text = "Okay";
            this.flatButton1.TextColor = System.Drawing.Color.Black;
            this.flatButton1.WaveColor = System.Drawing.Color.Black;
            this.flatButton1.Click += new System.EventHandler(this.flatButton1_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.materialLabel1.Location = new System.Drawing.Point(12, 58);
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(0, 19);
            this.materialLabel1.TabIndex = 3;
            // 
            // MaterialMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(222)))));
            this.BorderSize = 2;
            this.ClientSize = new System.Drawing.Size(423, 200);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.flatButton1);
            this.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Name = "MaterialMessageBox";
            this.ShowIcon = false;
            this.ShowTitleLabel = false;
            this.Sizeable = false;
            this.Text = "AccountInformationWrong";
            this.Load += new System.EventHandler(this.AccountInformationWrong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IndieGoat.MaterialFramework.Controls.FlatButton flatButton1;
        private IndieGoat.MaterialFramework.Controls.MaterialLabel materialLabel1;
    }
}