package by.ex2;

import by.ex2.Parking.Parking;

import java.time.Duration;
import java.time.LocalDateTime;

public class Car {
    private String name;
    private Parking park;
    public int TIME = 4;

    public Car(String name) {
        this.name = name;
        this.park = null;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Parking getPark() {
        return park;
    }

    public boolean parkCar(Parking park) throws InterruptedException {
        return startPark(park);
    }

    @Override
    public String toString() {
        return "Автомобиль \"" + this.getName() + "\"";
    }

    private boolean startPark(Parking park) throws InterruptedException {
        LocalDateTime start = LocalDateTime.now();
        LocalDateTime end;
        Duration dur;

        if(park.getCount() == park.getMaxCount()) {
            do {
                end = LocalDateTime.now();
                dur = Duration.between(start, end);

                if(dur.getSeconds() >= TIME) {
                    return false;
                }
            } while(park.getCount() == park.getMaxCount());
        }

        if(!park.addCar(this))
        {
            return false;
        }
        this.park = park;

        Thread thread = new Thread(() -> {
            try {
                takeCar();
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
        });

        thread.start();

        return true;
    }

    private void takeCar() throws InterruptedException {
        this.park.takeCar(this);
        this.park = null;
    }
}
