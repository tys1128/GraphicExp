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
            public static Node operator -(Node lhs, Node rhs)
            {
                return new Node(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
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
        /// <summary>
        /// 立方体
        /// </summary>
        class Cube
        {
            public Surface[] Square { get; }
            public Node[] Vertex { get; }
            public Node bg;
            static int size = 80;
            public Cube()
            {
                Square = new Surface[10];
                Vertex = new Node[10];
                Init();
            }
            public void Init()
            {
                bg = new Node(0, 0, 8*size);

                Vertex[0] = new Node(0, 0, 0);
                Vertex[1] = new Node(size, 0, 0);
                Vertex[2] = new Node(size, size, 0);
                Vertex[3] = new Node(0, size, 0);
                Vertex[4] = new Node(0, 0, size);
                Vertex[5] = new Node(size, 0, size);
                Vertex[6] = new Node(size, size, size);
                Vertex[7] = new Node(0, size, size);

                Square[0] = new Surface(0, 1, 2, 3);
                Square[1] = new Surface(1, 0, 4, 5);
                Square[2] = new Surface(1, 5, 6, 2);
                Square[3] = new Surface(3, 2, 6, 7);
                Square[4] = new Surface(4, 0, 3, 7);
                Square[5] = new Surface(7, 6, 5, 4);
            }

            public void MoveAloneX(int d)
            {
                for (int i = 0; i < Vertex.Length; i++)
                {
                    Vertex[i].X += d;
                }
            }
            public void MoveAloneY(int d)
            {
                for (int i = 0; i < Vertex.Length; i++)
                {
                    Vertex[i].Y += d;
                }
            }
            public void MoveAloneZ(int d)
            {
                for (int i = 0; i < Vertex.Length; i++)
                {
                    Vertex[i].Z += d;
                }
            }
            /// <summary>
            /// 旋转
            /// </summary>
            /// <param name="cxcx"></param>
            /// <param name="rad"></param>
            void Rotation(char cxcx, double rad)
            {
                double pi = Math.PI;
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

            public void RotateAroundX(int rad)
            {
                Rotation('x', rad);
            }
            public void RotateAroundY(int rad)
            {
                Rotation('y', rad);

            }
            public void RotateAroundZ(int rad)
            {
                Rotation('z', rad);

            }

        }

        /// <summary>
        /// 三维变换立方体
        /// </summary>
        Cube cube = new Cube();

        /// <summary>
        /// 将三维的点映射到平面,并添加了位移
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        Point ray(Node now)
        {
            Node tt = new Node();
            Point kk = new Point();
            tt.coco = now.Z / (-800) + 1;
            tt.X = now.X / tt.coco;
            tt.Y = now.Y / tt.coco;

            kk.X = (int)(tt.X + 0.5) + 300;
            kk.Y = (int)(tt.Y + 0.5) + 300;

            return kk;
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

        void DrawCube(Cube cb, Graphics graphic)
        {
            Brush[] brushArr = {
                Brushes.LightBlue,
                Brushes.Red,
                Brushes.Orange,
                Brushes.LightGreen,
                Brushes.Yellow,
                Brushes.Cyan,
            };
            Pen pen = new Pen(Color.Black);

            for (int i = 0; i < 6; i++)
            {
                Surface tt = cb.Square[i];
                Node fa = cross(cb.Vertex[tt.b] - cb.Vertex[tt.c], cb.Vertex[tt.a] - cb.Vertex[tt.b]);
                Node fb = cb.Vertex[tt.a] - cb.bg;
                if (!crss(fa, fb))
                {
                    Point a, b, c, d;
                    a = ray(cb.Vertex[tt.a]);
                    b = ray(cb.Vertex[tt.b]);
                    c = ray(cb.Vertex[tt.c]);
                    d = ray(cb.Vertex[tt.d]);

                    graphic.FillPolygon(brushArr[i], new Point[] { a, b, c, d });
                    graphic.DrawLine(pen, a.X, a.Y, b.X, b.Y);
                    graphic.DrawLine(pen, b.X, b.Y, c.X, c.Y);
                    graphic.DrawLine(pen, c.X, c.Y, d.X, d.Y);
                    graphic.DrawLine(pen, d.X, d.Y, a.X, a.Y);
                }
            }
        }

        /// <summary>
        /// 三维变换--绘制一帧，含清空操作
        /// </summary>
        void DrawAFrame()
        {
            graphics.Clear(Color.White);
            DrawCube(cube, graphics);

        }
        /// <summary>
        /// 平移  
        /// 按键为
        ///   W E
        /// A S D
        ///     C  
        /// 旋转
        /// 按键为
        /// U I O
        /// J K L
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown平移旋转(object sender, KeyEventArgs e)
        {
            //平移    
            if (e.KeyCode == Keys.W)//向上 y
            {
                cube.MoveAloneY(-dfData.step);
                DrawAFrame();
            }
            else if (e.KeyCode == Keys.S)//向下 y
            {
                cube.MoveAloneY(dfData.step);
                DrawAFrame();

            }
            else if (e.KeyCode == Keys.A)//向左 x
            {
                cube.MoveAloneX(-dfData.step);
                DrawAFrame();

            }
            else if (e.KeyCode == Keys.D)//向右 x
            {
                cube.MoveAloneX(dfData.step);
                DrawAFrame();

            }
            else if (e.KeyCode == Keys.C)//向外 z
            {
                cube.MoveAloneZ(dfData.step);
                DrawAFrame();

            }
            else if (e.KeyCode == Keys.E)//向内 z
            {
                cube.MoveAloneZ(-dfData.step);
                DrawAFrame();

            }
            //旋转
            else if (e.KeyCode == Keys.I)//x上
            {
                cube.RotateAroundX(dfData.angle);
                DrawAFrame();
            }
            else if (e.KeyCode == Keys.K)//x下
            {
                cube.RotateAroundX(-dfData.angle);
                DrawAFrame();

            }
            else if (e.KeyCode == Keys.J)//y左
            {
                cube.RotateAroundY(dfData.angle);
                DrawAFrame();

            }
            else if (e.KeyCode == Keys.L)//y右
            {
                cube.RotateAroundY(-dfData.angle);
                DrawAFrame();

            }
            else if (e.KeyCode == Keys.O)//z
            {
                cube.RotateAroundZ(dfData.angle);
                DrawAFrame();

            }
            else if (e.KeyCode == Keys.U)//z
            {
                cube.RotateAroundZ(-dfData.angle);
                DrawAFrame();

            }

        }


    }
}
