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
            //Console.WriteLine("A[rows]={0}, A[columns]={1},B[rows]={2},B[columns]={3}", firstMatrix.rows, firstMatrix.columns, secondMatrix.rows, secondMatrix.columns);
            if (firstMatrix.rows == secondMatrix.columns)
            {
                MyMatrix<T> temp = new MyMatrix<T>(firstMatrix.rows, secondMatrix.columns);
                for (int i = 0; i < firstMatrix.rows; i++)
                {
                    for (int j = 0; j < secondMatrix.columns; j++)
                    {
                        MyMatrix<T> sum = new MyMatrix<T>(1, 1);
                        //Tu nie działa!
                        sum.matrix[0, 0] = 0;
                        for (int k = 0; k < firstMatrix.columns; k++)
                        {
                            Console.WriteLine("Wynik przed = {0}", sum.matrix[0, 0]);
                            sum.matrix[0,0] = (dynamic)firstMatrix.matrix[i, k] * (dynamic)secondMatrix.matrix[k, j];
                            Console.WriteLine("A[row,column]={0},{1} * B[row,column]={2},{3} = {4}", i, k, k, j, sum.matrix[0, 0]);
                            sum.matrix[0, 0] = (dynamic)sum.matrix[0, 0] + (dynamic)sum.matrix[0, 0];
                            Console.WriteLine("Wynik po = {0}",sum.matrix[0, 0]);
                        }
                        temp.matrix[i, j] = sum.matrix[0,0];
                    }
                }
                return temp;
            }
            return new MyMatrix<T>(1, 1);
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
