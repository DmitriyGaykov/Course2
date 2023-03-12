public class Toyota extends PassengerCar
                    implements ITaxi
{
    private int price;
    public Toyota(int price) {
        super("Toyota", 100, 4);
        this.price = price;
    }
    public int getPrice() {
        return price;
    }
    public void setPrice(int value) {
        price = value;
    }
}
