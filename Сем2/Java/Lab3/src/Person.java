import java.util.logging.Logger;

public abstract class Person {
    private static final Logger logger = Logger.getLogger(Person.class.getName());
    protected  String name;
    protected  int age;

    public Person(String name, int age) {
        this.name = name;
        this.age = age;

        logger.info("Person created: " + this.toString());
    }

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setAge(int age) {
        this.age = age;
    }
}

