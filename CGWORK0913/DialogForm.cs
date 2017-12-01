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
    /// <summary>
    /// 两个选择颜色对话框的基类
    /// </summary>
    public partial class DialogForm : Form
    {
        protected FormData dfData;

        public DialogForm()
        {
            InitializeComponent();

        }


        protected void quitButton_Click(object sender, EventArgs e)
        {

        }


    }
    public class FormData
    {
        public int r1 = 0, g1 = 0, b1 = 0;//矩形颜色
        public int r2 = 0, g2 = 0, b2 = 0;//圆形颜色
        public int r3 = 0, g3 = 0, b3 = 0;//多边形颜色
        public int r4 = 0, g4 = 0, b4 = 0;//填充字体颜色
        public int step = 1, angle = 10;//步长、角度

        public Color GetColor1()
        {
            return Color.FromArgb(r1, g1, b1);
        }
        public Color GetColor2()
        {
            return Color.FromArgb(r2, g2, b3);
        }
        public Color GetColor3()
        {
            return Color.FromArgb(r3, g3, b3);
        }
        public Color GetColor4()
        {
            return Color.FromArgb(r4, g4, b4);
        }

    }

}
