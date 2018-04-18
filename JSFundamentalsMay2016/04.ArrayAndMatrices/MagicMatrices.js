function isMagicMatrix(matrix) {
    let sumArr = [];

    for (let row = 0; row < matrix.length - 1; row++) {
        let insideArrayLength = matrix[row].length;
        sumArr[row] = insideArrayLength;

        for (let col = 0; col < insideArrayLength; col++) {
            sumArr[row] += matrix[row][col];
        }
    }

    return sumArr.every(e => e === sumArr[0]);
}

console.log(isMagicMatrix([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
));