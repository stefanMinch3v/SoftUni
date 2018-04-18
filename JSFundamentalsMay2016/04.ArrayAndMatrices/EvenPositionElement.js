function evenPosition(arr) {
    return arr.filter((e, i) => i % 2 == 0)
        .join(' ');
}

console.log(evenPosition(['20', '30', '40']));