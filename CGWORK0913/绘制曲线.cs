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
        /// <summary>
        /// 绘制Bezier曲线
        /// </summary>
        /// <param name="bez">控制多边形</param>
        /// <param name="npoints">曲线上点的数量</param>
        /// <param name="graphic"></param>
        void bezpoints(Polygon bez, int npoints, Graphics graphic)
        {
            double t, delt;
            delt = 1.0 / (double)npoints;
            t = 0.0;
            Point st, ed;
            st = ed = bez.list[0];
            for (int i = 0; i <= npoints; i++)
            {
                ed = decas(bez, t);
                DDALine(graphic, st.X, st.Y, ed.X, ed.Y, Color.Cyan);
                st = ed;
                t += delt;
            }
        }
        Point decas(Polygon bez, double t)
        {
            Point[] R = new Point[10];
            Point[] Q = new Point[10];
            Point P0 = new Point();
            for (int i = 0; i < bez.list.Count; i++)
            {
                R[i] = bez.list[i];

            }
            int m = (int)bez.list.Count - 1;

            for (; m > 0; m--)
            {
                for (int i = 0; i <= m - 1; i++)
                {
                    Q[i].X = (int)(R[i].X + t * (R[i + 1].X - R[i].X));
                    Q[i].Y = (int)(R[i].Y + t * (R[i + 1].Y - R[i].Y));
                }
                for (int i = 0; i <= m - 1; i++) R[i] = Q[i];
            }
            P0 = R[0];
            return P0;
        }
        //B样条曲线
        double[] knot = new double[1000];

        /// <summary>
        /// 绘制B样条曲线
        /// </summary>
        /// <param name="bsp">控制多边形;  初始点记三次,结束点记三次</param>
        /// <param name="k">k阶B样条</param>
        /// <param name="npoints">为绘制曲线上的点所用的点的数目</param>
        /// <param name="graphic"></param>
        void bsppoints(Polygon bsp, int k, int npoints, Graphics graphic)
        {
            double u, delt;
            int n = (int)bsp.list.Count - 1;
            int i = 0;
            for (i = 0; i <= n + k; i++) knot[i] = i;
            //for ( i = k; i <= n; i++) knot[i] = i - k + 1;
            //for ( i = n + k; i > n; i--) knot[i] = n - k + 2;

            delt = (knot[n + 1] - knot[k - 1]) / (double)npoints;
            i = k - 1;
            u = knot[k - 1];
            bool flag = false;
            Point st = new Point();
            Point ed = new Point();
            for (int j = 0; j <= npoints; j++)
            {
                while ((i < n) && u > knot[i + 1]) i++;
                ed = deboor(bsp, i, k, u);
                if (flag)
                    DDALine(graphic, st.X, st.Y, ed.X, ed.Y, Color.DarkCyan);
                flag = true;
                st = ed;
                u += delt;
            }
        }
        Point deboor(Polygon bsp, int i, int k, double u)
        {
            double denom, alpha;
            Point[] p = new Point[10];
            const double eps = 0.005;

            for (int j = 0; j < k; j++)
            {
                p[j] = bsp.list[i - k + 1 + j];
            }
            for (int r = 1; r < k; r++)
            {
                for (int m = k - 1; m >= r; m--)
                {
                    int j;
                    j = m + i - k + 1;
                    denom = knot[j + k - r] - knot[j];
                    if (Math.Abs(denom) < eps) alpha = 0;
                    else alpha = (u - knot[j]) / denom;

                    p[m].X = (int)((1 - alpha) * p[m - 1].X + alpha * p[m].X);
                    p[m].Y = (int)((1 - alpha) * p[m - 1].Y + alpha * p[m].Y);
                }
            }
            return p[k - 1];
        }



        /// <summary>
        /// B样条曲线和Bezier曲线的控制多边形
        /// </summary>
        Polygon polyB = new Polygon();

        private void canvas_MouseDownBezier曲线(object sender, MouseEventArgs e)
        {
            polyB.list.Add(e.Location);
            int count = polyB.list.Count;
            //画线
            if (polyB.list.Count >= 2)
            {
                Point st = polyB.list[count - 1];
                Point ed = polyB.list[count - 2];

                DDALine(graphics, st.X, st.Y, ed.X, ed.Y, Color.DarkGray);
            }
        }
        private void Form1_KeyDownBezier曲线(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bezpoints(polyB, 2000, graphics);
                polyB.list.Clear();
            }

        }


        private void canvas_MouseDownB样条曲线(object sender, MouseEventArgs e)
        {
            //画线
            if(polyB.list.Count == 0)//初始点记三次
            {
                for(int i = 0; i < 3; i++)
                {
                    polyB.list.Add(e.Location);
                }
            }
            else if (polyB.list.Count >= 2)
            {
                polyB.list.Add(e.Location);
                Point st = polyB.list[polyB.list.Count - 1];
                Point ed = polyB.list[polyB.list.Count - 2];

                DDALine(graphics, st.X, st.Y, ed.X, ed.Y, Color.DarkGray);
            }

        }
        private void Form1_KeyDownB样条曲线(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < 2; i++)//结束点记3次(1 + 2)
                {
                    polyB.list.Add(polyB.list.Last());
                }
                bsppoints(polyB , 4, 2000, graphics);
                polyB.list.Clear();
            }

        }


    }
}
