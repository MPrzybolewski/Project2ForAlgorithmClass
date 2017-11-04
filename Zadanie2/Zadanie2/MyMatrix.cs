using System;
namespace Zadanie2
{
    public class MyMatrix<T>
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
    }
}
