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
const MAX_LENGTH = 255;
let wrapperOfComments = document.querySelector(".commentList");
let textForComment = `
<div class="comment">
    <span class="comment-text">TextHere</span>
</div>            
`;
let textInput = document.querySelector(".addCommentText");
textInput.maxLength = MAX_LENGTH;
textInput.style.display = "none";
let button = document.querySelector(".addCommentButton");
button.addEventListener("click", addComment);
function addComment() {
    let stateOfInput = textInput.style.display;
    if (stateOfInput === "none") {
        textInput.style.display = "block";
        button.innerText = "Отправить";
        textInput.focus();
    }
    else {
        let text = textInput.value;
        if (text.length > 0) {
            button.innerText = "Добавить комментарий";
            textInput.value = "";
            textInput.style.display = "none";
            text = text.replace(/кот/g, "*");
            text = text.replace(/собак/g, "Собак");
            text = text.replace(/пес/g, "многоуважаемый пес");
            text = text.replace(/Лукашенко/g, "Лучший президент");
            text = textForComment.replace("TextHere", text);
            wrapperOfComments.innerHTML += text;
        }
    }
}
