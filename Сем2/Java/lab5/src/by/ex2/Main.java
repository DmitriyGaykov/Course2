package by.ex2;

import by.ex2.Parking.Parking;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Main {
    public static void main(String[] args) {
        Parking parking1 = new Parking(10, 1);
        Parking parking2 = new Parking(5, 2);

        List<Parking> parks = new ArrayList<>();
        parks.add(parking1);
        parks.add(parking2);

        List<Car> cars = new ArrayList<>();

        Car car1 = new Car("Ferrari");
        Car car2 = new Car("Porsche");
        Car car3 = new Car("Lamborghini");
        Car car4 = new Car("Bugatti");
        Car car5 = new Car("McLaren");
        Car car6 = new Car("Aston Martin");
        Car car7 = new Car("Maserati");
        Car car8 = new Car("Bentley");
        Car car9 = new Car("Rolls-Royce");
        Car car10 = new Car("Mercedes-Benz");
        Car car11 = new Car("BMW");
        Car car12 = new Car("Audi");
        Car car13 = new Car("Jaguar");
        Car car14 = new Car("Lexus");
        Car car15 = new Car("Cadillac");
        Car car16 = new Car("Lincoln");
        Car car17 = new Car("Chevrolet");
        Car car18 = new Car("Dodge");
        Car car19 = new Car("Ford");
        Car car20 = new Car("GMC");
        Car car21 = new Car("Jeep");
        Car car22 = new Car("Ram");
        Car car23 = new Car("Toyota");
        Car car24 = new Car("Honda");
        Car car25 = new Car("Nissan");
        Car car26 = new Car("Subaru");
        Car car27 = new Car("Mitsubishi");
        Car car28 = new Car("Kia");
        Car car29 = new Car("Hyundai");
        Car car30 = new Car("Mazda");

        cars.add(car1);
        cars.add(car2);
        cars.add(car3);
        cars.add(car4);
        cars.add(car5);
        cars.add(car6);
        cars.add(car7);
        cars.add(car8);
        cars.add(car9);
        cars.add(car10);
        cars.add(car11);
        cars.add(car12);
        cars.add(car13);
        cars.add(car14);
        cars.add(car15);
        cars.add(car16);
        cars.add(car17);
        cars.add(car18);
        cars.add(car19);
        cars.add(car20);
        cars.add(car21);
        cars.add(car22);
        cars.add(car23);
        cars.add(car24);
        cars.add(car25);
        cars.add(car26);
        cars.add(car27);
        cars.add(car28);
        cars.add(car29);
        cars.add(car30);

        ExecutorService executorService = Executors.newFixedThreadPool(30);

        for (Car car : cars) {
            executorService.submit(new Thread(() -> {
                boolean answer;

                for(int i = 0; i < parks.size(); i++) {
                    try {
                        answer = car.parkCar(parks.get(i));
                    } catch (InterruptedException e) {
                        throw new RuntimeException(e);
                    }

                    if(answer) {
                        break;
                    } else if (i + 1 == parks.size()) {
                        i = -1;
                    }
                }

            }));
        }
    }
}
