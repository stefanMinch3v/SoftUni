function averageOperation(input) {
    function sumNums(array) {
        let sum = 0;

        for (let i = 0; i < array.length; i++) {
            sum += Number(array[i]);
        }

        return sum;
    };

    let arr = input.toString();
    let sum = sumNums(arr);
    let avg = sum / arr.length;

    while(avg <= 5){
        arr += '9';
        sum = sumNums(arr);

        avg = sum / arr.length;
    }

    return Number(arr);
}

console.log(averageOperation(5835));