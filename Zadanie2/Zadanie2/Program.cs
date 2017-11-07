using System;

namespace Zadanie2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            MyMatrix<double> doubleMatrix = new MyMatrix<double>(4,4);

            double[,] matrixSample = { { 4, -2, 4, -2 }, { 3, 1, 4, 2 }, { 2, 4, 2, 1 }, { 2, -2, 4, 2 } };

            doubleMatrix.complementMatrix(matrixSample);
            double[] bVector =  { 8, 7, 10, 2 };
            bVector = doubleMatrix.gaussWithoutChoice(bVector);

            for (int i = 0; i < bVector.Length; i++)
            {
                Console.WriteLine(bVector[i] + " ");
            }



        }


     
    }
}
