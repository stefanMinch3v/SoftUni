function print(arr) {
    let n = Number(arr.pop());

    for (let i = 0; i < arr.length; i+=n) {
        console.log(arr[i]);
    }
}

print([
    'dsa',
    'asd',
    'test',
    'tset',
    2
]);