var _a;
let trueAnswer = "Алфавит";
let enteredAnswer = (_a = prompt("Исправьте ошибку в слове 'Алфовит'?")) !== null && _a !== void 0 ? _a : "";
let positionsOfMist = [];
enteredAnswer = enteredAnswer.toLowerCase().trim();
trueAnswer = trueAnswer.toLowerCase().trim();
if (enteredAnswer === trueAnswer) {
    alert("Вы правы!");
}
else {
    for (let i = 0, j = 0; i < enteredAnswer.length; i++, j++) {
        if (enteredAnswer[i] !== trueAnswer[j]) {
            positionsOfMist.push(i + 1);
            continue;
        }
    }
}
alert(`Позиции ошибок: ${positionsOfMist.join(", ")}`);
