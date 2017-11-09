using System;

namespace Zadanie2
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            MyFraction fraction1 = new MyFraction(3, 5);
            MyFraction fraction2 = new MyFraction(3, 15);
            MyFraction resultOfSubtraction = fraction1 - fraction2;
            MyFraction resultOfDivide = fraction1 / fraction2;
            Console.WriteLine("Result of subtraction:  Numerator: {0}, Denominator: {1}",resultOfSubtraction.numerator,resultOfSubtraction.denominator);
            Console.WriteLine("Result of divide: Numerator: {0}, Denominator: {1}",resultOfDivide.numerator, resultOfDivide.denominator);
            MyMatrix<MyFraction> doubleMatrix = new MyMatrix<MyFraction>(4,4);

            MyFraction[,] matrixSample = { { new MyFraction(4), new MyFraction(-2), new MyFraction(4), new MyFraction(-2) },
                {new MyFraction(3), new MyFraction(1), new MyFraction(4), new MyFraction(2) },
                {new MyFraction(2), new MyFraction(4), new MyFraction(2), new MyFraction(1) },
                {new MyFraction(2), new MyFraction(-2), new MyFraction(4), new MyFraction(2) } };

            doubleMatrix.complementMatrix(matrixSample);
            MyFraction[] bVector =  { new MyFraction(8), new MyFraction(7), new MyFraction(10), new MyFraction(2) };
            bVector = doubleMatrix.gaussWithoutChoice(bVector);

            for (int i = 0; i < bVector.Length; i++)
            {
                Console.WriteLine(bVector[i] + " ");
            }



        }


     
    }
}
