#pragma once
#include "stdafx.h"

#define STREMPTY ""

namespace Lex
{
	void LexAnalize( // анализатор лексической структуры кода
		In::IN in, // структура с исходным кодом
		LT::LexTable& lextable, // таблица лексем
		IT::IdTable& idtable, // таблица идентификаторов
		Log::LOG log // логгер
	);

	void checkLine( // проверка строку на соответствие типу/ключевому слову
		char* word // слово
	);
};

