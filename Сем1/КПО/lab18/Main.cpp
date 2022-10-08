#include "stdafx.h"

void main()
{

	/// <summary>
	/// First test
	/// </summary>
	char* expr1 = new char[20];
	strcpy_s(expr1, 20, "2+3*4-5");

	if (PolishNotation::PolishNotation(expr1))
	{
		cout << "Expression is correct" << endl;
	}
	else
	{
		cout << "Expression " << expr1 << " is incorrect" << endl;
	}

	/// <summary>
	/// Second test
	/// </summary>

	char* expr2 = new char[20];
	strcpy_s(expr2, 20, "2+++3*4-5");

	if (PolishNotation::PolishNotation(expr2))
	{
		cout << "Expression is correct" << endl;
	}
	else
	{
		cout << "Expression " << expr2 << " is incorrect" << endl;
	}

	/// <summary>
	/// Third test
	/// </summary>

	char* expr3 = new char[50];
	strcpy_s(expr3, 50, "2-2-8+9*(3-3/2)*(1-2)");

	if (PolishNotation::PolishNotation(expr3))
	{
		cout << "Expression is correct" << endl;
	}
	else
	{
		cout << "Expression " << expr3 << " is incorrect" << endl;
	}

}