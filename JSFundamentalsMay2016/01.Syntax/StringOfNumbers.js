function stringToNumber(value) {
    let number = Number(value);
    let concatenate = '';

    for(let i = 1; i <= value; i++){
        concatenate += i;
    }

    return concatenate;
}

console.log(stringToNumber('11'));