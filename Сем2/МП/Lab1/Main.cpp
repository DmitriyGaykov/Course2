#include "Auxil.h"                            // вспомогательные функции 
#include <iostream>
#include <ctime>
#include <locale>
#define  CYCLE  1000000                       // количество циклов  

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
	auxil::start();   // старт генерации

	int n = 10;
	
	for (int j = 1; j <= n; j++)
	{

		t1 = clock();                            // фиксация времени 

		for (int i = 0; i < CYCLE * j; i++)
		{
			av1 += (double)auxil::iget(-100, 100); // сумма случайных чисел 
			av2 += auxil::dget(-100, 100);         // сумма случайных чисел 
		}

		t2 = clock();                            // фиксация времени

		std::cout << std::endl << "количество циклов:         " << CYCLE * j;
		std::cout << std::endl << "среднее значение (int):    " << av1 / (CYCLE * j);
		std::cout << std::endl << "среднее значение (double): " << av2 / (CYCLE * j);
		std::cout << std::endl << "продолжительность (у.е):   " << (t2 - t1);
		std::cout << std::endl << "                  (сек):   "
			<< ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
		std::cout << std::endl;
	}

	cout << "\n\n\nПоследовательность Фибоначчи:\n";

	int number = 4;
	for (int i = 1; i <= n; i++)
	{
		t1 = clock();

		fibonacci(number * i);

		t2 = clock();

		std::cout << std::endl << "число фибоначчи для :         " << number * i;
		std::cout << std::endl << "продолжительность (у.е):   " << (t2 - t1);
		std::cout << std::endl << "                  (сек):   "
			<< ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
		std::cout << std::endl;
	}
	

	system("pause");
}
