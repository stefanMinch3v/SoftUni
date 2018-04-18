function count(arr) {
    let obj = {};

    arr = arr
        .map(e => e
            .split(new RegExp(/\W/, 'g'))
            .filter(s => s !== ''));

    for (let element of arr) {
        for (let word of element) {
            if(!obj.hasOwnProperty(word)){
                obj[word] = 0;
            }

            obj[word] += 1;
        }
    }

    return JSON.stringify(obj);
}

console.log(count(['Far too slow, you\'re far too slow.']));