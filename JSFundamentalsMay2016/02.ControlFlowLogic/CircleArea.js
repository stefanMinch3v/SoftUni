function calcArea(radius) {
    let sum = Math.PI * Math.pow(radius, 2);

    console.log(sum);
    console.log(Number(sum.toFixed(2)));
}

calcArea(5);