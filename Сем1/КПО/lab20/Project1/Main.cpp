#include "stdafx.h"
#include "Analize.h"
using namespace fst;

int main(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "ru");
	Log::LOG log = Log::INITLOG; // инициализация лога
	Parm::PARM parm; // инициализация параметров

	log = Log::getlog();

	try
	{
		parm = Parm::getparm(argc, argv); // получение параметро
		Log::Close(log);

		log = Log::getlog(parm.log); // получение лога
		In::IN in = In::getin(parm.in); // получение входных данных

		LT::LexTable lextable = LT::Create(in.size); // создание таблицы лексем
		IT::IdTable idtable = IT::Create(in.size); // создание таблицы идентификаторов

		LexAnalize(in, lextable, idtable); // лексический анализ
		char* lexs = new char[lextable.size];
		
		for (ushort i = 0; i < lextable.size; i++)
		{
			lexs[i] = lextable.table[i].lexema;
		}
		lexs[lextable.size] = '\0';

		Log::WriteLog(log); // запись в лог
		Log::WriteParm(log, parm); // запись процесса проверки параметров
		Log::WriteIn(log, in); // запись процесса обработки входных данных
		Log::Close(log); // закрытие лога

		Out::OUT out(parm.out);
		out.Write(lexs);

		// Проверка инициализации

		FST init(
			(char*)"dti=ivivfi(l,l,fi(i,i));",
			13,
			NODE(1, RELATION('d', 1)), // 0
			NODE(1, RELATION('t', 2)), // 1
			NODE(2, RELATION('i', 3), RELATION('i', 11)), // 2
			NODE(1, RELATION('=', 4)), // 3
			
			NODE(4, RELATION('(', 4), RELATION('i', 5), RELATION('l', 5), RELATION('f', 6)), // 4
			NODE(3, RELATION(')', 5), RELATION(';', 12), RELATION('v', 4)), // 5
			
			NODE(1, RELATION('i', 7)), // 6
			NODE(2, RELATION('(', 8), RELATION('(', 10)), // 7
			NODE(5, RELATION('i', 9), RELATION('f', 6), RELATION('l', 9), RELATION('i', 10), RELATION('l', 10)), // 8
			NODE(1, RELATION(',', 8)), // 9
			NODE(2, RELATION(')', 9), RELATION(')', 5)), // 10
			
			NODE(1, RELATION(';', 12)), // 11
			
			NODE() // 12
		);

		FST initFunc(
			(char*)"tfi(ti,ti,ti)",
			9,
			NODE(1, RELATION('t', 1)),
			NODE(1, RELATION('f', 2)),
			NODE(1, RELATION('i', 3)),
			NODE(2, RELATION('(', 4), RELATION('(', 7)),
			NODE(1, RELATION('t', 5)),
			NODE(2, RELATION('i', 6), RELATION('i', 7)),
			NODE(1, RELATION(',', 4)),
			NODE(1, RELATION(')', 8)),
			NODE()
		);

		FST funcBody(
			(char*)"{dti;dti=lvfi(l,l,fi(i,i))viv(ivl);rl;};",
			18,
			//////////////////////////////////////////////
			NODE(1, RELATION('{', 1)), // 0
			NODE(3, RELATION('d', 2), RELATION('i', 4), RELATION('r', 13)), // 1
			//////////////////////////////////////////////
			
			//////////////////////////////////////////////
			NODE(1, RELATION('t', 3)), // 2
			NODE(2, RELATION('i', 4), RELATION('f', 7)), // 3
			//////////////////////////////////////////////
			
			//////////////////////////////////////////////
			NODE(2, RELATION(';', 1), RELATION('=', 5)), // 4
			NODE(4, RELATION('l', 6), RELATION('i', 6), RELATION('(', 5), RELATION('f', 7)), // 5
			NODE(3, RELATION(')', 6), RELATION(';', 1), RELATION('v', 5)), // 6
			//////////////////////////////////////////////
			
			//////////////////////////////////////////////
			NODE(1, RELATION('i', 8)), // 7
			NODE(2, RELATION('(', 9), RELATION('(', 11)), // 8
			NODE(5, RELATION('i', 10), RELATION('l', 10), RELATION('f', 7), RELATION('i', 11), RELATION('l', 11)), // 9
			NODE(1, RELATION(',', 9)), // 10
			NODE(4, RELATION(')', 12), RELATION(')', 6), RELATION(')', 10), RELATION(')', 11)), // 11
			NODE(1, RELATION(';', 1)), // 12
			//////////////////////////////////////////////

			//////////////////////////////////////////////
			NODE(2, RELATION('l', 14), RELATION('i', 14)), // 13
			NODE(1, RELATION(';', 15)), // 14
			NODE(1, RELATION('}', 16)), // 15
			NODE(1, RELATION(';', 17)), // 16
			NODE()
			//////////////////////////////////////////////
		);
		
		cout << execute(funcBody);
		
		
		// вывод таблицы лексем


		
		//cout << "Таблица лексем:" << endl;
		//
		//for (ushort i = 0; i < lextable.size; i++)
		//{
		//	cout << "lexema: " << lextable.table[i].lexema << "\t\t\t";
		//	cout << "sn: " << lextable.table[i].sn << "\t\t\t";
		//	cout << "idxTI: " << lextable.table[i].idxTI << "\t\t\t";
		//	cout << endl;
		//}
		//
		//// вывод таблицы идентификаторов
		//
		//cout << "\n\nТаблица идентификаторов:" << endl;
		//
		//for (ushort i = 0; i < idtable.size; i++)
		//{
		//	cout << "id: " << idtable.table[i].id << "\t\t\t";
		//	cout << "iddatatype: " << idtable.table[i].iddatatype << "\t\t\t";
		//	cout << "idxfirstLE: " << idtable.table[i].idxfirstLE << "\t\t\t";
		//	cout << "idtype: " << idtable.table[i].idtype << "\t\t\t";
		//	
		//	if (idtable.table[i].iddatatype == IT::INT)
		//	{
		//		cout << "value: " << idtable.table[i].value.vint << "\t\t\t";
		//	}
		//	else
		//	{
		//		cout << "value: " << idtable.table[i].value.vstr->str << "\t\t\t";
		//	}
		//	
		//	cout << endl;
		//}
	}
	catch (Error::ERROR e)
	{
		std::cout << "Ошибка: " << e.id << " : " << e.message << std::endl; // вывод ошибки
		if (e.inext.line != -1)
		{
			std::cout << "Строка: " << e.inext.line << "  Символ: " << e.inext.col << std::endl;
		}
		Log::WriteError(log, e); // запись ошибки в лог
		Log::Close(log); // закрытие лога
	}
	return 0;
}