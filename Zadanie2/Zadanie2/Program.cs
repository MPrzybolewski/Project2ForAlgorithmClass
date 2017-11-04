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
            MyMatrix<float> floatMatrix;
            MyMatrix<MyFraction> fractionMatrix = new MyMatrix<MyFraction>(3, 4);

            MyFraction[,] tableSample = new MyFraction[3,4];
            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tableSample[i,j] = new MyFraction(count);
                    count++;

                }
            }

            tableSample[2, 3] = new MyFraction(2,4);
            fractionMatrix.complementMatrix(tableSample);
            fractionMatrix.printMatrix();


        }


     
    }
}
