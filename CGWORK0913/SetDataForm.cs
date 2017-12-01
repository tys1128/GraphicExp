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
    public partial class SetDataForm : Form
    {
        FormData dfData;
        public SetDataForm(FormData dfData)
        {
            InitializeComponent();
            this.dfData = dfData;
            textBox6.Text = dfData.step.ToString();
            textBox5.Text = dfData.angle.ToString();
            
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            dfData.step = Convert.ToInt32(textBox6.Text);
            dfData.angle = Convert.ToInt32(textBox5.Text);
            this.Close();
        }
    }
}
