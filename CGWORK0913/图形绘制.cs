using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGWORK0913
{
    public partial class Form1 : Form
    {
        void SetPixel(Graphics grph, int x, int y, Color color)
        {
            //grph.DrawLine(new Pen(color) { Width = 10 }, (int)(x + 0.5), (int)(y + 0.5), (int)(x + 0.5)+1, (int)(y + 0.5)+1);
            grph.DrawRectangle(new Pen(color) { Width = 2 }, (int)(x + 0.5), (int)(y + 0.5), 1,1);
        }

        /// <summary>
        /// 画线
        /// </summary>
        void DDALine(Graphics grph, int sx, int sy, int ex, int ey, Color color)
        {
            double dx, dy, e, x, y;
            dx = ex - sx;
            dy = ey - sy;
            e = (Math.Abs(dx) > Math.Abs(dy)) ? Math.Abs(dx) : Math.Abs(dy);
            dx /= e;
            dy /= e;
            x = sx;
            y = sy;
            for (int i = 1; i <= e; i++)
            {
                SetPixel(grph, (int)(x + 0.5), (int)(y + 0.5), color);
                x += dx;
                y += dy;
            }
        }
        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="st"></param>
        /// <param name="ed"></param>
        /// <param name="grph"></param>
        void PaintRec(Point st, Point ed, Graphics grph)
        {
            Color color_Rec = dfData.GetColor1();
            DDALine(grph, st.X, st.Y, st.X, ed.Y, color_Rec);
            DDALine(grph, st.X, st.Y, ed.X, st.Y, color_Rec);
            DDALine(grph, st.X, ed.Y, ed.X, ed.Y, color_Rec);
            DDALine(grph, ed.X, st.Y, ed.X, ed.Y, color_Rec);
        }
        /// <summary>
        /// 画圆型
        /// </summary>
        /// <param name="st"></param>
        /// <param name="ed"></param>
        /// <param name="grph"></param>
        void BresenhamCircle(Point st, Point ed, Graphics grph)
        {

            int R = (int)Math.Sqrt((st.X - ed.X) * (st.X - ed.X) + (st.Y - ed.Y) * (st.Y - ed.Y));
            int x, y, p;
            x = 0;
            y = R;
            p = 3 - 2 * R;
            Color color_Cir = dfData.GetColor2();
            for (; x <= y; x++)
            {
                SetPixel(grph,st.X + x, st.Y + y, color_Cir);
                SetPixel(grph,st.X + y, st.Y + x, color_Cir);
                SetPixel(grph,st.X + x, st.Y - y, color_Cir);
                SetPixel(grph,st.X + y, st.Y - x, color_Cir);
                SetPixel(grph,st.X - x, st.Y + y, color_Cir);
                SetPixel(grph,st.X - y, st.Y + x, color_Cir);
                SetPixel(grph,st.X - x, st.Y - y, color_Cir);
                SetPixel(grph,st.X - y, st.Y - x, color_Cir);

                if (p >= 0)
                {
                    p += 4 * (x - y) + 10;
                    y--;
                }
                else
                {
                    p += 4 * x + 6;
                }
            }
        }
        //矩形
        private void canvas_MouseDown矩形(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;
            startPoint = e.Location;
            endPoint = e.Location;
            
        }

        private void canvas_MouseMove矩形(object sender, MouseEventArgs e)
        {
            while (mouseIsDown)
            {
                endPoint = e.Location;
                mouseIsDown = false;
                PaintRec(startPoint, endPoint, graphics);
                //PaintRec(startPoint, e.Location, graphics);
            }
        }

        private void canvas_MouseUp矩形(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            endPoint = e.Location;
            PaintRec(startPoint, endPoint, graphics);
            
        }

        //圆形
        private void canvas_MouseDown圆型(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;
            startPoint = e.Location;
            endPoint = e.Location;
        }

        private void canvas_MouseMove圆型(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {

            }
        }

        private void canvas_MouseUp圆型(object sender, MouseEventArgs e)
        {

        }

    }
}