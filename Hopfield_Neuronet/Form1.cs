using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hopfield_Neuronet
{
    public partial class Form1 : Form
    {
        Network net;
        Graphics g;
        DataClass dt;
        double[][] inputs;

        public Form1()
        {
            InitializeComponent();

            Init();

            StartNetwork();
        }
        
        // prepare for neuronet work
        private void Init()
        {
            // save path to damage picture
            DirectoryInfo dir = new DirectoryInfo(@"..\..\damage");
            // save files .bmp names in array
            FileInfo[] f = dir.GetFiles("*.bmp");
            // add saved names in form list
            for (int i = 0; i < f.Length; i++)
            {
                listPictures.Items.Add(f[i].Name);
            }
        }

        // 
        private void StartNetwork()
        {
            // create picture dataset
            dt = new DataClass();
            // save picture data from dataset
            inputs = dt.GetImg();
            // create neuronet with learning dataset
            net = new Network(inputs);
        }

        private void listPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            // save selected picture name 
            string name = listPictures.SelectedItem.ToString();
            // choose picture file from damaged picture directory by name
            Image img = getImg(name, @"..\..\damage");
            // drawing picture size between points
            int size = 15;
            
            // create bitmap from selected image
            Bitmap bmp1 = new Bitmap(img, damagePic.Width, damagePic.Height);

            // draw selected image
            g = Graphics.FromImage(bmp1);
            // save selected image bitmap in array
            double[] arrImg = dt.GetImg((Bitmap)img);

            // draw damage picture
            DrawRectGrid(g, 10, 10, size, arrImg);
            // add result picture in form 
            damagePic.Image = bmp1;
    
        }
        
        // take image from path by name
        private Image getImg(string name, string direct)
        {
            // take directory by path
            DirectoryInfo dir = new DirectoryInfo(direct);
            // take file by name
            FileInfo f = dir.GetFiles(name).First();
            // save image from file
            Image img = Image.FromFile(f.FullName);
            // return result
            return img;
        }
        
        // drawing recovered picture on button click
        private void recoverButton_Click(object sender, EventArgs e)
        {
            // save selected picture name
            string name = listPictures.SelectedItem.ToString();
            // take damage picture from path by name
            Image img = getImg(name, @"..\..\damage");
            // drawing picture size between points
            int size = 15;

            // create bitmap size of recover picture
            Bitmap bmp2 = new Bitmap(img, recoverPic.Width, recoverPic.Height);

            // save damage picture bitmap in array
            double[] damage = dt.GetImg((Bitmap)img);
            // define and recover damage picture array
            double[] res = net.Definition(damage);

            g = Graphics.FromImage(bmp2);

            //double[] selectedImgArr = inputs[listPictures.SelectedIndex];
            // draw recover image
            DrawRectGrid(g, 10, 10, size, res);
            // add recover image in form
            recoverPic.Image = bmp2;
        }
        
        // filling rectange from array by rule
        public void DrawRectGrid(Graphics gr, float xmax, float ymax, int height, double[] weigths)
        {
            // set start coordinates
            int x = 0, y = 0;
            // clear image
            gr.Clear(Color.White);
            
            // foreach element in image
            for (int row = 0, i = 0; row < xmax; row++)
            {
                for (int col = 0; col < ymax; col++)
                {
                    //set coordinates current value
                    y = col * height;
                    x = row * height;

                    // initialize brush
                    Brush brush;
                    // if current image element value = '1', brush color set black, else color set white
                    if (weigths[i] == 1) brush = new SolidBrush(Color.Black);
                    else brush = new SolidBrush(Color.White);
                    // fill rectangle size of height * height at current coordinates by brush color
                    gr.FillRectangle(brush, x, y, height, height);

                    i++;
                }
            }
        }

        // Scale image to specified size
        private Image ScaleImage(Image source, int width, int height)
        {
            // create future image bitmap
            Image dest = new Bitmap(width, height);
            
            using (Graphics gr = Graphics.FromImage(dest))
            {
                // clear bitmap
                gr.FillRectangle(Brushes.White, 0, 0, width, height);  
                // choose high quality compression mode
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                
                // save sourse and result image size
                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;
                
                // draw image with compression
                // if sourse image less target
                if (srcwidth <= dstwidth && srcheight <= dstheight)  
                {
                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                // if sourse image width more then target
                else if (srcwidth / srcheight > dstwidth / dstheight)  
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                // if sourse image width less then target
                else
                {
                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, left, 0, cx, dstheight);
                }
                
                // return result
                return dest;
            }
        }
    }
    
}
