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

	FST fst2(
		(char*)"if(aabcccacaaba){acab}",
		8,
		NODE(1, RELATION('i', 1)),
		NODE(1, RELATION('f', 2)),
		NODE(1, RELATION('(', 3)),
		NODE(6, RELATION('a', 3), RELATION('b', 3), RELATION('c', 3), RELATION('a', 4), RELATION('b', 4), RELATION('c', 4)),
		NODE(1, RELATION('+)', 5)),
		NODE(1, RELATION('{', 6)),
		NODE(6, RELATION('a', 6), RELATION('b', 6), RELATION('c', 6), RELATION('a', 7), RELATION('b', 7), RELATION('c', 7)),
		NODE(1, RELATION('}', 7)),
		NODE()
	);

	if (execute(fst2))
	{
		cout << "Цепочка " << fst2.string << " распознана" << endl;
	}
	else
	{
		cout << "Цепочка " << fst2.string << " не распознана" << endl;
	}
}