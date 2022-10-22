#pragma once
#include <iostream>
#include <string.h>
#include <cstring>
#include <stack>
#include <map>

using namespace std;

namespace PolishNotation
{
	bool PolishNotation(char* expression);

	void goThrowStr(char* expr, char* polExprs);

	bool isOperand(char symb);

	bool isOperation(char symb);

	bool isBrackets(char symb);

	void out(char* expr, char* polExpr);

	void writeTo(char* expr, stack<char> _stack);

	bool checkExpression(char* expression);

	bool checkOperations(char* expression);

	bool checkBrackets(char* expression);
}