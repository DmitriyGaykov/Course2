let days: object[] = new Array(7);

let Monday: object = {
    name: "Понедельник",
    number: 1,
};

let Tuesday: object = {
    name: "Вторник",
    number: 2,
};

let Wednesday: object = {
    name: "Среда",
    number: 3,
};

let Thursday: object = {
    name: "Четверг",
    number: 4,
};

let Friday: object = {
    name: "Пятница",
    number: 5,
};

let Saturday: object = {
    name: "Суббота",
    number: 6,
};

let Sunday: object = {
    name: "Воскресенье",
    number: 7,
};

days[0] = Monday;
days[1] = Tuesday;
days[2] = Wednesday;
days[3] = Thursday;
days[4] = Friday;
days[5] = Saturday;
days[6] = Sunday;

let count : number = 0;
let oddDays: string = "";
let outDay : string;

do
{
    outDay = prompt("Введите день недели");
} while(!isFinite(Number(outDay)) || Number(outDay) < 1 || Number(outDay) > 7);

for(let day of days)
{
    if(day["number"] % 2 !== 0)
    {
        oddDays += day["name"] + ",\n";
        count++;
    }
}

alert(oddDays +"\n" + "Количество нечетных дней: " + count);