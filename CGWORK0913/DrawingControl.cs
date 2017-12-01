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
        bool mouseIsDown = false;
        Point startPoint, endPoint;
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (currentMode)
            {
                case "图形绘制":
                    {
                        switch (currentState)
                        {
                            case "矩形":
                                canvas_MouseDown矩形(sender, e); break;
                            case "圆形":
                                canvas_MouseDown圆形(sender, e); break;
                        }
                    }
                    break;
                case "区域填充":
                    {
                        switch (currentState)
                        {
                            case "多边形":
                                canvas_MouseDown矩形(sender, e); break;
                        }
                    }
                    break;
                case "三维变换":
                    {
                        switch (currentState)
                        {
                            case "立方体":
                                canvas_MouseDown矩形(sender, e); break;
                            case "平移旋转":
                                canvas_MouseDown圆形(sender, e); break;
                        }
                    }
                    break;
                case "绘制曲线":
                    {
                        switch (currentState)
                        {
                            case "Bezier曲线":
                                canvas_MouseDown矩形(sender, e); break;
                            case "B样条曲线":
                                canvas_MouseDown圆形(sender, e); break;
                        }
                    }
                    break;
            }

        }
        
        /// <summary>
        /// 鼠标左键释放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (currentMode)
            {
                case "图形绘制":
                    {
                        switch (currentState)
                        {
                            case "矩形":
                                canvas_MouseUp矩形(sender, e); break;
                            case "圆形":
                                canvas_MouseUp圆形(sender, e); break;
                        }
                    }
                    break;
                case "区域填充":
                    {
                        switch (currentState)
                        {
                            case "多边形":
                                canvas_MouseUp矩形(sender, e); break;
                        }
                    }
                    break;
                case "三维变换":
                    {
                        switch (currentState)
                        {
                            case "立方体":
                                canvas_MouseUp矩形(sender, e); break;
                            case "平移旋转":
                                canvas_MouseUp圆形(sender, e); break;
                        }
                    }
                    break;
                case "绘制曲线":
                    {
                        switch (currentState)
                        {
                            case "Bezier曲线":
                                canvas_MouseUp矩形(sender, e); break;
                            case "B样条曲线":
                                canvas_MouseUp圆形(sender, e); break;
                        }
                    }
                    break;
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //switch (currentMode)
            //{
            //    case "图形绘制":
            //        canvas_MouseMove矩形(sender, e); break;
            //    case "区域填充":
            //        canvas_MouseDown矩形(sender, e); break;
            //    case "三维变换":
            //        canvas_MouseDown矩形(sender, e); break;
            //    case "绘制曲线":
            //        canvas_MouseDown矩形(sender, e); break;
            //}
        }
    }
}
