function uniqueSeq(arr) {
    let result = new Set();
    let sorted = [];

    let final = [];

    for (let line of arr) {
        let sortedLine = line.sort((a, b) => a < b);
        sorted.push(sortedLine);
    }

    for (let line of sorted) {
        result.add(line.toString());
    }

    for (let line of [...result].reverse()) {
        let toInt = line.split(',').map(Number);

        final.push(Array.from(toInt));
    }

    final.forEach(e => console.log(e));
}

uniqueSeq([
    [7.14, 7.180, 7.339, 80.099],
    [7.339, 80.0990, 7.140000, 7.18],
    [7.339, 7.180, 7.14, 80.099]
]);

// working solution
// function uniqueSequences(arr) {
//     let uniqueSeqs = new Map();
//     for (let line of arr) {
//         let seq = JSON.parse(line).map(Number);
//
//         seq.sort((a, b) => b - a);
//         let length = seq.length;
//         if (!uniqueSeqs.has(length))
//             uniqueSeqs.set(length, new Set());
//         uniqueSeqs.get(length).add(`[${seq.join(', ')}]`);
//     }
//
//     let lengthKeys = [...uniqueSeqs.keys()].sort((a, b) => a - b);
//     for (let len of lengthKeys) {
//         for (let seq of uniqueSeqs.get(len)) {
//             console.log(seq);
//         }
//     }
// }