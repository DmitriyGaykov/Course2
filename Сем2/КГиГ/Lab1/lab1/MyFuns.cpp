#include "pch.h"
#include "MyFuns.h"
#include <cstring>
#include <string>
#include <iostream>
using namespace std;

const wchar_t* to_wchar(double num)
{
	char chNum[20];

	wchar_t wchNum[20];
	strcpy_s(chNum, std::to_string(num).c_str());
	mbstowcs_s((size_t*)NULL, wchNum, chNum, 5);

	return wchNum;
}

const wchar_t* to_wchar(int num)
{
	char chNum[20];

	wchar_t wchNum[20];
	strcpy_s(chNum, std::to_string(num).c_str());
	mbstowcs_s((size_t*)NULL, wchNum, chNum, 20);

	return wchNum;
}

const wchar_t* to_wchar(char num)
{
	char chNum[20];
	chNum[0] = num;
	chNum[1] = 0;

	wchar_t wchNum[20];
	strcpy_s(chNum, chNum);
	mbstowcs_s((size_t*)NULL, wchNum, chNum, 4);

	return wchNum;
}

const wchar_t* to_wchar(string num)
{
	char chNum[50];

	wchar_t wchNum[50];
	strcpy_s(chNum, num.c_str());
	mbstowcs_s((size_t*)NULL, wchNum, chNum, 50);

	return wchNum;
}

int GetSize()
{
	return SIZE;
}

void PrintMatrix(CDC& dc, int x, int y, CMatrix& M)
{
	int countRows = M.rows();
	int countCols = M.cols();
	CRect* rect;
	int size = SIZE;
	const wchar_t* wchNum;

	int X = x - size / 2;
	int startY = y;
	int endY = y + size * countRows - size / 2;

	for (int i = 0; i < countRows; i++)
	{
		for (int j = 0; j < countCols; j++)
		{
			wchNum = to_wchar(M(i, j));
			dc.TextOutW(x + j * size, y + i * size, wchNum);
		}
	}

	dc.MoveTo(X, startY);
	dc.LineTo(X, endY);

	X = x + size * countCols;
	dc.MoveTo(X, startY);
	dc.LineTo(X, endY);
}

CPoint GetPlaceWhereSetSign(int x, int y, CMatrix& m)
{
	CPoint point;

	int countCols = m.cols();
	int countRows = m.rows();

	point.x = x + SIZE * (countCols + 1); 
	point.y = y + SIZE * (countRows - 1) / 2;

	return point;
}

CMatrix initMatrix(int rows, int cols, const int diap)
{
	auto m = new CMatrix(rows, cols);

	for (short i = 0; i < rows; i++)
	{
		for (short j = 0; j < cols; j++)
		{
			(*m)(i, j) = rand() % diap - diap / 2 + 1;
		}
	}

	return *m;
}

void PrintExpression(int x, int y, CDC& dc, CMatrix& A, const wchar_t* signEx, CMatrix& B, CMatrix& C)
{
	auto EQUAL = L"=";

	CPoint p(x, y);

	PrintMatrix(dc, p.x, p.y, A);
	auto signPoint = GetPlaceWhereSetSign(p.x, p.y, A);
	dc.TextOutW(signPoint.x, signPoint.y, signEx);

	p.x = signPoint.x + SIZE * 1.5;
	PrintMatrix(dc, p.x, p.y, B);
	signPoint = GetPlaceWhereSetSign(p.x, p.y, B);
	dc.TextOutW(signPoint.x, signPoint.y, EQUAL);

	p.x = signPoint.x + SIZE * 1.5;
	PrintMatrix(dc, p.x, p.y, C);
}

int PrintExpWithoutAnswer(int x, int y, CDC& dc, CMatrix& A, const wchar_t* signEx, CMatrix& B)
{
	auto EQUAL = L"=";

	CPoint p(x, y);

	PrintMatrix(dc, p.x, p.y, A);
	auto signPoint = GetPlaceWhereSetSign(p.x, p.y, A);
	dc.TextOutW(signPoint.x, signPoint.y, signEx);

	p.x = signPoint.x + SIZE * 1.5;
	PrintMatrix(dc, p.x, p.y, B);
	signPoint = GetPlaceWhereSetSign(p.x, p.y, B);
	dc.TextOutW(signPoint.x, signPoint.y, EQUAL);
	return signPoint.x + SIZE * 1.5;
}

CMatrix VectorMult(CMatrix& m1, CMatrix& m2)
{
	CMatrix res(3, 1);

	if (m1.rows() != 3 || m1.cols() != 1)
	{
		throw "VectorMult | Первый аргумент не вектор!";
	}
	else if (m2.rows() != 3 || m2.cols() != 1)
	{
		throw "VectorMult | Второй аргумент не вектор!";
	}


	res(0, 0) = m1(1, 0) * m2(2, 0) - m1(2, 0) * m2(2, 0);
	res(1, 0) = m1(2, 0) * m2(0, 0) - m1(0, 0) * m2(2, 0);
	res(2, 0) = m1(0, 0) * m2(1, 0) - m1(1, 0) * m2(0, 0);

	return res;
}

double ScalarMult(CMatrix& V1, CMatrix& V2)
{
	if (V1.rows() != 3 || V1.cols() != 1)
	{
		throw "ScalarMult | Первый аргумент не вектор!";
	}
	else if (V2.rows() != 3 || V2.cols() != 1)
	{
		throw "ScalarMult | Второй аргумент не вектор!";
	}
	double res = 0.0;

	for (int i = 0; i < 3; i++)
	{
		res += V1(i, 0) * V2(i, 0);
	}

	return res;
}

double ModVec(CMatrix& V)
{
	if (V.rows() != 3)
	{
		throw "ModVec | Аргумент — не вектор!";
	}

	double res = 0.0;

	for (int i = 0; i < 3; i++)
	{
		res += V(i, 0) * V(i, 0);
	}

	res = sqrt(res);

	return res;
}

double SinV1V2(double cos)
{
	return sqrt(1 - cos * cos);
}

double CosV1V2(CMatrix& V1, CMatrix& V2)
{
	if (V1.rows() != 3 || V1.cols() != 1)
	{
		throw "CosV1V2 | Первый аргумент не вектор!";
	}
	else if (V2.rows() != 3 || V2.cols() != 1)
	{
		throw "CosV1V2 | Второй аргумент не вектор!";
	}

	double res = ScalarMult(V1, V2) / (ModVec(V1) * ModVec(V2));

	return res;
}

CMatrix CartToSphere(CMatrix& PView)
{
	if (PView.rows() != 3 || PView.cols() != 1)
	{
		throw "CartToSphere | Аргумент не вектор!";
	}
	CMatrix res(1, 3);
	
	auto r = sqrt(PView(0, 0) * PView(0, 0) + PView(1, 0) * PView(1, 0) + PView(2, 0) * PView(2, 0));
	auto phi = acos(PView(2, 0) / r);
	auto theta = atan2(PView(1, 0), PView(0, 0));

	auto x = r * sin(phi) * cos(theta);
	auto y = r * sin(phi) * sin(theta);
	auto z = r * cos(phi);

	res(0, 0) = x;
	res(1, 0) = y;
	res(2, 0) = z;

	return res;
}

CMatrix SphereToCart(CMatrix& PView)
{
	if (PView.rows() != 3 || PView.cols() != 1)
	{
		throw "SphereToCart | Аргумент не вектор!";
	}
	CMatrix res(3, 1);

	auto x = PView(0, 0) * sin(PView(1, 0)) * cos(PView(2, 0));
	auto y = PView(0, 0) * sin(PView(1, 0)) * sin(PView(2, 0));
	auto z = PView(0, 0) * cos(PView(1, 0));

	res(0, 0) = x;
	res(1, 0) = y;
	res(2, 0) = z;

	return res;
}