#pragma once
#include "stdafx.h"
#include "IT.h"

void LexAnalize(In::IN in, // ������� �����
	LT::LexTable& lextable, // ������� ������
	IT::IdTable& idtable); // ������� ���������������

bool isStopSymb(char symb); //�������� �� ����-�������


void searchLexsAndIdns( // ����� ������ � ���������������
	vector<string> words, // ������ ����
	LT::LexTable& lextable, // ������� ������
	IT::IdTable& idtable, // ������� ���������������
	ushort& nLine // ����� ������
);