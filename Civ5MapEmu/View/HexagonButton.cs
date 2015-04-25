using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Civ5MapEmu.View
{
    public enum Orientation { Vertical, Horizontal };
    public partial class HexagonButton : Button
    {
        private Orientation _orientation;
        public HexagonButton() : this(30, default(Point)) { }
        public HexagonButton(int r, Point center, Orientation o = Orientation.Vertical)
        {
            InitializeComponent();
            _orientation = o;
            if (_orientation == Orientation.Vertical)
            {
                int x = center.X - (int)(Math.Sin(Math.PI / 3) * r);
                int y = center.Y - r;
                Location = new Point(x, y);
                Height = 2 * r;
            }
            else
            {
                int x = center.X - r;
                int y = center.Y - (int)(Math.Sin(Math.PI / 3) * r);
                Location = new Point(x, y);
                Width = 2 * r;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            Rectangle newRectangle = ClientRectangle;
            var path = new GraphicsPath();
            PointF[] hexagon = CreateHexagon();
            path.AddPolygon(hexagon);
            Region = new Region(path);
            g.DrawPolygon(new Pen(Color.Gray,2), hexagon);
        }

        private PointF[] CreateHexagon()
        {
            int centerX = ClientRectangle.Location.X + Width / 2;
            int centerY = ClientRectangle.Location.Y + Height / 2;
            int r = _orientation == Orientation.Vertical ? Height / 2 : Width / 2;
            double initAngle = _orientation == Orientation.Vertical ? 0 : Math.PI / 6;
            PointF[] hexagon = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                var angle = i * Math.PI / 3 + initAngle;
                float x = (float)(centerX + r * Math.Sin(angle));
                float y = (float)(centerY + r * Math.Cos(angle));
                hexagon[i] = new PointF(x, y);
            }
            return hexagon;
        }

        //lock aspect ratio
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_orientation == Orientation.Vertical)
            {
                Width = (int)(Math.Sin(Math.PI / 3) * Height);
            }
            else
            {
                Height = (int)(Math.Sin(Math.PI / 3) * Width);
            }

        }

        private void Tile_MouseUp(object sender, MouseEventArgs e)
        {
            HexagonButton t = (HexagonButton)sender;
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show(t.Name + ".left");
            }
            else if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(t.Name + ".Right");
            }
        }


        [Description("Orientation of the tile."), Category("Appearance")]
        public Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                _orientation = value;
                int longEdge = Math.Max(Height, Width);
                if (value == Orientation.Vertical)
                {
                    Height = longEdge;
                }
                else
                {
                    Width = longEdge;
                }
                Invalidate();
            }
        }
    }
}
