#include <iostream>
#include <fstream>
#include <iomanip>
#include <boost/algorithm/string/split.hpp>
#include <boost/algorithm/string/classification.hpp>
#include <Eigen/Dense>

using Eigen::MatrixXd;
using Eigen::MatrixXf;
using Eigen::VectorXd;
using Eigen::VectorXf;
using namespace std;

const int size = 4;

void writeFloatFile(string name, MatrixXf floatMatrix);

int CountSize()
{
	using namespace boost::algorithm;
	ifstream input("D:\\Projekty\\Algorytmy\\Data\\DataRange\\DataRangeDouble1.txt");
	vector<string> tokens;	
	string line;
	getline(input, line);
	split(tokens, line, is_any_of(" "));
	int result = tokens.size() - 1;
	return result;
}

void ReadDataDoubleFromFile(MatrixXd a,MatrixXd b,MatrixXd c, VectorXd x)
{
	using namespace boost::algorithm;
	int k = 0;
	int flag = 0;
	ifstream input("D:\\Projekty\\Algorytmy\\Data\\DataRange\\DataRangeDouble1.txt");
	for( std::string line; getline( input, line ); )
	{
		//cout << line << endl;
		
		int j = 0;
		if (line.find("***") != string::npos)
		{
				flag++;
				k--;
		}
		else
		{
			vector<string> tokens;	
			split(tokens, line, is_any_of(" "));
			for(auto& s: tokens)
			{
				replace( s.begin(), s.end(), ',', '.');
				if (j==10)
				{ 
					break;
				}
				else
				{
					if (flag==0)
					{
						double lol = atof(s.c_str());
						a(k,j) = lol;
						//cout << '"' << s << '"' << '\n';
						//break;
					} 
					else if (flag==1)
					{
						double lol = atof(s.c_str());
						b(k-10,j) = lol;
						//cout << '"' << s << '"' << '\n';
						//break;
					} 
					else if (flag==2)
					{
						double lol = atof(s.c_str());
						c(k-20,j) = lol;
						//cout << '"' << s << '"' << '\n';
						//break;
					}
					else
					{
						double lol = atof(s.c_str());
						x(k-30) = lol;
					}
					
				}
				j++;
			}			
		}		
		k++;		
	}
	
	cout << a << endl;
}

void ReadDataFloatFromFile(MatrixXd a,MatrixXd b,MatrixXd c, VectorXd x)
{
	using namespace boost::algorithm;
	int k = 0;
	int flag = 0;
	ifstream input("D:\\Projekty\\Algorytmy\\Data\\DataRange\\DataRangeDouble1.txt");
	for( std::string line; getline( input, line ); )
	{
		//cout << line << endl;
		
		int j = 0;
		if (line.find("***") != string::npos)
		{
				flag++;
				k--;
		}
		else
		{
			vector<string> tokens;	
			split(tokens, line, is_any_of(" "));
			for(auto& s: tokens)
			{
				replace( s.begin(), s.end(), ',', '.');
				if (j==10)
				{ 
					break;
				}
				else
				{
					if (flag==0)
					{
						double lol = atof(s.c_str());
						a(k,j) = lol;
						//cout << '"' << s << '"' << '\n';
						//break;
					} 
					else if (flag==1)
					{
						double lol = atof(s.c_str());
						b(k-10,j) = lol;
						//cout << '"' << s << '"' << '\n';
						//break;
					} 
					else if (flag==2)
					{
						double lol = atof(s.c_str());
						c(k-20,j) = lol;
						//cout << '"' << s << '"' << '\n';
						//break;
					}
					else
					{
						double lol = atof(s.c_str());
						x(k-30) = lol;
					}
					
				}
				j++;
			}			
		}		
		k++;		
	}
}

void ComputeAll()
{
	int numberOfLines = CountSize();
	MatrixXd firstDoubleMatrix(numberOfLines,numberOfLines);
	MatrixXd secondDoubleMatrix(numberOfLines,numberOfLines);
	MatrixXd thirdDoubleMatrix(numberOfLines,numberOfLines);
	VectorXd firstDoubleVector(numberOfLines);
	VectorXd firstDoubleResult(numberOfLines);
	VectorXd secondDoubleResult(numberOfLines);
	MatrixXd thirdDoubleResult(numberOfLines,numberOfLines);
	VectorXd fourthDoubleVector(numberOfLines);
	VectorXd fifthDoubleResult(numberOfLines);
	VectorXd sixthDoubleResult(numberOfLines);
	MatrixXf firstFloatMatrix(numberOfLines,numberOfLines);
	MatrixXf secondFloatMatrix(numberOfLines,numberOfLines);
	MatrixXf thirdFloatMatrix(numberOfLines,numberOfLines);
	VectorXf firstFloatVector(numberOfLines);
	VectorXf firstFloatResult(numberOfLines);
	VectorXf secondFloatResult(numberOfLines);
	MatrixXf thirdFloatResult(numberOfLines,numberOfLines);
	VectorXf fourthFloatVector(numberOfLines);
	VectorXf fifthFloatResult(numberOfLines);
	VectorXf sixthFloatResult(numberOfLines);
}

int main(int argc, char** argv) {
	using namespace boost::algorithm;
	
	ReadDataDoubleFromFile(firstDoubleMatrix,secondDoubleMatrix,thirdDoubleMatrix,firstDoubleVector);
	//ReadDataFloatFromFile(firstFloatMatrix,secondFloatMatrix,thirdFloatMatrix,firstFloatVector);
	//cout.precision(10);
	cout << firstDoubleMatrix(0) << '\n';
	return 0;
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
