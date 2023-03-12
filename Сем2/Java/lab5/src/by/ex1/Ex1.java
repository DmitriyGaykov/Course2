package by.ex1;

//Прокат лыж. В лыжном прокате имеется n пар гоных лыж (лыж на всех
//        клиентов не хватит). Работник проката может обслуживать только одного
//        клиента, остальные должны ждать своей очереди. Если в текущий момент в
//        прокате нет лыж, клиент может ждать или уйти,если превышено время
//        ожидания. Пенсионеры обслуживаются вне очереди.


import by.ex1.Person.Client;
import by.ex1.Person.Employer;

public class Ex1 {
    public static void main(String[] args) throws InterruptedException {
        var employer = new Employer("Работник Степа");

        Client.TIME = 10;

        var client1 = new Client("Дима");
        var client2 = new Client("Леша");
        var client3 = new Client("Андрей");
        var client4 = new Client("Ольга", true);
        var client5 = new Client("Арсений", true);

        client1.startDoOrder(employer);
        client2.startDoOrder(employer);
        client4.startDoOrder(employer);
        client5.startDoOrder(employer);
        client3.startDoOrder(employer);
    }
}
