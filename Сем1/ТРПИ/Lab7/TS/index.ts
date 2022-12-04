const dart : HTMLElement = document.querySelector('.dart');
const wrapper : HTMLElement = document.querySelector('.game-block');

let startX : number = -100;
let startY : number = -100;

let x : number = startX;
let y : number = startY;

let wasClicked : boolean = false;

dart.onmousedown = function(event : MouseEvent) {

    if(wasClicked) {
        document.body.onmousemove = null;
        document.body.onclick = () => animate(x, y, startX, startY);
        return;
    }

    dart.style.zIndex = '1000';

    wasClicked = wasClicked ? false : true;

    document.body.onmousemove = function(event : MouseEvent) {

        if(startX === -100 && startY === -100) {

            startX = event.clientX - 5;
            dart.style.left = `${startX}px`;
            startY = event.clientY - 20;
            dart.style.top = `${startY}px`;
    
            dart.style.cursor = "none";
            document.body.append(dart);
        }
       
        if(Math.abs(startX - event.clientX ) < 100) 
        {
            x = event.clientX - 5;
        }
        if(Math.abs(startY - event.clientY ) < 100) 
        {
            y = event.clientY - 5;
            dart.style.backgroundColor = `#${Math.abs(startY - event.clientY)}${100 - Math.abs(startY - event.clientY)}00`;
        }
        // alert(`event.clientX: ${event.clientX}, x: ${x}, y:${y}, startX: ${startX}, startY: ${startY}`);
        dart.style.left = `${x}px`;
        dart.style.top = `${y}px`;
    };
};

function animate(x : number,
                 y : number,
                 startX : number,
                 startY : number) : void
{
    dart.style.backgroundColor = `#009900`;
    let dx : number = (startX - x);
    let dy : number = (startY - y);

    let tg : number = dy / dx;

    startX = dx < 0 ? startX - 3 * Math.abs(dx) : startX + 3 * Math.abs(dx);
    startY = dy < 0 ? startY - 3 * Math.abs(tg * dx) : startY + 3 * Math.abs(tg * dx);
    
    // alert(`x: ${x}, y:${y}, dx: ${dx}, dy: ${dy}, tg: ${tg}, startX: ${startX}, startY: ${startY}`);

    dart.style.left = `${startX}px`;
    dart.style.top = `${startY}px`;
}
