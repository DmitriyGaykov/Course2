let radius : number;
let checkRadius : string;
do {
    checkRadius = prompt("Enter the radius of the circle");
} while (!isFinite(Number(checkRadius)));

radius = Number(checkRadius);

let getCircleDiametre: (number) => number = function(radius : number) : number {
    return radius * 2;
};

let circleSquare : number = getCircleSquare(radius);
let circleDiametre : number = getCircleDiametre(radius);
let circleLength :number = (radius => 2 * Math.PI * radius)(radius);

alert(`
    Circle square: ${circleSquare}\n
    Circle diametre: ${circleDiametre}\n
    Circle length: ${circleLength}\n
`)

function getCircleSquare(radius : number) : number {
    return Math.PI * Math.pow(radius, 2);
}