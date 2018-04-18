function sum(arr) {
    let obj = {};

    for (let i = 0; i < arr.length; i+=2) {
        let town = arr[i];
        let number = Number(arr[i+1]);

        if(!obj.hasOwnProperty(town)){
            obj[town] = 0;
        }

        obj[town] += number;
    }

    return JSON.stringify(obj);
}

console.log(sum([
    'Sofia',
    '20',
    'Varna',
    '3',
    'Sofia',
    '5',
    'Varna',
    '4'
]));