package by;

import by.Weather.Population;
import by.Weather.Region;
import by.Weather.Weather;
import by.db.DB;
import com.mysql.cj.Query;

import java.sql.*;
import java.time.Duration;
import java.time.LocalDate;
import java.util.Date;
import java.util.Locale;

public class Main {
    public static void main(String[] args) throws ClassNotFoundException, SQLException {
        DB db = new DB();

        var weathers = db.getData(new Weather());
        var regions = db.getData(new Region());
        var populs = db.getData(new Population());

        weathers.forEach(System.out::println);

        System.out.println("\n\n---------------------------\n\n");

        regions.forEach(System.out::println);

        System.out.println("\n\n---------------------------\n\n");

        populs.forEach(System.out::println);

        var statement = db.getStatement();

        /*
          • Вывести сведения о погоде в заданном регионе.
          • Вывести даты, когда в заданном регионе шел снег и температура была
        ниже заданной отрицательной.
          • Вывести информацию о погоде за прошедшую неделю в регионах,
                жители которых общаются на заданном языке.
          • Вывести среднюю температуру за прошедшую неделю в регионах с
площадью больше заданной.
          */

        System.out.println("\nЗапрос первый: Вывести сведения о погоде в заданном регионе.");
        var query1 = db.getData("select * from weather where weather.Region = 'Москва'", new Weather());
        query1.forEach(System.out::println);

        System.out.println("\nЗапрос второй: Вывести даты, когда в заданном регионе шел снег и температура была ниже заданной отрицательной.\n(Город: Москва, Температура < 0, Снег)");
        var query2 = db.getData("select * from weather where (weather.Region = 'Москва' and weather.Temperature < 0 and weather.Precipitation = 'Снег')", new Weather());
        query2.forEach(el -> System.out.println(el.getDate()));

        System.out.println("\nЗапрос третий: Вывести информацию о погоде за прошедшую неделю в регионах, жители которых общаются на заданном языке.");

        LocalDate now = LocalDate.now();
        LocalDate weekAgo = LocalDate.now().minusDays(7);

        System.out.println(now + "\n" + weekAgo);

        String sql =
        "select w.Region,  w.Date, w.Temperature, w.Precipitation " +
        " from " +
        " weather as w " +
        " join region as r on r.Name = w.Region and " +
        " w.Date between '2023-02-03' and '2023-03-14' " +
        "where r.PopulationType = 'городское население'";

        var query3 = db.getData(sql, new Weather());

        query3.forEach(System.out::println);


        System.out.println("Запрос четвертый: Вывести среднюю температуру за прошедшую неделю в регионах с площадью больше заданной.");
        var sql2 =
       "select " +
       " avg(w.Temperature) " +
        "from " +
       " weather as w " +
       " join region as r on w.Region = r.Name ";

        double res = db.getValueFromQuery(sql2);

        System.out.println("Результат: " + res);


        String sqlPrepared = "insert into populationtype values(?, ?, ?)";
        var preparedConnection = db.getConnection().prepareStatement(sqlPrepared);

        preparedConnection.setInt(1, 333);
        preparedConnection.setString(2, "Hello");
        preparedConnection.setString(3, "lan");

        preparedConnection.executeUpdate();

        db.end();
    }
}