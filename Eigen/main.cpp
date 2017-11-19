#include <iostream>
#include <fstream>
#include <typeinfo>
#include <sstream>
#include <string>
#include <iomanip>
#include <boost/algorithm/string/split.hpp>
#include <boost/algorithm/string/classification.hpp>
#include <Eigen/Dense>

using Eigen::MatrixXd;
using Eigen::MatrixXf;
using Eigen::VectorXd;
using Eigen::VectorXf;
using namespace std;

namespace patch
{
    template < typename T > std::string to_string( const T& n )
    {
        std::ostringstream stm ;
        stm << n ;
        return stm.str() ;
    }
}


void CleanFiles();
void writeDoubleMatrixToFile(MatrixXd a, int size,string name);
void writeFloatMatrixToFile(MatrixXd a, int size,string name);
void writeDoubleVectorFile(string name, VectorXd doubleVector, int size);
void writeFloatVectorFile(string name, VectorXf floatMatrix, int size);

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

void ReadDataDoubleFromFile(int size)
{
	int x = 1;
	using namespace boost::algorithm;
	while (x <=3)
	{
		MatrixXd firstDoubleMatrix(size,size);
		MatrixXd secondDoubleMatrix(size,size);
		MatrixXd thirdDoubleMatrix(size,size);
		VectorXd firstDoubleVector(size);
		VectorXd firstDoubleResult(size);
		VectorXd secondDoubleResult(size);
		MatrixXd thirdDoubleResult(size,size);
		VectorXd fourthDoubleResult(size);
		VectorXd fifthDoubleResult(size);
		VectorXd sixthDoubleResult(size);
		int k = 0;
		int flag = 0;
		string s = patch::to_string(x);
		ifstream input("D:\\Projekty\\Algorytmy\\Data\\DataRange\\DataRangeDouble"+s+".txt");
		for( std::string line; getline( input, line ); )
		{	
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
					if (j==size)
					{ 
						break;
					}
					else
					{
						if (flag==0)
						{
							double lol = atof(s.c_str());
							firstDoubleMatrix(k,j) = lol;
							//cout << '"' << s << '"' << '\n';
							//break;
						} 
						else if (flag==1)
						{
							double lol = atof(s.c_str());
							secondDoubleMatrix(k-size,j) = lol;
							//cout << '"' << s << '"' << '\n';
							//break;
						} 
						else if (flag==2)
						{
							double lol = atof(s.c_str());
							thirdDoubleMatrix(k-(size*2),j) = lol;
							//cout << '"' << s << '"' << '\n';
							//break;
						}
						else
						{
							double lol = atof(s.c_str());
							firstDoubleVector(k-(size*3)) = lol;
						}
						
					}
					j++;
				}			
			}		
			k++;		
		}	
		
		firstDoubleResult = firstDoubleMatrix * firstDoubleVector;
		writeDoubleVectorFile("(AxX)DataResultDouble[C].txt", firstDoubleResult, size);	
		secondDoubleResult = (firstDoubleMatrix + secondDoubleMatrix + thirdDoubleMatrix) * firstDoubleVector;
		writeDoubleVectorFile("(A+B+C)x(X)DataResultDouble[C].txt", secondDoubleResult, size);
		thirdDoubleResult = firstDoubleMatrix * (secondDoubleMatrix * thirdDoubleMatrix);
		writeDoubleMatrixToFile(thirdDoubleResult, size, "(Ax(BxC))DataResultDouble[C].txt");
		fourthDoubleResult = firstDoubleMatrix.fullPivLu().solve(firstDoubleVector);
		writeDoubleVectorFile("PartialGausseDouble[C].txt", fourthDoubleResult, size);
		fifthDoubleResult = firstDoubleMatrix.partialPivLu().solve(firstDoubleVector);
		writeDoubleVectorFile("FullGausseDouble[C].txt", fifthDoubleResult, size);
		x++;
	}
	
}

void ReadDataFloatFromFile(int size)
{
	int x = 1;
	while (x <=3)
	{
		using namespace boost::algorithm;
		MatrixXf firstFloatMatrix(size,size);
		MatrixXf secondFloatMatrix(size,size);
		MatrixXf thirdFloatMatrix(size,size);
		MatrixXf temp(size,size);
		VectorXf firstFloatVector(size);
		VectorXf firstFloatResult(size);
		VectorXf secondFloatResult(size);
		MatrixXf thirdFloatResult(size,size);
		VectorXf fourthFloatResult(size);
		VectorXf fifthFloatResult(size);
		VectorXf sixthFloatResult(size);
		int k = 0;
		int flag = 0;
		string s = patch::to_string(x);
		cout << "s= " << s << endl;
		ifstream input("D:\\Projekty\\Algorytmy\\Data\\DataRange\\DataRangeFloat"+s+".txt");
		for( std::string line; getline( input, line ); )
		{	
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
					replace(s.begin(), s.end(), ',', '.');
					if (j==size)
					{ 
						break;
					}
					else
					{
						if (flag==0)
						{
							float lol = atof(s.c_str());
							firstFloatMatrix(k,j) = lol;
							//cout << '"' << s << '"' << '\n';
							//break;
						} 
						else if (flag==1)
						{
							float lol = atof(s.c_str());
							secondFloatMatrix(k-size,j) = lol;
							//cout << '"' << s << '"' << '\n';
							//break;
						} 
						else if (flag==2)
						{
							float lol = atof(s.c_str());
							thirdFloatMatrix(k-(size*2),j) = lol;
							//cout << '"' << s << '"' << '\n';
							//break;
						}
						else
						{
							float lol = atof(s.c_str());
							firstFloatVector(k-(size*3)) = lol;
						}
						
					}
					j++;
				}			
			}		
			k++;		
		}

		firstFloatResult = firstFloatMatrix * firstFloatVector;
		writeFloatVectorFile("(AxX)DataResultFloat[C].txt", firstFloatResult, size);
		secondFloatResult = (firstFloatMatrix + secondFloatMatrix + thirdFloatMatrix) * firstFloatVector;
		writeFloatVectorFile("(A+B+C)x(X)DataResultFloat[C].txt", secondFloatResult, size);	
		thirdFloatResult = firstFloatMatrix * (secondFloatMatrix * thirdFloatMatrix);
		
		std::ofstream outfile;

		outfile.open("(Ax(BxC))DataResultFloat[C].txt", std::ios_base::app);
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				outfile << setprecision(16) << fixed << thirdFloatResult(i,j);
				outfile << " ";
			}
			outfile << "\n";
		}
		outfile << "*** *** *** *** *** ***\n";
		outfile.close();
		
		
		
		fourthFloatResult = firstFloatMatrix.fullPivLu().solve(firstFloatVector);
	    writeFloatVectorFile("PartialGausseFloat[C].txt", fourthFloatResult, size);
		fifthFloatResult = firstFloatMatrix.partialPivLu().solve(firstFloatVector);
		writeFloatVectorFile("FullGausseFloat[C].txt", fifthFloatResult, size);
		x++;
	}	
}

void ComputeAll()
{
	int numberOfLines = CountSize();	
	ReadDataDoubleFromFile(numberOfLines);
	ReadDataFloatFromFile(numberOfLines);
}

int main(int argc, char** argv) {
	using namespace boost::algorithm;
	CleanFiles();
	ComputeAll();
	return 0;
}

void CleanFiles()
{
	ofstream file1;
	ofstream file2;
	ofstream file3;
	ofstream file4;
	ofstream file5;
	ofstream file6;
	ofstream file7;
	ofstream file8;
	ofstream file9;
	ofstream file10;
	file1.open ("(AxX)DataResultDouble[C].txt", std::ofstream::out | std::ofstream::trunc);
    file2.open ("(A+B+C)x(X)DataResultDouble[C].txt", std::ofstream::out | std::ofstream::trunc);
    file3.open ("(Ax(BxC))DataResultDouble[C].txt", std::ofstream::out | std::ofstream::trunc);
	file4.open ("(AxX)DataResultFloat[C].txt", std::ofstream::out | std::ofstream::trunc);
    file5.open ("(A+B+C)x(X)DataResultFloat[C].txt", std::ofstream::out | std::ofstream::trunc);
    file6.open ("(Ax(BxC))DataResultFloat[C].txt", std::ofstream::out | std::ofstream::trunc);
	file7.open ("PartialGausseDouble[C].txt", std::ofstream::out | std::ofstream::trunc);
	file8.open ("FullGausseDouble[C].txt", std::ofstream::out | std::ofstream::trunc);
    file9.open ("PartialGausseFloat[C].txt", std::ofstream::out | std::ofstream::trunc);
    file10.open ("FullGausseFloat[C].txt", std::ofstream::out | std::ofstream::trunc);
	file1.close();
	file2.close();
	file3.close();
	file4.close();
	file5.close();
	file6.close();
	file7.close();
	file8.close();
	file9.close();
	file10.close();
}

void writeDoubleMatrixToFile(MatrixXd a, int size,string name)
{
	std::ofstream outfile;

	outfile.open(name, std::ios_base::app);
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			outfile << setprecision(16) << fixed << a(i,j);
			outfile << " ";
		}
		outfile << "\n";
	}
	outfile << "*** *** *** *** *** ***\n";
	outfile.close();
}

void writeFloatMatrixToFile(MatrixXf a, int size, string name)
{
	std::ofstream outfile;

	outfile.open(name, std::ios_base::app);
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			outfile << setprecision(16) << fixed << a(i,j);
			outfile << " ";
		}
		outfile << "\n";
	}
	outfile << "*** *** *** *** *** ***\n";
	outfile.close();
}

void writeDoubleVectorFile(string name, VectorXd doubleVector, int size)
{
  ofstream myfile;
  myfile.open (name, std::ios_base::app);
  for (int i = 0; i < size; i++)
  {
  	myfile << setprecision(16) << fixed << doubleVector(i);
  	myfile << "\n";
  }
  myfile << "*** *** *** *** *** *** ***\n";	
  myfile.close();	
}

void writeFloatVectorFile(string name, VectorXf floatVector, int size)
{
  ofstream myfile;
  myfile.open (name, std::ios_base::app);
  for (int i = 0; i < size; i++)
  {
  	myfile << setprecision(16) << fixed << floatVector(i);
  	myfile << "\n";
  }
  myfile << "*** *** *** *** *** *** ***\n";	
  myfile.close();	
}
