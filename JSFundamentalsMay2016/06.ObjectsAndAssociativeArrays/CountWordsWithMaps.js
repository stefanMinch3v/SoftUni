function count(arr) {
    let map = new Map();

    arr = arr
        .map(e => e
            .toLowerCase()
            .split(new RegExp(/\W/, 'g'))
            .filter(s => s !== ''));

    for (let element of arr) {
        for (let word of element) {
            if(!map.has(word)){
                map.set(word, 1);
            } else {
                map.set(word, map.get(word) + 1);
            }
        }
    }

    map = [...map].sort((a, b) => sortingAlphabetically(a[0], b[0]));

    for (let [k, v] of map) {
        console.log(`'${k}' -> ${v} times`)
    }

    function sortingAlphabetically(a, b) {
        if(a < b){
           return -1;
        } else if(a > b) {
            return 1;
        } else {
            return 0
        }
    }
}

count(['The man was walking the dog down the road when it suddenly started barking against the other dog. Surprised he pulled him away from it.']);