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

        char[,] background = {
        {'1','1','1',' ','1','1','1',' ',' ','1',' ',' ','1','1','1',' ',' ',' '},
        {'1',' ','1',' ','1',' ','1',' ',' ','1',' ',' ',' ',' ','1',' ',' ',' '},
        {'1',' ','1',' ','1','1','1',' ',' ','1',' ',' ','1','1','1',' ',' ',' '},
        {'1',' ','1',' ',' ',' ','1',' ',' ','1',' ',' ',' ',' ','1',' ',' ',' '},
        {'1','1','1',' ','1','1','1',' ',' ','1',' ',' ','1','1','1',' ',' ',' '},
        {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '}
    };
        bool chooseColor(int x, int y)
        {
            if (background[(x % 30) / 5][(y % 100) / 5] == '1') return true;
            else return false;
        }

        struct Line
        {
            Point s, e;
        };

        class Line_poly
        {
            public int Y { get; set ; }
            public double X { get; set ; }
            public double M { get; set ; }
            public bool operator <(Line_poly kt) => X > kt.X;
            public bool operator >(Line_poly kt) => X < kt.X;
        };

        class Polygon
        {
            //vector<CPoint> list;
            public List<Point> list = new List<Point>();
        };
        List<Polygon> list_Pol;
        Polygon tmp;

        Queue<Line_poly> mp = new Queue<Line_poly>(20000);

        void Polygonfill(Polygon poly, Graphics graphic)
        {
            int mod = poly.list.Count;
            for (int i = 0; i < (int)poly.list.Count; i++)
            {
                DDALine(graphic, poly.list[i].X, poly.list[i].Y, poly.list[(i + 1) % mod].X, poly.list[(i + 1) % mod].Y, dfData.GetColor3());
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

                mp[Math.Min(poly.list[i].Y, poly.list[(i + 1) % mod].Y)].push(tt);
            }

            for (int i = 0; i < top_max; i++)
            {
                while (!mp[i].empty())
                {
                    Line_poly a = mp[i].top();
                    mp[i].pop();
                    Line_poly b = mp[i].top();
                    mp[i].pop();

                    for (int j = (int)(a.X + 0.5) + 1; j < (int)(b.X + 0.5); j++)
                    {
                        if (chooseColor(i, j))
                            SetPixel(graphic, j, i, dfData.GetColor3());
                    }
                    a.X = a.X + a.M;
                    b.X = b.X + b.M;
                    if (a.Y > i + 1) mp[i + 1].push(a);
                    if (b.Y > i + 1) mp[i + 1].push(b);
                }
            }

        }



    }
}
