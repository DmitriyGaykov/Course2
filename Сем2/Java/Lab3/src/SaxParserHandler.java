import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class SaxParserHandler extends DefaultHandler {
    private static final String CAR_TAG = "car";
    private static final String NAME_TAG = "name";
    private static final String SPEED_TAG = "speed";
    private static final String FILLCONS_TAG = "fillConsumption";
    private static final String CARTYPE_TAG = "carType";

    private Car car = null;
    private String name = null;
    private Integer fillCons = null;
    private Integer speed = null;
    private Car.CarType carType = null;

    private String currentTag = "";
    @Override
    public void startDocument() throws SAXException {
//        System.out.println("Start document");
    }

    @Override
    public void endDocument() throws SAXException {
//        System.out.println("End document");
    }

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
//        System.out.println("Start element " + qName);
        currentTag = qName;
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
//        System.out.println("End element " + qName);
        currentTag = "";
    }

    public Car getCar()
    {
        if(name == null || carType == null || speed == null || fillCons == null) {
            return null;
        }

        if(carType == Car.CarType.SUPERCAR) {
            car = new SuperCar(name, speed, fillCons);
        } else if(carType == Car.CarType.PASSENGER) {
            car = new PassengerCar(name, speed, fillCons);
        } else {
            car = new SUVCar(name, speed, fillCons);
        }

        return car;
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        var context = new String(ch, start, length);
        switch (currentTag){
            case NAME_TAG -> {
                name = context;
            }
            case FILLCONS_TAG -> {
                fillCons = Integer.valueOf(context);
            }
            case SPEED_TAG -> {
                speed = Integer.valueOf(context);
            }
            case CARTYPE_TAG -> {
                switch (context) {
                    case "SUPERCAR" -> {
                        carType = Car.CarType.SUPERCAR;
                    }
                    case "PASSENGER" -> {
                        carType = Car.CarType.PASSENGER;
                    }
                    case "SUV" -> {
                        carType = Car.CarType.SUV;
                    }
                }
            }
        }
    }
}
