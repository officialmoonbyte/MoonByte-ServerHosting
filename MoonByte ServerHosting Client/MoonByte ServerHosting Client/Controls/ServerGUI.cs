using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace MoonByte.ClientSoftware.ServerHostingClient.Controls
{
    public class ServerGUI : UserControl
    {
        public ServerGUI(string Name)
        {
            this.Size = new System.Drawing.Size(180, 240);
        }

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //Drawing background
            DrawBackground(e);

        }

        #region Draw Background

        private void DrawBackground(PaintEventArgs e)
        {
            var request = WebRequest.Create("");

            Image background_Image = null;
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                background_Image = Bitmap.FromStream(stream);
            }


        }

        #endregion

        #endregion
    }
}
