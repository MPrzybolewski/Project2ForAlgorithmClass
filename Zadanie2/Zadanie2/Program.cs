﻿using System;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace Zadanie2
{
    class MainClass
    {
        public static string source = "D:\\Projekty\\Algorytmy\\Data\\";
        public static void CleanFiles()
        {
            int i = 1;
            while (i <= 3)
            {
                System.IO.File.WriteAllText(source + "DataRange\\DataRangeDouble" + i + ".txt", "");
                System.IO.File.WriteAllText(source + "DataRange\\DataRangeFloat" + i + ".txt", "");
                System.IO.File.WriteAllText(source + "DataRange\\DataRangeFraction" + i + ".txt", "");
                i++;
            }
            System.IO.File.WriteAllText(source + "Results\\(AxX)DataResultFraction.txt", "");
            System.IO.File.WriteAllText(source + "Results\\(A+B+C)x(X)DataResultFraction.txt", "");
            System.IO.File.WriteAllText(source + "Results\\(Ax(BxC))DataResultFraction.txt", "");

            System.IO.File.WriteAllText(source + "Results\\(AxX)DataResultFloat.txt", "");
            System.IO.File.WriteAllText(source + "Results\\(A+B+C)x(X)DataResultFloat.txt", "");
            System.IO.File.WriteAllText(source + "Results\\(Ax(BxC))DataResultFloat.txt", "");

            System.IO.File.WriteAllText(source + "Results\\(AxX)DataResultDouble.txt", "");
            System.IO.File.WriteAllText(source + "Results\\(A+B+C)x(X)DataResultDouble.txt", "");
            System.IO.File.WriteAllText(source + "Results\\(Ax(BxC))DataResultDouble.txt", "");

            System.IO.File.WriteAllText(source + "Results\\NoChoiceGaussFraction.txt", "");
            System.IO.File.WriteAllText(source + "Results\\RowChoiceGaussFraction.txt", "");
            System.IO.File.WriteAllText(source + "Results\\FullChoiceGaussFraction.txt", "");

            System.IO.File.WriteAllText(source + "Results\\NoChoiceGaussFloat.txt", "");
            System.IO.File.WriteAllText(source + "Results\\RowChoiceGaussFloat.txt", "");
            System.IO.File.WriteAllText(source + "Results\\FullChoiceGaussFloat.txt", "");

            System.IO.File.WriteAllText(source + "Results\\NoChoiceGaussDouble.txt", "");
            System.IO.File.WriteAllText(source + "Results\\RowChoiceGaussDouble.txt", "");
            System.IO.File.WriteAllText(source + "Results\\FullChoiceGaussDouble.txt", "");

        }

        public static void WriteVectorToFile<T>(T[] vector, string name)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(source + "Results\\" + name + ".txt", true))
                {
                    file.WriteLine(String.Format("{0:N3}", vector[i]));
                }
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(source + "Results\\" + name + ".txt", true))
            {
                file.Write("*** *** *** *** *** ***\n");
            }
        }

        public static void ComputeAll(int size)
        {
            int i = 1;
            while (i <= 3)
            {
                Console.WriteLine("Przed {0}", i);
                Random rand = new Random();
                MyMatrix<MyFraction> firstFractionMatrix = new MyMatrix<MyFraction>(size, size);
                MyMatrix<MyFraction> secondFractionMatrix = new MyMatrix<MyFraction>(size, size);
                MyMatrix<MyFraction> thirdFractionMatrix = new MyMatrix<MyFraction>(size, size);
                MyFraction[] firstFractionVector = new MyFraction[size];
                MyFraction[] firstFractionResult = new MyFraction[size];
                MyFraction[] secondFractionResult = new MyFraction[size];
                MyMatrix<MyFraction> thirdFractionResult = new MyMatrix<MyFraction>(size, size);
                MyFraction[] fourthFractionResult = new MyFraction[size];
                MyFraction[] fifthFractionResult = new MyFraction[size];
                MyFraction[] sixthFractionResult = new MyFraction[size];
                MyMatrix<float> firstFloatMatrix = new MyMatrix<float>(size, size);
                MyMatrix<float> secondFloatMatrix = new MyMatrix<float>(size, size);
                MyMatrix<float> thirdFloatMatrix = new MyMatrix<float>(size, size);
                float[] firstFloatVector = new float[size];
                float[] firstFloatResult = new float[size];
                float[] secondFloatResult = new float[size];
                MyMatrix<float> thirdFloatResult = new MyMatrix<float>(size, size);
                float[] fourthFloatResult = new float[size];
                float[] fifthFloatResult = new float[size];
                float[] sixthFloatResult = new float[size];
                MyMatrix<double> firstDoubleMatrix = new MyMatrix<double>(size, size);
                MyMatrix<double> secondDoubleMatrix = new MyMatrix<double>(size, size);
                MyMatrix<double> thirdDoubleMatrix = new MyMatrix<double>(size, size);
                double[] firstDoubleVector = new double[size];
                double[] firstDoubleResult = new double[size];
                double[] secondDoubleResult = new double[size];
                MyMatrix<double> thirdDoubleResult = new MyMatrix<double>(size, size);
                double[] fourthDoubleResult = new double[size];
                double[] fifthDoubleResult = new double[size];
                double[] sixthDoubleResult = new double[size];
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        int a = rand.Next(1, 10);
                        int b = rand.Next(1, 10);
                        firstFractionMatrix.matrix[j, k] = new MyFraction(a, b);
                        secondFractionMatrix.matrix[j, k] = new MyFraction(a, b);
                        thirdFractionMatrix.matrix[j, k] = new MyFraction(a, b);
                        firstFractionVector[j] = new MyFraction(a, b);
                        firstFloatMatrix.matrix[j, k] = (float)a / b;
                        secondFloatMatrix.matrix[j, k] = (float)a / b;
                        thirdFloatMatrix.matrix[j, k] = (float)a / b;
                        firstFloatVector[j] = (float)a / b;
                        firstDoubleMatrix.matrix[j, k] = (double)a / b;
                        secondDoubleMatrix.matrix[j, k] = (double)a / b;
                        thirdDoubleMatrix.matrix[j, k] = (double)a / b;
                        firstDoubleVector[j] = (double)a / b;
                    }

                }
                Console.WriteLine("Po forze {0}", i);
                firstFractionMatrix.WriteMatrixToFile("DataRangeFraction" + i.ToString());
                secondFractionMatrix.WriteMatrixToFile("DataRangeFraction" + i.ToString());
                thirdFractionMatrix.WriteMatrixToFile("DataRangeFraction" + i.ToString());

                firstFractionResult = firstFractionMatrix * firstFractionVector;
                secondFractionResult = (firstFractionMatrix + secondFractionMatrix + thirdFractionMatrix) * firstFractionVector;
                thirdFractionResult = firstFractionMatrix * (secondFractionMatrix * thirdFractionMatrix);
                /*Console.WriteLine("Przed Gaussem");
                fourthFractionResult = firstFractionMatrix.gaussWithoutChoice((MyFraction[])firstFractionVector.Clone());
                Console.WriteLine("Po 1");
                fifthFractionResult = firstFractionMatrix.gaussWithRowChoice((MyFraction[])firstFractionVector.Clone());
                Console.WriteLine("Po 2");
                sixthFractionResult = firstFractionMatrix.gaussWithFullChoice((MyFraction[])firstFractionVector.Clone());
                Console.WriteLine("Po 3");*/

                WriteVectorToFile(firstFractionResult, "(AxX)DataResultFactorial");
                WriteVectorToFile(secondFractionResult, "(A+B+C)x(X)DataResultFactorial");
                thirdFractionResult.WriteMatrixToFile("(Ax(BxC))DataResultFactorial");
                WriteVectorToFile(fourthFractionResult, "NoChoiceGaussFactorial");
                WriteVectorToFile(fifthFractionResult, "RowChoiceGaussFactorial");
                WriteVectorToFile(sixthFractionResult, "FullChoiceGaussFactorial");

                firstFractionMatrix.WriteMatrixToFile("DataRangeFloat" + i.ToString());
                secondFractionMatrix.WriteMatrixToFile("DataRangeFloat" + i.ToString());
                thirdFractionMatrix.WriteMatrixToFile("DataRangeFloat" + i.ToString());

                firstFloatResult = firstFloatMatrix * firstFloatVector;
                secondFloatResult = (firstFloatMatrix + secondFloatMatrix + thirdFloatMatrix) * firstFloatVector;
                thirdFloatResult = firstFloatMatrix * (secondFloatMatrix * thirdFloatMatrix);
                /*Console.WriteLine("Przed Gaussem");
                fourthFloatResult = firstFloatMatrix.gaussWithoutChoice((float[])firstFloatVector.Clone());
                Console.WriteLine("Po 1");
                fifthFloatResult = firstFloatMatrix.gaussWithRowChoice((float[])firstFloatVector.Clone());
                Console.WriteLine("Po 2");
                sixthFloatResult = firstFloatMatrix.gaussWithFullChoice((float[])firstFloatVector.Clone());
                Console.WriteLine("Po 3");*/

                WriteVectorToFile(firstFloatResult, "(AxX)DataResultFloat");
                WriteVectorToFile(secondFloatResult, "(A+B+C)x(X)DataResultFloat");
                thirdFloatResult.WriteMatrixToFile("(Ax(BxC))DataResultFloat");
                WriteVectorToFile(fourthFloatResult, "NoChoiceGaussFloat");
                WriteVectorToFile(fifthFloatResult, "RowChoiceGaussFloat");
                WriteVectorToFile(sixthFloatResult, "FullChoiceGaussFloat");

                firstDoubleMatrix.WriteMatrixToFile("DataRangeDouble" + i.ToString());
                secondDoubleMatrix.WriteMatrixToFile("DataRangeDouble" + i.ToString());
                thirdDoubleMatrix.WriteMatrixToFile("DataRangeDouble" + i.ToString());

                firstDoubleResult = firstDoubleMatrix * firstDoubleVector;
                secondDoubleResult = (firstDoubleMatrix + secondDoubleMatrix + thirdDoubleMatrix) * firstDoubleVector;
                thirdDoubleResult = firstDoubleMatrix * (secondDoubleMatrix * thirdDoubleMatrix);
                /*Console.WriteLine("Przed Gaussem");
                fourthDoubleResult = firstDoubleMatrix.gaussWithoutChoice((double[])firstDoubleVector.Clone());
                Console.WriteLine("Po 1");
                fifthDoubleResult = firstDoubleMatrix.gaussWithRowChoice((double[])firstDoubleVector.Clone());
                Console.WriteLine("Po 2");
                sixthDoubleResult = firstDoubleMatrix.gaussWithFullChoice((double[])firstDoubleVector.Clone());
                Console.WriteLine("Po 3");*/

                WriteVectorToFile(firstDoubleResult, "(AxX)DataResultDouble");
                WriteVectorToFile(secondDoubleResult, "(A+B+C)x(X)DataResultDouble");
                thirdDoubleResult.WriteMatrixToFile("(Ax(BxC))DataResultDouble");
                WriteVectorToFile(fourthDoubleResult, "NoChoiceGaussDouble");
                WriteVectorToFile(fifthDoubleResult, "RowChoiceGaussDouble");
                WriteVectorToFile(sixthDoubleResult, "FullChoiceGaussDouble");
                Console.WriteLine("koniec {0}", i);
                i++;
            }

        }


        public static void Main(string[] args)
        {
            CleanFiles();
            ComputeAll(10);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

    }
}
