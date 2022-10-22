#pragma once
#include "stdafx.h"

#define STREMPTY ""

namespace Lex
{
	void LexAnalize( // ���������� ����������� ��������� ����
		In::IN in, // ��������� � �������� �����
		LT::LexTable& lextable, // ������� ������
		IT::IdTable& idtable, // ������� ���������������
		Log::LOG log // ������
	);

	void checkLine( // �������� ������ �� ������������ ����/��������� �����
		string& word, // �����
		ushort nLine, // ����� ������
		LT::LexTable& lextable, // ������� ������
		IT::IdTable& idtable // ������� ���������������
	);

	bool isStopSymb( // �������� �� ����-������
		char symb // ������
	);

	string defineWord( // ����������� ���� �����
		string& word, // �����
		ushort nLine, // ����� ������
		LT::LexTable& lextable, // ������� ������
		IT::IdTable& idtable, // ������� ���������������
		string preWord // ���������� �����
	);

	void to_pchar( // �������������� string � char*
		string str, // ������
		char* pStr); // ��������� �� ������
};

