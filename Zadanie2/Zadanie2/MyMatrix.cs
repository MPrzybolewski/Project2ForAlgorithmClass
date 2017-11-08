using System;

namespace Zadanie2
{
    public class MyMatrix<T> where T : struct
    {
        private int rows;
        private int columns;
        private T[,] matrix;

        public MyMatrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.matrix = new T[rows,columns];
        }

        public void complementMatrix(T[,] table)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = table[i, j];
                }
            }
        }

        public void printMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("|");
                for (int j = 0; j < columns; j++)
                {
                    if (j != 0)
                    {
                        Console.Write("| ");
                    }                 

                    Console.Write(matrix[i,j]);

                }
                Console.WriteLine("|");
            }
        }

        public T[] gaussWithoutChoice(T[] bVector)
        {
            bVector = makeRowEchelonMatrix(bVector);
            return countXVector(bVector);
        }

        private T[] makeRowEchelonMatrix(T[] bVector)
        {
            for (int k = 0; k < columns; k++)
            {
                for (int i = k; i < rows - 1; i++)
                {
                    T numberForMultiply = (dynamic)matrix[i + 1, k] / matrix[k, k];

                    for (int j = k; j < columns; j++)
                    {
                        matrix[i + 1, j] -= ((dynamic)matrix[k, j] * numberForMultiply);
                    }

                    bVector[i + 1] -= ((dynamic)bVector[k] * numberForMultiply);
                }
            }

            return bVector;
        }

        private T[] countXVector(T[] bVector)
        {
            T[] xVector = new T[bVector.Length];
            for (int i = bVector.Length - 1; i >= 0; i--)
            {
                int j = i;
                T numerator = bVector[i];
                while (j < (columns - 1))
                {
                    numerator -= ((dynamic)matrix[i, j + 1] * xVector[j + 1]);
                    j++;
                }
                xVector[i] = (dynamic)numerator / matrix[i, i];

            }

            return xVector;
        }

    }
}
