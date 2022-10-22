// 7.	Пользователь управляет движением объекта, вводя в модальное окно  команды left, right, up, down. 
// Объект совершает 10 шагов в заданном направлении (т.е. высчитываются и выводятся в консоль соответствующие 
//     координаты) и запрашивает новую команду. Разработайте генератор, который возвращает координаты объекта,
//      согласно заданному направлению движения. 
function* move() {
    var _a;
    let x = 0;
    let y = 0;
    let direction;
    for (let i = 0; i < 10; i++) {
        direction = (_a = prompt("Enter direction")) !== null && _a !== void 0 ? _a : "default";
        switch (direction.trim().toLowerCase()) {
            case "left":
                x--;
                break;
            case "right":
                x++;
                break;
            case "up":
                y++;
                break;
            case "down":
                y--;
                break;
        }
        yield [x, y];
    }
}
let generator = move();
for (let i = 0; i < 10; i++) {
    console.log(generator.next().value);
}
