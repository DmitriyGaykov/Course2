console.log(isMore("Привет", "привет")); // = false
console.log(isMore("привет", "Привет")); // = true

console.log(isMore("Привет", "Пока")); // = true
console.log(isMore("Пока", "Привет")); // = false

console.log(isMore(45, "53")); // = false

console.log(isMore(false, 3)); // = false

console.log(isMore(true, "3")); // = false

console.log(isMore(3, "5мм")); // false

console.log(isMore(null, undefined)); // false
console.log(isMore(undefined, null)); // false

function isMore(El1, El2) {
    return El1 > El2;
}