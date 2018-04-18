function produceJuice(arr) {
    arr = arr.map(e => e.split(' => '));
    let collect = new Map();
    let result = new Map();

    for (let line of arr) {
        let fruit = line[0];
        let gr = Number(line[1]);

        if(!collect.has(fruit)){
            collect.set(fruit, 0);
        }

        collect.set(fruit, collect.get(fruit) + gr);

        while(collect.get(fruit) >= 1000) {
            collect.set(fruit, collect.get(fruit) - 1000);

            if(!result.has(fruit)){
                result.set(fruit, 1);
            } else {
                result.set(fruit, result.get(fruit) + 1);
            }
        }
    }

    for (let [fruit, kg] of result) {
        console.log(`${fruit} => ${kg}`);
    }
}

produceJuice([
    'Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
]);