function split(input) {
    let result = input[0].split(/[\s,;().]/g);
    let finalArray = [];

    for(let i=0;i < result.length;i++){
        if(result[i].length > 0){
            finalArray.push(result[i]);
        }
    }

    return finalArray.join('\n');
}

console.log(split(['let sum = 4 * 4,b = "wow";']));