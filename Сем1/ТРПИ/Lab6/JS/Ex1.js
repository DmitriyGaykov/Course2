let square1 = {
    name: "Желтый большой квадрат",
    edge: 10,
    color: "yellow",
    border: "1px solid black"
};
let cyrcle1 = {
    name: "Белый круг",
    radius: 5,
    color: "white",
    border: "1px solid black"
};
let triangle1 = {
    name: "Белый треугольник с одной полосой посередине",
    base: 10,
    height: 5,
    color: "red",
    border: "1px solid black",
    countLinesIn: 1
};
let square2 = {
    name: "Желтый маленький квадрат",
    edge: 5,
    color: "yellow",
    border: "1px solid black"
};
let cyrcle2 = {
    name: "Зеленый круг",
    radius: 5,
    color: "green",
    border: "1px solid black",
    countLinesIn: 3
};
let triangle2 = {
    name: "Белый треугольник с тремя полосами посередине",
    base: 10,
    height: 5,
    color: "red",
    border: "1px solid black",
    countLinesIn: 1
};
////////////////////////////////
let figures = [
    square1,
    cyrcle1,
    triangle1,
    square2,
    cyrcle2,
    triangle2
];
////////////////////////////////
let propsOfGreenCyrcle = Object.keys(cyrcle2);
for (let i = 0; i < figures.length; i++) {
    console.log("Зеленый круг отличается свойствами от " + figures[i].name + ":\n");
    for (let prop of propsOfGreenCyrcle) {
        if (Object.keys(figures[i]).indexOf(prop) == -1) {
            console.log(prop);
        }
    }
    console.log("\n");
}
// свойства, которые описывают фигуру «треугольник с тремя линиями»
let propsOfTriangleWithThreeLines = Object.keys(triangle2);
propsOfTriangleWithThreeLines.forEach((prop) => {
    console.log(prop);
});
// есть ли у фигуры «маленький квадрат» собственное свойство, которое определяет цвет фигуры.
let propsOfSquare2 = Object.keys(square2);
propsOfSquare2.forEach(prop => {
    if (prop === "color") {
        console.log("Есть");
    }
});
