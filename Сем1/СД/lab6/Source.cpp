#include "stdafx.h"
#include <Windows.h>

int main()
{
	setlocale(LC_ALL, "ru");
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	
	string str;

	cout << "������� ������: ";
	getline(cin, str);

	hafner(str);
}