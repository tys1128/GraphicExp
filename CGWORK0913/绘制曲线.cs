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
        //Bezier曲线
        Polygon bez;
        /// <summary>
        /// 绘制Bezier曲线
        /// </summary>
        /// <param name="bez"></param>
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
                DDALine(graphic, st.X, st.Y, ed.X, ed.Y, Color.Black);
                st = ed;
                t += delt;
            }
        }
        Point decas(Polygon bez, double t)
        {
            Point[] R= new Point[10];
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
        /// <param name="bsp"></param>
        /// <param name="k"></param>
        /// <param name="npoints"></param>
        /// <param name="graphic"></param>
        void bsppoints(Polygon bsp, int k, int npoints, Graphics graphic)
        {
            double u, delt;
            int n = (int)bsp.list.Count - 1;
            int i = 0;
            for ( i = 0; i < k; i++) knot[i] = 0;
            for ( i = k; i <= n; i++) knot[i] = i - k + 1;
            for ( i = n + k; i > n; i--) knot[i] = n - k + 2;

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
                    DDALine(graphic, st.X, st.Y, ed.X, ed.Y, Color.Black);
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

        private void canvas_MouseDownB样条曲线形(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void canvas_MouseDownBezier曲线(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
