let paramA;
let paramB;
let paramC;
let isAgree = false;

paramA = prompt("Введите первый параметр: ");
paramB = prompt("Введите второй параметр: ");

isAgree = confirm("Вы хотите ввести третий параметр?");

if (isAgree) {
    paramC = prompt("Введите третий параметр: ");
    alert(toString(paramA, paramB, paramC));
} else {
    alert(toString(paramA, paramB));
}

alert(toString())

function toString(paramA = 2, paramB, paramC = "default") {
    return `${paramA} ${paramB} ${paramC}`;
}