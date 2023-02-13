#pragma once
#include "CMatrix.h"
#include <iostream>
using namespace std;

#define SIZE 50

void PrintMatrix(CDC& dc, int x, int y, CMatrix& M);
const wchar_t* to_wchar(double num);
const wchar_t* to_wchar(int num);
const wchar_t* to_wchar(char num);
const wchar_t* to_wchar(string num);
int GetSize();
CPoint GetPlaceWhereSetSign(int x, int y, CMatrix& m);
CMatrix initMatrix(int cols, int rows, const int diap = 20);
void PrintExpression(int x, int y, CDC& dc, CMatrix& A, const wchar_t* signEx, CMatrix& B, CMatrix& C);
int PrintExpWithoutAnswer(int x, int y, CDC& dc, CMatrix& A, const wchar_t* signEx, CMatrix& B);
CMatrix VectorMult(CMatrix& m1, CMatrix& m2);
double ScalarMult(CMatrix& V1, CMatrix& V2);
double ModVec(CMatrix& V);
double CosV1V2(CMatrix& V1, CMatrix& V2);
double SinV1V2(double cos);
CMatrix CartToSphere(CMatrix& PView);
CMatrix SphereToCart(CMatrix& PView);