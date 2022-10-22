#include "Lex.h"
#include <map>

namespace Lex
{
	void LexAnalize( // анализатор лексической структуры кода
		In::IN in, // структура с исходным кодом
		LT::LexTable& lextable, // таблица лексем
		IT::IdTable& idtable, // таблица идентификаторов
		Log::LOG log) // логгер
	{
		char* text = (char*)in.text;

		string line = "";

		ushort nLine = 1;

		char* lexems = new char[in.size];

		for (ushort i = 0; i < in.size; i++)
		{
			if (text[i] == '\n')
			{
				nLine++;
			}
			if (
				text[i] == ' ' ||
				text[i] == '\t' ||
				text[i] == '\n')
			{
				checkLine(line, nLine);

				line = "";
				continue;
			}
			else
			{
				line.push_back(text[i]);
			}
		}
	}

	void checkLine(
		string& line,
		ushort nLine,
		LT::LexTable& lextable,
		IT::IdTable& idtable)
	{
		string word = "";
		string endLine = (nLine >= 10 ? to_string(nLine) : "0" + to_string(nLine)) + " ";
		string preWord = "none";
		string temp;

		for (ushort i = 0; i < line.size(); i++)
		{
			if (!isStopSymb(line[i]))
			{
				word.push_back(line[i]);
			}
			else
			{
				if (word == "")
				{
					continue;
				}

				temp = word;
				word = defineWord(word, nLine, lextable, idtable, preWord);
				preWord = temp;

				endLine += word;
				word = "";

				if (
					line[i] != ' ' ||
					line[i] != '\t')
				{
					word.push_back(line[i]);
					word = defineWord(word, nLine, lextable, idtable, preWord);
				}
			}
		}
	}

	bool isStopSymb(char symb)
	{
		char stopSymbs[] = " ,;(){}[]+-*/=`\n\t";

		for (ushort i = 0; i < strlen(stopSymbs); i++)
		{
			if (symb == stopSymbs[i])
			{
				return true;
			}
		}

		return false;
	}


	string defineWord(
		string& word,
		ushort nLine,
		LT::LexTable& lextable,
		IT::IdTable& idtable,
		string preWord)
	{
		if (word == "integer")
		{
			LT::Add(lextable, { LEX_INTEGER, nLine, -1 });
			word = "";
			word.push_back(LEX_INTEGER);
		}
		else if (word == "string")
		{
			LT::Add(lextable, { LEX_STRING, nLine, -1 });
			word = "";
			word.push_back(LEX_STRING);
		}
		else if (word == "function")
		{
			LT::Add(lextable, { LEX_FUNCTION, nLine, -1 });
			word = "";
			word.push_back(LEX_STRING);
		}
		else if (word == "declare")
		{
			LT::Add(lextable, { LEX_DECLARE, nLine, -1 });
			word = "";
			word.push_back(LEX_DECLARE);
		}
		else if (word == "return")
		{
			LT::Add(lextable, { LEX_RETURN, nLine, -1 });
			word = "";
			word.push_back(LEX_RETURN);
		}
		else if (word == "print")
		{
			LT::Add(lextable, { LEX_PRINT, nLine, -1 });
			word = "";
			word.push_back(LEX_PRINT);
		}
		else if (word == ",")
		{
			LT::Add(lextable, { LEX_COMMA, nLine, -1 });
			word = "";
			word.push_back(LEX_COMMA);
		}
		else if (word == ";")
		{
			LT::Add(lextable, { LEX_SEMICOLON, nLine, -1 });
			word = "";
			word.push_back(LEX_SEMICOLON);
		}
		else if (word == "{")
		{
			LT::Add(lextable, { LEX_LEFTBRACE, nLine, -1 });
			word = "";
			word.push_back(LEX_LEFTBRACE);
		}
		else if (word == "}")
		{
			LT::Add(lextable, { LEX_BRACELET, nLine, -1 });
			word = "";
			word.push_back(LEX_BRACELET);
		}
		else if (word == "(")
		{
			LT::Add(lextable, { LEX_LEFTHESIS, nLine, -1 });
			word = "";
			word.push_back(LEX_LEFTHESIS);
		}
		else if (word == ")")
		{
			LT::Add(lextable, { LEX_RIGHTHESIS, nLine, -1 });
			word = "";
			word.push_back(LEX_RIGHTHESIS);
		}
		else if (word == "+")
		{
			LT::Add(lextable, { LEX_PLUS, nLine, -1 });
			word = "";
			word.push_back(LEX_PLUS);
		}
		else if (word == "-")
		{
			LT::Add(lextable, { LEX_MINUS, nLine, -1 });
			word = "";
			word.push_back(LEX_MINUS);
		}
		else if (word == "*")
		{
			LT::Add(lextable, { LEX_STAR, nLine, -1 });
			word = "";
			word.push_back(LEX_STAR);
		}
		else if (word == "/")
		{
			LT::Add(lextable, { LEX_DIRSLASH, nLine, -1 });
			word = "";
			word.push_back(LEX_DIRSLASH);
		}
		else
		{
			if (word.size() > ID_MAXSIZE)
			{
				throw ERROR_THROW_IN(110, nLine, 0);
			}

			char str[ID_MAXSIZE];

			to_pchar(word, str);

			if (word == "none")
			{
				IT::Add(idtable, );
			}
		}

		return word;
	}


	void to_pchar(
		string str,
		char* pStr
	)
	{
		for (ushort i = 0; i < str.size(); i++)
		{
			pStr[i] = str[i];
		}

		pStr[str.size()] = '\0';
	}
}
