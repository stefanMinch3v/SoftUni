function countCars(arr) {
    let map = new Map();

    for (let line of arr) {
        let [brand, model, counts] = line.split(' | ');
        let countCars = Number(counts);

        if(!map.has(brand)){
            map.set(brand, new Map());
        }

        if(map.get(brand).get(model)) {
            countCars += map.get(brand).get(model);
        }

        map.get(brand).set(model, countCars);
    }

    for (let brand of [...map.keys()]) {
        console.log(brand);

        let modelsAndCounts = [...map.get(brand)];
        for (let [k, v] of modelsAndCounts) {
            console.log(`###${k} -> ${v}`);
        }
    }
}

countCars([
    'Mercedes-Benz | 50PS | 123',
    'Mini | Clubman | 20000',
    'Mini | Convertible | 1000',
    'Mercedes-Benz | 60PS | 3000',
    'Hyunday | Elantra GT | 20000',
    'Mini | Countryman | 100',
    'Mercedes-Benz | W210 | 100',
    'Mini | Clubman | 1000',
    'Mercedes-Benz | W163 | 200'
]);