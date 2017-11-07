using System;

namespace Zadanie2
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            //Test fraction operations
            //MyFraction firstFraction = new MyFraction(2, 5);
            //MyFraction secondFraction = new MyFraction(3, 4);
            //MyFraction resultMultiply = firstFraction * secondFraction;
            //MyFraction resutlAdd = firstFraction + secondFraction;
            //Console.WriteLine("Multiply result: Nominator: {0}, Denominator: {1}", resultMultiply.numerator, resultMultiply.denominator);
            //Console.WriteLine("Add result: Nominator: {0}, Denominator {1}", resutlAdd.numerator, resutlAdd.denominator);

            MyMatrix<double> addDoubleMatrix = new MyMatrix<double>(3, 4);
            MyMatrix<double> multiplyDoubleMatrix = new MyMatrix<double>(4, 3);
            MyMatrix<MyFraction> addFractionMatrix = new MyMatrix<MyFraction>(3, 4);
            MyMatrix<MyFraction> multiplyFractionMatrix = new MyMatrix<MyFraction>(4, 3);

            MyFraction[,] tableSample = new MyFraction[3, 4];
            MyFraction[,] tableSample2 = new MyFraction[4, 3];
            double[,] doubleTable = new double[3, 4];
            double[,] doubleTable2 = new double[4, 3];

            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tableSample[i, j] = new MyFraction(count,count+2);
                    doubleTable[i, j] = count+0.3;
                    count++;

                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tableSample2[i, j] = new MyFraction(count+1,count/2);
                    doubleTable2[i, j] = count + 0.3;
                    count++;

                }
            }

            tableSample[0, 0] = new MyFraction(2, 3);
            addFractionMatrix.complementMatrix(tableSample);
            multiplyFractionMatrix.complementMatrix(tableSample2);
            addDoubleMatrix.complementMatrix(doubleTable);
            multiplyDoubleMatrix.complementMatrix(doubleTable2);

            Console.WriteLine("First add double Matrix:");
            addDoubleMatrix.printMatrix();
            Console.WriteLine("Second add double Matrix:");
            addDoubleMatrix.printMatrix();
            MyMatrix<double> addResult = addDoubleMatrix + addDoubleMatrix;
            MyMatrix<double> multiplyResult = addDoubleMatrix * multiplyDoubleMatrix;
            Console.WriteLine("Add result double Matrix:");
            addResult.printMatrix();

            Console.WriteLine("------ ------");

            Console.WriteLine("First multiply double Matrix:");
            addDoubleMatrix.printMatrix();
            Console.WriteLine("Second multiply double Matrix:");
            multiplyDoubleMatrix.printMatrix();
            Console.WriteLine("Multiply result double Matrix:");
            multiplyResult.printMatrix();

            Console.WriteLine("------ ------");

            Console.WriteLine("First add fraction Matrix:");
            addFractionMatrix.printMatrix();
            Console.WriteLine("Second add fraction Matrix:");
            addFractionMatrix.printMatrix();
            MyMatrix<MyFraction> addResultMatrix = addFractionMatrix + addFractionMatrix;
            Console.WriteLine("Add Result fraction Matrix:");
            addResultMatrix.printMatrix();

            Console.WriteLine("------ ------");

            Console.WriteLine("First multiply fraction Matrix:");
            addFractionMatrix.printMatrix();
            Console.WriteLine("Second multiply fraction Matrix:");
            multiplyFractionMatrix.printMatrix();
            Console.WriteLine("Multiply result fraction Matrix:");
            MyMatrix<MyFraction> multiplyResultMatrix = addFractionMatrix * multiplyFractionMatrix;
            multiplyResultMatrix.printMatrix();
            Console.ReadLine();

        }


     
    }
}
