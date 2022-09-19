// 7.	Разработайте геометрический калькулятор для расчета
//  параметров треугольника: площадь, периметр, высота, cos,
//   sin, tg, ctg. Пользователь указывает длину катетов.
class Triagle {
    constructor(kat1, kat2) {
        this.hypotenuse = () => Number((Math.sqrt(Math.pow(this.kat1, 2) + Math.pow(this.kat2, 2))).toFixed(2));
        this.perimeter = () => Number((this.kat1 + this.kat2 + this.hypotenuse()).toFixed(2));
        this.square = () => Number(((this.kat1 * this.kat2) / 2).toFixed(2));
        this.height = () => Number(((2 * this.square()) / this.kat1).toFixed(2));
        this.cos = () => Number((this.kat1 / this.hypotenuse()).toFixed(2));
        this.sin = () => Number((this.kat2 / this.hypotenuse()).toFixed(2));
        this.tg = () => Number((this.kat2 / this.kat1).toFixed(2));
        this.ctg = () => Number((this.kat1 / this.kat2).toFixed(2));
        this.kat1 = kat1;
        this.kat2 = kat2;
    }
}
let checkVal;
do {
    checkVal = prompt("Введите длину первого катета?");
} while (!isFinite(Number(checkVal)));
let kat1 = Number(checkVal);
do {
    checkVal = prompt("Введите длину второго катета?");
} while (!isFinite(Number(checkVal)));
let kat2 = Number(checkVal);
let newTriagle = new Triagle(kat1, kat2);
alert(`
    Катет1: ${kat1}\n
    Катет2: ${kat2}\n
    Гипотенуза: ${newTriagle.hypotenuse()}\n
    Периметр: ${newTriagle.perimeter()}\n
    Площадь: ${newTriagle.square()}\n
    Высота: ${newTriagle.height()}\n
    cos: ${newTriagle.cos()}\n
    sin: ${newTriagle.sin()}\n
    tg: ${newTriagle.tg()}\n
    ctg: ${newTriagle.ctg()}\n
`);
