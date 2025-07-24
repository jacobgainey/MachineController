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
        Dictionary<string, Point> points = [];

        public TemperatureChart()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            //using Graphics g = this.CreateGraphics();

            pe.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), new Rectangle(0, 0, this.Width, this.Height));

            Brush GridBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new PointF(1, 1), new PointF(2, 2), Color.DarkGray, Color.DarkGray);
            Brush FontBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new PointF(1, 1), new PointF(2, 2), Color.DarkGray, Color.DarkGray);

            // horizontal line x
            int iHLineTop = 10;
            int iHLineLeft = 25;
            int iHLineLength = this.Width - 40;
            for (int i = iHLineTop; i <= 330; i += 40)
                pe.Graphics.FillRectangle(GridBrush, new Rectangle(iHLineLeft, i, iHLineLength, 1));

            // vertical line y
            int iVLineTop = 10;
            int iVLineLeft = 25;
            int iVLineHeight = this.Height - 24;
            for (int i = iVLineLeft; i <= 420; i += 42)
                pe.Graphics.FillRectangle(GridBrush, new Rectangle(i, iVLineTop, 1, iVLineHeight));

            // seconds (bottom)
            int iSecFontTop = 332;
            int iSecFontIncrament = 5;
            for (int iFontLeft = 19; iFontLeft < 440; iFontLeft += 42)
            {
                pe.Graphics.DrawString($@"{iSecFontIncrament}", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), FontBrush,
                    new PointF(iFontLeft, iSecFontTop));
                iSecFontIncrament += 5;
            }

            // temperature (left)
            int iTmpFontLeft = 1;
            int iTmpFontIncrament = 250;
            for (int iTmpFontTop = 5; iTmpFontTop < 290; iTmpFontTop += 40)
            {
                pe.Graphics.DrawString($@"{iTmpFontIncrament}", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), FontBrush,
                    new PointF(iTmpFontLeft, iTmpFontTop));
                iTmpFontIncrament -= 25;
            }
        }

        public void Clear()
        {
            using Graphics g = this.CreateGraphics();

            g.FillRectangle(new SolidBrush(Color.WhiteSmoke), new Rectangle(0, 0, this.Width, this.Height));

            Brush GridBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new PointF(1, 1), new PointF(2, 2), Color.DarkGray, Color.DarkGray);
            Brush FontBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new PointF(1, 1), new PointF(2, 2), Color.DarkGray, Color.DarkGray);

            // horizontal line x
            int iHLineTop = 10;
            int iHLineLeft = 25;
            int iHLineLength = this.Width - 40;
            for (int i = iHLineTop; i <= 330; i += 40)
                g.FillRectangle(GridBrush, new Rectangle(iHLineLeft, i, iHLineLength, 1));

            // vertical line y
            int iVLineTop = 10;
            int iVLineLeft = 25;
            int iVLineHeight = this.Height - 24;
            for (int i = iVLineLeft; i <= 420; i += 42)
                g.FillRectangle(GridBrush, new Rectangle(i, iVLineTop, 1, iVLineHeight));

            // seconds (bottom)
            int iSecFontTop = 332;
            int iSecFontIncrament = 5;
            for (int iFontLeft = 19; iFontLeft < 440; iFontLeft += 42)
            {
                g.DrawString($@"{iSecFontIncrament}", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), FontBrush,
                    new PointF(iFontLeft, iSecFontTop));
                iSecFontIncrament += 5;
            }

            // temperature (left)
            int iTmpFontLeft = 1;
            int iTmpFontIncrament = 250;
            for (int iTmpFontTop = 5; iTmpFontTop < 290; iTmpFontTop += 40)
            {
                g.DrawString($@"{iTmpFontIncrament}", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), FontBrush,
                    new PointF(iTmpFontLeft, iTmpFontTop));
                iTmpFontIncrament -= 25;
            }
            points.Clear();
            points.Add("Starting Extruder Temperature Point", new(25, this.Height - 15));
            points.Add("Ending Extruder Temperature Point", new(25, this.Height - 15));
            points.Add("Starting Heated Bed Temperature Point", new(25, this.Height - 15));
            points.Add("Ending Heated Bed Temperature Point", new(25, this.Height - 15));
            points.Add("Starting Extruder SetPoint", new(25, this.Height - 15));
            points.Add("Ending Extruder SetPoint", new(25, this.Height - 15));
            points.Add("Starting Heated Bed SetPoint", new(25, this.Height - 15));
            points.Add("Ending Heated Bed SetPoint", new(25, this.Height - 15));
        }

        public void SetExtruderTemperature(int temperature, int second)
        {
            DrawLine("Starting Extruder Temperature Point", "Ending Extruder Temperature Point", Pens.Red, temperature, second);
        }

        public void SetHeatedBedTemperature(int temperature, int second)
        {
            DrawLine("Starting Heated Bed Temperature Point", "Ending Heated Bed Temperature Point", Pens.Blue, temperature, second);
        }

        public void SetExtruderSetPoint(int temperature, int second)
        {
            DrawLine("Starting Extruder SetPoint", "Ending Extruder SetPoint", Pens.DarkRed, temperature, second);
        }

        public void SetHeatedBedSetPoint(int temperature, int second)
        {
            DrawLine("Starting Heated Bed SetPoint", "Ending Heated Bed SetPoint", Pens.DarkBlue, temperature, second);
        }

        public void DrawLine(string s, string e, Pen p, int temperature, int second)
        {
            using Graphics g = this.CreateGraphics();

            points[e] = new Point(temperature, this.Height - 15 - (8 * second));
            g.DrawLine(p, points[s], points[e]);
            points[s] = points[e];
        }

        public void DrawLine2(string s, string e, Pen p, int temperature, int second)
        {
            using Graphics g = this.CreateGraphics();

            points[e] = new Point(temperature, this.Height - 15 - (8 * second));
            g.DrawLine(p, points[s], points[e]);
            points[s] = points[e];
        }
    }
}
