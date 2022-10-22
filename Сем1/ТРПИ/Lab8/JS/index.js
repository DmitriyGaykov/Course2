let form = document.querySelector('form');
let spanMistake = document.querySelector('.mistake');
spanMistake.style.transform = "scale(.04)";
let inputName = document.querySelector('.inputName');
let inputSurname = document.querySelector('.inputSurname');
let inputEmail = document.querySelector('.inputEmail');
let inputPassword = document.querySelector('.inputPassword');
let inputBithday = document.querySelector('.inputBirthday');
let inputSubmit = document.querySelector('.submit');
inputSubmit.onclick = checkForm;
function checkForm() {
    spanMistake.style.transform = "scale(.04)";
    spanMistake.innerHTML = "";
    let mistake = '';
    let name = inputName.value;
    let surname = inputSurname.value;
    let email = inputEmail.value;
    let password = inputPassword.value;
    let birthday = inputBithday?.value;
    let regName = /[A-Z]([a-z]){1,20}/;
    let regEmail = /[a-z0-9A-Z_]{1,50}@[a-z]{1,10}.[a-z]{1,10}/;
    let regPassword = /[a-z0-9A-Z]{8,20}/;
    if (!regName.test(name)) {
        mistake += 'Name is not correct.<br>';
    }
    if (!regName.test(surname)) {
        mistake += 'Surname is not correct.<br>';
    }
    if (!regEmail.test(email)) {
        mistake += 'Email is not correct.<br>';
    }
    if (!regPassword.test(password)) {
        mistake += 'Password is not correct.<br>';
    }
    if (birthday == '') {
        mistake += 'Birthday is not correct.<br>';
    }
    if (mistake.length != 0) {
        spanMistake.innerHTML = mistake;
        spanMistake.style.transform = "scale(1)";
        setTimeout(() => {
            spanMistake.style.transform = "scale(.0001)";
            setTimeout(() => spanMistake.innerHTML = '', 400);
        }, 2000);
    }
    else {
        alert("All is correct");
        form.submit();
    }
}
