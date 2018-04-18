function firstLast(arr) {
    let number = Number(arr.shift());

    console.log(arr.slice(0, number)
        .join(' '));
    console.log(arr.slice(arr.length - number)
        .join(' '));
}

firstLast([2, 7, 8, 9]);