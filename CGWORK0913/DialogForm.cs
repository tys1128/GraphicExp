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


        protected void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void quitButton_Click(object sender, EventArgs e)
        {

        }


    }
}
