function biggestElement(matrix) {
    let biggestNum = Number.NEGATIVE_INFINITY;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            let currentElement = matrix[row][col];
            if(currentElement >= biggestNum){
                biggestNum = currentElement;
            }
        }
    }

    return biggestNum;
}

console.log(biggestElement([[20, 50, 10], [8, 33, 145]]));

/*function biggestElement(matrix) {
    let biggestNum = Number.NEGATIVE_INFINITY;

    matrix.forEach(e => e.forEach(n => n > biggestNum ? biggestNum = n : biggestNum));

    return biggestNum;
}*/