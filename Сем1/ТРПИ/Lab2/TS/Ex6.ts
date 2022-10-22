let trueAnswer: string = "Алфавит";
let enteredAnswer: string = prompt("Исправьте ошибку в слове 'Алфовит'?") ?? "";
let positionsOfMist: number[] = [];

enteredAnswer = enteredAnswer.toLowerCase().trim();
trueAnswer = trueAnswer.toLowerCase().trim();

if (enteredAnswer === trueAnswer) {
    alert("Вы правы!");
} else {
    for(let i : number = 0 , j : number = 0; i < enteredAnswer.length; i++, j++)
    {
        if(enteredAnswer[i] !== trueAnswer[j])
        {
            positionsOfMist.push(i + 1);
            continue;
        }
    }
}

alert(`Позиции ошибок: ${positionsOfMist.join(", ")}`);