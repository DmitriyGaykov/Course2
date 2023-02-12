public class RangeRover extends Car
                        implements ITaxi
{
    private int price;
    public RangeRover(int price) {
        super("Range Rover", 150, 6, CarType.SUV);
        this.price = price;
    }
    public int getPrice() {
        return price;
    }
    public void setPrice(int value) {
        price = value;
    }
}
