function towns(arr) {
    arr.shift();

    let operation = arr
        .map(e => e
            .split('|')
            .filter(s => s !== '')
            .map(t => t.trim()));

    let result = [];

    for (let element of operation) {
        let obj = {
            Town: element[0],
            Latitude: Number(element[1]),
            Longitude: Number(element[2])
        };

        result.push(obj);
    }

    return JSON.stringify(result);
}

console.log(towns(
    ['| Town | Latitude | Longitude |',
        '| Sofia | 42.696552 | 23.32601 |',
        '| Beijing | 39.913818 | 116.363625 |']
));