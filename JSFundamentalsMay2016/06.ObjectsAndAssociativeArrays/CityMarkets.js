function markets(arr) {
    let map = new Map();

    for (let element of arr) {
        let line = element.split(' -> ');

        let city = line[0];
        let product = line[1];
        let sum = line[2].split(' : ').reduce((a, b) => Number(a) * b);

        if(!map.has(city)){
            map.set(city, new Map());

            if(!map.get(city).get(product)){
                map.get(city).set(product, sum);
            }
        } else {
            if(!map.get(city).get(product)) {
                map.get(city).set(product, sum);
            } else {
                map.get(city).set(map.get(city).get(product) + sum);
            }
        }
    }

    for (let [town, values] of map) {
        console.log(`Town - ${town}`)
        for (let [product, money] of values) {
            console.log(`$$$${product} : ${money}`);
        }
    }
}

console.log(markets([
    'Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3'
]));