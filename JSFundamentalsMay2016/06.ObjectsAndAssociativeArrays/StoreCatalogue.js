function catalog(arr) {
    let map = new Map();

    for (let line of arr) {
        let [product, price] = line.split(' : ');
        let letter = product[0];

        if(!map.has(letter)){
            map.set(letter, new Map());
        }

        map.get(letter).set(product, Number(price));
    }

    let keys = [...map.keys()].sort();

    for (let key of keys) {
        console.log(key);
        let products = [...map.get(key).keys()].sort();

        for (let product of products) {
            console.log(`  ${product}: ${map.get(key).get(product)}`);
        }
    }
}

catalog([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]);