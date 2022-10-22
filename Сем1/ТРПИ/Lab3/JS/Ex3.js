let objButton = {
    class: "button",
    width: 100,
    height: 50,
};
let objLink = {
    class: "link",
    size: 20,
    font: "Arial",
    color: "blue",
};
let objElement = {
    class: "element",
    backgroundColor: "yellow"
};
let buttons = document.querySelectorAll("." + objButton["class"]);
let links = document.querySelectorAll("." + objLink["class"]);
let elements = document.querySelectorAll("." + objElement["class"]);
for (let i = 0; i < buttons.length; i++) {
    buttons[i].style.width = objButton["width"] + "px";
    buttons[i].style.height = objButton["height"] + "px";
    buttons[i].style.backgroundColor = objButton["backgroundColor"];
    buttons[i].style.color = objButton["textColor"];
}
for (let i = 0; i < links.length; i++) {
    links[i].style.fontSize = objLink["size"] + "px";
    links[i].style.fontFamily = objLink["font"];
    links[i].style.color = objLink["color"];
}
for (let i = 0; i < elements.length; i++) {
    elements[i].style.backgroundColor = objElement["backgroundColor"];
}
