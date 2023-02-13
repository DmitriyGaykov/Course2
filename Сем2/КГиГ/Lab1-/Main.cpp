#include <iostream>
#include "stdafx.h"

using namespace std;

// void PrintMatrix(CDC& dc, int x, int y, CMatrix& M);
// dc � ������ �� ��������
// x, y � ���������� ����� � ����, ������ ���������� �����
// M � ��������� �������

void PrintMatrix(CDC& dc, int x, int y, CMatrix& M)
{
	int i, j;
	CString str;
	for (i = 0; i < M.rows(); i++)
	{
		for (j = 0; j < M.cols(); j++)
		{
			str.Format(_T("%f"), M(i, j));
			dc.TextOut(x, y, str);
			x += str.GetLength() * 6;
		}
		x = 0;
		y += 15;
	}
}

void main()
{
	
}