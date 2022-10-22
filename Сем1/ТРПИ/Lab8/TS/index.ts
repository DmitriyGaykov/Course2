let form : HTMLFormElement = document.querySelector('form');
let spanMistake : HTMLSpanElement = document.querySelector('.mistake');

spanMistake.style.transform = "scale(.04)";

let inputName : HTMLInputElement = document.querySelector('.inputName');
let inputSurname : HTMLInputElement = document.querySelector('.inputSurname');
let inputEmail : HTMLInputElement = document.querySelector('.inputEmail');
let inputPassword : HTMLInputElement = document.querySelector('.inputPassword');
let inputBithday : HTMLInputElement = document.querySelector('.inputBirthday');
let inputSubmit : HTMLInputElement = document.querySelector('.submit');

inputSubmit.onclick = checkForm;

function checkForm()
{
    spanMistake.style.transform = "scale(.04)";
    spanMistake.innerHTML = "";

    let mistake : string = '';

    let name : string = inputName.value;
    let surname : string = inputSurname.value;
    let email : string = inputEmail.value;
    let password : string = inputPassword.value;
    let birthday : string = inputBithday?.value;

    let regName : RegExp = /[A-Z]([a-z]){1,20}/;
    let regEmail : RegExp = /[a-z0-9A-Z_]{1,50}@[a-z]{1,10}.[a-z]{1,10}/;
    let regPassword : RegExp = /[a-z0-9A-Z]{8,20}/;

    if (!regName.test(name))
    {
        mistake += 'Name is not correct.<br>';
    }

    if(!regName.test(surname))
    {
        mistake += 'Surname is not correct.<br>';
    }

    if(!regEmail.test(email))
    {
        mistake += 'Email is not correct.<br>';
    }

    if(!regPassword.test(password))
    {
        mistake += 'Password is not correct.<br>';
    }

    if(birthday == '')
    {
        mistake += 'Birthday is not correct.<br>';
    }

    if(mistake.length != 0)
    {
        spanMistake.innerHTML = mistake;
        spanMistake.style.transform = "scale(1)";
        setTimeout(() => {
            spanMistake.style.transform = "scale(.0001)";
            setTimeout(() => spanMistake.innerHTML = '', 400);
        }, 2000);
    }
    else
    {
        alert("All is correct");
        form.submit();
    }
}