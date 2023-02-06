class Challenge {
    static solution(number) {
        if (number < 0) {
            return 0;
        }
        let sum = 0;
        for (let i = 1; i <= number; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum += i;
            }
        }
        return sum;
    }
}
let result = Challenge.solution(10);
console.log(`
    Exesize 2
    Result: ${result}
    `);
