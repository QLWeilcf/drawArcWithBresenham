using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drawArcWithBresenham {
    public partial class pixelForm : Form {
        public pixelForm() {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.pixelFrom_Paint); //初始化载入的像素方格
            this.MouseClick += new MouseEventHandler(this.pixelFrom_Click); //监听点击事件
            this.MouseMove += new MouseEventHandler(this.pixelFrom_MouseMove); //监听鼠标移动事件 
        }
        public Graphics g;//画 像素点 用
        public Graphics gpat;//初始化画格子用
        private int wsize = 10;//像素格宽度
        private int hsize = 10;//像素格高度
        private Point cirCentPoi;//圆心
        private Point lineP_start;
        private Point lineP_end;
        private int radius = 10; //半径
        private int deciPoiIn = 0; //决策点的赋值用
        private bool showPixAxisPoi = true; //显示xy像素坐标点
        //private int matUse = 0;
        private int rotateHgt = 560;//矩阵变换高度

        private void pixelFrom_Paint(object sender, PaintEventArgs e) {
            gpat = e.Graphics;
            //if (matUse == 0) { }
            Matrix mat = new Matrix(1, 0, 0, -1, 0, 0);//沿X轴翻转
            gpat.Transform = mat;
            gpat.TranslateTransform(0, -rotateHgt);
            //matUse = 1;
            plantInitial(gpat, 800, 530);//初始化
        }
        private void pixelForm_Load(object sender, EventArgs e) {
            g = CreateGraphics();
            Matrix mat = new Matrix(1, 0, 0, -1, 0, 0);//沿X轴翻转
            g.Transform = mat;
            g.TranslateTransform(0, -rotateHgt);
        }
        //监听鼠标点击事件，获取坐标
        private void pixelFrom_Click(object sender, MouseEventArgs e) {

            if (e.Button == MouseButtons.Left) {  //鼠标左击
                Point readPoint = this.PointToClient(Control.MousePosition);//基于工作区的坐标

                if (deciPoiIn == 0) {  //没有选择过起点时
                    lineP_start = mouseToGrap(readPoint);//鼠标坐标转换为xy下的坐标
                    drawPixelsPoint(g, lineP_start);//显示点，画像素点
                    deciPoiIn += 1;
                } else if (deciPoiIn == 1) {
                    lineP_end = mouseToGrap(readPoint);
                    drawPixelsPoint(g, lineP_end);
                    deciPoiIn += 1;
                } else {
                    bool willErase = true;//选择是否擦除前面的点，该变量如果需要可以设置为全局变量
                    if (willErase) {
                        erasePixelPoi(g, lineP_start.X, lineP_start.Y, BackColor);//清除原先画的前面的点
                    }
                    lineP_start = lineP_end;
                    lineP_end = mouseToGrap(readPoint);
                    drawPixelsPoint(g, lineP_end);
                }
                startPoilbl.Text = displayPixelPoi(lineP_start);//显示到窗体上
                endPoilbl.Text = displayPixelPoi(lineP_end);

                cirCentPoi = mouseToGrap(readPoint);//圆心坐标一直取最新的点
            } else if (e.Button == MouseButtons.Right) {
                //目前没有其他操作
            }
        }

        //显示实时点，
        private void pixelFrom_MouseMove(object sender, MouseEventArgs e) {
            if (showPixAxisPoi) {
                Point inTpo = mouseToGrap(this.PointToClient(Control.MousePosition));
                Point intimePoi = new Point(inTpo.X/10, inTpo.Y/10);
                intimePoilbl.Text = intimePoi.ToString();
            } else { //显示wenFrom像素下的坐标
                Point intimePoi = this.PointToClient(Control.MousePosition);
                Point inTimepo = mouseToGrap(intimePoi);
                intimePoilbl.Text = inTimepo.ToString();
            }
        }
        //初始化像素格子
        public void plantInitial(Graphics gh, int xw, int yh) {
            Pen pw = new Pen(Color.Black, 1);
            //xw：初始化时画板长度；yh：画板高度
            for (int x = 0; x <= xw;) {
                gh.DrawLine(pw, new Point(x, 0), new Point(x, yh));
                x += wsize;
            }
            for (int y = 0; y <= yh;) {
                gh.DrawLine(pw, new Point(0, y), new Point(xw, y));
                y += hsize;
            }
        }

        //鼠标坐标转换为坐标系下的坐标 mouse to Graphics
        public Point mouseToGrap(Point readPoi) {
            int poiy = (rotateHgt - readPoi.Y);
            return new Point(readPoi.X, poiy);
        }
        
        //画像素点
        public void drawPixelsPoint(Graphics grph, Point readPoi) {
            //默认采用红色，画起点、终点的接口
            int px5 = (readPoi.X / 10) * 10;
            int py5 = (readPoi.Y / 10) * 10;
            Rectangle recg = new Rectangle(px5, py5, wsize, hsize);
            SolidBrush sruh = new SolidBrush(Color.Red);
            grph.FillRectangle(sruh, recg);//用矩形填充的方式“画坐标点”
        }
        public void drawPixelPoint(Graphics grph, int x, int y) {
            //输入x y的情况下的画像素点，输入的xy为像素点坐标；画直线的接口
            int px5 = x * 10;
            int py5 = y * 10;
            Rectangle recg = new Rectangle(px5, py5, wsize, hsize);
            SolidBrush sruh = new SolidBrush(Color.Blue);//改颜色需要在这里改
            grph.FillRectangle(sruh, recg);
        }

        public void drawPixelPoint(Graphics grph, int x, int y, Color col) { //画圆的接口
            //传入的坐标是圆心在原点对应的坐标，所以要加上cirCentPoi.X/Y
            int px5 = (x + cirCentPoi.X / 10) * 10; //每个点加上圆心值
            int py5 = (y + cirCentPoi.Y / 10) * 10;
            Rectangle recg = new Rectangle(px5, py5, wsize, hsize);
            SolidBrush sruh = new SolidBrush(col);
            grph.FillRectangle(sruh, recg);

        }

        //画对称的8个点，画圆用
        private void drawAightPoi(Graphics g, int x, int y,Color col) {
            drawPixelPoint(g, x, y,col);//0
            drawPixelPoint(g, y, x, col);
            drawPixelPoint(g, y, -x, col);
            drawPixelPoint(g, x, -y, col);
            drawPixelPoint(g, -x, -y, col);
            drawPixelPoint(g, -y, -x, col);
            drawPixelPoint(g, -y, x, col);
            drawPixelPoint(g, -x, y, col);//7
        }
 
        //擦除起点之前的点
        public void erasePixelPoi(Graphics grph, int x, int y, Color col) {//输入点为winForm坐标点
            int px5 = (x / 10) * 10;
            int py5 = (y / 10) * 10;
            Rectangle recg = new Rectangle(px5, py5, wsize, hsize);
            SolidBrush sruh = new SolidBrush(col);
            grph.FillRectangle(sruh, recg);//背景色填充
            grph.DrawRectangle(new Pen(Color.Black, 1), recg);//重新画一下该格子
        }
        //显示坐标像素点
        public string displayPixelPoi(Point readpoi) {
            int rpx = readpoi.X / wsize;
            int rpy = readpoi.Y / hsize;
            Point displayPoi = new Point(rpx, rpy);
            return displayPoi.ToString();
        }
        /*另一种显示点坐标的方式
        public string displayPixelPoi(Point readpoi) {
            int rpx = readpoi.X / wsize;
            int rpy = readpoi.Y / hsize;
            string rpxy = rpx + "," + rpy;
            return rpxy;
        }
        */

        //bresenham算法画直线
        public void bresenham(Point linePs, Point linePe) {
            //输入为 像素点坐标，起点和终点
            int dx = Math.Abs(linePe.X - linePs.X);
            int dy = Math.Abs(linePe.Y - linePs.Y);
            int x = linePs.X;//起点x坐标
            int y = linePs.Y;
            int s1, s2, interc;//指示参数
            if (linePe.X - linePs.X >= 0) {
                s1 = 1;  //终点x大于起点的x
            } else { s1 = -1; }
            if (linePe.Y - linePs.Y >= 0) {
                s2 = 1; //终点y大于起点的y
            } else { s2 = -1; }
            if (dy > dx) {
                int temp = dx;  //x y交换
                dx = dy;
                dy = temp;
                interc = 1;
            } else { interc = -1; }
            int f = 2 * dy - dx; //决策参数
            for (int i = 1; i <= dx; i++) {
                drawPixelPoint(g, x, y);
                if (f >= 0) {
                    if (interc == 1) {
                        x += s1;
                    } else {
                        y += s2;
                    }
                    f = f - 2 * dx;
                }
                if (interc == 1) {
                    y += s2;
                } else {
                    x += s1;
                }
                f = f + 2 * dy;
            }
        }

        //bresenham算法画圆弧，包括画圆
        public void brshArc(int rdi,int arcIst,Color col) {
            //rdi:半径；arcIst-指示，0对应画圆，1对应画圆弧，配置圆弧的对应角度会用到其他值，col:颜色
            int x = 0;//画圆弧
            int y = rdi;
            int d = 3 - 2 * rdi; //指示参数
            while (x <= y) {
                if (arcIst == 0)
                    drawAightPoi(g, x, y, col);
                else
                    drawPixelPoint(g, x, y,col);

                if (d < 0) {
                    d = d + 4 * x + 6;//向右
                } else {
                    d = d + 4 * (x - y) + 10;  //向右下
                    y -= 1;
                }
                x += 1;
            }
        }

        #region 按钮交互部分
        //画直线 按钮
        private void drawLineBtn_Click(object sender, EventArgs e) {
            Point ps = new Point(lineP_start.X / 10, lineP_start.Y / 10);
            Point pe = new Point(lineP_end.X / 10, lineP_end.Y / 10);
            startPoilbl.Text = ps.ToString();
            endPoilbl.Text = pe.ToString();
            bresenham(ps, pe);
            //画直线的显示颜色需要在函数drawPixelPoint(g,x,y)处改，在112行左右
        }
        //画圆弧（目前只做1/8的弧段，之后可以拓展为任意角度）
        private void drawArcBtn_Click(object sender, EventArgs e) {
            try {
                radius = Convert.ToInt32(radiusTBox.Text);
                if (radius >= 0)
                    brshArc(radius,1, Color.Gold);//改显示颜色从这里的接口改
                else {
                    MessageBox.Show("半径请输入正整数");
                }
            }
            catch (Exception exp) {
                MessageBox.Show(exp.ToString());
            }
        }
        //画圆 按钮
        private void drawCircleBtn_Click(object sender, EventArgs e) {
            try {
                radius = Convert.ToInt32(radiusTBox.Text);
                if (radius >= 0)
                    brshArc(radius, 0,Color.Gold);
                else {
                    MessageBox.Show("半径请输入正整数");
                }
            }catch(Exception exp) {
                MessageBox.Show(exp.ToString());
            }
        }
        //清除 按钮
        private void clearBtn_Click(object sender, EventArgs e) {
            g.Clear(this.BackColor);//用背景色填充
            plantInitial(g, 800, 530);//再画一遍格子
        }

        //拓展：画粗直线-用小圆填充，画椭圆

        #endregion
    }
}
