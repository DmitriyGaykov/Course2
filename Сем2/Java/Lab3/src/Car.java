import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.logging.Logger;

public class Car
        implements Serializable, Comparable<Car>, IJson<Car>
{
    private static final Logger logger = Logger.getLogger(Car.class.getName());
    protected String name;
    protected int speed;
    protected int fillConsumption;
    protected CarType carType;
    public Car(String name,
               int speed,
               int fillConsumption,
               CarType carType) {
        this.name = name;
        this.speed = speed;
        this.fillConsumption = fillConsumption;
        this.carType = carType;

        logger.info("Car created: " + this.toString());
    }

    public Car()
    {
        this.name = "";
        this.speed = 0;
        this.fillConsumption = 0;
        this.carType = CarType.PASSENGER;
    }

    public String getName() {
        return name;
    }
    public int getSpeed() {
        return speed;
    }
    public int getFillConsumption() {
        return fillConsumption;
    }
    public CarType getCarType()
    {
        return this.carType;
    }
    public void setName(String name) {
        this.name = name;
    }

    public void setSpeed(int speed) {
        this.speed = speed;
    }

    public void setFillConsumption(int fillConsumption) {
        this.fillConsumption = fillConsumption;
    }

    @Override
    public String toString() {
        return "Car{" + "name=" + name + ", speed=" + speed + ", fillConsumption=" + fillConsumption + '}';
    }

    @Override
    public int compareTo(Car o) {
        return this.getName().compareTo(o.getName());
    }

    @Override
    public void toJson() throws IOException {
        ObjectMapper objectMapper = new ObjectMapper();
        var json = objectMapper.writeValueAsString(this);

        var writer = new FileWriter("car.json");
        writer.write(json, 0, json.length());
        writer.close();
    }

    @Override
    public Car fromJson()  {
        Car car = null;
        Object obj;
        try {
            var file = new File("car.json");
            ObjectMapper ow = new ObjectMapper();
            obj = ow.readValue(Files.readString(Path.of(file.getPath())), Car.class);
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return null;
        }

        if(obj instanceof Car)
        {
            car = (Car) obj;
        }

        return car;
    }

    enum CarType {
        PASSENGER,
        TRUCK,
        BUS,
        SUV,
        SUPERCAR
    }
}
