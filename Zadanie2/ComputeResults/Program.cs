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
            size = Int32.Parse(args[0]);
            Console.WriteLine("Obliczenia dla macierzy kwadratowej {0}", size);
            ComputeOperationsResults();
            Console.WriteLine("Koniec");
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
            double doubleAndFractionFullDiffrenceSumCpp = 0;
            double doubleAndFractionPartialDiffrenceSumCpp = 0;
            double floatAndFractionDiffrenceSum = 0;
            double floatAndFractionFullDiffrenceSumCpp = 0;
            double floatAndFractionPartiaDiffrenceSumCpp = 0;

            for (int i = 0; i < 3; i++)
            {
                double[] doubleResult = ReadVector<double>("Zadanie2\\Zadanie2\\Data\\Results\\" + type + "Double", i + 1);
                float[] floatResult = ReadVector<float>("Zadanie2\\Zadanie2\\Data\\Results\\" + type + "Float", i + 1);
                double[] fractionResult = ReadVector<double>("Zadanie2\\Zadanie2\\Data\\Results\\" + type + "Fraction", i + 1);
                if (type == "RowChoiceGauss")
                {
                    double[] doubleResultPartialCpp = ReadVector<double>("Eigen\\PartialGausseDouble[C]", i + 1);
                    float[] floatResultPartialCpp = ReadVector<float>("Eigen\\PartialGausseFloat[C]", i + 1);
                    double doubleAndFractionPartialDiffrenceCpp = vectorNorm(doubleResultPartialCpp, fractionResult);
                    double floatAndFractionPartialDiffrenceCpp = vectorNorm(floatResultPartialCpp, fractionResult);
                    doubleAndFractionPartialDiffrenceSumCpp += doubleAndFractionPartialDiffrenceCpp;
                    floatAndFractionPartiaDiffrenceSumCpp += floatAndFractionPartialDiffrenceCpp;
                } else if( type == "FullChoiceGauss")
                {
                    double[] doubleResultFullCpp = ReadVector<double>("Eigen\\FullGausseDouble[C]", i + 1);
                    float[] floatResultFullCpp = ReadVector<float>("Eigen\\FullGausseFloat[C]", i + 1);
                    double doubleAndFractionFullDiffrenceCpp = vectorNorm(doubleResultFullCpp, fractionResult);
                    double floatAndFractionFullDiffrenceCpp = vectorNorm(floatResultFullCpp, fractionResult);
                    doubleAndFractionFullDiffrenceSumCpp += doubleAndFractionFullDiffrenceCpp;
                    floatAndFractionFullDiffrenceSumCpp += floatAndFractionFullDiffrenceCpp;
                }
               

                double doubleAndFractionDiffrence = vectorNorm(doubleResult, fractionResult);
                double floatAndFractionDiffrence = vectorNorm(floatResult, fractionResult);
                doubleAndFractionDiffrenceSum += doubleAndFractionDiffrence;
                floatAndFractionDiffrenceSum += floatAndFractionDiffrence;
                
               

            }

            Console.WriteLine("Bład dla double: {0}", doubleAndFractionDiffrenceSum/3);
            Console.WriteLine("Błąd dla float: {0}", floatAndFractionDiffrenceSum/3);
            if (type == "RowChoiceGauss")
            {
                Console.WriteLine("Bład dla double Partial: {0}", doubleAndFractionPartialDiffrenceSumCpp);
                Console.WriteLine("Bład dla float Partial: {0}", floatAndFractionPartiaDiffrenceSumCpp);

            } else if(type == "FullChoiceGauss")
            {
                Console.WriteLine("Bład dla double Full: {0}", doubleAndFractionFullDiffrenceSumCpp);
                Console.WriteLine("Bład dla float Full: {0}", floatAndFractionFullDiffrenceSumCpp);
            }



        }

        private static void computeAxX(string fileName)
        {
            Console.WriteLine();
            Console.WriteLine("A * X");
            double doubleAndFractionDiffrenceSum = 0;
            double doubleAndFractionDiffrenceSumCpp = 0;
            double floatAndFractionDiffrenceSum = 0;
            double floatAndFractionDiffrenceSumCpp = 0;


            for (int i = 0; i < 3; i++)
            {
                double[] doubleResult = ReadVector<double>("Zadanie2\\Zadanie2\\Data\\Results\\" + fileName + "Double", i + 1);
                float[] floatResult = ReadVector<float>("Zadanie2\\Zadanie2\\Data\\Results\\" + fileName + "Float", i + 1);
                double[] fractionResult = ReadVector<double>("Zadanie2\\Zadanie2\\Data\\Results\\" + fileName + "Fraction", i + 1);
                double[] doubleResultCpp = ReadVector<double>("Eigen\\" + fileName + "Double[C]", i + 1);
                float[] floatResultCpp = ReadVector<float>("Eigen\\" + fileName + "Float[C]", i + 1);

                double doubleAndFractionDiffrence = vectorNorm(doubleResult, fractionResult);
                double floatAndFractionDiffrence = vectorNorm(floatResult, fractionResult);
                double doubleAndFracitonDriffrenceCpp = vectorNorm(doubleResultCpp, fractionResult);
                double floatAndFractionDiffrenceCpp = vectorNorm(floatResultCpp, fractionResult);

                doubleAndFractionDiffrenceSum += doubleAndFractionDiffrence;
                floatAndFractionDiffrenceSum += floatAndFractionDiffrence;
                doubleAndFractionDiffrenceSumCpp += doubleAndFracitonDriffrenceCpp;
                floatAndFractionDiffrenceSumCpp += floatAndFractionDiffrenceCpp;


            }

            Console.WriteLine("Bład dla double: {0}", doubleAndFractionDiffrenceSum/3);
            Console.WriteLine("Błąd dla float: {0}", floatAndFractionDiffrenceSum/3);
            Console.WriteLine("Błąd dla double c++: {0}", doubleAndFractionDiffrenceSumCpp/3);
            Console.WriteLine("Błąd dla float c++: {0}", floatAndFractionDiffrenceSumCpp/3);
        }

        private static void computeAxBxC(string fileName)
        {
            Console.WriteLine();
            Console.WriteLine("A * (B * C)");
            double doubleAndFractionDiffrenceSum = 0;
            double doubleAndFractionDiffrenceSumCpp = 0;
            double floatAndFractionDiffrenceSum = 0;
            double floatAndFractionDiffrenceSumCpp = 0;

            for (int i = 0; i < 3; i++)
            {
                double[] doubleResult = ReadMatrix<double>("Zadanie2\\Zadanie2\\Data\\Results\\" + fileName + "Double", i + 1);
                float[] floatResult = ReadMatrix<float>("Zadanie2\\Zadanie2\\Data\\Results\\" + fileName + "Float", i + 1);
                double[] fractionResult = ReadMatrix<double>("Zadanie2\\Zadanie2\\Data\\Results\\" + fileName + "Fraction", i + 1);
                double[] doubleResultCpp = ReadMatrix<double>("Eigen\\" + fileName + "Double[C]", i + 1);
                float[] floatResultCpp = ReadMatrix<float>("Eigen\\" + fileName + "Float[C]", i + 1);

                double doubleAndFractionDiffrence = vectorNorm(doubleResult, fractionResult);
                double floatAndFractionDiffrence = vectorNorm(floatResult, fractionResult);
                double doubleAndFracitonDriffrenceCpp = vectorNorm(doubleResultCpp, fractionResult);
                double floatAndFractionDiffrenceCpp = vectorNorm(floatResultCpp, fractionResult);

                doubleAndFractionDiffrenceSum += doubleAndFractionDiffrence;
                floatAndFractionDiffrenceSum += floatAndFractionDiffrence;
            }

            Console.WriteLine("Bład dla double: {0}", doubleAndFractionDiffrenceSum/3);
            Console.WriteLine("Błąd dla float: {0}", floatAndFractionDiffrenceSum/3);
            Console.WriteLine("Błąd dla double c++: {0}", doubleAndFractionDiffrenceSumCpp / 3);
            Console.WriteLine("Błąd dla float c++: {0}", floatAndFractionDiffrenceSumCpp / 3);
        }


        private static void computeApBpCxX(string fileName)
        {
            Console.WriteLine();
            Console.WriteLine("(A+B+C)*X");
            double doubleAndFractionDiffrenceSum = 0;
            double doubleAndFractionDiffrenceSumCpp = 0;
            double floatAndFractionDiffrenceSum = 0;
            double floatAndFractionDiffrenceSumCpp = 0;

            for (int i = 0; i < 3; i++)
            {
                double[] doubleResult = ReadVector<double>("Zadanie2\\Zadanie2\\Data\\Results\\" + fileName + "Double", i+1);
                float[] floatResult = ReadVector<float>("Zadanie2\\Zadanie2\\Data\\Results\\" + fileName + "Float", i+1);
                double[] fractionResult = ReadVector<double>("Zadanie2\\Zadanie2\\Data\\Results\\" + fileName + "Fraction", i+1);
                double[] doubleResultCpp = ReadVector<double>("Eigen\\" + fileName + "Double[C]", i + 1);
                float[] floatResultCpp = ReadVector<float>("Eigen\\" + fileName + "Float[C]", i + 1);

                double doubleAndFractionDiffrence = vectorNorm(doubleResult, fractionResult);
                double floatAndFractionDiffrence = vectorNorm(floatResult, fractionResult);
                double doubleAndFracitonDriffrenceCpp = vectorNorm(doubleResultCpp, fractionResult);
                double floatAndFractionDiffrenceCpp = vectorNorm(floatResultCpp, fractionResult);

                doubleAndFractionDiffrenceSum += doubleAndFractionDiffrence;
                floatAndFractionDiffrenceSum += floatAndFractionDiffrence;
                doubleAndFractionDiffrenceSumCpp += doubleAndFracitonDriffrenceCpp;
                floatAndFractionDiffrenceSumCpp += floatAndFractionDiffrenceCpp;
            }

            Console.WriteLine("Bład dla double: {0}", doubleAndFractionDiffrenceSum/3);
            Console.WriteLine("Błąd dla float: {0}", floatAndFractionDiffrenceSum/3);
            Console.WriteLine("Błąd dla double c++: {0}", doubleAndFractionDiffrenceSumCpp / 3);
            Console.WriteLine("Błąd dla float c++: {0}", floatAndFractionDiffrenceSumCpp / 3);

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
            string[] lines = System.IO.File.ReadAllLines("C:\\Users\\Marek\\Documents\\Project2ForAlgorithmClass\\" + fileName + ".txt");
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
                    tempTable[i] = (T)tc.ConvertFrom(line.Replace(".",","));
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
            string[] lines = System.IO.File.ReadAllLines("C:\\Users\\Marek\\Documents\\Project2ForAlgorithmClass\\" + fileName + ".txt");
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
                        string test = item[k].Replace(".", ",");
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
