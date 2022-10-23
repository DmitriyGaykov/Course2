#include "stdafx.h"
#include "Analize.h"

int main(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "ru");
	Log::LOG log = Log::INITLOG; // ������������� ����
	Parm::PARM parm; // ������������� ����������

	log = Log::getlog();

	try
	{
		parm = Parm::getparm(argc, argv); // ��������� ���������
		Log::Close(log);

		log = Log::getlog(parm.log); // ��������� ����
		In::IN in = In::getin(parm.in); // ��������� ������� ������

		LT::LexTable lextable = LT::Create(in.size); // �������� ������� ������
		IT::IdTable idtable = IT::Create(in.size); // �������� ������� ���������������

		LexAnalize(in, lextable, idtable); // ����������� ������

		for (ushort i = 0; i < lextable.size; i++)
		{
			cout << lextable.table[i].lexema;
		}

		Log::WriteLog(log); // ������ � ���
		Log::WriteParm(log, parm); // ������ �������� �������� ����������
		Log::WriteIn(log, in); // ������ �������� ��������� ������� ������
		Log::Close(log); // �������� ����

		Out::OUT out(parm.out);
		out.Write((char*)in.text);
	}
	catch (Error::ERROR e)
	{
		std::cout << "������: " << e.id << " : " << e.message << std::endl; // ����� ������
		if (e.inext.line != -1)
		{
			std::cout << "������: " << e.inext.line << "  ������: " << e.inext.col << std::endl;
		}
		Log::WriteError(log, e); // ������ ������ � ���
		Log::Close(log); // �������� ����
	}
	return 0;
}