#include <iostream>
#include <string>
#include "check.h"
using namespace std;

void hanoi(int i, int k, int n)
{
	if (n == 1)
	{
		cout << "Переместить диск " << n << " из стержня " << i << " к стержню " << k << endl;
	}
	else
	{
		int temp = 6 - i - k;
		hanoi(i, temp, n - 1);
		cout << "Переместить диск " << n << " из стержня " << i << " к стержню " << k << endl;
		hanoi(temp, k, n - 1);
	}
}

int main()
{
	setlocale(LC_ALL, "ru");

	string Test;
	do {
		getline(cin, Test);
	} while (!isProved(Test, 1, 100000));

	int Num = stoi(Test);

	hanoi(1, 2, Num);
	return 0;
}
