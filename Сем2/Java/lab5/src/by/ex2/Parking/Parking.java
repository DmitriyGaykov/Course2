package by.ex2.Parking;

import by.ex2.Car;

import java.util.concurrent.ConcurrentLinkedDeque;
import java.util.concurrent.Semaphore;

public class Parking {
    private final int max_count;
    private final int number;
    private final Semaphore semaphore = new Semaphore(3);
    private int count;
    private final ConcurrentLinkedDeque<Car> list = new ConcurrentLinkedDeque<>();
    public Parking(int number) {
        this(10, number);
        this.count = 0;
    }

    public Parking(int max_count, int number) {
        this.max_count = max_count;
        this.number = number;
        this.count = 0;
    }

    public int getCount() {
        return count;
    }

    public int getMaxCount() {
        return max_count;
    }

    public void setCount(int count) throws InterruptedException {
        semaphore.acquire();
        this.count = count;
        semaphore.release();
    }

    public boolean addCar(Car car) throws InterruptedException {
        semaphore.acquire(3);

        if(count < max_count) {
            list.add(car);
            count = list.size();

            System.out.println(car + " припаркован на " + this);
            semaphore.release(3);
            return true;
        } else {
            System.out.println("На " + this + " мест нет!");
        }

        semaphore.release(3);
        return false;
    }

    public void takeCar(Car car) throws InterruptedException {
        semaphore.acquire(3);

        if(list.contains(car)) {
            list.remove(car);
            count = list.size();
            System.out.println(this + ". " + car + " забрана");
        } else {
            System.out.println("На " + this + " не стоит " + car);
        }

        semaphore.release(3);
    }

    @Override
    public String toString() {
        return "Парковка №" + this.number;
    }
}
