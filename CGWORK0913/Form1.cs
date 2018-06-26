using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGWORK0913
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Graphics对象
        /// </summary>
        Graphics graphics;
        Bitmap bitmap;
        /// <summary>
        /// 标记当前的二级菜单
        /// </summary>
        string currentMode = "图形绘制";
        /// <summary>
        /// 标记当前的三级菜单
        /// </summary>
        string currentState = "矩形";
        /// <summary>
        /// 存储颜色数据
        /// </summary>
        FormData dfData = new FormData();
        /// <summary>
        /// 保存图像状态
        /// </summary>



        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(700, 600);

            graphics = Graphics.FromImage(bitmap);
            canvas.BackgroundImage = bitmap;

            graphics = canvas.CreateGraphics();

            TextBox.Text = "图形绘制" + "-" + "矩形";

        }
        /// <summary>
        /// 判断当前的模式,
        /// </summary>
        /// <param name="thisMode">模式名称</param>
        ///
        /// <summary>
        /// 判断当前的模式
        /// </summary>
        /// <param name="thisMode">二级菜单名称</param>
        /// <param name="thisState">三级菜单名称</param>
        void ConvertToModAndState(string thisMode, string thisState)
        {
            if (currentMode != thisMode)
            {
                currentMode = thisMode;
                清空屏幕初始化ToolStripMenuItem_Click(null, null);
            }
            currentState = thisState;
            TextBox.Text = thisMode + "-" + thisState;
        }
        private void 清空屏幕初始化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            poly = new Polygon();
            polyB = new Polygon();
            cube = new Cube();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            //graphics.Restore(gState);
            canvas.BackgroundImage = bitmap;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
        }

        private void 绘制矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToModAndState("图形绘制", "矩形");

        }

        private void 绘制圆形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToModAndState("图形绘制", "圆形");

        }

        private void 设置颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SetColorForm1(dfData).ShowDialog();
        }




        private void 绘制多边形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToModAndState("区域填充", "多边形");

        }

        private void 设置颜色ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new SetColorForm2(dfData).ShowDialog();

        }




        private void 绘制立方体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToModAndState("三维变换", "立方体");
            cube = new Cube();
            DrawAFrame();
        }

        private void 平移旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToModAndState("三维变换", "平移旋转");
            DrawAFrame();

        }

        private void 设置数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SetDataForm(dfData).ShowDialog();
        }




        private void 绘制Bezier曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToModAndState("绘制曲线", "Bezier曲线");

        }

        private void 绘制B样条曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToModAndState("绘制曲线", "B样条曲线");
        }

    }
}
