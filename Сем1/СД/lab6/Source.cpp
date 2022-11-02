#include "Hafner.h"

int main()
{
	setlocale(LC_ALL, "ru");
	string str;

	cout << "¬ведите строку: ";
	getline(cin, str);

	hafner(str);
}