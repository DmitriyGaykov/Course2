class User {
    Login;
    Password;

    constructor(login, password) {
        this.Login = login;
        this.Password = password;
    }
}

let Client = new User("admin", "12345");
let NewClient = new User();

NewClient.Login = prompt("Введите логин:");
NewClient.Password = prompt("Введите пароль:");

if (
    NewClient.Login === Client.Login &&
    NewClient.Password === Client.Password
) {
    alert("Добро пожаловать!");
} else {
    alert("Неверный логин или пароль!");
}