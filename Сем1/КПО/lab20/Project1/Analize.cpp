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
	bool isStrLit = false;

	for (ushort i = 0; i < in.size; i++)
	{
		if (!isStrLit)
		{
			if (!isStopSymb((char)in.text[i]))
			{
				word.push_back((char)in.text[i]);
			}
			else
			{
				if (word != "")
				{
					words.push_back(word);
					word = "";
				}
				if (
					(char)in.text[i] != ' ' &&
					(char)in.text[i] != '\t'
					)
				{
					word.push_back((char)in.text[i]);
					words.push_back(word);
					word = "";
				}

				if ((char)in.text[i] == '\'')
				{
					isStrLit = true;
				}
			}
		}
		else
		{
			if ((char)in.text[i] == '\'')
			{
				words.push_back(word);
				word = "";
				words.push_back("'");
				isStrLit = false;
			}
			else
			{
				word.push_back((char)in.text[i]);
			}
		}
	}

	searchLexsAndIdns(words, lextable, idtable, nLine);
}

bool isStopSymb(char symb)
{
	char stopSymbs[] = " ,;'(){}[]+-*/=\n\t";

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
	char str[TI_MAXSIZE];

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
			char* _id = new char[TI_MAXSIZE];
			to_pchar(words[i - 1], _id);

			ushort _index = IT::IsId(idtable, _id);
			auto _idx = idtable.table[_index];

			lex.lexema = LEX_ID;
			lex.sn = nLine;
			lex.idxTI = idtable.size;

			LT::Add(lextable, lex);

			delete[] _id;

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
				if (
					i - 1 >= 0 &&
					words[i - 1] == "=" &&
					((isProved(word) && words[i + 1] == ";") || (word == "'" && words[i + 3] == ";"))
					)
				{
					char* _id = new char[TI_MAXSIZE];
					to_pchar(words[i - 2], _id);

					ushort _index = IT::IsId(idtable, _id);
					auto _idx = idtable.table[_index];

					strcpy_s(idn.id, _id);

					idn.iddatatype = _idx.iddatatype;
					idn.idtype = IT::V;
					idn.idxfirstLE = _index;

					lex.lexema = LEX_LITERAL;
					lex.sn = lextable.size;

					LT::Add(lextable, lex);

					if (isProved(word))
					{
						idn.value.vint = stoi(word);
						_idx.value.vint = stoi(word);
					}
					else
					{
						to_pchar(words[i + 1], str);
						strcpy_s(idn.value.vstr->str, str);
						idn.value.vstr->len = strlen(str);

						strcpy_s(_idx.value.vstr->str, str);
						_idx.value.vstr->len = strlen(str);
					}

					IT::Add(idtable, idn);
					delete[] _id;
				}


				// TODO: сделать для функции

				else
				{
					/*lex.idxTI = TI_NULLIDX;
					lex.lexema = LEX_LITERAL;
					lex.sn = nLine;

					LT::Add(lextable, lex);*/
				}

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

bool isProved(string num)
{
	if (num == "")
		return false;
	char nums[] = "-0123456789";
	bool isNotNum = false;

	for (int i = 0; i < num.size(); i++)
	{
		for (int j = 0; j < strlen(nums); j++)
		{
			if (num[i] == nums[j])
			{
				if (num[i] == '-' && i != 0)
					return false;
				if (num[i] == '-' && i == 0 && num.size() == 1)
					return false;

				isNotNum = false;
				break;
			}
			else
			{
				isNotNum = true;
			}
		}

		if (isNotNum)
		{
			return false;
		}
	}

	return true;
}
