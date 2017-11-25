using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicExp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string currentMode = null;
        int r1 = 0, g1 = 0, b1 = 0;
        int r2 = 0, g2 = 0, b2 = 0;
        int step = 1, angle = 10;
        /// <summary>
        /// 判断当前的模式,
        /// </summary>
        /// <param name="thisMode">模式名称</param>
        void JudgeMod(string thisMode)
        {
            if (currentMode != thisMode)
            {
                currentMode = thisMode;
                theCanvas.Children.Clear();
            }
        }

        //图形绘制
        private void DrawRectangle_Click(object sender, RoutedEventArgs e)
        {
            JudgeMod("图形绘制");
        }

        private void DrawCircle_Click(object sender, RoutedEventArgs e)
        {
            JudgeMod("图形绘制");

        }

        private void DrawingSetColor_Click(object sender, RoutedEventArgs e)
        {
            Window setColorWindow = new SetColorWindow1();
            setColorWindow.Owner = this;
            setColorWindow.ShowDialog();
        }



        //区域填充
        private void DrawPolygons_Click(object sender, RoutedEventArgs e)
        {
            JudgeMod("区域填充");

        }

        private void FillingSetColor_Click(object sender, RoutedEventArgs e)
        {
            Window setColorWindow = new SetColorWindow2();
            setColorWindow.Owner = this;
            setColorWindow.ShowDialog();

        }



        //三维变换
        private void DrawCube_Click(object sender, RoutedEventArgs e)
        {
            JudgeMod("三维变换");

        }

        private void X_Translat_Click(object sender, RoutedEventArgs e)
        {
            JudgeMod("三维变换");

        }

        private void Y_Translat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Z_Translat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void X_Rotate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Y_Rotate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Z_Rotate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SetData_Click(object sender, RoutedEventArgs e)
        {
            Window setDataWindow = new SetDataWindow1();
            setDataWindow.Owner = this;
            setDataWindow.ShowDialog();

        }



        //绘制曲线
        private void DrawBezierCurve(object sender, RoutedEventArgs e)
        {
            JudgeMod("绘制曲线");

        }

        private void DrawBsplineCurve(object sender, RoutedEventArgs e)
        {
            JudgeMod("绘制曲线");

        }
    }
}
