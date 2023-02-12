let tuple : [number, string];
tuple = [1, "hello"];

//////////////////////////////////////////////////////

interface IPerson {
    readonly name: string;
    age: number;
}

interface INoPerson extends IPerson {
    readonly name: undefined;
    readonly age: undefined;
}

const setPerson = (name?: string, age?: number) : IPerson | INoPerson => {
    if(name && age) {
        return {name, age};
    }
    else
    {       
        return {name: undefined, age: undefined};
    }
}

const doInfinitely = () : never =>
{
    while(true) {
        console.log("I am doing something");
    }
}

//////////////////////////////////////////////////////

interface IVeryLongCompanyName {
    name: string;
}

type Company = IVeryLongCompanyName;

const company: Company = {
    name: "Microsoft"
}

type Day = number;
type Month = number;
type Year = number;

class DateTime
{
    /**
     *
     */
    constructor(
        public dd : Day,
        public mm : Month,
        public yyyy : Year
        ) {
        
        
    }
}

const today = new DateTime(1, 1, 2020);
console.log(today.yyyy);

//////////////////////////////////////////////////////

interface IQuestions {
    [key: string] : string;
}

const questions: IQuestions = {
    question1 : "What is your name?",
    question2 : "What is your age?"
}

//////////////////////////////////////////////////////

enum Color {
    Red = "Red",
    Green = "Green",
    Blue = "Blue"
}

const color : Color = Color.Red;
console.log(color);

//////////////////////////////////////////////////////

abstract class Animal {
    abstract makeSound(): void;
    public move(): void {
        console.log("roaming the earth...");
    }
}

class Cow extends Animal {
    makeSound(): void {
        console.log("Moo");
    }

    public move(): void {
        console.log("Walking...");
    }
}

const cow : Animal = new Cow();
cow.makeSound();

if(cow instanceof Animal)
{
    cow.move();
}

//////////////////////////////////////////////////////

type ID = string | number;

const id : ID = 1;

function checkId(id: ID) : boolean {
    if(typeof id === "string")
    {
        if(isFinite(parseInt(id)))
        {
            return true;
        }

        return false;
    }

    return true;
}

//////////////////////////////////////////////////////

type User = {
    id : number,
    name : string
    password : string
    img: string
}

type UserWithoutPassword = Omit<User, "password">;
type UserFillSite = Exclude<keyof User, "password" | "id">;
type UserWithoutPasswordAndImg = Pick<User, UserFillSite>;