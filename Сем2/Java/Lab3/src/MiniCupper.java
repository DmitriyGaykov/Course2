public class MiniCupper extends Car
                        implements ITaxi
{
    private int price;
    public MiniCupper(int price) {
        super("Minicupper", 70, 2, CarType.PASSENGER);
        this.price = price;
    }
    public int getPrice() {
        return price;
    }
    public void setPrice(int value) {
        price = value;
    }
}
