#pragma once
#include "stdafx.h"
#include "IT.h"

void LexAnalize(In::IN in, // входной поток
	LT::LexTable& lextable, // таблица лексем
	IT::IdTable& idtable); // таблица идентификаторов

bool isStopSymb(char symb); //проверка на стоп-символы


void searchLexsAndIdns( // поиск лексем и идентификаторов
	vector<string> words, // вектор слов
	LT::LexTable& lextable, // таблица лексем
	IT::IdTable& idtable, // таблица идентификаторов
	ushort& nLine // номер строки
);