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
        Graphics graphics;

        public Form1()
        {
            InitializeComponent();
            graphics = canvas.CreateGraphics();
            TextBox.Text = "图形绘制" + "-" + "矩形";

            //graphics.Save
        }
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
        /// 判断当前的模式,
        /// </summary>
        /// <param name="thisMode">模式名称</param>
        void ConvertToModAndState(string thisMode, string thisState)
        {
            if (currentMode != thisMode)
            {
                currentMode = thisMode;
                graphics.Clear(Color.White);
            }
            currentState = thisState;
            TextBox.Text = thisMode + "-"+ thisState;
        }
        private void 清空屏幕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
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
            InitAndDraw();
            init();
            cube_draw(graphics);
        }

        private void 延X轴方向平移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToModAndState("三维变换", "平移旋转");

        }

        private void 绕X轴旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToModAndState("三维变换", "圆形");

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
