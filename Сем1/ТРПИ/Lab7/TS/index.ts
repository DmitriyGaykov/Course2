const mainWrapper : HTMLElement = document.querySelector('.game-block');

const dart : HTMLElement = document.querySelector(".dart");
const dartWrapper : HTMLElement = document.querySelector(".block-with-dart");

dart.onmousedown = event => 
{
    let shiftX : number = event.clientX - dart.getBoundingClientRect().left;
    let shiftY : number = event.clientY - dart.getBoundingClientRect().top;

    dart.style.position = 'absolute';
    dart.style.zIndex = '1000';

    moveAt(event.pageX, event.pageY);

    function moveAt(pageX, pageY) 
    {
        dart.style.left = pageX -  shiftX + 'px';
        dart.style.top = pageY - shiftY + 'px';
    }

    function onMouseMove(event) 
    {
        moveAt(event.pageX, event.pageY);
    }

    document.addEventListener('mousemove', onMouseMove);

    dart.onmouseup = function() 
    {
        document.removeEventListener('mousemove', onMouseMove);
        dart.onmouseup = null;
    };
}