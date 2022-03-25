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

namespace NetworkofHopfild
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

            //инициализация формы
            Init();

            //запускаем нейронную сеть?
            StartNetwork();
        }

        private void Init()
        {
            //указываем директорию с изображниями
            DirectoryInfo dir = new DirectoryInfo(@"..\..\damage");
            //записываем в массив все файлы директории dir с расширением .bmp
            FileInfo[] f = dir.GetFiles("*.bmp");
            //в цикле по массиву файлов f добавляем в столбец рисунков названия файлов
            for (int i = 0; i < f.Length; i++)
            {
                listPictures.Items.Add(f[i].Name);
            }
        }


        private void StartNetwork()
        {
            //создаем новую базу с картинками
            dt = new DataClass();
            //записываем исходные картинки в массив inputs
            inputs = dt.GetImg();
            //создаем новую сеть с входными данными в виде двойного массива inputs
            net = new Network(inputs);
        }

        private void listPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            //запоминаем полное имя выбранного файла
            string name = listPictures.SelectedItem.ToString();
            //выбираем картинку с выбранным именем в директории damage
            Image img = getImg(name, @"..\..\damage");
            //размер = 15
            int size = 15;
            
            //создаем битовую карту изображения по его размерам блока для поврежденной картинки
            Bitmap bmp1 = new Bitmap(img, damagePic.Width, damagePic.Height);

            //отрисовываем битовую карту изображения
            g = Graphics.FromImage(bmp1);
            //сохраняем битовую карту изображения в виде массива arrImg
            double[] arrImg = dt.GetImg((Bitmap)img);

            //отрисовываем карту по массиву arrImg
            DrawRectGrid(g, 10, 10, size, arrImg);
            //вставляем поученную картинку в блок damagePic 
            damagePic.Image = bmp1;
    
        }

        private Image getImg(string name, string direct)
        {
            //находим директорию по пути
            DirectoryInfo dir = new DirectoryInfo(direct);
            //выбираем первый файл с указанным именем
            FileInfo f = dir.GetFiles(name).First();
            //открываем картинку по полному имени файла
            Image img = Image.FromFile(f.FullName);
            //возвращаем картинку
            return img;
        }
        
        private void recoverButton_Click(object sender, EventArgs e)
        {
            //запоминаем полное имя выбранного файла
            string name = listPictures.SelectedItem.ToString();
            //выбираем картинку с выбранным именем в директории damage
            Image img = getImg(name, @"..\..\damage");
            //размер = 15
            int size = 15;

            //создаем битовую карту изображения по его размерам блока для восстановленной картинки
            Bitmap bmp2 = new Bitmap(img, recoverPic.Width, recoverPic.Height);

            //сохраняем битовую карту изображения в виде массива damage
            double[] damage = dt.GetImg((Bitmap)img);
            //определяем нарушение? картинки
            double[] res = net.Definition(damage);

            //подготавливаем карту к отрисовке блока с исправленной картинкой
            g = Graphics.FromImage(bmp2);

            //double[] selectedImgArr = inputs[listPictures.SelectedIndex];
            //отрисовываем исправленную картнику
            DrawRectGrid(g, 10, 10, size, res);
            //сохраняем исправленную картинку в блок исправленного изображения
            recoverPic.Image = bmp2;
        }
         
        public void DrawRectGrid(Graphics gr, float xmax, float ymax, int height, double[] weigths)
        {
            //задаем начальные значения координат
            int x = 0, y = 0;
            //отчищаем изображение
            gr.Clear(Color.White);
            
            //в цикле размеру картинки 
            for (int row = 0, i = 0; row < xmax; row++)
            {
                for (int col = 0; col < ymax; col++)
                {
                    //выставляем необходимые значения
                    y = col * height;
                    x = row * height;

                    //инициализируем кисть
                    Brush brush;
                    //если значение веса = '1', то цвет кисти становиться черным, иначе белым
                    if (weigths[i] == 1) brush = new SolidBrush(Color.Black);
                    else brush = new SolidBrush(Color.White);
                    //отрисовываем квадрат выбраной кистью по координатам, размером height * height
                    gr.FillRectangle(brush, x, y, height, height);

                    //Pen pen = new Pen(Color.Black);

                    //gr.DrawRectangle(pen, x, y, height, height);

                    i++;
                }
            }
        }


        private Image ScaleImage(Image source, int width, int height)
        {
            //создаем битовую карту размером width * height
            Image dest = new Bitmap(width, height);
            //
            using (Graphics gr = Graphics.FromImage(dest))
            {
                // Очищаем экран
                gr.FillRectangle(Brushes.White, 0, 0, width, height);  
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;

                if (srcwidth <= dstwidth && srcheight <= dstheight)  // Исходное изображение меньше целевого
                {
                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                else if (srcwidth / srcheight > dstwidth / dstheight)  // Пропорции исходного изображения более широкие
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                else  // Пропорции исходного изображения более узкие
                {
                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, left, 0, cx, dstheight);
                }

                return dest;
            }
        }
    }
    
}
