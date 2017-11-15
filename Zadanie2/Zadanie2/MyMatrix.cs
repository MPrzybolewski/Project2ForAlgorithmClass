using System;
namespace Zadanie2
{
    public class MyMatrix<T> where T : new()
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

        public static MyMatrix<T> operator +(MyMatrix <T> firstMatrix, MyMatrix <T> secondMatrix)
        {
            if ((firstMatrix.rows==secondMatrix.rows) && (firstMatrix.columns==secondMatrix.columns))
            {
                MyMatrix<T> temp = new MyMatrix<T>(firstMatrix.rows, firstMatrix.columns);
                for (int i = 0; i < firstMatrix.rows; i++)
                {
                    for (int j = 0; j < firstMatrix.columns; j++)
                    {
                        temp.matrix[i, j] = (dynamic)firstMatrix.matrix[i, j] + (dynamic)secondMatrix.matrix[i, j];                    
                    }
                }
                return temp;
            }
            return new MyMatrix<T>(1,1);
        }

        public static MyMatrix<T> operator *(MyMatrix<T> firstMatrix, MyMatrix<T> secondMatrix)
        {
            MyMatrix<T> result = new MyMatrix<T>(firstMatrix.rows,secondMatrix.columns);
            for (int i = 0; i < firstMatrix.rows; i++)
            {
                for (int j = 0; j < secondMatrix.columns; j++)
                {
                    T[] instance = new T[firstMatrix.rows];
                    instance[0] = new T();
                    for (int k = 0; k < secondMatrix.rows; k++)
                    {
                        instance[0] = (dynamic)instance[0] + (dynamic)firstMatrix.matrix[i, k] * (dynamic)secondMatrix.matrix[k, j];
                    }
                    result.matrix[i, j] = (dynamic)instance[0];
                }
            }
            return result;
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
                Console.Write("| ");
                for (int j = 0; j < columns; j++)
                {
                    if (j != 0)
                    {
                        Console.Write("| ");
                    }
                    String s = String.Format("{0,-20:C5}", matrix[i,j]);
                    Console.Write(s);

                }
                Console.WriteLine("|");
            }
        }
    }
}
