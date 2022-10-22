#include "Lex.h"

namespace Lex
{
	void LexAnalize( // анализатор лексической структуры кода
		In::IN in, // структура с исходным кодом
		LT::LexTable& lextable, // таблица лексем
		IT::IdTable& idtable, // таблица идентификаторов
		Log::LOG log) // логгер
	{
		char* outText = new char[in.size];
		char* text = (char*)in.text;
		char str[MAX_LEN_LINE] = STREMPTY;

		for (ushort i = 0, j = 0; i < in.size; i++)
		{
			if (
				text[i] != ' ' ||
				text[i] != '\t' ||
				text[i] != '\n')
			{
				str[j] = text[i];
				j++;
			}
			else
			{
				if (j > 0)
				{
					str[j] = '\0';
					j = 0;

					checkLine(str);
				}
			}
		}
	}

	void checkLine(char* str)
	{

	}
}