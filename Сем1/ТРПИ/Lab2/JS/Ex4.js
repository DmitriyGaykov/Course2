let countLettersInEn = 26;
let countNumbers = 10;
let countPositionForLetters = 5;
let countPositionForNumbers = 3;
let propability = Math.pow(countLettersInEn, countPositionForLetters) * Math.pow(countNumbers, countPositionForNumbers);
let averageTime = 3; // seconds
let seconds = propability * averageTime;
let minutes = seconds / 60;
seconds = seconds % 60;
let hours = minutes / 60;
minutes = minutes % 60;
let days = hours / 24;
hours = hours % 24;
let years = days / 365;
days = days % 365;
alert(`
    Years: ${Math.floor(years)},\n
    days: ${Math.floor(days)},\n
    hours: ${Math.floor(hours)},\n
    minutes: ${Math.floor(minutes)},\n
    seconds: ${Math.floor(seconds)}
`);
