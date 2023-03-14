package by.db;

import by.Weather.Population;
import by.Weather.Weather;

import java.sql.*;
import java.time.Duration;
import java.time.LocalDateTime;
import java.util.*;
import java.util.Date;

public class DB {
    private static final String connectionPath = "jdbc:mysql://localhost:3306/weather_db";
    private static final String userName = "my";
    private static final String password = "1111";

    private Connection connection;
    private Statement statement;

    public DB() throws SQLException, ClassNotFoundException {
        start();
    }

    private void start() throws SQLException, ClassNotFoundException {
        Class.forName("com.mysql.cj.jdbc.Driver");

        connection = DriverManager.getConnection(connectionPath, userName, password);
        statement = connection.createStatement();
    }

    public <T extends IBDInfo, Object> List<T> getData(T obj) throws SQLException {
        List<T> list = new ArrayList<>();

        var set = statement.executeQuery("select * from weather");

        T el = obj; // Не работает

        while(set.next()) {
            el = (T)el.getValue(set);
            list.add(el);
        }

        return list;
    }

    public <T extends IBDInfo, Object> List<T> getData(String query, T obj) throws SQLException {
        List<T> list = new ArrayList<>();

        var set = statement.executeQuery(query);

        T el = obj; // Не работает

        while(set.next()) {
            el = (T)el.getValue(set);
            list.add(el);
        }

        return list;
    }

    public double getValueFromQuery(String sql) throws SQLException {
        var set = statement.executeQuery(sql);
        set.next();
        double res = set.getFloat(1);
        return res;
    }

    public Statement getStatement() {
        return statement;
    }

    public Connection getConnection() {
        return connection;
    }

    public void end() throws SQLException {
        connection.close();
    }
}
