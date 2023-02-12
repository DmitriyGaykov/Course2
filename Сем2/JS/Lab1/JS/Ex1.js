const createPhoneNumber = (numbers) => {
    if (numbers.length !== 10) {
        return null;
    }
    let phoneNumber = "(";
    for (let i = 0; i < numbers.length; i++) {
        if (i === 3) {
            phoneNumber += ") ";
        }
        else if (i === 6) {
            phoneNumber += "-";
        }
        phoneNumber += numbers[i];
    }
    return phoneNumber;
};
let test = createPhoneNumber([1, 2, 3, 4, 5, 6, 7, 8, 9, 0]);
console.log(`
    Exesize 1
    Result: ${test ?? "No result"}
    `);
