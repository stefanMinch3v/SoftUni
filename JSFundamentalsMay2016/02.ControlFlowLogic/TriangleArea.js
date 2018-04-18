function calcArea(a, b, c) {
    var perimeter = (a + b + c) / 2;
    return Math.sqrt(perimeter * ((perimeter - a) * (perimeter - b) * (perimeter - c)));
}

console.log(calcArea(2, 3.5, 4));