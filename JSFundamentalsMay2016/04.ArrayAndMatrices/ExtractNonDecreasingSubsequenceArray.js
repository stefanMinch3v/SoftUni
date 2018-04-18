function extract(arr) {
    let newArr = [];
    let biggestNumber = Number.NEGATIVE_INFINITY;

    for (let i = 0; i < arr.length; i++) {
        let currentElement = arr[i];

        if(currentElement >= biggestNumber){
            biggestNumber = currentElement;
            newArr.push(biggestNumber);
        }
    }

    return newArr.join('\n');
}

console.log(extract([1, 3, 8, 4, 10, 12, 3, 2, 24]));