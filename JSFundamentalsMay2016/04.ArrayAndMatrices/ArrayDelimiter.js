function print(arr) {
    let delimiter = arr.splice(arr.length - 1);

    return arr.join(delimiter);
}

console.log(print([
    'One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-'
]));