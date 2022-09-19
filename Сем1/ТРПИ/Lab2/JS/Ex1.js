let radius;
let checkRadius;
do {
    checkRadius = prompt("Enter the radius of the circle");
} while (!isFinite(Number(checkRadius)));
radius = Number(checkRadius);
let getCircleDiametre = function (radius) {
    return radius * 2;
};
let circleSquare = getCircleSquare(radius);
let circleDiametre = getCircleDiametre(radius);
let circleLength = (radius => 2 * Math.PI * radius)(radius);
alert(`
    Circle square: ${circleSquare}\n
    Circle diametre: ${circleDiametre}\n
    Circle length: ${circleLength}\n
`);
function getCircleSquare(radius) {
    return Math.PI * Math.pow(radius, 2);
}
