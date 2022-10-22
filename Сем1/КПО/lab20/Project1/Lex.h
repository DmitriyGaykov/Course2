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
		string& word, // слово
		ushort nLine, // номер строки
		LT::LexTable& lextable, // таблица лексем
		IT::IdTable& idtable // таблица идентификаторов
	);

	bool isStopSymb( // проверка на стоп-символ
		char symb // символ
	);

	string defineWord( // определение типа слова
		string& word, // слово
		ushort nLine, // номер строки
		LT::LexTable& lextable, // таблица лексем
		IT::IdTable& idtable, // таблица идентификаторов
		string preWord // предыдущее слово
	);

	void to_pchar( // преобразование string в char*
		string str, // строка
		char* pStr); // указатель на строку
};

