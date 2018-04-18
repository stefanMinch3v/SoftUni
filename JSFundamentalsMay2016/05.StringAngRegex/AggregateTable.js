function aggregate(arr) {
    let cities = [];
    let sum = 0;

    for (let element of arr) {
        let result = element
            .split('|')
            .map(e => e.trim())
            .filter(e => e != '');

        cities.push(result[0]);
        sum += Number(result[1]);
    }

    console.log(cities.join(', '));
    console.log(sum);
}

aggregate([
    '| Sofia           | 300',
    '| Veliko Tarnovo  | 500',
    '| Yambol          | 275']
);