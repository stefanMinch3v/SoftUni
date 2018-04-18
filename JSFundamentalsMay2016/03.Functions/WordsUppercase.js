function makeUppercase(input) {
    function extractWords() {
        return strUpper.split(/\W+/);
    };

    let strUpper = input.toUpperCase();
    let words = extractWords();
    words = words.filter(w => w != '');
    return words.join(', ');
};

console.log(makeUppercase('Hi, how are you?'));