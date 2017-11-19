using System;
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

            System.IO.File.WriteAllText(source + "Results\\Times.txt", "");

        }

        public static void WriteVectorToFile<T>(T[] vector, string name)
        {
            if(name.Contains("Range"))
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(source + "DataRange\\" + name + ".txt", true))
                    {
                        file.WriteLine(String.Format("{0:N16}", vector[i]));
                    }
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(source + "DataRange\\" + name + ".txt", true))
                {
                    file.Write("*** *** *** *** *** ***\n");
                }
            }
            else
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(source + "Results\\" + name + ".txt", true))
                    {
                        file.WriteLine(String.Format("{0:N16}", vector[i]));
                    }
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(source + "Results\\" + name + ".txt", true))
                {
                    file.Write("*** *** *** *** *** ***\n");
                }
            }
            
        }

        public static void ComputeAll(int size)
        {
            TimeSpan firstSumF = default(TimeSpan); 
            TimeSpan secondSumF = default(TimeSpan); 
            TimeSpan thirdSumF = default(TimeSpan); 
            TimeSpan fourthSumF = default(TimeSpan); 
            TimeSpan fifthSumF = default(TimeSpan); 
            TimeSpan sixthSumF = default(TimeSpan); 
            TimeSpan firstSumD = default(TimeSpan); 
            TimeSpan secondSumD = default(TimeSpan); 
            TimeSpan thirdSumD = default(TimeSpan); 
            TimeSpan fourthSumD = default(TimeSpan); 
            TimeSpan fifthSumD = default(TimeSpan); 
            TimeSpan sixthSumD = default(TimeSpan); 
            TimeSpan firstSumFr = default(TimeSpan); 
            TimeSpan secondSumFr = default(TimeSpan); 
            TimeSpan thirdSumFr = default(TimeSpan); 
            TimeSpan fourthSumFr = default(TimeSpan); 
            TimeSpan fifthSumFr = default(TimeSpan); 
            TimeSpan sixthSumFr = default(TimeSpan); 
            int i = 1;
            while (i <= 3)
            {
                Console.WriteLine("Przed {0}", i);
                Random rand = new Random();
                MyMatrix<MyFraction> firstFractionMatrix = new MyMatrix<MyFraction>(size, size);
                MyMatrix<MyFraction> secondFractionMatrix = new MyMatrix<MyFraction>(size, size);
                MyMatrix<MyFraction> thirdFractionMatrix = new MyMatrix<MyFraction>(size, size);
                MyFraction[,] firstFractionTable = new MyFraction[size, size];
                MyFraction[,] secondFractionTable = new MyFraction[size, size];
                MyFraction[,] thirdFractionTable = new MyFraction[size, size];
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
                float[,] firstFloatTable = new float[size, size];
                float[,] secondFloatTable = new float[size, size];
                float[,] thirdFloatTable = new float[size, size];
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
                double[,] firstDoubleTable = new double[size, size];
                double[,] secondDoubleTable = new double[size, size];
                double[,] thirdDoubleTable = new double[size, size];
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
                        firstFractionTable[j,k] = new MyFraction(a, b);                    
                        firstFloatTable[j, k] = (float)a / b;                  
                        firstDoubleTable[j, k] = (double)a / b;
                        int c = rand.Next(1, 10);
                        int d = rand.Next(1, 10);
                        firstFractionVector[j] = new MyFraction(c, d);
                        firstDoubleVector[j] = (double)c / d;
                        firstFloatVector[j] = (float)c / d;
                    }

                }

                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        int a = rand.Next(1, 10);
                        int b = rand.Next(1, 10);
                        secondFractionTable[j, k] = new MyFraction(a, b);
                        secondFloatTable[j, k] = (float)a / b;
                        secondDoubleTable[j, k] = (double)a / b;
                    }

                }

                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        int a = rand.Next(1, 10);
                        int b = rand.Next(1, 10);
                        thirdFractionTable[j, k] = new MyFraction(a, b);
                        thirdFloatTable[j, k] = (float)a / b;
                        thirdDoubleTable[j, k] = (double)a / b;
                    }

                }

                firstFractionMatrix.complementMatrix(firstFractionTable);
                secondFractionMatrix.complementMatrix(secondFractionTable);
                thirdFractionMatrix.complementMatrix(thirdFractionTable);
                firstFloatMatrix.complementMatrix(firstFloatTable);
                secondFloatMatrix.complementMatrix(secondFloatTable);
                thirdFloatMatrix.complementMatrix(thirdFloatTable);
                firstDoubleMatrix.complementMatrix(firstDoubleTable);
                secondDoubleMatrix.complementMatrix(secondDoubleTable);
                thirdDoubleMatrix.complementMatrix(thirdDoubleTable);

                if (i==3)
                {
                    Console.WriteLine("debug");
                    thirdDoubleMatrix.printMatrix();
                }


                Console.WriteLine("Po forze {0}", i);
                firstFractionMatrix.WriteMatrixToFile("DataRangeFraction" + i.ToString());
                secondFractionMatrix.WriteMatrixToFile("DataRangeFraction" + i.ToString());
                thirdFractionMatrix.WriteMatrixToFile("DataRangeFraction" + i.ToString());
                WriteVectorToFile(firstFractionVector, "DataRangeFraction" + i.ToString());

                DateTime startTime = DateTime.Now;
                firstFractionResult = firstFractionMatrix * firstFractionVector;
                DateTime endTime = DateTime.Now;
                firstSumFr += startTime - endTime;
                startTime = DateTime.Now;
                secondFractionResult = (firstFractionMatrix + secondFractionMatrix + thirdFractionMatrix) * firstFractionVector;
                endTime = DateTime.Now;
                secondSumFr += startTime - endTime;
                startTime = DateTime.Now;
                thirdFractionResult = firstFractionMatrix * (secondFractionMatrix * thirdFractionMatrix);
                endTime = DateTime.Now;
                thirdSumFr += startTime - endTime;
                startTime = DateTime.Now;
                fourthFractionResult = firstFractionMatrix.gaussWithoutChoice((MyFraction[])firstFractionVector.Clone());
                endTime = DateTime.Now;
                fourthSumFr += startTime - endTime;
                startTime = DateTime.Now;
                fifthFractionResult = firstFractionMatrix.gaussWithRowChoice((MyFraction[])firstFractionVector.Clone());
                endTime = DateTime.Now;
                fifthSumFr += startTime - endTime;
                startTime = DateTime.Now;
                sixthFractionResult = firstFractionMatrix.gaussWithFullChoice((MyFraction[])firstFractionVector.Clone());
                endTime = DateTime.Now;
                sixthSumFr += startTime - endTime;

                WriteVectorToFile(firstFractionResult, "(AxX)DataResultFraction");
                WriteVectorToFile(secondFractionResult, "(A+B+C)x(X)DataResultFraction");
                thirdFractionResult.WriteMatrixToFile("(Ax(BxC))DataResultFraction");
                WriteVectorToFile(fourthFractionResult, "NoChoiceGaussFraction");
                WriteVectorToFile(fifthFractionResult, "RowChoiceGaussFraction");
                WriteVectorToFile(sixthFractionResult, "FullChoiceGaussFraction");

                firstFractionMatrix.WriteMatrixToFile("DataRangeFloat" + i.ToString());
                secondFractionMatrix.WriteMatrixToFile("DataRangeFloat" + i.ToString());
                thirdFractionMatrix.WriteMatrixToFile("DataRangeFloat" + i.ToString());
                WriteVectorToFile(firstFloatVector, "DataRangeFloat" + i.ToString());

                startTime = DateTime.Now;
                firstFloatResult = firstFloatMatrix * firstFloatVector;
                endTime = DateTime.Now;
                firstSumF += startTime - endTime;
                startTime = DateTime.Now;
                secondFloatResult = (firstFloatMatrix + secondFloatMatrix + thirdFloatMatrix) * firstFloatVector;
                endTime = DateTime.Now;
                secondSumF += startTime - endTime;
                startTime = DateTime.Now;
                thirdFloatResult = firstFloatMatrix * (secondFloatMatrix * thirdFloatMatrix);
                endTime = DateTime.Now;
                thirdSumF += startTime - endTime;
                startTime = DateTime.Now;
                fourthFloatResult = firstFloatMatrix.gaussWithoutChoice((float[])firstFloatVector.Clone());
                endTime = DateTime.Now;
                fourthSumF += startTime - endTime;
                startTime = DateTime.Now;
                fifthFloatResult = firstFloatMatrix.gaussWithRowChoice((float[])firstFloatVector.Clone());
                endTime = DateTime.Now;
                fifthSumF += startTime - endTime;
                startTime = DateTime.Now;
                sixthFloatResult = firstFloatMatrix.gaussWithFullChoice((float[])firstFloatVector.Clone());
                endTime = DateTime.Now;
                sixthSumF += startTime - endTime;
                startTime = DateTime.Now;

                WriteVectorToFile(firstFloatResult, "(AxX)DataResultFloat");
                WriteVectorToFile(secondFloatResult, "(A+B+C)x(X)DataResultFloat");
                thirdFloatResult.WriteMatrixToFile("(Ax(BxC))DataResultFloat");
                WriteVectorToFile(fourthFloatResult, "NoChoiceGaussFloat");
                WriteVectorToFile(fifthFloatResult, "RowChoiceGaussFloat");
                WriteVectorToFile(sixthFloatResult, "FullChoiceGaussFloat");

                firstDoubleMatrix.WriteMatrixToFile("DataRangeDouble" + i.ToString());
                secondDoubleMatrix.WriteMatrixToFile("DataRangeDouble" + i.ToString());
                thirdDoubleMatrix.WriteMatrixToFile("DataRangeDouble" + i.ToString());
                WriteVectorToFile(firstDoubleVector, "DataRangeDouble" + i.ToString());

                startTime = DateTime.Now;
                firstDoubleResult = firstDoubleMatrix * firstDoubleVector;
                endTime = DateTime.Now;
                firstSumD += startTime - endTime;
                startTime = DateTime.Now;
                secondDoubleResult = (firstDoubleMatrix + secondDoubleMatrix + thirdDoubleMatrix) * firstDoubleVector;
                endTime = DateTime.Now;
                secondSumD += startTime - endTime;
                startTime = DateTime.Now;
                thirdDoubleResult = firstDoubleMatrix * (secondDoubleMatrix * thirdDoubleMatrix);
                endTime = DateTime.Now;
                thirdSumD += startTime - endTime;
                startTime = DateTime.Now;
                fourthDoubleResult = firstDoubleMatrix.gaussWithoutChoice((double[])firstDoubleVector.Clone());
                endTime = DateTime.Now;
                fourthSumD += startTime - endTime;
                startTime = DateTime.Now;
                fifthDoubleResult = firstDoubleMatrix.gaussWithRowChoice((double[])firstDoubleVector.Clone());
                endTime = DateTime.Now;
                fifthSumD += startTime - endTime;
                startTime = DateTime.Now;
                sixthDoubleResult = firstDoubleMatrix.gaussWithFullChoice((double[])firstDoubleVector.Clone());
                endTime = DateTime.Now;
                sixthSumD += startTime - endTime;
                startTime = DateTime.Now;

                WriteVectorToFile(firstDoubleResult, "(AxX)DataResultDouble");
                WriteVectorToFile(secondDoubleResult, "(A+B+C)x(X)DataResultDouble");
                thirdDoubleResult.WriteMatrixToFile("(Ax(BxC))DataResultDouble");
                WriteVectorToFile(fourthDoubleResult, "NoChoiceGaussDouble");
                WriteVectorToFile(fifthDoubleResult, "RowChoiceGaussDouble");
                WriteVectorToFile(sixthDoubleResult, "FullChoiceGaussDouble");


                i++;
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(source + "Results\\Times.txt", true))
            {
                file.WriteLine(String.Format("{0:N16}", firstSumFr.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", secondSumFr.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", thirdSumFr.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", fourthSumFr.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", fifthSumFr.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", sixthSumFr.TotalSeconds / -3));
                file.WriteLine("*** *** *** *** ***");
                file.WriteLine(String.Format("{0:N16}", firstSumF.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", secondSumF.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", thirdSumF.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", fourthSumF.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", fifthSumF.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", sixthSumF.TotalSeconds / -3));
                file.WriteLine("*** *** *** *** ***");
                file.WriteLine(String.Format("{0:N16}", firstSumD.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", secondSumD.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", thirdSumD.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", fourthSumD.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", fifthSumD.TotalSeconds / -3));
                file.WriteLine(String.Format("{0:N16}", sixthSumD.TotalSeconds / -3));
                file.WriteLine("*** *** *** *** ***");
            }

        }


        public static void Main(string[] args)
        {
            CleanFiles();
            ComputeAll(Int32.Parse(args[0]));
            Console.WriteLine("Done");
            Console.ReadKey();
        }

    }
}
