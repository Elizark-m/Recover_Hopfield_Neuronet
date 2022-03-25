using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkofHopfild
{
    class Network
    {
        double[][] inputs;

        double[][] matrix;

        public Network(double[][] inputs)
        {
            //сохраняем входные данные
            this.inputs = inputs;
            //создаем сеть
            Create();
            //обучаем сеть
            Study();
        }

        private void Create()
        {
            //создаем матрицу размером [размер inputs[0], размер inputs[0]]
            matrix = new double[inputs[0].Length][];
            for(int i=0; i<matrix.Length;i++)
            {
                matrix[i] = new double[inputs[0].Length];
            }
        }

        private void Study()
        {
            //в цикле по двойному массиву inputs и матрице
            for (int pic = 0; pic < inputs.Length; pic++)
            {
                for (int i = 0; i < inputs[pic].Length; i++)
                { 
                    for (int j = 0; j < inputs[pic].Length; j++)
                    {
                        //если координаты ячейки матрицы равно, то ячейка равна '0', иначе += inputs[pic][i] * inputs[pic][j]
                        if (i == j) matrix[i][j] = 0;
                        //W=W+Xk*X
                        else matrix[i][j] += inputs[pic][i] * inputs[pic][j];
                    }
                }

            }
        }

        public double[] Definition(double[] damage)
        {
            //массив temp по размеру длины массива поврежденного изображения
            double[] temp = new double[damage.Length];
            //массив res по размеру длины массива поврежденного изображения
            double[] res = new double[damage.Length];

            bool was = false;

            //массив step1 по размеру длины массива поврежденного изображения
            double[] step1 = new double[damage.Length];
            //массив step2 по размеру длины массива поврежденного изображения
            double[] step2 = new double[damage.Length];

            //в бесконечном цикле
            while(true)
            {
                //сохраняем сумму произведений step1 * damage   W*y=y'
                step1 = MultiplyVector(step1, damage);
                //приводим к стабильным значениям Если >=0 то 1, иначе -1
                step2 = funcSign(step1);

                //записываем в переменную was совпадают ли массивы step1 и temp 
                was = step1.SequenceEqual(temp);
                //если совпадают, то выходим из цикла
                if (was) break;
                //иначе сохраняем в буфер temp значение step1
                temp = step1;
            }
            //возвращаем step1
            return step1;
        }

        private double[] MultiplyVector(double[] temp, double[] damage)
        {
            //в цикле размеру массива matrix
            for (int i = 0; i < matrix.Length; i++)
            {   //обнуляем temp
                temp[i] = 0;
                //в цике по массиву matrix[] находим сумму произведений matrix * damage W*y'=y'*
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    temp[i] += matrix[i][j] * damage[j];
                }
            }
            //возвращаем temp
            return temp;
        }

        private double[] funcSign(double[] arr)
        {
            //в цикле по массиву arr 
            for(int i=0;i<arr.Length;i++)
            {
                //если значение >= 0, значение =1, иначе -1
                if (arr[i] >= 0) arr[i] = 1;
                else arr[i] = -1;
            }
            //возвращает массив arr
            return arr;
        }
    }
}
