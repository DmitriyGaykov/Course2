// --- Main
#include <iostream>
#include <iomanip>
#include "Boat.h"
#define NN (sizeof(v)/sizeof(int))
#define MM 5

struct TIME
{
    double start;
    double end;

    TIME(double start, double end) : start(start), end(end) {}
    TIME() : start(0), end(0) {}

    double getMilliseconds()
    {
        return end - start;
    }

    double getSeconds()
    {
        return (end - start) / 1000.0;
    }
};

using namespace std;

TIME ex5(int n);
int* fillV(int n);
int* fillC(int n, int* v);

int main()
{
    srand(time(NULL));
    setlocale(LC_ALL, "rus");

    TIME time;
  
    for (int i = 25; i <= 30; i++)
    {
        cout << endl << i << ":\n\n";
        time = ex5(i);
        cout << "\nTime: " << time.getSeconds() << "c" << endl;
    }

    system("pause");
    return 0;
}

TIME ex5(int n)
{
    double start,
            end;

    auto v = fillV(n);
    auto c = fillC(n, v);
    int V = 1500;
    short* r = new short[MM];

    start = clock();
    int cc = boat(
        V,   // [in]  ������������ ��� �����
        MM,  // [in]  ���������� ���� ��� �����������     
        n,  // [in]  ����� �����������  
        v,   // [in]  ��� ������� ����������  
        c,   // [in]  ����� �� ��������� ������� ����������     
        r    // [out] ���������: ������� ��������� �����������  
    );
    end = clock();

    std::cout << std::endl << "- ������ � ���������� ����������� �� �����";
    std::cout << std::endl << "- ����� ���������� �����������    : " << n;
    std::cout << std::endl << "- ���������� ���� ��� ����������� : " << MM;
    std::cout << std::endl << "- ����������� �� ���������� ����  : " << V;
    std::cout << std::endl << "- ��� �����������                 : ";
    for (int i = 0; i < n; i++) std::cout << std::setw(3) << v[i] << " ";
    std::cout << std::endl << "- ����� �� ���������              : ";
    for (int i = 0; i < n; i++) std::cout << std::setw(3) << c[i] << " ";
    std::cout << std::endl << "- ������� ���������� (0,1,...,m-1): ";
    for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
    std::cout << std::endl << "- ����� �� ���������              : " << cc;
    std::cout << std::endl << "- ����� ��� ��������� ����������� : ";
    int s = 0; for (int i = 0; i < MM; i++) s += v[r[i]]; std::cout << s;
    std::cout << std::endl << std::endl;

    delete[] v;
    delete[] c;

    return TIME(start, end);
}

int* fillV(int n) 
{
    int* v = new int[n];

    for (int i = 0; i < n; i++)
    {
        v[i] = (rand() % 90 + 11) * 10;
    }

    return v;
}

int* fillC(int n, int* v)
{
    int* c = new int[n];

    for (int i = 0; i < n; i++)
    {
        c[i] = v[i] / 100 * 15;
    }

    return c;
}