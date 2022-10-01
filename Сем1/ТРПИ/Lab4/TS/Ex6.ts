// 6.	Реализуйте каррированную функцию, которая
//  рассчитывает объем прямоугольного параллелепипеда. 

function volume(a: number) : (b: number) => (c: number) => number {
    return (b: number) => (c: number) => a * b * c;
}

alert(`Volume of the parallelepiped is ${volume(2)(3)(4)}`);

//  Выполните преобразование функции для неоднократного
//   расчёта объема прямоугольных параллелепипедов, у
//    которых одно ребро одинаковой длины.

let volume2: (b: number) => (c: number) => number = volume(2);
alert(`Volume of the parallelepiped is ${volume2(3)(4)}`);