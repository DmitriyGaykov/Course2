//Выведите: свойства, которые отличают фигуру «зеленый круг»; 
//свойства, которые описывают фигуру «треугольник с тремя линиями»;
//есть ли у фигуры «маленький квадрат» собственное свойство, которое определяет цвет фигуры.

// Какой метод помогает узнать отличие в полях объектов?
// Ответ: Object.keys (obj1).filter(key => obj1[key] !== obj2[key]); 

let figure : object = {
    name: "figure Name",
    color : "green",
    border: "1px solid black"
}


let square : object = 
{
    edge: 10
};

square.__proto__ = figure;

console.log(square.name + "  " + square.edge);

// вывести поля одного объекта, которых нет в других объекте

for(let prop of Object.keys(square)) {
    let isOwn : boolean = square.hasOwnProperty(prop);
  
    if (isOwn) {
      alert(`Our: ${prop}`); // Our: jumps
    } else {
      alert(`Inherited: ${prop}`); // Inherited: eats
    }
  }
  

// let cyrcle1 : object =
// {
//     name: "Белый круг",
//     radius: 5,
//     color: "white",
//     border: "1px solid black"
// };

// let triangle1 : object =
// {
//     name: "Белый треугольник с одной полосой посередине",
//     base: 10,
//     height: 5,
//     color: "red",
//     border: "1px solid black",
//     countLinesIn: 1
// };

// let square2 : object = {
//     name: "Желтый маленький квадрат",
//     edge: 5,
//     color: "yellow",
//     border: "1px solid black"
// };

// let cyrcle2 : object =
// {
//     name: "Зеленый круг",
//     radius: 5,
//     color: "green",
//     border: "1px solid black",
//     countLinesIn: 3
// }

// let triangle2 : object =
// {
//     name: "Белый треугольник с тремя полосами посередине",
//     base: 10,
//     height: 5,
//     color: "red",
//     border: "1px solid black",
//     countLinesIn: 1
// };

// ////////////////////////////////
// let figures : object[] = 
// [
//     square1, 
//     cyrcle1, 
//     triangle1, 
//     square2, 
//     cyrcle2,
//     triangle2
// ];

// ////////////////////////////////
// let propsOfGreenCyrcle : string[] = Object.keys(cyrcle2);

// for(let i = 0; i < figures.length; i++)
// {
//     console.log("Зеленый круг отличается свойствами от " + figures[i].name + ":\n");
//     for(let prop of propsOfGreenCyrcle)
//     {
//         if(Object.keys(figures[i]).indexOf(prop) === -1)
//         {
//             console.log(prop);
//         }
//     }
//     console.log("\n");
// }

// // свойства, которые описывают фигуру «треугольник с тремя линиями»

// let propsOfTriangleWithThreeLines : string[] = Object.keys(triangle2);

// propsOfTriangleWithThreeLines.forEach((prop) => {
//     console.log(prop);
// });

// // есть ли у фигуры «маленький квадрат» собственное свойство, которое определяет цвет фигуры.

// let propsOfSquare2 : string[] = Object.keys(square2);

// propsOfSquare2.forEach(prop => {
//     if(prop === "color")
//     {
//         console.log("Есть");
//     }
// });