function  rounding(number, symbols) {
    if(symbols >= 15) {
        symbols = 15;
    }

    let tempResult = number.toFixed(symbols);
    let array = tempResult.split('.');

    let result = array[1];
    let emptyString = '';

    for(let letter of result){
        if(Number(letter) != 0){
            emptyString += letter;
        } else {
            break;
        }
    }

    return `${array[0]}.${emptyString}`;
}

console.log(rounding(10.5, 3));