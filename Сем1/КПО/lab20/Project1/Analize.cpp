#include "Analize.h"


void LexAnalize(
	In::IN in,
	LT::LexTable& lextable,
	IT::IdTable& idtable)
{
	string text = "";

	for (ushort i = 0; i < in.size; i++)
	{
		text.push_back(in.text[i]);
	}

	ushort nLine = 1;

	vector<string> words;
	string word = "";

	for (char el : text)
	{
		if (!isStopSymb(el))
		{
			word.push_back(el);
		}
		else
		{
			words.push_back(word);
			word = "";
			if (
				el != ' ' &&
				el != '\t'
				)
			{
				word.push_back(el);
				words.push_back(word);
				word = "";
			}
		}
	}

	searchLexsAndIdns(words, lextable, idtable, nLine);
}

bool isStopSymb(char symb)
{
	char stopSymbs[] = " ,;(){}[]+-*/='\n\t";

	for (ushort i = 0; i < strlen(stopSymbs); i++)
	{
		if (symb == stopSymbs[i])
		{
			return true;
		}
	}

	return false;
}

void searchLexsAndIdns(
	vector<string> words,
	LT::LexTable& lextable,
	IT::IdTable& idtable,
	ushort& nLine)
{
	string word;
	LT::Entry lex;
	IT::Entry idn;
	char str[MAX_LEN_LINE];

	for (auto i : words)
	{
		cout << i << "\n";
	}

	for (ushort i = 0; i < words.size(); i++)
	{
		word = words[i];

		if (word == "\n")
		{
			nLine++;
		}

		if (word == "function")
		{
			lex.lexema = LEX_FUNCTION;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "integer")
		{
			lex.lexema = LEX_INTEGER;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "string")
		{
			lex.lexema = LEX_STRING;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "declare")
		{
			lex.lexema = LEX_DECLARE;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "return")
		{
			lex.lexema = LEX_RETURN;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "print")
		{
			lex.lexema = LEX_PRINT;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == ";")
		{
			lex.lexema = LEX_SEMICOLON;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == ",")
		{
			lex.lexema = LEX_COMMA;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "{")
		{
			lex.lexema = LEX_LEFTBRACE;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "}")
		{
			lex.lexema = LEX_RIGHTBRACE;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "(")
		{
			lex.lexema = LEX_LEFTHESIS;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == ")")
		{
			lex.lexema = LEX_RIGHTHESIS;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "+")
		{
			lex.lexema = LEX_PLUS;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "-")
		{
			lex.lexema = LEX_MINUS;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "*")
		{
			lex.lexema = LEX_STAR;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "/")
		{
			lex.lexema = LEX_DIRSLASH;
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "\n")
		{
			lex.lexema = '\n';
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else if (word == "=")
		{
			lex.lexema = '=';
			lex.sn = nLine;
			lex.idxTI = -1;

			word = "";
			word.push_back(lex.lexema);

			LT::Add(lextable, lex);
		}
		else
		{

			to_pchar(word, str);
			strcpy_s(idn.id, str);

			if (
				words[i - 1] == "function" &&
				words[i - 2] == "integer")
			{
				idn.iddatatype = IT::INT;
				idn.idtype = IT::F;
				idn.idxfirstLE = lextable.size;

				lex.idxTI = idtable.size;
				lex.lexema = LEX_ID;
				lex.sn = nLine;

				LT::Add(lextable, lex);
				IT::Add(idtable, idn);
			}
			else if (
				words[i - 1] == "function" &&
				words[i - 2] == "string"
				)
			{
				idn.iddatatype = IT::STR;
				idn.idtype = IT::F;
				idn.idxfirstLE = lextable.size;

				lex.idxTI = idtable.size;
				lex.lexema = LEX_ID;
				lex.sn = nLine;

				LT::Add(lextable, lex);
				IT::Add(idtable, idn);
			}
			else if (
				(words[i - 1] == "string" || words[i - 1] == "integer")
				&&
				(words[i - 2] == "(" || words[i - 2] == ",")
				)
			{
				idn.iddatatype = (words[i - 1] == "string" ? IT::STR : IT::INT);
				idn.idtype = IT::P;
				idn.idxfirstLE = lextable.size;

				lex.idxTI = idtable.size;
				lex.lexema = LEX_ID;
				lex.sn = nLine;

				LT::Add(lextable, lex);
				IT::Add(idtable, idn);
			}
			else if (
				words[i - 1] == "string" ||
				words[i - 1] == "integer")
			{
				idn.iddatatype = (words[i - 1] == "string" ? IT::STR : IT::INT);
				idn.idtype = IT::V;
				idn.idxfirstLE = lextable.size;

				lex.idxTI = idtable.size;
				lex.lexema = LEX_ID;
				lex.sn = nLine;

				LT::Add(lextable, lex);
				IT::Add(idtable, idn);
			}
			else
			{

			}
		}
	}
}

void to_pchar(string str, char* pchar)
{
	for (ushort i = 0; i < str.size(); i++)
	{
		pchar[i] = str[i];
	}
	pchar[str.size()] = '\0';
}
