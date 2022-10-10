#include <iostream>
#include "stdafx.h"
using namespace fst;

void main()
{
	setlocale(LC_ALL, "ru");

	FST fst1(
		(char*)"aaaabaabbbaba",
		4,
		NODE(3, RELATION('a', 0), RELATION('b', 0), RELATION('a', 1)),
		NODE(1, RELATION('b', 2)),
		NODE(1, RELATION('a', 3)),
		NODE()
	);

	if (execute(fst1))
	{
		cout << "Цепочка " << fst1.string << " распознана" << endl;
	}
	else
	{
		cout << "Цепочка " << fst1.string << " не распознана" << endl;
	}
}