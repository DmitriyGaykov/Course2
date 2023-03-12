public class RangeRover extends SUVCar
                        implements ITaxi
{
    private int price;
    public RangeRover(int price) {
        super("Range Rover", 150, 6);
        this.price = price;
    }
    public int getPrice() {
        return price;
    }
    public void setPrice(int value) {
        price = value;
    }
}
