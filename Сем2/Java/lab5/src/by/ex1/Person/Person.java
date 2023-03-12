package by.ex1.Person;

public abstract class Person implements Comparable<Person> {
    private String name;
    private boolean isPensioner = false;

    public Person(String name) {
        this.name = name;
    }

    public Person(String name, boolean isPensioner) {
        this(name);
        this.isPensioner = isPensioner;
    }

    public boolean isPensioner() {
        return isPensioner;
    }

    public void setPensioner(boolean pensioner) {
        isPensioner = pensioner;
    }

    @Override
    public String toString() {
        return this.name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public int compareTo(Person o) {
        if(this.isPensioner() && !o.isPensioner()) {
            return -1;
        } else if (!this.isPensioner() && o.isPensioner()) {
            return 1;
        } else {
            return 0;
        }
    }
}
