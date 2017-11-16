using System;

namespace Zadanie2
{
    public class MyMatrix<T> where T : new()
    {
        public int rows;
        public int columns;
        public T[,] matrix;
        public T[,] defaultMatrix;

        public MyMatrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.matrix = new T[rows, columns];
            this.defaultMatrix = new T[rows, columns];
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

        public static T[] operator *(MyMatrix<T> firstMatrix, T[] vector)
        {
            T[] instance = new T[firstMatrix.rows];
            for (int i = 0; i < firstMatrix.rows; i++)
            {
                instance[i] = new T();
            }
            for (int i = 0; i < firstMatrix.rows; i++)
            {
                for (int j = 0; j < firstMatrix.columns; j++)
                {
                    instance[i] += (dynamic)firstMatrix.matrix[i, j] * (dynamic)vector[j];
                }
            }
            return instance;
        }

        public void complementMatrix(T[,] table)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = table[i, j];
                    defaultMatrix[i, j] = table[i, j];
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
                    String s = String.Format("{0}", matrix[i,j]);
                    Console.Write(s);

                }
                Console.WriteLine("|");
            }
        }

        public T[] gaussWithoutChoice(T[] bVector)
        {
            bVector = makeRowEchelonMatrix(bVector);
            return countXVector(bVector);
        }


        public T[] gaussWithRowChoice(T[] bVector)
        {
            bVector = makeRowEchelonMatrixWithRowChoice(bVector);
            return countXVector(bVector);
        }

        public T[] gaussWithFullChoice(T[] bVector)
        {
            int[] xVectorNumberChangeTable = {1,2,3,4};
            bVector = makeRowEchelonMatrixWithFullChoice(bVector, xVectorNumberChangeTable);
            return countModifiedXVector(bVector,xVectorNumberChangeTable);

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

        private T[] makeRowEchelonMatrixWithRowChoice(T[] bVector)
        {
            for (int k = 0; k < columns; k++)
            {
                int rowWithDiagonalNumber = k;
                int rowNumberWithMaxNumberInColumn = findRowWithMaxNumberInColumnUnderDiagonal(k);

                if(rowNumberWithMaxNumberInColumn != rowWithDiagonalNumber)
                {
                    bVector = swapRows(rowWithDiagonalNumber, rowNumberWithMaxNumberInColumn, bVector);
                }

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


        private T[] makeRowEchelonMatrixWithFullChoice(T[] bVector, int[] xVectorNumberChangeTable)
        {
            for (int k = 0; k < columns; k++)
            {
                
                int rowNumberWithDiagonalPoint = k;
                int rowNumberWithMaxNumberInMatrix = rowNumberWithDiagonalPoint;
                int columnNumberWithMaxNumberInMatrix = rowNumberWithDiagonalPoint;

                findRowAndColumnWithMaxElementInMatrix(rowNumberWithDiagonalPoint, ref rowNumberWithMaxNumberInMatrix, ref columnNumberWithMaxNumberInMatrix);
                if(rowNumberWithMaxNumberInMatrix != rowNumberWithDiagonalPoint)
                {
                    bVector = swapRows(rowNumberWithDiagonalPoint, rowNumberWithMaxNumberInMatrix, bVector);
                }

                if(columnNumberWithMaxNumberInMatrix != rowNumberWithDiagonalPoint)
                {
                    xVectorNumberChangeTable = swapColumns(rowNumberWithDiagonalPoint, columnNumberWithMaxNumberInMatrix, xVectorNumberChangeTable);
                }

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

        private int findRowWithMaxNumberInColumnUnderDiagonal(int columnNumber)
        {
            int rowNumberWithMaxNumberInColumn = columnNumber;
            int firstRowUnderDiagonal = columnNumber + 1;
            for (int i = firstRowUnderDiagonal; i < rows; i++)
            {
                if((dynamic)matrix[rowNumberWithMaxNumberInColumn,columnNumber] < matrix[i,columnNumber])
                {
                    rowNumberWithMaxNumberInColumn = i;
                }
            }
            return rowNumberWithMaxNumberInColumn;
        }

        private void findRowAndColumnWithMaxElementInMatrix(int rowNumberWithDiagonalPoint, ref int rowNumberWithMaxNumberInMatrix, ref int columnNumberWithMaxNumberInMatrix)
        {
            int columnNumberWithDiagonalPoint = rowNumberWithDiagonalPoint;

            for (int i = rowNumberWithDiagonalPoint; i < rows; i++)
            {
                for (int j = columnNumberWithDiagonalPoint; j < columns; j++)
                {
                    if ((dynamic)matrix[rowNumberWithMaxNumberInMatrix,columnNumberWithMaxNumberInMatrix] < matrix[i,j])
                    {
                        rowNumberWithMaxNumberInMatrix = i;
                        columnNumberWithMaxNumberInMatrix = j;
                    }    
                }
            }
        }

        private T[] swapRows(int rowWithDiagonalNumber, int rowNumberWithMaxNumber, T[] bVector)
        {
            T[] tempRow = new T[columns];
            T tempValue;
            for (int i = 0; i < columns; i++)
            {
                tempRow[i] = matrix[rowWithDiagonalNumber, i];
                matrix[rowWithDiagonalNumber, i] = matrix[rowNumberWithMaxNumber, i];
                matrix[rowNumberWithMaxNumber, i] = tempRow[i];
            }

            tempValue = bVector[rowWithDiagonalNumber];
            bVector[rowWithDiagonalNumber] = bVector[rowNumberWithMaxNumber];
            bVector[rowNumberWithMaxNumber] = tempValue;

            return bVector;
        }

        private int[] swapColumns(int columnNumberWithDiagonalPoint, int columnNumberWithMaxNumber, int[] xVector)
        {
            T[] tempColumn = new T[rows];
            int tempValue;
            for (int i = 0; i < rows; i++)
            {
                tempColumn[i] = matrix[i, columnNumberWithDiagonalPoint];
                matrix[i, columnNumberWithDiagonalPoint] = matrix[i, columnNumberWithMaxNumber];
                matrix[i, columnNumberWithMaxNumber] = tempColumn[i];
            }

            tempValue = xVector[columnNumberWithDiagonalPoint];
            xVector[columnNumberWithDiagonalPoint] = xVector[columnNumberWithMaxNumber];
            xVector[columnNumberWithMaxNumber] = tempValue;

            return xVector;
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

        private T[] countModifiedXVector(T[] bVector, int[] xVectorNumberChangeTable)
        {
            T[] xVector = new T[bVector.Length];
            xVector = countXVector(bVector);

            int indexTemp;
            T valueTemp;

            for (int i = 0; i < xVector.Length; i++)
            {
                if(xVectorNumberChangeTable[i] != i)
                {
                    int indexForReplacing = xVectorNumberChangeTable[i] - 1;

                    indexTemp = xVectorNumberChangeTable[i];
                    xVectorNumberChangeTable[i] = xVectorNumberChangeTable[indexForReplacing];
                    xVectorNumberChangeTable[indexForReplacing] = indexTemp;

                    valueTemp = xVector[i];
                    xVector[i] = xVector[indexForReplacing];
                    xVector[indexForReplacing] = valueTemp;
                }
            }


            return xVector;
        }

        public void printVector(T[] vector)
        {
            Console.WriteLine("Wektor B");
            for (int i = 0; i < vector.Length; i++)
            {
                Console.WriteLine(vector[i]);
            }
        }

        public void setDefaultMatrix()
        {
            matrix = (T[,])defaultMatrix.Clone();
        }
    }
}
