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
        struct Node
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
            public double coco { get; set; }
            public Node(double a, double b, double c)
            {
                X = a; Y = b; Z = c; coco = 1.0;
            }
            public static Node operator -(Node lhs ,Node rhs)
            {
                return new Node(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
            }
        };

        struct Surface
        {
            public int a, b, c, d;
            public Surface(int a,int b,int c,int d)
            {
                this.a = a; 
                this.b = b;
                this.c = c;
                this.d = d;

            }
        };
        Surface[] surface= new Surface[10];

        Node[] vertex= new Node[10];
        Node bg;

        void init()
        {
            bg = new Node(0, 0, 800);

            vertex[0] = new Node(0, 0, 0);
            vertex[1] = new Node(100, 0, 0);
            vertex[2] = new Node(100, 100, 0);
            vertex[3] = new Node(0, 100, 0);
            vertex[4] = new Node(0, 0, 100);
            vertex[5] = new Node(100, 0, 100);
            vertex[6] = new Node(100, 100, 100);
            vertex[7] = new Node(0, 100, 100);

            surface[0] = new Surface( 0, 1, 2, 3);
            surface[1] = new Surface( 1, 0, 4, 5);
            surface[2] = new Surface( 1, 5, 6, 2);
            surface[3] = new Surface( 3, 2, 6, 7);
            surface[4] = new Surface( 4, 0, 3, 7);
            surface[5] = new Surface( 7, 6, 5, 4);
        }


        Point ray(Node now)
        {
            Node tt = new Node();
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
                if (cxcx == 'x') vertex[i].X += len;
                else if (cxcx == 'y') vertex[i].Y += len;
                else vertex[i].Z += len;
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
                double x = vertex[i].X;
                double y = vertex[i].Y;
                double z = vertex[i].Z;
                if (cxcx == 'x')
                {
                    vertex[i].Y = y * c - z * s;
                    vertex[i].Z = y * s + z * c;
                }
                else if (cxcx == 'y')
                {
                    vertex[i].X = x * c + z * s;
                    vertex[i].Z = x * (-s) + z * c;
                }
                else
                {
                    vertex[i].X = x * c - y * s;
                    vertex[i].Y = x * s + c * y;
                }
            }
        }

        Node cross(Node a, Node b)
        {
            Node tt = new Node();
            tt.X = a.Y * b.Z - a.Z * b.Y;
            tt.Y = a.Z * b.X - a.X * b.Z;
            tt.Z = a.X * b.Y - a.Y * b.X;
            return tt;
        }

        bool crss(Node a, Node b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z > 0;
        }

        void cube_draw(Graphics graphic)
        {
            for (int i = 0; i < 6; i++)
            {
                Surface tt = surface[i];
                Node fa = cross(vertex[tt.b] - vertex[tt.c], vertex[tt.a] - vertex[tt.b]);
                Node fb = vertex[tt.a] - bg;
                if (crss(fa, fb))
                {
                    Point a, b, c, d;
                    a = ray(vertex[tt.a]);
                    b = ray(vertex[tt.b]);
                    c = ray(vertex[tt.c]);
                    d = ray(vertex[tt.d]);

                    DDALine(graphic, a.X + 300, a.Y + 300, b.X + 300, b.Y + 300, Color.Black);
                    DDALine(graphic, b.X + 300, b.Y + 300, c.X + 300, c.Y + 300, Color.Black);
                    DDALine(graphic, c.X + 300, c.Y + 300, d.X + 300, d.Y + 300, Color.Black);
                    DDALine(graphic, d.X + 300, d.Y + 300, a.X + 300, a.Y + 300, Color.Black);
                }
            }
        }

        private void InitAndDraw()
        {
            init();
            cube_draw(graphics);
        }



        private void Form1_KeyDown平移旋转(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}
