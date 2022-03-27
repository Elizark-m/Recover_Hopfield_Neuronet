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
            // save input data
            this.inputs = inputs;
            // create neuronet matrix
            Create();
            // start study neuronet
            Study();
        }
        
        // create neuronet matrix
        private void Create()
        {
            // create neuronet matrix [size of inputs[0], size of inputs[0]]
            matrix = new double[inputs[0].Length][];
            for(int i=0; i<matrix.Length;i++)
            {
                matrix[i] = new double[inputs[0].Length];
            }
        }
        
        // start neuronet studing ( filling matrix )
        private void Study()
        {
            // for each picture data in inputs and squared each data element in picture data filling matrix
            for (int pic = 0; pic < inputs.Length; pic++)
            {
                for (int i = 0; i < inputs[pic].Length; i++)
                { 
                    for (int j = 0; j < inputs[pic].Length; j++)
                    {
                        // if matrix coordinate is equal, value in this element is '0', 
                        // else value sum multiplying inputs picture data [i] by inputs picture data [j]
                        if (i == j) matrix[i][j] = 0;
                        else matrix[i][j] += inputs[pic][i] * inputs[pic][j];
                    }
                }

            }
        }
        
        // try to difine 
        public double[] Definition(double[] damage)
        {
            // create temporal array size of damage picture data
            double[] temp = new double[damage.Length];
            // create result array size of damagge picture data
            double[] res = new double[damage.Length];

            // create finish flag
            bool isEqual = false;

            // create step1 array size of damagge picture data
            double[] step1 = new double[damage.Length];
            // create step2 array size of damagge picture data
            double[] step2 = new double[damage.Length];

            while(true)
            {
                // save sum multiplication step1 matrix and damage picture matrix
                step1 = MultiplyVector(step1, damage);
                // stabilise step1 results, if matrix element >= 0 set '1', else '-1'
                step2 = funcSign(step1);

                // check step1 equals temp, it's finish recover flag
                isEqual = step2.SequenceEqual(temp);
                // finish recover, if equals is true
                if (isEqual) break;
                // else save step1 results in temp for next step
                temp = step2;
            }
            // return stabilised results
            return step2;
        }

        //  multiplying picture data by matrix
        private double[] MultiplyVector(double[] temp, double[] damage)
        {
            // foreach 
            for (int i = 0; i < matrix.Length; i++)
            {   
                // clear temp
                temp[i] = 0;
                // foreach element in matrix[] save in temp sum multipying damage * matrix
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    temp[i] += matrix[i][j] * damage[j];
                }
            }
            
            //return results
            return temp;
        }
        
        // stabilise results, if matrix element >= 0 set '1', else '-1'
        private double[] funcSign(double[] arr)
        {
            // for each element in array, if element value >= 0, set '1', else '-1'
            for(int i=0;i<arr.Length;i++)
            {
                if (arr[i] >= 0) arr[i] = 1;
                else arr[i] = -1;
            }
            
            // return results
            return arr;
        }
    }
}
