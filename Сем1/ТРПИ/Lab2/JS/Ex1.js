var _a;
let radius;
let checkRadius;
do {
    checkRadius = (_a = prompt("Enter the radius of the circle")) !== null && _a !== void 0 ? _a : "default";
} while (!isFinite(Number(checkRadius)) || Number(checkRadius) < 1);
radius = Number(checkRadius);
let getCircleDiametre = function (radius) {
    return radius * 2;
};
let circleSquare = getCircleSquare(radius);
let circleDiametre = getCircleDiametre(radius);
let circleLength = radius => 2 * Math.PI * radius;
alert(`
    Circle square: ${circleSquare}
    Circle diametre: ${circleDiametre}
    Circle length: ${circleLength}
`);
function getCircleSquare(radius) {
    return Math.PI * Math.pow(radius, 2);
}
