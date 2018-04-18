function diagonalSum(matrix) {
    let firstDiagonal = 0;
    let lastDiagonal = 0;

    for (let row = 0; row < matrix.length; row++) {
        firstDiagonal += matrix[row][row];
        lastDiagonal += matrix[row][matrix.length - 1 - row];
    }

    console.log(`${firstDiagonal} ${lastDiagonal}`);
}

diagonalSum([[20, 40], [10, 60]]);