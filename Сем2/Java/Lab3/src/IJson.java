import com.fasterxml.jackson.core.JsonProcessingException;

import java.io.FileNotFoundException;
import java.io.IOException;

public interface IJson<T> {
    void toJson() throws IOException;
    T fromJson() throws IOException;
}
