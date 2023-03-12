package by.ex1.Door;

import by.ex1.Person.Student;

public class Door implements Runnable {
    private Student student;
    private final int number;
    private static final Object obj = new Object();
    public boolean exit(Student student) {
        synchronized (obj) {
            if(this.getStudent() != null) {
                return false;
            } else {
                this.student = student;
            }
            var thread = new Thread(this);
            thread.start();
        }

        return true;
    }

    public Door(int number) {
        student = null;
        this.number = number;
    }

    public Student getStudent() {
        return student;
    }

    public int getNumber() {
        return number;
    }

    @Override
    public void run() {
        synchronized (obj) {
            System.out.println("На дверь под номером " + this.getNumber() + " вошел " + student.toString());

            try {
                Thread.sleep(1500);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }

            System.out.println(this.getStudent() + " вышел из двери под номером " + this.getNumber());
            this.student = null;
        }
    }
}
