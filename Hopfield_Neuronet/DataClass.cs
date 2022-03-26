using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopfield_Neuronet
{
    class DataClass
    {
        int inputCount = 0;
        public int outputcount = 0;

        public double[] GetImg(Bitmap img)
        {
            // forming data line from image
            inputCount = img.Height * img.Width;

            //создаем массив по длине матрицы
            double[] input = new double[inputCount];

            //в цикле по длине и ширине картинки
            for (int i = 0, l = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    //узнаем цвет пикселя
                    Color c = img.GetPixel(i, j);
                    //если пиксель закрашен записываем в массив input '1', иначе записываем '-1'
                    if (c.R == 0 && c.G == 0 && c.B == 0) input[l] = 1;
                    else input[l] = -1;
                    l++;
                }
            }
            //возвращаем массив input
            return input;
        }
        
        public double[][] GetImg()
        {
            // save image directory
            DirectoryInfo dir = new DirectoryInfo(@"..\..\data");
            // count files .bmp
            outputcount = dir.EnumerateFiles("*.bmp").Count();
            
            
            int imgC = 0; //счетчик изображений
            //создаем двойной массив input размером по количеству файлов в директории
            double[][] input = new double[outputcount][];

            //в цикле по каждому файлу в директории с расширением .bmp
            foreach (FileInfo file in dir.EnumerateFiles("*.bmp"))
            {
                //создаем битовую карту изображения file с размером 10x10
                Bitmap img = new Bitmap(Image.FromFile(file.FullName), 10,10);
                //находим количество пикселей в картинке = длина картинки * высота картинки
                inputCount = img.Height * img.Width;
                //создаем массив в input[imgC] по размерру равному количеству пикселей в картинке
                input[imgC] = new double[inputCount];

                //в цикле по размеру картинки
                for (int i = 0, l = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        //узнаем цвет пикселя
                        Color c = img.GetPixel(i, j);
                        //если пиксель закрашен, то записываем в массив input[imgC] '1', иначе '-1'
                        if (c.R == 0 && c.G == 0 && c.B == 0) input[imgC][l] = 1;
                        else input[imgC][l] = -1;
                        l++;
                    }
                }

                imgC++;
            }
            //возвращаем двойной массив input 
            return input;
        }

    }
}
