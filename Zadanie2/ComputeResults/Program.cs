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
            double doubleAndFractionDiffrenceSum = 0;
            double floatAndFractionDiffrenceSum = 0;

            for (int i = 0; i < 3; i++)
            {
                double[] doubleResult1 = ReadMatrix<double>(fileName + "Double", i+1);
                float[] floatResult1 = ReadMatrix<float>(fileName + "Float", i+1);
                double[] fractionResult1 = ReadMatrix<double>(fileName + "Fraction", i+1);

                double doubleAndFractionDiffrence = vectorNorm(doubleResult1, fractionResult1);
                double floatAndFractionDiffrence = vectorNorm(floatResult1, fractionResult1);

                doubleAndFractionDiffrenceSum += doubleAndFractionDiffrence;
                floatAndFractionDiffrenceSum += floatAndFractionDiffrence;
            }

            Console.WriteLine("Bład dla double: {0}", doubleAndFractionDiffrenceSum);
            Console.WriteLine("Błąd dla float: {0}", floatAndFractionDiffrenceSum);
            
        }

        private static double vectorNorm(double[] doubleResult, double[] fractionResult)
        {
            double[] temp = new double[size];
            double sum = 0;
            for(int i = 0; i < size; i++)
            {
                temp[i] = fractionResult[i] - doubleResult[i];
                temp[i] *= temp[i];
                sum += temp[i];
            }

            sum = Math.Sqrt(sum);

            return sum;
        }

        private static double vectorNorm(float[] floatResult, double[] fractionResult)
        {
            double[] temp = new double[size];
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                temp[i] = fractionResult[i] - floatResult[i];
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
