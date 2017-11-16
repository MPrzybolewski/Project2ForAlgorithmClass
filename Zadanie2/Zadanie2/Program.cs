using System;

namespace Zadanie2
{
    class MainClass
    {
        private static int size = 4;
        
        private static MyMatrix<double> ReadDoubleMatrix(string name)
        {
            MyMatrix<double> temp = new MyMatrix<double>(size,size);
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Eigen\"+name+".txt");
            int i = 0;
            foreach (string line in lines)
            {
                string[] item = line.Split(' ');
                for (int j = 0; j < item.Length-1; j++)
                {
                    temp.matrix[i,j] = double.Parse(item[j], System.Globalization.CultureInfo.InvariantCulture);
                }
                i++;
            }

            return temp;

        }
        
        private static double[] ReadDoubleVector(string name)
        {
            double[] temp = new double[size];
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\pmatusza\Documents\MobaXterm\home\Studia\Algorytmy\Eigen\"+name+".txt");
            foreach (string line in lines)
            {
                string[] item = line.Split(' ');
                for (int j = 0; j < item.Length-1; j++)
                {
                    temp[j] = double.Parse(item[j], System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            return temp;

        }
        
        
        /*public static MyMatrix<float> ReadFloatMatrix(string name)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");   
        }

        public static float[] ReadFloatVector(string name)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt"); 
        } 
        
        public static double[] ReadDoubleVector(string name)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
        } */
        
        public static void Main(string[] args)
        {       
            MyMatrix<double> doubleAMatrix = new MyMatrix<double>(size,size);
            MyMatrix<double> doubleBMatrix = new MyMatrix<double>(size,size);
            MyMatrix<double> doubleCMatrix = new MyMatrix<double>(size,size);
            doubleAMatrix = ReadDoubleMatrix("doubleAMatrix");
            doubleBMatrix = ReadDoubleMatrix("doubleBMatrix");
            doubleCMatrix = ReadDoubleMatrix("doubleCMatrix");
            doubleAMatrix.printMatrix();
            Console.WriteLine("\n");
            doubleBMatrix.printMatrix();
            Console.WriteLine("\n");
            doubleCMatrix.printMatrix();
            Console.WriteLine("\n");
            MyMatrix<double> multiplyMatrixDoubleResult = doubleAMatrix * doubleBMatrix;
            double[] doubleVector = new double[size];
            
            
            multiplyMatrixDoubleResult.printMatrix();

            /*doubleVector = ReadDoubleVector("doubleVector");
            doubleAMatrix.printMatrix();
            Console.WriteLine("Vector:");
            foreach (var item in doubleVector)
            {
                Console.WriteLine(item.ToString());
            }*/
            
        }
     
    }
}
