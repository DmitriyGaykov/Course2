public class Ferrari extends Car
                     implements ITaxi
{
    private int price;
    public Ferrari(int price) {
        super("Ferrari", 200, 8, CarType.SUPERCAR);
        this.price = price;
    }
    @Override
    public void setPrice(int value) {
        price = value;
    }
    @Override
    public int getPrice() {
        return price;
    }
}
