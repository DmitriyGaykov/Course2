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
		char* word // �����
	);
};

