function countLetters(input, check) {
    let counter = 0;

    for(let letter of input){
        if(check === letter){
            counter++;
        }
    }

    return counter;
}

console.log(countLetters('hello', 'l'));