function rotate(arr) {
    let times = Number(arr.pop()) % arr.length;

    console.log(times);

    for (let i = 0; i < times; i++) {
        let elementToRight = arr.pop();
        arr.unshift(elementToRight);
    }

    return arr.join(' ');
}

console.log(rotate(['Banana', 'Orange', 'Coconut', 'Apple', '15']));