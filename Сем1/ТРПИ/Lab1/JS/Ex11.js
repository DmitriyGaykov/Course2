(function doTesting() {
    let ExamInfo = {
        Russian: false,
        Math: false,
        English: false,
    }

    let RussiaDone = RussianTest();
    let MathDone = MathTest();
    let EnglishDone = EnglishTest();

    ExamInfo.English = EnglishDone;
    ExamInfo.Math = MathDone;
    ExamInfo.Russian = RussiaDone;

    let isPassed = true;
    switch (!isPassed) {
        case Boolean(
            Number(RussiaDone) +
            Number(MathDone) +
            Number(EnglishDone)
        ):
            alert("Вы не сдали экзамены и исключены");
            break;

        case RussiaDone:
            alert("Вы не сдали экзамен по русскому языку");
            break;

        case MathDone:
            alert("Вы не сдали экзамен по математике");
            break;

        case EnglishDone:
            alert("Вы не сдали экзамен по английскому языку");
            break;

        default:
            alert("Вы сдали все экзамены и переведены на следующий курс");
            break;
    }
})();

function RussianTest() {
    let Question = "Что такое 'делать'?";
    let Answer = "глагол";
    let EnteredAnswer = prompt(Question);

    if (EnteredAnswer.toLowerCase() === Answer.toLowerCase()) {
        return true;
    }
    return false;
}

function MathTest() {
    let Question = "Сколько будет 2 * 3?";
    let Answer = "6";
    let EnteredAnswer = prompt(Question);

    if (EnteredAnswer === Answer) {
        return true;
    }
    return false;
}

function EnglishTest() {
    let Question = "How translate the word 'water'?";
    let Answer = "Вода";
    let EnteredAnswer = prompt(Question);

    if (EnteredAnswer.toLowerCase() === Answer.toLowerCase()) {
        return true;
    }
    return false;
}