package by.db;

import java.sql.ResultSet;
import java.sql.SQLException;

public interface IBDInfo {
    Object getValue(ResultSet tuple) throws SQLException;
}
