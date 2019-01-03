using IndieGoat.MaterialFramework.Controls;
using MoonByte.ClientSoftware.ServerHostingClient.Main;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MoonByte.ClientSoftware.ServerHostingClient.Controls
{
    public class ServerGUI : UserControl
    {

        #region Vars

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        bool FileDownloaded = false;

        readonly string Name;
        readonly string urlLink = "https://moonbyte.net/img/Banner/minecraft.png";

        string ImageDirectory;

        Rectangle TopLeft;
        Rectangle TopRight;
        Rectangle BottomLeft;
        Rectangle BottomRight;


        #region Suspend Drawing

        public void SuspendDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);
        }

        public void ResumeDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Refresh();
        }

        #endregion

        #region Controls

        MaterialProgressBar downloadImageProgress;
        Label downloadProgressLabel;

        #endregion

        #endregion

        #region Start

        public ServerGUI(string name)
        {

            this.Size = new Size(180, 240);
            this.Name = name;
            this.DoubleBuffered = true;
            this.ImageDirectory = Path.GetTempPath() + @"\Moonbyte\ServerHosting\";

            if (!Directory.Exists(ImageDirectory)) Directory.CreateDirectory(ImageDirectory);
            ImageDirectory += this.Name + "img.png";

            downloadImageProgress = new MaterialProgressBar();
            downloadImageProgress.Width = this.Width / 2;
            downloadImageProgress.Location = new Point((this.Width / 2) - (downloadImageProgress.Width / 2), (this.Height / 2) - (downloadImageProgress.Height / 2));

            this.Controls.Add(downloadImageProgress);

            downloadProgressLabel = new MaterialLabel();
            downloadProgressLabel.Location = new Point((this.Width / 2) - (downloadProgressLabel.Width / 2), (this.Height / 2) + (downloadImageProgress.Height / 2) + (downloadProgressLabel.Height));
            downloadProgressLabel.Text = "Downloading...";

            this.Controls.Add(downloadProgressLabel);

            SuspendDrawing();

            SaveImage();

            ResumeDrawing();
        }

        #endregion

        #region WebClient

        void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            downloadProgressLabel.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
            downloadProgressLabel.Location = new Point((this.Width / 2) - (downloadProgressLabel.Width / 2), (this.Height / 2) + (downloadImageProgress.Height / 2) + (downloadProgressLabel.Height));
            downloadImageProgress.Value = int.Parse(Math.Truncate(percentage).ToString());
        }
        void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.Controls.Remove(downloadImageProgress);
            this.Controls.Remove(downloadProgressLabel);

            downloadImageProgress.Dispose();
            downloadProgressLabel.Dispose();

            FileDownloaded = true;

            this.Invalidate();
        }

        #endregion

        #region OnMouseOver

        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.Invalidate(); base.OnMouseMove(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.Invalidate(); base.OnMouseLeave(e); 
        }

        #endregion

        #region MouseClick

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (TopRight.Contains(this.PointToClient(MousePosition)))
            {

            }
            if (TopLeft.Contains(this.PointToClient(MousePosition)))
            {
                MaterialForm parentForm = (MaterialForm)((Panel)this.Parent).Parent; parentForm.Hide();
                ServerSettings settingsPage = new ServerSettings(this.Name, parentForm); settingsPage.Show();
            }
            if (BottomLeft.Contains(this.PointToClient(MousePosition)))
            {

            }
            if (BottomRight.Contains(this.PointToClient(MousePosition)))
            {

            }

            base.OnMouseClick(e);
        }

        #endregion

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawBackground(e.Graphics);

            if (this.ClientRectangle.Contains(this.PointToClient(MousePosition))) { DrawCursorOver(e.Graphics); }

            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        #region Draw Background

        private void DrawBackground(Graphics g)
        {
            if (File.Exists(ImageDirectory) && FileDownloaded) { g.DrawImage(Image.FromFile(ImageDirectory), this.ClientRectangle); }
            g.DrawRectangle(new Pen(new SolidBrush(Color.Gray), 2), this.ClientRectangle);
        }

        private void DrawCursorOver(Graphics g)
        {
            if (FileDownloaded)
            {
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                g.FillRectangle(new SolidBrush(Color.FromArgb(190, 0, 0, 0)), this.ClientRectangle);

                Font TitleFont = new Font("Segoe UI", 12, FontStyle.Italic);
                Size TitleFont_Size = TextRenderer.MeasureText(this.Name, TitleFont);
                g.DrawString(this.Name, TitleFont, new SolidBrush(Color.White), new Point((this.Width / 2) - (TitleFont_Size.Width / 2), (this.Height) - TitleFont_Size.Height - 6));

                g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(150, 235, 235, 235)), 1), new Point(this.Width / 2, 10), new Point(this.Width / 2, this.Height - TitleFont_Size.Height - 16));
                g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(150, 235, 235, 235)), 1), new Point(10, this.Height / 2 - 10), new Point(this.Width - 10, this.Height / 2 - 10));

                Image settingsIcon = Image.FromFile(Application.StartupPath + @"\img\Settings-icon.png");

                TopLeft = new Rectangle(new Point(10, (this.Height / 2) - 90), new Size(70, 70));
                TopRight = new Rectangle(new Point(this.Width / 2 + 10, (this.Height / 2) - 90), new Size(70, 70));
                BottomLeft = new Rectangle(new Point(10, this.Height / 2), new Size(70, 70));
                BottomRight = new Rectangle(new Point((this.Width / 2) + 10, (this.Height / 2)), new Size(70, 70));

                g.InterpolationMode = InterpolationMode.High;
                g.CompositingQuality = CompositingQuality.HighQuality;

                g.DrawImage(settingsIcon, TopLeft);
                g.FillRectangle(new SolidBrush(Color.Red), TopRight);
                g.FillRectangle(new SolidBrush(Color.Red), BottomLeft);
                g.FillRectangle(new SolidBrush(Color.Red), BottomRight);
            }
        }

        #endregion

        #endregion

        #region Image

        public void SaveImage()
        {
            if (File.Exists(ImageDirectory)) File.Delete(ImageDirectory);

            WebClient Client = new WebClient();
            Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            Client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
            Client.DownloadFileAsync(new Uri(urlLink), ImageDirectory);
        }

        #endregion
    }
}
