#include <iostream>
using namespace std;

void main()
{
	int num = 1234;
	int ostatok;
	while (num % 10 != 0)
	{
		ostatok = num % 10;
		num /= 10;
	}
}