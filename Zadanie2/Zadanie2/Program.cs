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
            MyMatrix<MyFraction> fractionMatrix;

            double[,] tableSample = { { 1, 2, 3, 0 }, { 4, 5, 6, 0 }, { 7, 8, 9, 0 } };

            doubleMatrix.complementMatrix(tableSample);
            doubleMatrix.printMatrix();


        }


     
    }
}
