import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import java.io.File;
import java.io.IOException;
import java.util.logging.Logger;
public class Main {
    private static final Logger logger = Logger.getLogger(Main.class.getName());
    public static void main(String[] args) throws IOException {
        try
        {
            logger.info("Program started");

            Car car = null;
            File file = new File("car.xml");

            var handler = new SaxParserHandler();
            var factory = SAXParserFactory.newInstance();
            SAXParser parser = null;

            parser = factory.newSAXParser();

            parser.parse(file, handler);

            car = handler.getCar();
            System.out.println(car.toString());

            // JSON:
            car.setName("Ferrari McLarren");
            car.toJson();
            var carJson = car.fromJson();
            System.out.println(carJson);
//
//            ITaxi toyota = new Toyota(1000);
//            ITaxi ferrari = new Ferrari(2000);
//            ITaxi ferrari2 = new Ferrari(2000);
//            ITaxi rangeRover = new RangeRover(1500);
//            ITaxi miniCupper = new MiniCupper(1200);
//            ITaxi camry = new Camry3_5(1800);
//
//            Manager manager = new Manager("Manager", 30);
//            TaxiPark taxiPark = new TaxiPark(manager);
//
//            taxiPark.addTaxi(ferrari2, toyota, rangeRover, ferrari, camry, miniCupper);
//
//            var price = manager.priceOfAllCars();
//            System.out.println("\nPrice of all cars: " + price + "\n");
//
//            manager.sortCarsByFillConsumption();
//            taxiPark.printCars();
//
//            System.out.println("\nFind car by speed:" + manager.findCarBySpeed(60, 100));
//
//            Point p1 = new Point(1, 2);
//            Point p2 = new Point(3, 4);
//
//            System.out.println(p1);
//            System.out.println(p2);
        } catch (Exception e) {
            System.out.println(e.getMessage());
            logger.warning(e.getMessage());
        }
        logger.info("Program finished");
    }


    static class Point
    {
        private static final Logger logger = Logger.getLogger(Point.class.getName());
        public int a;
        public int b;
        public Point(int a, int b)
        {
            this.a = a;
            this.b = b;

            logger.info("Point created: " + this.toString());
        }

        @Override
        public String toString()
        {
            return "a: " + a + " b: " + b;
        }
    }
}