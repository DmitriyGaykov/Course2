#include "Hafner.h"

int main()
{
	setlocale(LC_ALL, "ru");
	string str;

	cout << "������� ������: ";
	getline(cin, str);

	hafner(str);
}