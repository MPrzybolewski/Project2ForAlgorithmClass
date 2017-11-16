using System;

namespace Zadanie2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            MyMatrix<MyFraction> myFractionMatrix = new MyMatrix<MyFraction>(4,4);

            //Test dodawanie i mnożenia 
            
            MyMatrix<double> addDoubleMatrix = new MyMatrix<double>(4,4);
            MyMatrix<double> multiplyDoubleMatrix = new MyMatrix<double>(4, 4);
            double[] multiplyDoubleVector = new double[4];
            MyMatrix<MyFraction> addFractionMatrix = new MyMatrix<MyFraction>(4, 4);
            MyMatrix<MyFraction> multiplyFractionMatrix = new MyMatrix<MyFraction>(4, 4);
            MyFraction[] multiplyFractionVector = new MyFraction[4];

            MyFraction[,] tableSample = new MyFraction[4, 4];
            double[,] doubleTable = new double[4, 4];

            int count = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tableSample[i, j] = new MyFraction(1,2);
                    doubleTable[i, j] = 0.5;
                    multiplyDoubleVector[j] = 0.5;
                    multiplyFractionVector[j] = new MyFraction(1, 2);
                    count++;

                }
            }
            addFractionMatrix.complementMatrix(tableSample);
            multiplyFractionMatrix.complementMatrix(tableSample);
            addDoubleMatrix.complementMatrix(doubleTable);
            multiplyDoubleMatrix.complementMatrix(doubleTable);

            Console.WriteLine("First add double Matrix:");
            addDoubleMatrix.printMatrix();
            Console.WriteLine("Second add double Matrix:");
            addDoubleMatrix.printMatrix();
            Console.WriteLine("Add result double Matrix:");
            MyMatrix<double> addResult = addDoubleMatrix + addDoubleMatrix;
            addResult.printMatrix();

            Console.WriteLine("------ ------");

            Console.WriteLine("First multiply double Matrix:");
            addDoubleMatrix.printMatrix();
            Console.WriteLine("Second multiply double Matrix:");
            multiplyDoubleMatrix.printMatrix();
            Console.WriteLine("Multiply result double Matrix:");
            MyMatrix<double> multiplyResult = addDoubleMatrix * multiplyDoubleMatrix;
            multiplyResult.printMatrix();

            Console.WriteLine("------ ------");

            Console.WriteLine("First multiply double Matrix:");
            addDoubleMatrix.printMatrix();
            Console.WriteLine("Double Vector:");
            foreach (var item in multiplyDoubleVector)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Multiply result double Vector:");
            double[] multiplyDoubleByVectorResult = addDoubleMatrix * multiplyDoubleVector;
            foreach (var item in multiplyDoubleByVectorResult)
            {
                Console.WriteLine(item.ToString());
            }

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

            Console.WriteLine("------ ------");

            Console.WriteLine("First multiply fraction Matrix:");
            addFractionMatrix.printMatrix();
            Console.WriteLine("Multiply Fraction Vector:");
            foreach (var item in multiplyFractionVector)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Multiply result Fraction Vector:");
            MyFraction[] multiplyFractionByVectorResult = addFractionMatrix * multiplyFractionVector;
            foreach (var item in multiplyFractionByVectorResult)
            {
                Console.WriteLine(item.ToString());
            }


            //Test Gaussa   
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
