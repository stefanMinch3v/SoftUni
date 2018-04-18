function  populate(arr) {
    let map = new Map();

    for (let element of arr) {
        let [name, number] = element.split(' <->');

        if(!map.has(name)) {
            map.set(name, 0);
        }

        map.set(name, map.get(name) + Number(number));
    }

    for (let [k, v] of map) {
        console.log(`${k} : ${v}`);
    }
}

populate([
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'
]);