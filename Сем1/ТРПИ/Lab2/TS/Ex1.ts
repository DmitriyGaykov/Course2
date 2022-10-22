let radius : number;
let checkRadius : string;

do {
    checkRadius = prompt("Enter the radius of the circle") ?? "default";
} while (!isFinite(Number(checkRadius)) || Number(checkRadius) < 1);

radius = Number(checkRadius);

let getCircleDiametre: (number) => number = function(radius : number) : number {
    return radius * 2;
};

let circleSquare : number = getCircleSquare(radius);
let circleDiametre : number = getCircleDiametre(radius);
let circleLength : number = radius => 2 * Math.PI * radius;

alert(`
    Circle square: ${circleSquare}
    Circle diametre: ${circleDiametre}
    Circle length: ${circleLength}
`)

function getCircleSquare(radius : number) : number {
    return Math.PI * Math.pow(radius, 2);
}