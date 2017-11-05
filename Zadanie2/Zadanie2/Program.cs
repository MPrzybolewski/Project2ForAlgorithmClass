using System;

namespace Zadanie2
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            //Test fraction operations
            MyFraction firstFraction = new MyFraction(2, 5);
            MyFraction secondFraction = new MyFraction(3, 4);
            MyFraction resultMultiply = firstFraction * secondFraction;
            MyFraction resutlAdd = firstFraction + secondFraction;
            Console.WriteLine("Multiply result: Nominator: {0}, Denominator: {1}", resultMultiply.numerator, resultMultiply.denominator);
            Console.WriteLine("Add result: Nominator: {0}, Denominator {1}", resutlAdd.numerator, resutlAdd.denominator);

            MyMatrix<double> doubleMatrix = new MyMatrix<double>(3,4);
            MyMatrix<double> doubleMatrix2 = new MyMatrix<double>(3, 4);
            MyMatrix<float> floatMatrix;
            MyMatrix<MyFraction> fractionMatrix = new MyMatrix<MyFraction>(3, 4);
            MyMatrix<MyFraction> fractionMatrix2 = new MyMatrix<MyFraction>(3, 4);

            MyFraction[,] tableSample = new MyFraction[3,4];
            MyFraction[,] tableSample2 = new MyFraction[3, 4];
            double[,] doubleTable = new double[3, 4];
            double[,] doubleTable2 = new double[3, 4];
            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tableSample[i,j] = new MyFraction(count);
                    doubleTable[i, j] = count+0.3;
                    doubleTable2[i, j] = count+0.3;
                    count++;

                }
            }

            tableSample[2, 3] = new MyFraction(2,4);
            fractionMatrix.complementMatrix(tableSample);
            fractionMatrix2.complementMatrix(tableSample);
            Console.WriteLine("---Przerwa---");
            doubleMatrix.complementMatrix(doubleTable);
            doubleMatrix2.complementMatrix(doubleTable2);
            Console.WriteLine("First double Matrix:");
            doubleMatrix.printMatrix();
            Console.WriteLine("Second double Matrix:");
            doubleMatrix.printMatrix();
            MyMatrix<double> result = doubleMatrix + doubleMatrix2;
            Console.WriteLine("Result double Matrix:");
            result.printMatrix();
            Console.WriteLine("---Przerwa---");
            Console.WriteLine("First <T> Matrix:");
            fractionMatrix.printMatrix();
            Console.WriteLine("Second <T> Matrix:");
            fractionMatrix2.printMatrix();
            MyMatrix<MyFraction> result2 = fractionMatrix + fractionMatrix2;
            Console.WriteLine("Result <T> Matrix:");
            result2.printMatrix();
            Console.ReadLine();

        }


     
    }
}
