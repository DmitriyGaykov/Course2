//#pragma once
//#include "stdafx.h"
//#include "IT.h"
//#include "Log.h"
//#include <vector>
//
//using namespace IT;
//using namespace Log;
//
//namespace Lex
//{
//	void LexAnalize( // лексический анализ
//		In::IN in, // входной поток
//		LT::LexTable& lextable, // таблица лексем
//		IdTable& idtable, // таблица идентификаторов
//		LOG& log); // лог
//
//	//void checkLine( // проверка строку на соответствие типу/ключевому слову
//	//	string& word, // слово
//	//	ushort nLine, // номер строки
//	//	LT::LexTable& lextable, // таблица лексем
//	//	IT::IdTable& idtable // таблица идентификаторов
//	//);
//
//	bool isStopSymb( // проверка на стоп-символ
//		char symb // символ
//	);
//
//	//string defineWord( // определение типа слова
//	//	string& word, // слово
//	//	ushort nLine, // номер строки
//	//	LT::LexTable& lextable, // таблица лексем
//	//	IT::IdTable& idtable, // таблица идентификаторов
//	//	vector<string>& words // предыдущие слова
//	//);
//
//	void to_pchar( // преобразование string в char*
//		string str, // строка
//		char* pStr); // указатель на строку
//}