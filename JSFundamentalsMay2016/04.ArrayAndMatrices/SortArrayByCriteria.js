function sorting(arr) {
    //return arr.sort((a, b) => comparing(a, b)).join('\n');
    return arr.sort(comparing).join('\n');

    function comparing(a, b) {
        let lengthA = a.length;
        let lengthB = b.length;
        let wordA = a.toLowerCase();
        let wordB = b.toLowerCase();

        if(lengthA < lengthB){
            return - 1;
        } else if(lengthA > lengthB){
            return 1;
        } else {
            if(wordA < wordB){
                return - 1;
            } else if(wordA > wordB){
                return 1;
            }

            return 0;
        }
    }
}

console.log(sorting(['a', 'sadadsda','test', 'Deny', 'omen', 'Default']));