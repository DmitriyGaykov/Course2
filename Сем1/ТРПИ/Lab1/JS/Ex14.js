let Nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

Nums = Nums.map(Num => {
    if (Num % 2 === 0) {
        Num += 2;
    } else {
        Num += "мм";
    }
    return Num;
});

console.log(Nums);