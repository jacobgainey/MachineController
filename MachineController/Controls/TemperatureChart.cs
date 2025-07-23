using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Reflection.Metadata;

namespace MachineController.Controls
{
    public partial class TemperatureChart : System.Windows.Forms.PictureBox
    {
        public TemperatureChart()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), ClientRectangle);
            Brush GridBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new PointF(1, 1), new PointF(2, 2), Color.DarkGray, Color.DarkGray);
            Brush FontBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new PointF(1, 1), new PointF(2, 2), Color.DarkGray, Color.DarkGray);

            // horizontal line
            for (int i = 10; i <= 330; i += 40)
                pe.Graphics.FillRectangle(GridBrush, new Rectangle(25, i, this.Width - 38, 1));

            // vertical line
            for (int i = 25; i <= 420; i += 42)
                pe.Graphics.FillRectangle(GridBrush, new Rectangle(i, 10, 1, this.Height - 30));

            // seconds (bottom)
            int x = 5;
            for (int i = 19; i < 440; i += 42)
            {
                pe.Graphics.DrawString($@"{x}", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), FontBrush, new PointF(i, 335));
                x += 5;
            }
            int y = 250;
            // temperature (left)
            for (int i = 5; i < 290; i += 40)
            {
                pe.Graphics.DrawString($@"{y}", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), FontBrush, new PointF(1, i));
                y -= 25;
            }
        }

        public void PlotTemperature()
        {
            Brush TemperatureBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new PointF(1, 1), new PointF(2, 2), Color.Red, Color.Red);

            using (Graphics g = this.CreateGraphics())
            {
                // Draw next line and...
                g.DrawLine(Pens.Red, new Point(10, 10), new Point(100, 100));
            }
        }

    }
}
