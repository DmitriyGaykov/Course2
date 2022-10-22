#include "stdafx.h"

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


		//Log::WriteLine(log, (wchar_t*)L"�����:", (wchar_t*)L" ��� ������\n", (wchar_t*)L""); // ������ � ��� �� ������
		//Log::WriteLine(log, (char*)"�����: ", (char*)" ��� ������\n", (char*)""); // ������ � ��� �� ������

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