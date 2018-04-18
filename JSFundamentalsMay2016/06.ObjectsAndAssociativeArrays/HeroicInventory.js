function inventory(arr) {
    let result = [];
    
    arr = arr
        .map(e => e.split('/'));

    for (let element of arr) {
        let name = element[0].trim();
        let level = Number(element[1]);
        let items = [];

        if(element.length > 2){
            items = element[2]
                .split(',')
                .map(e => e.trim());
        }

        let hero = {
            name: name,
            level: level,
            items: items
        };

        result.push(hero);
    }

    return JSON.stringify(result);
}

console.log(inventory([
    'Jake / 1000 / Gauss, HolidayGrenade'
]));