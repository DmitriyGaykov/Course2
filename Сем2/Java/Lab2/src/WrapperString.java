import java.util.Objects;

public class WrapperString {
    /**
     * Текстовое поле
     * @value text
     * */
    private String text;

    /**
     * Метод заменяет все вхождения символа oldChar на символ newChar
     * @param oldChar
     * @param newChar
     * @return void
     * */
    public void replace(char oldChar, char newChar) {

        text = text.replace(oldChar, newChar);
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    public WrapperString(String text) {
        this.text = text;
    }

    public WrapperString() {
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        WrapperString that = (WrapperString) o;
        return Objects.equals(text, that.text);
    }

    @Override
    public int hashCode() {
        return Objects.hash(text);
    }

    @Override
    public String toString() {
        return "WrapperString{" +
                "text='" + text + '\'' +
                '}';
    }
}
