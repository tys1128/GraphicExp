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
            graphics = panel1.CreateGraphics();

        }

        string currentMode = "图形应用";//标记当前模式名
        FormData dfData = new FormData();//存储数据；

        /// <summary>
        /// 判断当前的模式,
        /// </summary>
        /// <param name="thisMode">模式名称</param>
        void JudgeMod(string thisMode)
        {
            if (currentMode != thisMode)
            {
                currentMode = thisMode;
                graphics.Clear(Color.White);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
        }

        private void 绘制矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JudgeMod("图形绘制");

        }

        private void 绘制圆形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JudgeMod("图形绘制");

        }

        private void 设置颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SetColorForm1(dfData).ShowDialog();
        }




        private void 绘制多边形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JudgeMod("区域填充");

        }

        private void 设置颜色ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new SetColorForm2(dfData).ShowDialog();

        }




        private void 绘制立方体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JudgeMod("三维变换");

        }

        private void 延X轴方向平移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JudgeMod("三维变换");

        }

        private void 绕X轴旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JudgeMod("三维变换");

        }

        private void 设置数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SetDataForm(dfData).ShowDialog();
        }




        private void 绘制Bezier曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JudgeMod("绘制曲线");

        }

        private void 绘制B样条曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
