function concat(arr) {
    return Array.from(arr.join(''))
        .reverse()
        .join('');
}

console.log(concat(['I', 'am', 'student']));