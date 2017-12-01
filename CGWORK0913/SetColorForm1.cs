using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CGWORK0913
{
    public partial class SetColorForm1 : CGWORK0913.DialogForm
    {
        public SetColorForm1(FormData dfData)
        {
            InitializeComponent();
            this.dfData = dfData;
            textBox1.Text = dfData.r1.ToString();
            textBox2.Text = dfData.g1.ToString();
            textBox3.Text = dfData.b1.ToString();
            textBox6.Text = dfData.r2.ToString();
            textBox5.Text = dfData.g2.ToString();
            textBox4.Text = dfData.b2.ToString();

        }

        private void SetColorForm1_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "设置矩型颜色";
            groupBox2.Text = "设置圆型颜色";

        }

        private void OKButton_Click_1(object sender, EventArgs e)
        {
            dfData.r1 = Convert.ToInt32(textBox1.Text);
            dfData.g1 = Convert.ToInt32(textBox2.Text);
            dfData.b1 = Convert.ToInt32(textBox3.Text);
            dfData.r2 = Convert.ToInt32(textBox6.Text);
            dfData.g2 = Convert.ToInt32(textBox5.Text);
            dfData.b2 = Convert.ToInt32(textBox4.Text);
            this.Close();

        }
    }
}
