import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "passengerCar")
@XmlAccessorType(XmlAccessType.FIELD)
public class PassengerCar extends Car {
    public PassengerCar(String name, int speed, int fillConsumption) {
        super(name, speed, fillConsumption, CarType.PASSENGER);
    }

    public PassengerCar()
    {
        super();
    }
}
