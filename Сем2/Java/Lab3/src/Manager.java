import java.util.stream.Collectors;

public class Manager extends Person {
    private TaxiPark park;
    public Manager(String name, int age) {
        super(name, age);
    }
    public void setPark(TaxiPark park) {
        this.park = park;
    }

    public int priceOfAllCars()
    {
        int price = 0;

        for (ITaxi taxi : park.getPark())
        {
            price += taxi.getPrice();
        }

        return price;
    }

    public void sortCarsByFillConsumption()
    {
        var cars = park.getPark();
        cars = cars.stream().sorted().collect(Collectors.toList());
    }

    public Car findCarBySpeed(int speedStart, int speedEnd) throws Exception {
        Car car = (Car)park.getPark().stream()
                           .filter(c -> ((Car)c).getSpeed() >= speedStart && ((Car)c).getSpeed() <= speedEnd)
                           .findFirst()
                           .orElse(null);

        if(car == null)
        {
            throw new Exception("Car not found");
        }

        return car;
    }
}
