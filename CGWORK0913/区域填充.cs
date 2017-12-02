using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGWORK0913
{
    /// <summary>
    /// 多边形边
    /// </summary>
    class Line_poly
    {
        public double X { get; set; }
        public int Y { get; set; }
        public double M { get; set; }
        //public static bool operator <(Line_poly kt1, Line_poly kt2) => kt1.X > kt2.X;
    };
    /// <summary>
    /// 多边形
    /// </summary>
    class Polygon
    {
        //vector<CPoint> list;
        public List<Point> list = new List<Point>();
    };
    /// <summary>
    /// 排序
    /// </summary>
    sealed class MyComparer : Comparer<Line_poly>
    {
        //public bool Compare(Line_poly kt1, Line_poly kt2) => kt1.X > kt2.X;
        public override int Compare(Line_poly x, Line_poly y)
        {
            return (int)(x.X - y.X) <= 0 ? -1 : 1;
        }
    }
    public partial class Form1 : Form
    {
        char[,] background = {
            {'1','1','1',' ','1','1','1',' ',' ','1',' ',' ','1','1','1',' ',' ',' '},
            {'1',' ','1',' ','1',' ','1',' ',' ','1',' ',' ',' ',' ','1',' ',' ',' '},
            {'1',' ','1',' ','1','1','1',' ',' ','1',' ',' ','1','1','1',' ',' ',' '},
            {'1',' ','1',' ',' ',' ','1',' ',' ','1',' ',' ',' ',' ','1',' ',' ',' '},
            {'1','1','1',' ','1','1','1',' ',' ','1',' ',' ','1','1','1',' ',' ',' '},
            {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '}
        };

        //PriorityQueue<Line_poly> mp = new Queue<Line_poly>(20000);

        /// <summary>
        /// 获得要显示的文字的像素信息
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool chooseColor(int x, int y)
        {
            if (background[(x % 30) / 5, (y % 90) / 5] == '1') return true;
            else return false;
        }
        /// <summary>
        /// 填充多边形
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="graphic"></param>
        void Polygonfill(Polygon poly, Graphics graphic)
        {
            //SortedList<Line_poly, object> mp = new SortedList<Line_poly, object>(new MyComparer());
            List<SortedList> mp = new List<SortedList>();
            MyComparer comparer = new MyComparer();
            for (int i = 0; i < 2000; i++)
            {
                mp.Add(new SortedList(comparer));
            }

            int mod = poly.list.Count;
            for (int i = 0; i < (int)poly.list.Count; i++)
            {
                DDALine(graphic, poly.list[i].X, poly.list[i].Y, poly.list[(i + 1) % mod].X, poly.list[(i + 1) % mod].Y, dfData.GetColor多边形());
            }

            int top_max = 0;
            for (int i = 0; i < (int)poly.list.Count; i++)
            {
                top_max = Math.Max(top_max, poly.list[i].Y);
                Line_poly tt = new Line_poly();
                if (poly.list[i].Y == poly.list[(i + 1) % mod].Y) continue;

                if (poly.list[i].Y > poly.list[(i + 1) % mod].Y)
                {
                    tt.Y = poly.list[i].Y;
                    tt.X = poly.list[(i + 1) % mod].X;
                }
                else
                {
                    tt.Y = poly.list[(i + 1) % mod].Y;
                    tt.X = poly.list[i].X;
                }
                tt.M = (poly.list[i].X - poly.list[(i + 1) % mod].X) * 1.0 / (poly.list[i].Y - poly.list[(i + 1) % mod].Y);

                mp[Math.Min(poly.list[i].Y, poly.list[(i + 1) % mod].Y)].Add(tt, null);
            }

            for (int i = 0; i < top_max; i++)
            {
                while (mp[i].Count != 0)
                {
                    Line_poly a = (Line_poly)mp[i].GetKey(0);
                    mp[i].RemoveAt(0);
                    Line_poly b = (Line_poly)mp[i].GetKey(0);
                    mp[i].RemoveAt(0);

                    for (int j = (int)(a.X + 0.5) + 1; j < (int)(b.X + 0.5); j++)
                    {
                        if (chooseColor(i, j))
                            SetPixel(graphic, j, i, dfData.GetColor填充字());
                    }
                    a.X = a.X + a.M;
                    b.X = b.X + b.M;
                    if (a.Y > i + 1) mp[i + 1].Add(a, null);
                    if (b.Y > i + 1) mp[i + 1].Add(b, null);
                }
            }
        }

        /// <summary>
        /// 区域填充--多边形
        /// </summary>
        Polygon poly = new Polygon();
        private void canvas_MouseDown多边形(object sender, MouseEventArgs e)
        {
            poly.list.Add(e.Location);
            int count = poly.list.Count;
            //画线
            if (poly.list.Count >= 2)
            {
                Point st = poly.list[count - 1];
                Point ed = poly.list[count - 2];

                DDALine(graphics, st.X, st.Y, ed.X, ed.Y, dfData.GetColor多边形());
            }

        }

        private void Form1_KeyDown多边形(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int count = poly.list.Count;

                Point st = poly.list[count - 1];
                Point ed = poly.list[0];

                DDALine(graphics, st.X, st.Y, ed.X, ed.Y, dfData.GetColor多边形());
                Polygonfill(poly, graphics);
            }

        }

    }
}
