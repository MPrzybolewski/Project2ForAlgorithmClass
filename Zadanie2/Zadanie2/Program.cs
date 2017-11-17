using System;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace Zadanie2
{
    class MainClass
    {
        public static void CleanFiles()
        {
            int i = 1;
            while (i <= 3)
            {
                System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\DataRange\DataRangeDouble"+i+".txt", "");
                System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\DataRange\DataRangeFloat"+i+".txt", "");
                System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\DataRange\DataRangeFactorial"+i+".txt", "");
                i++;
            }
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\(AxX)DataResultFactorial.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\(A+B+C)x(X)DataResultFactorial.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\(Ax(BxC))DataResultFactorial.txt", "");
            
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\(AxX)DataResultFloat.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\(A+B+C)x(X)DataResultFloat.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\(Ax(BxC))DataResultFloat.txt", "");
            
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\(AxX)DataResultDouble.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\(A+B+C)x(X)DataResultDouble.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\(Ax(BxC))DataResultDouble.txt", "");
            
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\NoChoiceGaussFactorial.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\RowChoiceGaussFactorial.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\FullChoiceGaussFactorial.txt", "");
            
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\NoChoiceGaussFloat.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\RowChoiceGaussFloat.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\FullChoiceGaussFloat.txt", "");
            
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\NoChoiceGaussDouble.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\RowChoiceGaussDouble.txt", "");
            System.IO.File.WriteAllText(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\FullChoiceGaussDouble.txt", "");
            
        }

        public static void WriteVectorToFile<T>(T[] vector, string name)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\"+name+".txt", true))
                {
                    file.WriteLine(String.Format("{0:N3}", vector[i]));
                }
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Zad2\Zadanie2\Zadanie2\Data\Results\"+name+".txt", true))
            {
                file.Write("*** *** *** *** *** ***\n");
            }
        }
        
        public static void ComputeAll<T>(int size)
        {
            int i = 1;
            while (i <= 3)
            {
                Random rand = new Random();
                T[] temp = new T[10];
                Type t = temp.GetType();
                if (t.ToString() == typeof(MyFraction) + "[]")
                {
                    MyMatrix<MyFraction> firstMatrix = new MyMatrix<MyFraction>(size,size);
                    MyMatrix<MyFraction> secondMatrix = new MyMatrix<MyFraction>(size,size);
                    MyMatrix<MyFraction> thirdMatrix = new MyMatrix<MyFraction>(size,size);
                    MyFraction[] firstVector = new MyFraction[size];
                    MyFraction[] firstResult = new MyFraction[size];
                    MyFraction[] secondResult = new MyFraction[size];
                    MyMatrix<MyFraction> thirdResult = new MyMatrix<MyFraction>(size,size);
                    MyFraction[] fourthResult = new MyFraction[size];
                    MyFraction[] fifthResult = new MyFraction[size];
                    MyFraction[] sixthResult = new MyFraction[size];
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            int a = rand.Next(1, 10);
                            int b = rand.Next(1, 10);
                            firstMatrix.matrix[j,k] = new MyFraction(a,b);
                            a = rand.Next(1, 10);
                            b = rand.Next(1, 10);
                            secondMatrix.matrix[j,k] = new MyFraction(a,b);
                            a = rand.Next(1, 10);
                            b = rand.Next(1, 10);
                            thirdMatrix.matrix[j,k] = new MyFraction(a,b);
                            a = rand.Next(1, 10);
                            b = rand.Next(1, 10);
                            firstVector[j] = new MyFraction(a,b);
                        }
                        
                    }
                    firstMatrix.WriteMatrixToFile("DataRangeFactorial"+i.ToString());
                    secondMatrix.WriteMatrixToFile("DataRangeFactorial"+i.ToString());
                    thirdMatrix.WriteMatrixToFile("DataRangeFactorial"+i.ToString());

                    firstResult = firstMatrix * firstVector;
                    secondResult = (firstMatrix + secondMatrix + thirdMatrix) * firstVector;
                    thirdResult = firstMatrix * (secondMatrix * thirdMatrix);
//                    Console.WriteLine("Przed Gaussem");
//                    fourthResult = firstMatrix.gaussWithoutChoice((MyFraction[])firstVector.Clone());
//                    Console.WriteLine("Po 1");
//                    fifthResult = firstMatrix.gaussWithRowChoice((MyFraction[])firstVector.Clone());
//                    Console.WriteLine("Po 2");
//                    sixthResult = firstMatrix.gaussWithFullChoice((MyFraction[])firstVector.Clone());
//                    Console.WriteLine("Po 3");
                    
                    WriteVectorToFile(firstResult, "(AxX)DataResultFactorial");
                    WriteVectorToFile(secondResult, "(A+B+C)x(X)DataResultFactorial");
                    thirdResult.WriteMatrixToFile("(Ax(BxC))DataResultFactorial");
                    WriteVectorToFile(fourthResult, "NoChoiceGaussFactorial");
                    WriteVectorToFile(fifthResult, "RowChoiceGaussFactorial");
                    WriteVectorToFile(sixthResult, "FullChoiceGaussFactorial");
                }
                else if (t.ToString() == typeof(float) + "[]")
                {
                    MyMatrix<float> firstMatrix = new MyMatrix<float>(size,size);
                    MyMatrix<float> secondMatrix = new MyMatrix<float>(size,size);
                    MyMatrix<float> thirdMatrix = new MyMatrix<float>(size,size);
                    float[] firstVector = new float[size];
                    float[] firstResult = new float[size];
                    float[] secondResult = new float[size];
                    MyMatrix<float> thirdResult = new MyMatrix<float>(size,size);
                    float[] fourthResult = new float[size];
                    float[] fifthResult = new float[size];
                    float[] sixthResult = new float[size];
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            int a = rand.Next(1, 10);
                            int b = rand.Next(1, 10);
                            firstMatrix.matrix[j,k] = (float)a/b;
                            a = rand.Next(1, 10);
                            b = rand.Next(1, 10);
                            secondMatrix.matrix[j,k] = (float)a/b;
                            a = rand.Next(1, 10);
                            b = rand.Next(1, 10);
                            thirdMatrix.matrix[j,k] = (float)a/b;
                            a = rand.Next(1, 10);
                            b = rand.Next(1, 10);
                            firstVector[j] = (float)a/b;
                        }
                    }
                    firstMatrix.WriteMatrixToFile("DataRangeFloat"+i.ToString());
                    secondMatrix.WriteMatrixToFile("DataRangeFloat"+i.ToString());
                    thirdMatrix.WriteMatrixToFile("DataRangeFloat"+i.ToString());
                    
                    firstResult = firstMatrix * firstVector;
                    secondResult = (firstMatrix + secondMatrix + thirdMatrix) * firstVector;
                    thirdResult = firstMatrix * (secondMatrix * thirdMatrix);
//                    Console.WriteLine("Przed Gaussem");
//                    fourthResult = firstMatrix.gaussWithoutChoice((float[])firstVector.Clone());
//                    Console.WriteLine("Po 1");
//                    fifthResult = firstMatrix.gaussWithRowChoice((float[])firstVector.Clone());
//                    Console.WriteLine("Po 2");
//                    sixthResult = firstMatrix.gaussWithFullChoice((float[])firstVector.Clone());
//                    Console.WriteLine("Po 3");
                    
                    WriteVectorToFile(firstResult, "(AxX)DataResultFloat");
                    WriteVectorToFile(secondResult, "(A+B+C)x(X)DataResultFloat");
                    thirdResult.WriteMatrixToFile("(Ax(BxC))DataResultFloat");
                    WriteVectorToFile(fourthResult, "NoChoiceGaussFloat");
                    WriteVectorToFile(fifthResult, "RowChoiceGaussFloat");
                    WriteVectorToFile(sixthResult, "FullChoiceGaussFloat");
                    
                }
                else
                {
                    MyMatrix<double> firstMatrix = new MyMatrix<double>(size,size);
                    MyMatrix<double> secondMatrix = new MyMatrix<double>(size,size);
                    MyMatrix<double> thirdMatrix = new MyMatrix<double>(size,size);
                    double[] firstVector = new double[size];
                    double[] firstResult = new double[size];
                    double[] secondResult = new double[size];
                    MyMatrix<double> thirdResult = new MyMatrix<double>(size,size);
                    double[] fourthResult = new double[size];
                    double[] fifthResult = new double[size];
                    double[] sixthResult = new double[size];
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            int a = rand.Next(1, 10);
                            int b = rand.Next(1, 10);
                            firstMatrix.matrix[j,k] = (double)a/b;
                            a = rand.Next(1, 10);
                            b = rand.Next(1, 10);
                            secondMatrix.matrix[j,k] = (double)a/b;
                            a = rand.Next(1, 10);
                            b = rand.Next(1, 10);
                            thirdMatrix.matrix[j,k] = (double)a/b;
                            a = rand.Next(1, 10);
                            b = rand.Next(1, 10);
                            firstVector[j] = (double)a/b;
                        }
                    }
                    firstMatrix.WriteMatrixToFile("DataRangeDouble"+i.ToString());
                    secondMatrix.WriteMatrixToFile("DataRangeDouble"+i.ToString());
                    thirdMatrix.WriteMatrixToFile("DataRangeDouble"+i.ToString());
                    
                    firstResult = firstMatrix * firstVector;
                    secondResult = (firstMatrix + secondMatrix + thirdMatrix) * firstVector;
                    thirdResult = firstMatrix * (secondMatrix * thirdMatrix);
//                    Console.WriteLine("Przed Gaussem");
//                    fourthResult = firstMatrix.gaussWithoutChoice((double[])firstVector.Clone());
//                    Console.WriteLine("Po 1");
//                    fifthResult = firstMatrix.gaussWithRowChoice((double[])firstVector.Clone());
//                    Console.WriteLine("Po 2");
//                    sixthResult = firstMatrix.gaussWithFullChoice((double[])firstVector.Clone());
//                    Console.WriteLine("Po 3");
                    
                    WriteVectorToFile(firstResult, "(AxX)DataResultDouble");
                    WriteVectorToFile(secondResult, "(A+B+C)x(X)DataResultDouble");
                    thirdResult.WriteMatrixToFile("(Ax(BxC))DataResultDouble");
                    WriteVectorToFile(fourthResult, "NoChoiceGaussDouble");
                    WriteVectorToFile(fifthResult, "RowChoiceGaussDouble");
                    WriteVectorToFile(sixthResult, "FullChoiceGaussDouble");
                }
                i++;
            }
            
        }
        
        
        public static void Main(string[] args)
        {
            CleanFiles();
            ComputeAll<MyFraction>(10);
            ComputeAll<float>(10);
            ComputeAll<double>(10);
            Console.WriteLine("Done");
        }
     
    }
}
