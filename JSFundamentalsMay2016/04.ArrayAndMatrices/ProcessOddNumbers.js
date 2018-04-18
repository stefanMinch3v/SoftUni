function processOdd(arr) {
    return arr.filter((e, i) => i % 2 == 1)
        .map(e => e * 2)
        .reverse();
}

console.log(processOdd([10, 15, 20, 25]));