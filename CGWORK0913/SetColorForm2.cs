using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CGWORK0913
{
    public partial class SetColorForm2 : CGWORK0913.DialogForm
    {
        public SetColorForm2(FormData dfData)
        {
            InitializeComponent();
            this.dfData = dfData;
            textBox1.Text = dfData.r3.ToString();
            textBox2.Text = dfData.g3.ToString();
            textBox3.Text = dfData.b3.ToString();
            textBox6.Text = dfData.r4.ToString();
            textBox5.Text = dfData.g4.ToString();
            textBox4.Text = dfData.b4.ToString();

        }

        private void SetColorForm2_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "设置边界颜色";
            groupBox2.Text = "设置学号颜色";

        }

        private void OKButton_Click_1(object sender, EventArgs e)
        {
            dfData.r3 = Convert.ToInt32(textBox1.Text);
            dfData.g3 = Convert.ToInt32(textBox2.Text);
            dfData.b3 = Convert.ToInt32(textBox3.Text);
            dfData.r4 = Convert.ToInt32(textBox6.Text);
            dfData.g4 = Convert.ToInt32(textBox5.Text);
            dfData.b4 = Convert.ToInt32(textBox4.Text);
            this.Close();
        }
    }
}
