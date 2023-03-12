package by.ex1.Person;

import java.util.*;

public class Employer extends Person
                      implements Runnable {
    private static final Object obj = new Object();
    private final PriorityQueue<Person> queue = new PriorityQueue<Person>();
    private final Thread thread = new Thread(this);
    private int count = this.MAX_COUNT;
    public final int MAX_COUNT = 2;
    private Person orderer;

    public Person getOrderer() {
        synchronized (obj) {
            return orderer;
        }
    }

    private void setOrderer(Person orderer) {
        synchronized (obj) {
            if (orderer == null) {
                System.out.println("Работник " + this + " выполнил заказ от " + this.orderer + ". Статус: " + (this.orderer.isPensioner() ? "Пенсионер" : "Не пенсионер"));
                System.out.println("Свободных лыж: " + this.count);

                ((Client)this.orderer).setDoneOrder(true);
            } else {
                System.out.println("Работник " + this + " взял заказ от " + orderer);
            }

            this.orderer = orderer;
        }
    }

    public Employer(String name) {
        super(name);

    }
    public Employer(String name, boolean isPensioner) {
        super(name, isPensioner);
    }

    public void doOrder(Person who) {
        synchronized(obj) {
            if(!queue.contains(who)) {
                queue.add(who);

            }
            if(!this.thread.isAlive()) {
                this.thread.setPriority(Thread.MAX_PRIORITY);
                this.thread.start();
            }
        }
    }


    @Override
    public void run() {
        System.out.println("Start");

        while(!queue.isEmpty()) {
            System.out.print("");
            if(this.count > 0) {
                Client client = (Client) queue.poll();
                this.setOrderer(client);

                this.count--;

                try {
                    Thread.sleep(2000);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }

                client.setDoneOrder(true);
                this.setOrderer(null);
            }
        }

        System.out.println("End");
    }

    public void cancelOrder(Person person) {
        synchronized (obj) {
            queue.remove(person);
        }
    }

    public void back() {
        synchronized (obj) {
            this.count++;
            System.out.println("Лыжи вернули. Теперь их: " + this.count);
        }
    }
}
