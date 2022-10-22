let countLettersInEn: number = 26;
let countNumbers: number = 10;

let countPositionForLetters: number = 5;
let countPositionForNumbers: number = 3;

let propability: number = Math.pow(countLettersInEn, countPositionForLetters) * Math.pow(countNumbers, countPositionForNumbers);

let averageTime: number = 3; // seconds

let seconds: number = propability * averageTime;

let minutes: number = seconds / 60;
seconds = seconds % 60;

let hours: number = minutes / 60;
minutes = minutes % 60;

let days: number = hours / 24;
hours = hours % 24;

let years: number = days / 365;
days = days % 365;

alert
( `
    Years: ${Math.floor(years)},
    days: ${Math.floor(days)},
    hours: ${Math.floor(hours)},
    minutes: ${Math.floor(minutes)},
    seconds: ${Math.floor(seconds)}
` );
