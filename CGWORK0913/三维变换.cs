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
        /// 用于存储立方体的顶点
        /// </summary>
        struct Edge
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
            public double coco { get; set; }
            public Edge(double a, double b, double c)
            {
                X = a; Y = b; Z = c; coco = 1.0;
            }
            public static Edge operator -(Edge lhs, Edge rhs)
            {
                return new Edge(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
            }
        };
        /// <summary>
        /// 用于存储立方体的表面
        /// </summary>
        struct Surface
        {
            public int a, b, c, d;
            public Surface(int a, int b, int c, int d)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                this.d = d;
            }
        };
        class Cube
        {
            public Surface[] Square { get; }
            public Edge[] Vertex { get; }

            public Cube()
            {
                Square = new Surface[10];
                Vertex = new Edge[10];
                Init();
            }
            public void Init()
            {
                Vertex[0] = new Edge(0, 0, 0);
                Vertex[1] = new Edge(100, 0, 0);
                Vertex[2] = new Edge(100, 100, 0);
                Vertex[3] = new Edge(0, 100, 0);
                Vertex[4] = new Edge(0, 0, 100);
                Vertex[5] = new Edge(100, 0, 100);
                Vertex[6] = new Edge(100, 100, 100);
                Vertex[7] = new Edge(0, 100, 100);

                Square[0] = new Surface(0, 1, 2, 3);
                Square[1] = new Surface(1, 0, 4, 5);
                Square[2] = new Surface(1, 5, 6, 2);
                Square[3] = new Surface(3, 2, 6, 7);
                Square[4] = new Surface(4, 0, 3, 7);
                Square[5] = new Surface(7, 6, 5, 4);
            }

            public void MoveAloneX(int d)
            {
                //foreach(var ver)
            }
            public void MoveAloneY(int d)
            {

            }
            public void MoveAloneZ(int d)
            {

            }

        }
        Surface[] Square = new Surface[10];
        Edge[] Vertex = new Edge[10];

        Cube cube = new Cube();
        Edge bg;

        void Init()
        {
            bg = new Edge(0, 0, 800);

            Vertex[0] = new Edge(0, 0, 0);
            Vertex[1] = new Edge(100, 0, 0);
            Vertex[2] = new Edge(100, 100, 0);
            Vertex[3] = new Edge(0, 100, 0);
            Vertex[4] = new Edge(0, 0, 100);
            Vertex[5] = new Edge(100, 0, 100);
            Vertex[6] = new Edge(100, 100, 100);
            Vertex[7] = new Edge(0, 100, 100);

            Square[0] = new Surface(0, 1, 2, 3);
            Square[1] = new Surface(1, 0, 4, 5);
            Square[2] = new Surface(1, 5, 6, 2);
            Square[3] = new Surface(3, 2, 6, 7);
            Square[4] = new Surface(4, 0, 3, 7);
            Square[5] = new Surface(7, 6, 5, 4);
        }


        Point ray(Edge now)
        {
            Edge tt = new Edge();
            tt.coco = now.Z / (-800) + 1;
            tt.X = now.X / tt.coco;
            tt.Y = now.Y / tt.coco;

            Point kk = new Point();
            kk.X = (int)(tt.X + 0.5);
            kk.Y = (int)(tt.Y + 0.5);


            return kk;
        }

        void translation(char cxcx, double len)
        {
            for (int i = 0; i < 8; i++)
            {
                if (cxcx == 'x') Vertex[i].X += len;
                else if (cxcx == 'y') Vertex[i].Y += len;
                else Vertex[i].Z += len;
            }
        }

        void rotation(char cxcx, double rad)
        {
            double pi = Math.Acos(-1.0);
            double r = rad * pi / 180;
            double s = Math.Sin(r);
            double c = Math.Cos(r);

            for (int i = 0; i < 8; i++)
            {
                double x = Vertex[i].X;
                double y = Vertex[i].Y;
                double z = Vertex[i].Z;
                if (cxcx == 'x')
                {
                    Vertex[i].Y = y * c - z * s;
                    Vertex[i].Z = y * s + z * c;
                }
                else if (cxcx == 'y')
                {
                    Vertex[i].X = x * c + z * s;
                    Vertex[i].Z = x * (-s) + z * c;
                }
                else
                {
                    Vertex[i].X = x * c - y * s;
                    Vertex[i].Y = x * s + c * y;
                }
            }
        }

        Edge cross(Edge a, Edge b)
        {
            Edge tt = new Edge();
            tt.X = a.Y * b.Z - a.Z * b.Y;
            tt.Y = a.Z * b.X - a.X * b.Z;
            tt.Z = a.X * b.Y - a.Y * b.X;
            return tt;
        }

        bool crss(Edge a, Edge b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z > 0;
        }

        void DrawCube(Graphics graphic)
        {
            for (int i = 0; i < 6; i++)
            {
                Surface tt = Square[i];
                Edge fa = cross(Vertex[tt.b] - Vertex[tt.c], Vertex[tt.a] - Vertex[tt.b]);
                Edge fb = Vertex[tt.a] - bg;
                if (crss(fa, fb))
                {
                    Point a, b, c, d;
                    a = ray(Vertex[tt.a]);
                    b = ray(Vertex[tt.b]);
                    c = ray(Vertex[tt.c]);
                    d = ray(Vertex[tt.d]);



                    DDALine(graphic, a.X + 300, a.Y + 300, b.X + 300, b.Y + 300, Color.Black);
                    DDALine(graphic, b.X + 300, b.Y + 300, c.X + 300, c.Y + 300, Color.Black);
                    DDALine(graphic, c.X + 300, c.Y + 300, d.X + 300, d.Y + 300, Color.Black);
                    DDALine(graphic, d.X + 300, d.Y + 300, a.X + 300, a.Y + 300, Color.Black);
                }
            }
        }

        private void InitAndDraw()
        {
            Init();
            DrawCube(graphics);
        }



        private void Form1_KeyDown平移旋转(object sender, KeyEventArgs e)
        {
            //平移
            if (e.KeyCode == Keys.E)//向上 y
            {

            }
            else if (e.KeyCode == Keys.D)//向下 y
            {

            }
            else if (e.KeyCode == Keys.S)//向左 x
            {

            }
            else if (e.KeyCode == Keys.F)//向右 x
            {

            }
            else if (e.KeyCode == Keys.W)//向外 z
            {

            }
            else if (e.KeyCode == Keys.R)//向内 z
            {

            }
            //旋转
            else if (e.KeyCode == Keys.I)
            {

            }
            else if (e.KeyCode == Keys.K)
            {

            }
            else if (e.KeyCode == Keys.J)
            {

            }
            else if (e.KeyCode == Keys.L)
            {

            }
            else if (e.KeyCode == Keys.U)
            {

            }
            else if (e.KeyCode == Keys.O)
            {

            }

        }


    }
}
