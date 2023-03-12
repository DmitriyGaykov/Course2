public class Ferrari extends SuperCar
                     implements ITaxi
{
    private int price;
    public Ferrari(int price) {
        super("Ferrari", 200, 8);
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
