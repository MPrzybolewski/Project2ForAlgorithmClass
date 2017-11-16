#include <iostream>
#include <fstream>
#include <iomanip>
#include <Eigen/Dense>

using Eigen::MatrixXd;
using Eigen::MatrixXf;
using Eigen::VectorXd;
using Eigen::VectorXf;
using namespace std;

const int size = 4;

void writeDoubleFile(string name, MatrixXd doubleMatrix);
void writeDoubleVectorFile(string name, VectorXd doubleVector);
void writeFloatVectorFile(string name, VectorXd floatVector);
void writeFloatFile(string name, MatrixXf floatMatrix);

int main(int argc, char** argv) {
	MatrixXd doubleAMatrix = MatrixXd::Random(size,size);
	MatrixXd doubleBMatrix = MatrixXd::Random(size,size);
	MatrixXd doubleCMatrix = MatrixXd::Random(size,size);
	VectorXd doubleVector = VectorXd::Random(size);
	VectorXd multiplyMatrixByVectorDoubleResult = doubleAMatrix * doubleVector;
	VectorXd multiplySumMatrixByVectorDoubleResult = (doubleAMatrix + doubleBMatrix + doubleCMatrix) * doubleVector;
	MatrixXd multiplyMatrixDoubleResult = doubleAMatrix * doubleBMatrix;

    writeDoubleFile("doubleAMatrix", doubleAMatrix);
    writeDoubleFile("doubleBMatrix", doubleAMatrix);
    writeDoubleFile("doubleCMatrix", doubleAMatrix);
    writeDoubleFile("multiplyMatrixDoubleResult", multiplyMatrixDoubleResult);
    writeDoubleVectorFile("doubleVector", doubleVector);
    writeDoubleVectorFile("multiplyMatrixByVectorDoubleResult", multiplyMatrixByVectorDoubleResult);
    writeDoubleVectorFile("multiplySumMatrixByVectorDoubleResult", multiplySumMatrixByVectorDoubleResult);
	return 0;
}

void writeDoubleFile(string name, MatrixXd doubleMatrix)
{
  ofstream myfile;
  myfile.open (name+".txt");
  for (int i = 0; i < size; i++)
  {
  	for (int j = 0; j < size; j++)
  	{
  		myfile << setprecision(2) << doubleMatrix(i,j);
  		myfile << " ";
	}
	myfile << "\n";
	
  }
  myfile.close();
}

void writeFloatFile(string name, MatrixXf floatMatrix)
{
  ofstream myfile;
  myfile.open (name+".txt");
  for (int i = 0; i < size; i++)
  {
  	for (int j = 0; j < size; j++)
  	{
  		myfile << floatMatrix(i,j);
  		myfile << " ";
	}
	myfile << "\n";
	
  }
  myfile.close();
}

void writeDoubleVectorFile(string name, VectorXd doubleVector)
{
  ofstream myfile;
  myfile.open (name+".txt");
  for (int i = 0; i < size; i++)
  {
  	myfile << doubleVector(i);
  	myfile << " ";
  }
  myfile << "\n";	
  myfile.close();	
}

void writeFloatVectorFile(string name, VectorXf floatVector)
{
  ofstream myfile;
  myfile.open (name+".txt");
  for (int i = 0; i < size; i++)
  {
  	myfile << floatVector(i);
  	myfile << " ";
  }
  myfile << "\n";	
  myfile.close();	
}
