// --- Вoat.h
// -- решение  задачи об оптимальной загрузке судна  
//    функция возвращает доход  от перевози выбранных контейнеров
#pragma once 
#include "Combi.h"
namespace  boatfnc
{
    void copycomb(short m, short* r1, const short* r2); // копировать
    int calcc(combi::xcombination s, const int c[]); // доход
    int calcv(combi::xcombination s, const int v[]);  // вес
}

int boat(
    int V,         // [in]  максимальный вес груза
    short m,       // [in]  количество мест для контейнеров     
    short n,       // [in]  всего контейнеров  
    const int v[], // [in]  вес каждого контейнера  
    const int c[], // [in]  доход от перевозки каждого контейнера     
    short r[]      // [out] результат: индексы выбранных контейнеров
);
