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
            Type t = firstMatrix.matrix[0, 0].GetType();
            object result = 0, x  = 0, y = 0;
            if ((firstMatrix.rows==secondMatrix.rows) && (firstMatrix.columns==secondMatrix.columns))
            {
                MyMatrix<T> temp = new MyMatrix<T>(firstMatrix.rows, firstMatrix.columns);
                for (int i = 0; i < firstMatrix.columns; i++)
                {
                    for (int j = 0; j < firstMatrix.rows; j++)
                    {
                        if (t == typeof(double))
                        {
                            x = Convert.ToDouble(firstMatrix.matrix[j, i].ToString());
                            y = Convert.ToDouble(secondMatrix.matrix[j, i].ToString());
                            result = (double)x + (double)y;
                            temp.matrix[j, i] = (T)result;
                        }

                        if (t == typeof(float))
                        {
                            x = float.Parse(firstMatrix.matrix[j, i].ToString());
                            y = float.Parse(secondMatrix.matrix[j, i].ToString());
                            result = (float)x + (float)y;
                            temp.matrix[j, i] = (T)result;
                        }

                        if (t == typeof(Int64))
                        {
                            x = Convert.ToInt64(firstMatrix.matrix[j, i].ToString());
                            y = Convert.ToDouble(secondMatrix.matrix[j, i].ToString());
                            result = (int)x + (int)y;
                            temp.matrix[j, i] = (T)result;
                        }

                        if (t == typeof(MyFraction))
                        {
                            x = firstMatrix.matrix[j, i];
                            y = secondMatrix.matrix[j, i];
                            result = (MyFraction)x + (MyFraction)y;
                            temp.matrix[j, i] = (T)result;
                        }

                    }
                }
                return temp;
            }
            return new MyMatrix<T>(1,1);
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
