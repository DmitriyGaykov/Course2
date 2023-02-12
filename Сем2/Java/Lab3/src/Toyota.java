public class Toyota extends Car
                    implements ITaxi
{
    private int price;
    public Toyota(int price) {
        super("Toyota", 100, 4, CarType.PASSENGER);
        this.price = price;
    }
    public int getPrice() {
        return price;
    }
    public void setPrice(int value) {
        price = value;
    }
}
