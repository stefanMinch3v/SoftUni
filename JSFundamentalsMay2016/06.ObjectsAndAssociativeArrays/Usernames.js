function sortUsernames(arr) {
    let set = new Set();

    arr.forEach(e => set.add(e));

    let result = [...set].sort((a, b) => sorting(a, b));

    result.forEach(e => console.log(e));

    function sorting(a, b) {
        if(a.length < b.length){
            return -1;
        } else if(a.length > b.length){
            return 1;
        } else {
            if(a < b){
                return -1;
            } else if(a > b){
                return 1;
            } else {
                return 0;
            }
        }
    }
}

sortUsernames([
    'Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston'
]);