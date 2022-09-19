//  1.	Вы – модератор на форуме о собаках.
//  Существуют определённые правила модерации
//   комментариев пользователей: длина
//    комментария не более n символов;
//     запрещается использовать слова с корнем
//      «кот» – он заменяется на символ *; 
//      слова с корнем «собак» должны быть с 
//      большой буквы; перед словом «пес» 
//      обязательно должно быть слово 
//      «многоуважаемый». Выполните модерацию
//       комментария пользователя и опубликуйте
//        на форуме, правильный комментарий.

const MAX_LENGTH : number = 255;
let wrapperOfComments : HTMLElement = document.querySelector(".commentList");
let textForComment : string = 
`
<div class="comment">
    <span class="comment-text">TextHere</span>
</div>            
`

let textInput : HTMLInputElement = document.querySelector(".addCommentText");
textInput.maxLength = MAX_LENGTH;
textInput.style.display = "none";

let button : HTMLButtonElement = document.querySelector(".addCommentButton");

button.addEventListener("click", addComment);

function addComment() : void
{
    let stateOfInput : string = textInput.style.display;
    if (stateOfInput === "none")
    {
        textInput.style.display = "block";
        button.innerText = "Отправить";
        textInput.focus();
    }
    else
    {
        let text : string = textInput.value;
        if(text.length > 0)
        {
            button.innerText = "Добавить комментарий";
            textInput.value = "";
            textInput.style.display = "none";

            text = text.replace(/кот/g, "*");
            text = text.replace(/собак/g, "Собак");
            text = text.replace(/пес/g, "многоуважаемый пес");

            text = textForComment.replace("TextHere", text);
            wrapperOfComments.innerHTML  += text;
        }
    }
}