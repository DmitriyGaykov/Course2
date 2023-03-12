public class MiniCupper extends PassengerCar
                        implements ITaxi
{
    private int price;
    public MiniCupper(int price) {
        super("Minicupper", 70, 2);
        this.price = price;
    }
    public int getPrice() {
        return price;
    }
    public void setPrice(int value) {
        price = value;
    }
}
