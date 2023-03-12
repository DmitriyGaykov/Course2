const array = [
    { id: 1, name: "Vasya", group: 4 },
    { id: 2, name: "Ivan", group: 2 },
    { id: 3, name: "Dima", group: 5 }
];
const car1 = {};
car1.manufacturer = "Что-то";
car1.model = "Шото";
const car2 = {};
car2.manufacturer = "Шото";
car2.model = "Жигуль";
const arrayCars = [
    {
        cars: [car1, car2]
    }
];
const mark1 = {
    subject: "BGTU",
    mark: 10,
    done: true
};
const student1 = {
    id: 1,
    name: "Shiman",
    group: 12,
    marks: [mark1]
};
const group = {
    students: [student1],
    mark: 2,
    group: 12,
    studentsFilter(group) {
        const students = this.students;
        return students.filter(el => el.group === group);
    },
    marksFilter(mark) {
        const students = this.students;
        return students.filter(el => {
            const marks = el.marks;
            let sum = 0;
            for (let i = 0; i < marks.length; i++) {
                sum = marks[i].mark;
            }
            let avr = sum / marks.length;
            return Math.round(avr) == Math.round(mark);
        });
    },
    deleteStudent(id) {
        const students = this.students;
        this.students = students.map(el => el.id !== id);
    }
};
