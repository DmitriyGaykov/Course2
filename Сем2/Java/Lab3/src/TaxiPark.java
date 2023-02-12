import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class TaxiPark {
    private final List<ITaxi> park = new ArrayList<ITaxi>();
    private final Manager manager;
    public TaxiPark(Manager manager) {
        this.manager = manager;
        manager.setPark(this);
    }
    public List<ITaxi> getPark() {
        return park;
    }
    public Manager getManager() {
        return manager;
    }

    public void addTaxi(ITaxi... taxis) {
        park.addAll(Arrays.asList(taxis));
    }

    public void printCars()
    {
        for (var car : park)
        {
            System.out.println(car);
        }
    }
}
