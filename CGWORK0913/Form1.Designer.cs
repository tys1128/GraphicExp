namespace CGWORK0913
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制矩形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制圆形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.区域填充ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制多边形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置颜色ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.三维变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制立方体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平移旋转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制Bezier曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制B样条曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空屏幕ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBox = new System.Windows.Forms.ToolStripTextBox();
            this.canvas = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.清空屏幕ToolStripMenuItem,
            this.TextBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(679, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.区域填充ToolStripMenuItem,
            this.三维变换ToolStripMenuItem,
            this.绘制曲线ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 23);
            this.toolStripMenuItem1.Text = "图形应用";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制矩形ToolStripMenuItem,
            this.绘制圆形ToolStripMenuItem,
            this.设置颜色ToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "图形绘制";
            // 
            // 绘制矩形ToolStripMenuItem
            // 
            this.绘制矩形ToolStripMenuItem.Name = "绘制矩形ToolStripMenuItem";
            this.绘制矩形ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.绘制矩形ToolStripMenuItem.Text = "绘制矩形";
            this.绘制矩形ToolStripMenuItem.Click += new System.EventHandler(this.绘制矩形ToolStripMenuItem_Click);
            // 
            // 绘制圆形ToolStripMenuItem
            // 
            this.绘制圆形ToolStripMenuItem.Name = "绘制圆形ToolStripMenuItem";
            this.绘制圆形ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.绘制圆形ToolStripMenuItem.Text = "绘制圆形";
            this.绘制圆形ToolStripMenuItem.Click += new System.EventHandler(this.绘制圆形ToolStripMenuItem_Click);
            // 
            // 设置颜色ToolStripMenuItem
            // 
            this.设置颜色ToolStripMenuItem.Name = "设置颜色ToolStripMenuItem";
            this.设置颜色ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设置颜色ToolStripMenuItem.Text = "设置颜色";
            this.设置颜色ToolStripMenuItem.Click += new System.EventHandler(this.设置颜色ToolStripMenuItem_Click);
            // 
            // 区域填充ToolStripMenuItem
            // 
            this.区域填充ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制多边形ToolStripMenuItem,
            this.设置颜色ToolStripMenuItem1});
            this.区域填充ToolStripMenuItem.Name = "区域填充ToolStripMenuItem";
            this.区域填充ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.区域填充ToolStripMenuItem.Text = "区域填充";
            // 
            // 绘制多边形ToolStripMenuItem
            // 
            this.绘制多边形ToolStripMenuItem.Name = "绘制多边形ToolStripMenuItem";
            this.绘制多边形ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.绘制多边形ToolStripMenuItem.Text = "绘制多边形";
            this.绘制多边形ToolStripMenuItem.Click += new System.EventHandler(this.绘制多边形ToolStripMenuItem_Click);
            // 
            // 设置颜色ToolStripMenuItem1
            // 
            this.设置颜色ToolStripMenuItem1.Name = "设置颜色ToolStripMenuItem1";
            this.设置颜色ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.设置颜色ToolStripMenuItem1.Text = "设置颜色";
            this.设置颜色ToolStripMenuItem1.Click += new System.EventHandler(this.设置颜色ToolStripMenuItem1_Click);
            // 
            // 三维变换ToolStripMenuItem
            // 
            this.三维变换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制立方体ToolStripMenuItem,
            this.平移旋转ToolStripMenuItem,
            this.设置数据ToolStripMenuItem});
            this.三维变换ToolStripMenuItem.Name = "三维变换ToolStripMenuItem";
            this.三维变换ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.三维变换ToolStripMenuItem.Text = "三维变换";
            // 
            // 绘制立方体ToolStripMenuItem
            // 
            this.绘制立方体ToolStripMenuItem.Name = "绘制立方体ToolStripMenuItem";
            this.绘制立方体ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.绘制立方体ToolStripMenuItem.Text = "绘制立方体";
            this.绘制立方体ToolStripMenuItem.Click += new System.EventHandler(this.绘制立方体ToolStripMenuItem_Click);
            // 
            // 平移旋转ToolStripMenuItem
            // 
            this.平移旋转ToolStripMenuItem.Name = "平移旋转ToolStripMenuItem";
            this.平移旋转ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.平移旋转ToolStripMenuItem.Text = "平移旋转";
            this.平移旋转ToolStripMenuItem.Click += new System.EventHandler(this.平移旋转ToolStripMenuItem_Click);
            // 
            // 设置数据ToolStripMenuItem
            // 
            this.设置数据ToolStripMenuItem.Name = "设置数据ToolStripMenuItem";
            this.设置数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置数据ToolStripMenuItem.Text = "设置数据";
            this.设置数据ToolStripMenuItem.Click += new System.EventHandler(this.设置数据ToolStripMenuItem_Click);
            // 
            // 绘制曲线ToolStripMenuItem
            // 
            this.绘制曲线ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制Bezier曲线ToolStripMenuItem,
            this.绘制B样条曲线ToolStripMenuItem});
            this.绘制曲线ToolStripMenuItem.Name = "绘制曲线ToolStripMenuItem";
            this.绘制曲线ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.绘制曲线ToolStripMenuItem.Text = "绘制曲线";
            // 
            // 绘制Bezier曲线ToolStripMenuItem
            // 
            this.绘制Bezier曲线ToolStripMenuItem.Name = "绘制Bezier曲线ToolStripMenuItem";
            this.绘制Bezier曲线ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.绘制Bezier曲线ToolStripMenuItem.Text = "绘制 Bezier 曲线";
            this.绘制Bezier曲线ToolStripMenuItem.Click += new System.EventHandler(this.绘制Bezier曲线ToolStripMenuItem_Click);
            // 
            // 绘制B样条曲线ToolStripMenuItem
            // 
            this.绘制B样条曲线ToolStripMenuItem.Name = "绘制B样条曲线ToolStripMenuItem";
            this.绘制B样条曲线ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.绘制B样条曲线ToolStripMenuItem.Text = "绘制 B 样条曲线";
            this.绘制B样条曲线ToolStripMenuItem.Click += new System.EventHandler(this.绘制B样条曲线ToolStripMenuItem_Click);
            // 
            // 清空屏幕ToolStripMenuItem
            // 
            this.清空屏幕ToolStripMenuItem.Name = "清空屏幕ToolStripMenuItem";
            this.清空屏幕ToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.清空屏幕ToolStripMenuItem.Text = "清空屏幕";
            this.清空屏幕ToolStripMenuItem.Click += new System.EventHandler(this.清空屏幕ToolStripMenuItem_Click);
            // 
            // TextBox
            // 
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(120, 23);
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 27);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(679, 469);
            this.canvas.TabIndex = 1;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(679, 496);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CGWORK0913";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 区域填充ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三维变换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制曲线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制矩形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制圆形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置颜色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制多边形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置颜色ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 绘制立方体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平移旋转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制Bezier曲线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制B样条曲线ToolStripMenuItem;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.ToolStripMenuItem 清空屏幕ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox TextBox;
    }
}

