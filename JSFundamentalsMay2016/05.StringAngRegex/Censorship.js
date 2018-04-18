function censor(text, arrPattern) {
    for (let element of arrPattern) {
        while(text.indexOf(element) !== -1){
            text = text.replace(element, '-'.repeat(element.length));
        }
    }

    return text;
}

console.log(censor('roses are red, violets are blue', [', violets are', 'red']));