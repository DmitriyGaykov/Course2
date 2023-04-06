// --- �oat.h
// -- �������  ������ �� ����������� �������� �����  
//    ������� ���������� �����  �� �������� ��������� �����������
#pragma once 
#include "Combi.h"
namespace  boatfnc
{
    void copycomb(short m, short* r1, const short* r2); // ����������
    int calcc(combi::xcombination s, const int c[]); // �����
    int calcv(combi::xcombination s, const int v[]);  // ���
}

int boat(
    int V,         // [in]  ������������ ��� �����
    short m,       // [in]  ���������� ���� ��� �����������     
    short n,       // [in]  ����� �����������  
    const int v[], // [in]  ��� ������� ����������  
    const int c[], // [in]  ����� �� ��������� ������� ����������     
    short r[]      // [out] ���������: ������� ��������� �����������
);
