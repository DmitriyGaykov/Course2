#include "stdafx.h"
#include <regex>

namespace PolishNotation
{
	typedef char operation;

	map<operation, int> priorities =
	{
		{'(', 1},
		{')', 1},
		{'+', 2},
		{'-', 2},
		{'*', 3},
		{'/', 3}
	};

	bool PolishNotation(char* expression)
	{
		if (!checkExpression(expression))
		{
			return false;
		}

		char* polishExpression = new char[strlen(expression)];
		strcpy_s(polishExpression, strlen(expression), "");

		goThrowStr(expression, polishExpression);

		out(expression, polishExpression);

		return true;
	}

	bool checkExpression(char* expression)
	{
		if (
			!checkBrackets(expression) ||
			!checkOperations(expression)
			)
		{
			return false;
		}
		return true;
	}

	bool checkBrackets(char* expression)
	{
		stack<char> brackets;

		for (int i = 0; i < strlen(expression); i++)
		{
			if (expression[i] == '(')
			{
				brackets.push(expression[i]);
			}
			else if (expression[i] == ')')
			{
				if (brackets.empty())
				{
					return false;
				}
				else
				{
					brackets.pop();
				}
			}
		}

		if (brackets.empty())
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	bool checkOperations(char* expression)
	{
		for (int i = 0; i < strlen(expression); i++)
		{
			if (isOperation(expression[i]) && !isBrackets(expression[i]))
			{
				if (i == 0)
				{
					return false;
				}
				else if (i == strlen(expression) - 1 && !isBrackets(expression[i]))
				{
					return false;
				}
				else if (isOperation(expression[i - 1]) && !isBrackets(expression[i - 1]))
				{
					return false;
				}
				else if (isOperation(expression[i + 1]) && !isBrackets(expression[i + 1]))
				{
					return false;
				}
			}
		}
		return true;
	}

	void goThrowStr(char* expr, char* polExprs)
	{
		stack<operation> _stack;
		int	polExprIndex = 0;

		for (auto i = 0; i < strlen(expr); i++)
		{
			if (isOperand(expr[i]))
			{
				polExprs[polExprIndex++] = expr[i];
			}
			else if (isOperation(expr[i]))
			{
				if (_stack.empty() ||
					expr[i] == '(' ||
					priorities[expr[i]] > priorities[_stack.top()])
				{
					_stack.push(expr[i]);
				}
				else
				{
					while (
						!_stack.empty() &&
						priorities[expr[i]] <= priorities[_stack.top()])
					{
						if (!isBrackets(_stack.top()))
						{
							polExprs[polExprIndex++] = _stack.top();
						}

						_stack.pop();
					}
					_stack.push(expr[i]);
				}
			}
		}

		polExprs[polExprIndex] = '\0';

		if (!_stack.empty())
		{
			writeTo(polExprs, _stack);
		}

	}

	void writeTo(char* expr, stack<operation> _stack)
	{
		int exprIndex = strlen(expr);

		while (!_stack.empty())
		{
			if (!isBrackets(_stack.top()))
			{
				expr[exprIndex++] = _stack.top();
			}

			_stack.pop();
		}

		expr[exprIndex] = '\0';
	}

	bool isOperand(char symb)
	{
		return
			(symb >= '0' && symb <= '9') ||
			(symb >= 'a' && symb <= 'z') ||
			(symb >= 'A' && symb <= 'Z');
	}

	bool isOperation(char symb)
	{
		return symb ==
			'+' ||
			symb == '-' ||
			symb == '*' ||
			symb == '/' ||
			isBrackets(symb);
	}

	bool isBrackets(char symb)
	{
		return symb == '(' ||
			symb == ')';
	}

	void out(char* expr, char* polExpr)
	{
		cout << expr << " >>>> " << polExpr << endl;
	}
}