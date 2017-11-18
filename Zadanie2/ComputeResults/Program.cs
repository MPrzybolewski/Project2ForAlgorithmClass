using System;
using System.ComponentModel;
using Zadanie2;

namespace ComputeResults
{
    class MainClass
    {
        private static int size = 10;
        public static void Main(string[] args)
        {

            //computeGaussMultiply();
            ComputeOperationsResults();
            Console.ReadKey();
        }

        private static void ComputeOperationsResults()
        {

            computeApBpCxX("(A+B+C)x(X)DataResult");
            //computeAxBxC("(Ax(BxC))DataResult");
            //computeAxX("(AxX)DataResult");
            //copmuteGauss();
          //  double[] doubleMuliplyResultSharp = ReadMatrix<double>("doubleMultiplyResultSharp");
            //float[] floatMultiplyResultSharp = ReadMatrix<float>("floatMultiplyResultSharp");
           // MyFraction[] fractionMultiplyResultSharp = ReadMatrix<MyFraction>("fractionMultiplyResultSharp");
        }


        private static void computeApBpCxX(string fileName)
        {
            double[] doubleResult1 = ReadMatrix<double>(fileName + "Double", 1);
            double[] doubleResult2 = ReadMatrix<double>(fileName + "Double", 2);
            double[] doubleResult3 = ReadMatrix<double>(fileName + "Double", 3);
            float[] floatResult1 = ReadMatrix<float>(fileName + "Float", 1);
            float[] floatResult2 = ReadMatrix<float>(fileName + "Float", 2);
            float[] floatResult3 = ReadMatrix<float>(fileName + "Float", 3);

            double[] fractionResult1 = ReadMatrix<double>(fileName + "Factorial", 1);
            double[] fractionResult2 = ReadMatrix<double>(fileName + "Factorial", 2);
            double[] fractionResult3 = ReadMatrix<double>(fileName + "Factorial", 3);
            
            double doubleAndFactorialDiffrence = vectorNorm(doubleResult1, fractionResult1);
            double floatAndFactorialDiffrence = vectorNorm(floatResult1, fractionResult1);

            Console.WriteLine("Roznica double: {0}", doubleAndFactorialDiffrence);
            Console.WriteLine("Roznica float: {0}", floatAndFactorialDiffrence);
        }

        private static double vectorNorm(double[] doubleResult, double[] factorialResult)
        {
            double[] temp = new double[size];
            double sum = 0;
            for(int i = 0; i < size; i++)
            {
                temp[i] = doubleResult[i] - factorialResult[i];
                temp[i] *= temp[i];
                sum += temp[i];
            }

            sum = Math.Sqrt(sum);

            return sum;
        }

        private static double vectorNorm(float[] floatResult, double[] factorialResult)
        {
            double[] temp = new double[size];
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                temp[i] = (Double)floatResult[i] - factorialResult[i];
                temp[i] *= temp[i];
                sum += temp[i];
            }
            sum = Math.Sqrt(sum);

            return sum;
        }
        private static T[] ReadMatrix<T>(string fileName, int numberOfMatrix)
        {
            T[] tempTable = new T[size];
            Type t = tempTable.GetType();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Marek\Documents\Project2ForAlgorithmClass\Zadanie2\Zadanie2\Data\Results\" + fileName + ".txt");
            int i = 0;
            int j = 0;

            foreach(string line in lines)
            {
                if(j == numberOfMatrix - 1)
                {
                    if(size == i)
                    {
                        break;
                    }
                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                    tempTable[i] = (T)tc.ConvertFrom(line);
                    i++;
                }

                if (line.Contains("*") == true )
                {
                    j++;
                }
                
            }

            return tempTable;
            //test

        }
    }
}
