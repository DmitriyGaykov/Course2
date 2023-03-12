package by.ex1.Person;

import java.time.Duration;
import java.time.LocalDateTime;

public class Client extends Person
                    implements Runnable {
    private boolean doneOrder = false;
    private static final Object obj = new Object();
    public static int TIME = 6;
    private Employer employer;
    public Client(String name) {
        super(name);
        this.doneOrder = false;
    }

    public Client(String name, boolean isPensioner) {
        super(name, isPensioner);
    }

    public void startDoOrder(Employer employer) {
        this.employer = employer;

        Thread thread = new Thread(this);
        thread.setPriority(Thread.MIN_PRIORITY);
        thread.start();
    }

    @Override
    public void run() {
        LocalDateTime start = LocalDateTime.now();
        LocalDateTime end;
        Duration dur;

        employer.doOrder(this);

        while(!this.doneOrder) {
            end = LocalDateTime.now();
            dur = Duration.between(start, end);

            if(dur.getSeconds() >= TIME && !this.isDoneOrder()) {
                System.out.println("Клиент " + this + " отказывается от заказа. Ожидал: " + dur.getSeconds() + " секунд.");
                this.employer.cancelOrder(this);
                return;
            }
        }

        try {
            Thread.sleep(3000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }

        this.employer.back();
    }

    public boolean isDoneOrder() {
        synchronized (obj) {
            return doneOrder;
        }
    }

    public void setDoneOrder(boolean doneOrder) {
        synchronized (obj) {
            this.doneOrder = doneOrder;
        }
    }
}
