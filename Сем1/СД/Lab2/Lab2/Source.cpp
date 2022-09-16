#include <iostream>
#include <string>
#include <vector>
#include <queue>
using namespace std;

#include "User.h"

int main()
{
	setlocale(LC_ALL, "ru");
	User us1(1, "Dima");
	User us2(2, "Andrey");
	User us3(3, "Pasha");
	User us4(4, "Olya");
	User us5(5, "Dasha");
	User us6(6, "Kolya");
	User us7(7, "Masha");
	User us8(8, "Mark");
	User us9(9, "Mia");
	User us10(10, "Julia");

	us1.LinksWith(2, &us2, &us5);
	// us1.LinkWith(&us2);
	us2.LinksWith(2, &us7, &us8);
	us3.LinkWith(&us8);
	us4.LinksWith(2, &us6, &us9);
	us5.LinkWith(&us6);
	us6.LinkWith(&us9);
	us7.LinkWith(&us8);
	us9.LinkWith(&us10);

	// Поиск в ширину:
	cout << us8.ToUserBy(10)->Name << endl;

	// Поиск в глубину:
	cout << us8.GoDeep(10)->Name << endl;

	cout << "Матрица смежности: \n";
	us1.PrintInfoFromMatrix();

	cout << "Список ребер: \n";
	for (auto& el : us1.Edges)
	{
		cout << el.toString() << "\n";
	}
}