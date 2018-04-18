function extract(input) {
    let result = [];
    let start = input.indexOf('(');
    let end = input.indexOf(')', start);

    while(start !== -1 && end !== -1){
        result.push(input.substring(start + 1, end));

        start = input.indexOf('(', end + 1);
        end = input.indexOf(')', end + 1);
    }

    return result.join(', ');
}

console.log(extract('Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)'));