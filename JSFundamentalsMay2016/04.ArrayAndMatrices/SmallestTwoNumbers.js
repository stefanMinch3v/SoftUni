function smallestTwo(arr) {
    let result = arr.map(e => Number(e))
        .sort((a, b) => a - b);
    return result.slice(0, 2);
}

console.log(smallestTwo([15, 5, 10, 25, 12]));