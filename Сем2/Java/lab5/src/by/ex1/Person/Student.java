package by.ex1.Person;

import by.ex1.Door.Door;

import java.time.Duration;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class Student extends Person
                     implements Runnable {
    private List<Door> doors;
    private final static int TIME = 3;
    public Student(String name) {
        super(name);
        doors = new ArrayList<>();
    }

    @Override
    public String toString() {
        return "Студент: " + this.getName();
    }

    public void exit(List<Door> doors) {
        this.doors = doors;
        var thread = new Thread(this);
        thread.start();
    }

    @Override
    public void run() {
        LocalDateTime start = LocalDateTime.now();
        LocalDateTime end;
        Duration dur;

        byte i = 0;

        do {
            end = LocalDateTime.now();
            dur = Duration.between(start, end);

            if(dur.getSeconds() >= TIME && doors.get(i).getStudent() != this) {
                start = LocalDateTime.now();
                i = (byte)(i + 1 == doors.size() ? 0
                                                 : i + 1);
            }

        } while(!doors.get(i).exit(this));
    }
}
