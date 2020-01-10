using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace WindowsFormsApp17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strFileName = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Mat img_to_mat = new Mat();
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(ofd.FileName);
                Mat img1 = CvInvoke.Imread(ofd.FileName, Emgu.CV.CvEnum.LoadImageType.AnyColor);
                var image1 = CvInvoke.Imread(ofd.FileName, LoadImageType.Color); //从文件中读取图像
                img_to_mat = img.Mat;
                //CvInvoke.Imshow("img1", img);
                //CvInvoke.Imshow("img2", img1);
                //CvInvoke.Imshow("img3", img_to_mat);
                Image<Bgr, byte> image = new Image<Bgr, byte>(200, 300, new Bgr(0, 0, 255));//创建一张 200 * 300 尺寸颜色为红色的图像。
                pictureBox1.Image = image.Bitmap;

                Mat scr = new Mat(ofd.FileName, Emgu.CV.CvEnum.LoadImageType.AnyColor);
                //指定路径加载图片。(如果Op.FileName 含有中文路径Mat 类是打不开文件的，但是Image<TColor, TDepth> 类却可以。)
                imageBox1.Image = scr;//显示加载完成的图片。

                Matrix<Byte> mat1 = new Matrix<byte>(new Size(200, 300));
                for (int i = 0; i < 300; i++)
                    for (int j = 0; j < 200; j++)
                        mat1[i, j] = Convert.ToByte(j);
                imageBox2.Image = mat1.Mat;
                mat1.Save("mei.jpg"); //图片
               


                img.Dispose(); img1.Dispose();
                CvInvoke.WaitKey(0);
            }

        }
    }
}
