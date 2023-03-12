var array = [
    { id: 1, name: "Vasya", group: 4 },
    { id: 2, name: "Ivan", group: 2 },
    { id: 3, name: "Dima", group: 5 }
];
var car1 = {};
car1.manufacturer = "Что-то";
car1.model = "Шото";
var car2 = {};
car2.manufacturer = "Шото";
car2.model = "Жигуль";
var arrayCars = [
    {
        cars: [car1, car2]
    }
];
var mark1 = {
    subject: "BGTU",
    mark: 10,
    done: true
};
var student1 = {
    id: 1,
    name: "Shiman",
    group: 12,
    marks: [mark1]
};
var group = {
    students: [student1],
    mark: 2,
    group: 12,
    studentsFilter: function (group) {
        var students = this.students;
        return students.filter(function (el) { return el.group === group; });
    },
    marksFilter: function (mark) {
        var students = this.students;
        return students.filter(function (el) {
            var marks = el.marks;
            var sum = 0;
            for (var i = 0; i < marks.length; i++) {
                sum = marks[i].mark;
            }
            return Math.round(sum) == Math.round(mark);
        });
    },
    deleteStudent: function (id) {
        var students = this.students;
        this.students = students.map(function (el) { return el.id !== id; });
    },
    clone: function () {
        return {
            students: Object.assign({}, this.students),
            mark: Object.assign({}, this.mark),
            group: Object.assign({}, this.group),
            studentsFilter: new Function(this.studentsFilter),
            marksFilter: new Function(this.marksFilter),
            deleteStudent: new Function(this.deleteStudent),
            clone: new Function(this.clone)
        };
    }
};
console.log("hello world");
