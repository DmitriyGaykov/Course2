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
        V,   // [in]  максимальный вес груза
        MM,  // [in]  количество мест для контейнеров     
        n,  // [in]  всего контейнеров  
        v,   // [in]  вес каждого контейнера  
        c,   // [in]  доход от перевозки каждого контейнера     
        r    // [out] результат: индексы выбранных контейнеров  
    );
    end = clock();

    std::cout << std::endl << "- Задача о размещении контейнеров на судне";
    std::cout << std::endl << "- общее количество контейнеров    : " << n;
    std::cout << std::endl << "- количество мест для контейнеров : " << MM;
    std::cout << std::endl << "- ограничение по суммарному весу  : " << V;
    std::cout << std::endl << "- вес контейнеров                 : ";
    for (int i = 0; i < n; i++) std::cout << std::setw(3) << v[i] << " ";
    std::cout << std::endl << "- доход от перевозки              : ";
    for (int i = 0; i < n; i++) std::cout << std::setw(3) << c[i] << " ";
    std::cout << std::endl << "- выбраны контейнеры (0,1,...,m-1): ";
    for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
    std::cout << std::endl << "- доход от перевозки              : " << cc;
    std::cout << std::endl << "- общий вес выбранных контейнеров : ";
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