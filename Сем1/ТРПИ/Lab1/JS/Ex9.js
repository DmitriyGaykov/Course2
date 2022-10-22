let Quetion = "Как зовут вашу кошку?";
let ExpectedAnswer = "Мурзик";
let EnteredAnswer = prompt(Quetion);

if (EnteredAnswer === ExpectedAnswer) {
    alert("Молодец!");
} else {
    alert("Неправильно!");
}