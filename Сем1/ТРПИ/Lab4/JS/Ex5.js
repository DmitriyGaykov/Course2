function makeCounter() {
    let currentCount = 1;
    return function () {
        return currentCount++;
    };
}
let currentCount = 1;
function makeCounter1() {
    return function () {
        return currentCount++;
    };
}
alert(`
Name of first func is ${makeCounter.name}
Name of second func is ${makeCounter1.name}
`);
