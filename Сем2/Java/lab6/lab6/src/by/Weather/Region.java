package by.Weather;

import by.db.IBDInfo;

import java.sql.ResultSet;
import java.sql.SQLException;

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
public class Region implements IBDInfo {
    private String title;
    private float square;
    private String populationTitle;

    public Region(String title, float square, String populationTitle) {
        this.title = title;
        this.square = square;
        this.populationTitle = populationTitle;
    }

    public Region() {
        this("", 0.0f, "");
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public float getSquare() {
        return square;
    }

    public void setSquare(float square) {
        this.square = square;
    }

    public String getPopulationTitle() {
        return populationTitle;
    }

    public void setPopulationTitle(String populationTitle) {
        this.populationTitle = populationTitle;
    }

    @Override
    public String toString() {
        return "Region{" +
                "title='" + title + '\'' +
                ", square=" + square +
                ", populationTitle='" + populationTitle + '\'' +
                '}';
    }

    @Override
    public Object getValue(ResultSet tuple) throws SQLException {
        Region r = new Region();

        r.setTitle(tuple.getString(2));
        r.setSquare(tuple.getFloat(3));
        r.setPopulationTitle(tuple.getString(4));

        return r;
    }
}
