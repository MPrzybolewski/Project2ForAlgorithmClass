using System;

namespace Zadanie2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            MyMatrix<MyFraction> myFractionMatrix = new MyMatrix<MyFraction>(4,4);

            MyFraction[,] matrixSample = { { new MyFraction(4), new MyFraction(-2), new MyFraction(4), new MyFraction(-2) },
                {new MyFraction(3), new MyFraction(1), new MyFraction(4), new MyFraction(2) },
                {new MyFraction(2), new MyFraction(4), new MyFraction(2), new MyFraction(1) },
                {new MyFraction(2), new MyFraction(-2), new MyFraction(4), new MyFraction(2) } };

            myFractionMatrix.complementMatrix(matrixSample);
            MyFraction[] bVector =  { new MyFraction(8), new MyFraction(7), new MyFraction(10), new MyFraction(2) };

            MyFraction[] xVectorFromGaussWithoutChoice = new MyFraction[4];
            MyFraction[] xVectorFromGaussWithRowChoice = new MyFraction[4];
            MyFraction[] xVectorFromGaussWithFullChoice = new MyFraction[4];

            xVectorFromGaussWithoutChoice = myFractionMatrix.gaussWithoutChoice((MyFraction[])bVector.Clone());
            myFractionMatrix.setDefaultMatrix();

            xVectorFromGaussWithRowChoice = myFractionMatrix.gaussWithRowChoice((MyFraction[])bVector.Clone());
            myFractionMatrix.setDefaultMatrix();

            xVectorFromGaussWithFullChoice = myFractionMatrix.gaussWithFullChoice((MyFraction[])bVector.Clone());

            Console.WriteLine("Bez Wyboru | Z wyborem wierszy | z pełny wyborem ");
            for (int i = 0; i < bVector.Length; i++)
            {
                Console.WriteLine("{0} | {1} | {2}",xVectorFromGaussWithoutChoice[i], xVectorFromGaussWithRowChoice[i], xVectorFromGaussWithFullChoice[i]);
            }

        }
     
    }
}
