let tuple;
tuple = [1, "hello"];
const setPerson = (name, age) => {
    if (name && age) {
        return { name, age };
    }
    else {
        return { name: undefined, age: undefined };
    }
};
const doInfinitely = () => {
    while (true) {
        console.log("I am doing something");
    }
};
const company = {
    name: "Microsoft"
};
class DateTime {
    dd;
    mm;
    yyyy;
    /**
     *
     */
    constructor(dd, mm, yyyy) {
        this.dd = dd;
        this.mm = mm;
        this.yyyy = yyyy;
    }
}
const today = new DateTime(1, 1, 2020);
console.log(today.yyyy);
const questions = {
    question1: "What is your name?",
    question2: "What is your age?"
};
//////////////////////////////////////////////////////
var Color;
(function (Color) {
    Color["Red"] = "Red";
    Color["Green"] = "Green";
    Color["Blue"] = "Blue";
})(Color || (Color = {}));
const color = Color.Red;
console.log(color);
//////////////////////////////////////////////////////
class Animal {
    move() {
        console.log("roaming the earth...");
    }
}
class Cow extends Animal {
    makeSound() {
        console.log("Moo");
    }
    move() {
        console.log("Walking...");
    }
}
const cow = new Cow();
cow.makeSound();
if (cow instanceof Cow) {
    cow.move();
}
const id = 1;
function checkId(id) {
    if (typeof id === "string") {
        if (isFinite(parseInt(id))) {
            return true;
        }
        return false;
    }
    return true;
}
