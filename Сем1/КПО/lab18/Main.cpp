#include "stdafx.h"

void main()
{

	/// <summary>
	/// First test
	/// </summary>
	char* expr1 = new char[20];
	strcpy_s(expr1, 20, "a&~(b|c)");

	if (PolishNotation::PolishNotation(expr1))
	{
		cout << "Expression is correct" << endl;
	}
	else
	{
		cout << "Expression " << expr1 << " is incorrect" << endl;
	}


}