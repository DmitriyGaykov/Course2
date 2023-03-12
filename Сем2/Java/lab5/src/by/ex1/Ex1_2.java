package by.ex1;

import by.ex1.Door.Door;
import by.ex1.Person.Student;

import java.util.ArrayList;
import java.util.List;

public class Ex1_2 {
    public static void main(String[] args) {
        List<Student> students = new ArrayList<>();
        students.add(new Student("Dima"));
        students.add(new Student("Andrey"));
        students.add(new Student("Olga"));
        students.add(new Student("John"));
        students.add(new Student("Kate"));

        List<Door> doors = new ArrayList<>();
        doors.add(new Door(1));
        doors.add(new Door(2));

        students.forEach(el -> el.exit(doors));
    }
}
