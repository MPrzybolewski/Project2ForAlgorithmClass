using System;

namespace Zadanie2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            MyMatrix<double> doubleMatrix;
            MyMatrix<float> floatMatrix;

            MyFraction firstFraction = new MyFraction(2, 5);
            MyFraction secondFraction = new MyFraction(3, 4);
            MyFraction resultMultiply = firstFraction * secondFraction;
            MyFraction resutlAdd = firstFraction + secondFraction;
            Console.WriteLine("Multiply result: Nominator: {0}, Denominator: {1}", resultMultiply.numerator, resultMultiply.denominator);
            Console.WriteLine("Add result: Nominator: {0}, Denominator {1}", resutlAdd.numerator, resutlAdd.denominator);

        }
    }
}
