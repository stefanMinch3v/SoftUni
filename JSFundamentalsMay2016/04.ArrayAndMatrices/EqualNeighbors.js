function equalNeighbours(matrix) {
    let counter = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            let current = matrix[row][col];
            let neighbourRightTo = matrix[row][col + 1] != undefined ? matrix[row][col + 1] : undefined;

            if(current === neighbourRightTo){
                counter++;
            }

            if(matrix[row] === matrix[matrix.length - 1]){
                continue;
            }

            let neighbourDown = matrix[row + 1][col];

            if(current === neighbourDown){
                counter++;
            }
        }
    }

    return counter;
}

console.log(equalNeighbours([
    [2, 2, 5, 7, 4],
    [4, 0, 5, 3, 4],
    [2, 5, 5, 4, 2]
]));