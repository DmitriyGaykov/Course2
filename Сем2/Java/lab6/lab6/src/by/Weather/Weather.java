package by.Weather;

import by.db.IBDInfo;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDateTime;
import java.util.Date;

//Для погоды необходимо хранить:
//        — регион;
//        — дату;
//        — температуру;
//        — осадки.
//        Для регионов необходимо хранить:
//        — название;
//        — площадь;
//        — тип жителей.
//        Для типов жителей необходимо хранить:
//        — название;
//        — язык общения
public class Weather implements IBDInfo {
    private String regionName;
    private Date date;
    private int temperature;
    private String precipication;

    public Weather(String regionName, Date date, int temperature, String precipication) {
        this.regionName = regionName;
        this.date = date;
        this.temperature = temperature;
        this.precipication = precipication;
    }

    public Weather() {
        this("", new Date(), 0, "");
    }

    public String getRegionName() {
        return regionName;
    }

    public void setRegionName(String regionName) {
        this.regionName = regionName;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public int getTemperature() {
        return temperature;
    }

    public void setTemperature(int temperature) {
        this.temperature = temperature;
    }

    public String getPrecipication() {
        return precipication;
    }

    public void setPrecipication(String precipication) {
        this.precipication = precipication;
    }

    @Override
    public String toString() {
        return "Weather{" +
                "regionName='" + regionName + '\'' +
                ", date=" + date +
                ", temperature=" + temperature +
                ", precipication='" + precipication + '\'' +
                '}';
    }

    @Override
    public Object getValue(ResultSet tuple) throws SQLException {
        Weather w = new Weather();

        w.setRegionName(tuple.getString(1));
        w.setDate(tuple.getDate(2));
        w.setTemperature(tuple.getInt(3));
        w.setPrecipication(tuple.getString(4));

        return w;
    }
}

