import java.util.logging.Logger;

public abstract class Car
{
    private static final Logger logger = Logger.getLogger(Car.class.getName());
    protected String name;
    protected int speed;
    protected int fillConsumption;
    protected CarType carType;
    public Car(String name, int speed, int fillConsumption, CarType carType) {
        this.name = name;
        this.speed = speed;
        this.fillConsumption = fillConsumption;
        this.carType = carType;

        logger.info("Car created: " + this.toString());
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

    enum CarType {
        PASSENGER,
        TRUCK,
        BUS,
        SUV,
        SUPERCAR
    }
}
