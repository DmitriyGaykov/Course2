interface IRegs
{
    email : RegExp;
    password : RegExp;
    name : RegExp;
}

const stateReg : HTMLElement = document.querySelector('.reg');
const stateAuto : HTMLElement = document.querySelector('.auto');

let _email : HTMLInputElement;
let _password : HTMLInputElement;
let _name : HTMLInputElement;
let inputs : Array<HTMLInputElement>;
let buttonReg : HTMLButtonElement;

let isClicked : boolean = false;

const regs : IRegs = 
{
    email : new RegExp(/^[a-zA-Z0-9_.]+@[a-z]+\.[a-z]+$/),
    name : new RegExp(/^[a-zA-Z]{2,}$/),
    password : new RegExp(/^[a-zA-Z0-9_.]{8,64}$/)
}

stateAuto.onclick = () =>
{
    isClicked = false;
}

stateReg.onclick = () => 
{ 
    if(!isClicked)
    {
        isClicked = true;
        regestration();
    }
};


function regestration() : void
{
    let resEmail : boolean;
    let resPassword : boolean;
    let resName : boolean;

    inputs = Array.from(document.querySelectorAll('.input'));

    _email = inputs.find(el => el.type == "email");
    _password = inputs.find(el => el.type == "password");
    _name = inputs.find(el => el.type == "text");

    buttonReg = document.querySelector('.button-reg') as HTMLButtonElement;

    buttonReg.onclick = () => 
    {
        resEmail = testEmail(_email);
        resPassword = testPassword(_password);
        resName = testName(_name);

        console.log(resEmail, resPassword, resName);

        if(!resPassword)
        {
            _password.value = "";
            _password.placeholder = "Password is not valid";

            setTimeout(() =>
            {
                if(_password.placeholder == "Password is not valid")
                {
                    _password.placeholder = "Введите пароль";
                }
            }
            , 2000);
        }

        if(!resEmail)
        {
            _email.value = "Ошибка в емаиле";

            setTimeout(() =>
            {
                if(_email.value == "Ошибка в емаиле")
                {
                    _email.value = "";
                }
            }
            , 2000);
        }

        if(!resName)
        {
            _name.value = "Ошибка в имени";
            setTimeout(() =>
            {
                if(_name.value == "Ошибка в имени")
                {
                    _name.value = "";
                }
            }
            , 2000);
        }
    }
}

function testEmail(email : HTMLInputElement) : boolean
{
    return regs.email.test(email.value);
}

function testPassword(password : HTMLInputElement) : boolean
{
    return regs.password.test(password.value);
}

function testName(name : HTMLInputElement) : boolean
{
    return regs.name.test(name.value);
}