interface Student
{
    id : number;
    name : string;
    group : number;
}

const array : Student[] =
[
    {id: 1, name: "Vasya", group: 4},
    {id: 2, name: "Ivan", group: 2},
    {id: 3, name: "Dima", group: 5}
];

///////////////////////////////////////////////////

interface CarsType
{
    manufacturer?: string;
    model?: string;
}

interface ArrayCarsType
{
    cars?: CarsType[]
}

const car1 : CarsType = {};
car1.manufacturer = "Что-то";
car1.model = "Шото";

const car2 : CarsType = {};
car2.manufacturer = "Шото";
car2.model = "Жигуль";

const arrayCars : Array<ArrayCarsType> = [
{
    cars: [car1, car2]
}
];

///////////////////////////////////////////////////
type MarkFilterType = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10;
type GroupFilterType = MarkFilterType | 11 | 12;

type DoneType = Boolean;

type MarkType =
{
    subject : string,
    mark : MarkFilterType,
    done : DoneType
}

type StudentType = 
{
    id: number,
    name: string,
    group: GroupFilterType,
    marks: MarkType[]
}

type GroupType = 
{
    students: StudentType[],
    studentsFilter : (group : number) => StudentType[],
    marksFilter : (mark: number) => StudentType[],
    deleteStudent: (id: number) => void,
    mark: MarkFilterType,
    group: GroupFilterType
}

const mark1 : MarkType = {
    subject: "BGTU",
    mark: 10,
    done: true
}

const student1 : StudentType =
{
    id: 1,
    name: "Shiman",
    group: 12,
    marks: [mark1]
}

const group : GroupType = 
{
    students: [student1],
    mark: 2,
    group: 12,

    studentsFilter(group: number)
    {
        const students = this.students as StudentType[];
        return students.filter(el => el.group === group);
    },

    marksFilter(mark: number)
    {
        const students = this.students as StudentType[];
        return students.filter(el => 
            {
                const marks = el.marks as MarkType[];
                let sum = 0;

                for(let i = 0; i < marks.length; i++)
                {
                    sum = marks[i].mark;
                }


                let avr = sum / marks.length;

                return Math.round(avr) == Math.round(mark);
            })
    },

    deleteStudent(id: number) 
    {
        const students = this.students as StudentType[];
        this.students = students.map(el => el.id !== id);
    }
}