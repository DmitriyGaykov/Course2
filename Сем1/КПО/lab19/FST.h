#pragma once
#include "stdafx.h"

namespace fst
{
	struct RELATION // �����:������ -> ������� ����� ��������� ��
	{
		char symbol; // ������ ��������
		int nnode; // ����� ������� �������

		RELATION(
			char c = 0x00, // ������ ��������
			short ns = 0 // ����� ���������
		);
	};

	struct NODE // ������� ����� ���������
	{
		short n_relation; // ���������� ������������ �����
		RELATION* relations; // ������ ������������ �����

		NODE();

		NODE(
			short n, // ���������� ������������ �����
			RELATION rel, // ������ �����
			... // ������ �����
		);
	};

	struct FST // ������������������� �������� �������
	{
		char* string; // �������(������ ����������� 0x00)
		short position; // ������� ������� � �������
		short nstates; // ���������� ��������� ��
		NODE* nodes; // ���� ���������: [0] - ��������� ���������, [nstate-1] - ��������
		short* rstates; // ��������� ��������� �������� �� ������ �������

		FST(
			char* s, // �������
			short ns, // ���������� ���������
			NODE n, // ���� ���������/ ������ ���������
			...
		);
	};

	bool execute( // ��������� ������������� �������
		FST& fst // ������������������� �������� �������
	);
	bool step(FST& fst, short*& rstates);

	short* setRelState(
		char symb,
		FST& fst,
		short* pNRStates,
		short* rstates);

	bool isAllowed(
		char symb,
		short*& rstates,
		short nRelations,
		FST& fst);

	bool isLastState(
		short* rstates,
		short length,
		short countStates);
}