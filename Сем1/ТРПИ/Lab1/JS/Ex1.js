Num = prompt("Введите число: ")
NumPower = prompt("Введите степень(от 1 и выше):")

if (NumPower < 0) {
    alert(`Степень ${NumPower} не поддерживается, введите целую степень, большую 0`)
} else {
    alert(pow(Num, NumPower)) // Math.pow(Num, NumPower)
}

function pow(Num, NPower) {
    let Result = 1;
    for (let i = 0; i < NPower; i++) {
        Result *= Num;
    }
    return Result;
}