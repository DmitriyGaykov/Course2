#include "Auxil.h"                            // ��������������� ������� 
#include <iostream>
#include <ctime>
#include <locale>
#define  CYCLE  1000000                       // ���������� ������  

using namespace std;

int fibonacci(int n) {
	if (n <= 1) return n;
	return fibonacci(n - 1) + fibonacci(n - 2);
}

int main()
{
	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0;
	setlocale(LC_ALL, "rus");
	auxil::start();   // ����� ���������

	int n = 10;
	
	for (int j = 1; j <= n; j++)
	{

		t1 = clock();                            // �������� ������� 

		for (int i = 0; i < CYCLE * j; i++)
		{
			av1 += (double)auxil::iget(-100, 100); // ����� ��������� ����� 
			av2 += auxil::dget(-100, 100);         // ����� ��������� ����� 
		}

		t2 = clock();                            // �������� �������

		std::cout << std::endl << "���������� ������:         " << CYCLE * j;
		std::cout << std::endl << "������� �������� (int):    " << av1 / (CYCLE * j);
		std::cout << std::endl << "������� �������� (double): " << av2 / (CYCLE * j);
		std::cout << std::endl << "����������������� (�.�):   " << (t2 - t1);
		std::cout << std::endl << "                  (���):   "
			<< ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
		std::cout << std::endl;
	}

	cout << "\n\n\n������������������ ���������:\n";

	int number = 4;
	for (int i = 1; i <= n; i++)
	{
		t1 = clock();

		fibonacci(number * i);

		t2 = clock();

		std::cout << std::endl << "����� ��������� ��� :         " << number * i;
		std::cout << std::endl << "����������������� (�.�):   " << (t2 - t1);
		std::cout << std::endl << "                  (���):   "
			<< ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
		std::cout << std::endl;
	}
	

	system("pause");
}
