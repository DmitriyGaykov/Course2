package by.Weather;

import by.db.IBDInfo;

import java.sql.ResultSet;
import java.sql.SQLException;

public class Population implements IBDInfo {
    private String title;
    private String language;

    public Population(String title, String language) {
        this.title = title;
        this.language = language;
    }

    public Population() {
        this("", "");
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getLanguage() {
        return language;
    }

    public void setLanguage(String language) {
        this.language = language;
    }

    @Override
    public String toString() {
        return "Population{" +
                "title='" + title + '\'' +
                ", language='" + language + '\'' +
                '}';
    }

    @Override
    public Object getValue(ResultSet tuple) throws SQLException {
        Population pop = new Population();

        pop.setTitle(tuple.getString(2));
        pop.setLanguage(tuple.getString(3));

        return pop;
    }

}
