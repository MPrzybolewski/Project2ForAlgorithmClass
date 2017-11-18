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
            ComputeOperationsResults();
            Console.ReadKey();
        }

        private static void ComputeOperationsResults()
        {

            computeApBpCxX("(A+B+C)x(X)DataResult");
            computeAxBxC("(Ax(BxC))DataResult");
            computeAxX("(AxX)DataResult");

            computeGauss();
        }

        private static void computeGauss()
        {
            computeGaussType("NoChoiceGauss");
            computeGaussType("RowChoiceGauss"); 
            computeGaussType("FullChoiceGauss");
           
            
        }

        private static void computeGaussType(string type)
        {
            Console.WriteLine();
            Console.WriteLine(type);
            double doubleAndFractionDiffrenceSum = 0;
            double floatAndFractionDiffrenceSum = 0;
            for (int i = 0; i < 3; i++)
            {
                double[] doubleResult = ReadVector<double>(type + "Double", i + 1);
                float[] floatResult = ReadVector<float>(type + "Float", i + 1);
                double[] fractionResult = ReadVector<double>(type + "Fraction", i + 1);

                double doubleAndFractionDiffrence = vectorNorm(doubleResult, fractionResult);
                double floatAndFractionDiffrence = vectorNorm(floatResult, fractionResult);

                doubleAndFractionDiffrenceSum += doubleAndFractionDiffrence;
                floatAndFractionDiffrenceSum += floatAndFractionDiffrence;
            }

            Console.WriteLine("Bład dla double: {0}", doubleAndFractionDiffrenceSum);
            Console.WriteLine("Błąd dla float: {0}", floatAndFractionDiffrenceSum);
        }

        private static void computeAxX(string fileName)
        {
            Console.WriteLine();
            Console.WriteLine("A * X");
            double doubleAndFractionDiffrenceSum = 0;
            double floatAndFractionDiffrenceSum = 0;

            for (int i = 0; i < 3; i++)
            {
                double[] doubleResult1 = ReadVector<double>(fileName + "Double", i + 1);
                float[] floatResult1 = ReadVector<float>(fileName + "Float", i + 1);
                double[] fractionResult1 = ReadVector<double>(fileName + "Fraction", i + 1);

                double doubleAndFractionDiffrence = vectorNorm(doubleResult1, fractionResult1);
                double floatAndFractionDiffrence = vectorNorm(floatResult1, fractionResult1);

                doubleAndFractionDiffrenceSum += doubleAndFractionDiffrence;
                floatAndFractionDiffrenceSum += floatAndFractionDiffrence;
            }

            Console.WriteLine("Bład dla double: {0}", doubleAndFractionDiffrenceSum);
            Console.WriteLine("Błąd dla float: {0}", floatAndFractionDiffrenceSum);
        }

        private static void computeAxBxC(string fileName)
        {
            Console.WriteLine();
            Console.WriteLine("A * (B * C)");
            double doubleAndFractionDiffrenceSum = 0;
            double floatAndFractionDiffrenceSum = 0;

            for (int i = 0; i < 3; i++)
            {
                double[] doubleResult1 = ReadMatrix<double>(fileName + "Double", i + 1);
                float[] floatResult1 = ReadMatrix<float>(fileName + "Float", i + 1);
                double[] fractionResult1 = ReadMatrix<double>(fileName + "Fraction", i + 1);

                double doubleAndFractionDiffrence = vectorNorm(doubleResult1, fractionResult1);
                double floatAndFractionDiffrence = vectorNorm(floatResult1, fractionResult1);

                doubleAndFractionDiffrenceSum += doubleAndFractionDiffrence;
                floatAndFractionDiffrenceSum += floatAndFractionDiffrence;
            }

            Console.WriteLine("Bład dla double: {0}", doubleAndFractionDiffrenceSum);
            Console.WriteLine("Błąd dla float: {0}", floatAndFractionDiffrenceSum);
        }


        private static void computeApBpCxX(string fileName)
        {
            Console.WriteLine();
            Console.WriteLine("(A+B+C)*X");
            double doubleAndFractionDiffrenceSum = 0;
            double floatAndFractionDiffrenceSum = 0;

            for (int i = 0; i < 3; i++)
            {
                double[] doubleResult1 = ReadVector<double>(fileName + "Double", i+1);
                
                float[] floatResult1 = ReadVector<float>(fileName + "Float", i+1);
                double[] fractionResult1 = ReadVector<double>(fileName + "Fraction", i+1);

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
        private static T[] ReadVector<T>(string fileName, int numberOfMatrix)
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
        }


        private static T[] ReadMatrix<T>(string fileName, int numberOfMatrix)
        {
            int sizeOfVector = size * size;
            T[] tempTable = new T[sizeOfVector];
            Type t = tempTable.GetType();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Marek\Documents\Project2ForAlgorithmClass\Zadanie2\Zadanie2\Data\Results\" + fileName + ".txt");
            int i = 0;
            int j = 0;
            int rowInVector = 0;

            foreach (string line in lines)
            {
                if (j == numberOfMatrix - 1)
                {
                    if (sizeOfVector == rowInVector)
                    {
                        break;
                    }
                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                    string[] item = line.Split(' ');
                    for(int k = 0; k < item.Length-1; k++)
                    {
                        string test = item[k];
                        tempTable[rowInVector] = (T)tc.ConvertFrom(test);
                        rowInVector++;
                    }
                    i++;
                }

                if (line.Contains("*") == true)
                {
                    j++;
                }

            }
            return tempTable;
        }
    }
}
