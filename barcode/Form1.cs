using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
namespace barcode
{
    public partial class Form1 : Form
    {
        int flag = 0;
        string barcode; 
        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
        }

        private void Genarate_Click(object sender, EventArgs e)
        {
            try
            {
                barcode = textBox1.Text;
                bitmap = new Bitmap(barcode.Length * 40,50);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Font ofont = new System.Drawing.Font("IDAutomationHC39M", 20);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush black = new SolidBrush(Color.Black);
                    SolidBrush white = new SolidBrush(Color.White);
                    graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                    graphics.DrawString("*" + barcode + "*", ofont, black, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    pictureBox1.Image = bitmap;
                    pictureBox1.Height = bitmap.Height;
                    pictureBox1.Width = bitmap.Width;
                }
                //   bitmap.Save("" +barcode + ".Jpeg");
                flag = 1;
            }
            catch
            {
                MessageBox.Show("Enter String");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // int flag=0;
            if (flag == 0)
            {
                MessageBox.Show("Generate Barcode First");
            }
            else if (flag == 1)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Save BarCode";
                saveFileDialog1.FileName = barcode;
                saveFileDialog1.DefaultExt = "png";
                saveFileDialog1.Filter = "jpeg (*.jpeg)|*.jpeg|png (*.png)|*.png|gif(*.gif)|*.gif|bmp (*.bmp)|*.bmp|tiff (*.tiff)|*.tiff";
                string name="image";
                string ext = "ext";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                         name = saveFileDialog1.FileName;
                         ext = System.IO.Path.GetExtension(saveFileDialog1.FileName);
                         bitmap.Save(name);
                        
                    }
                    catch
                    {
                        Console.WriteLine("error 404");
                    }
                }
               
            } 
            else
            {
                MessageBox.Show("Unknown Error");
            }
        }
 
    }
}
