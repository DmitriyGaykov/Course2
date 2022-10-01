// 7.	Пользователь управляет движением объекта, вводя в модальное окно  команды left, right, up, down. 
// Объект совершает 10 шагов в заданном направлении (т.е. высчитываются и выводятся в консоль соответствующие 
//     координаты) и запрашивает новую команду. Разработайте генератор, который возвращает координаты объекта,
//      согласно заданному направлению движения. 

function* move(): Generator<number[]> {
    let x: number = 0;
    let y: number = 0;
    let direction: string;
    for (let i = 0; i < 10; i++) {
        direction = prompt("Enter direction") ?? "default";
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

let generator: Generator<number[]> = move();
for (let i = 0; i < 10; i++) {
    console.log(generator.next().value);
}

