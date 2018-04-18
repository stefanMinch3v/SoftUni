function getUsernames(arr) {
    let splitted = arr.map(e => e.split('@'));
    let result = [];

    for (let element of splitted) {
        let afterDot = '';
        element[1]
            .split('.')
            .map(e => afterDot += e[0]);

        result.push(`${element[0]}.${afterDot}`);
    }

    return result.join(', ');
}

console.log(getUsernames(['peshoo@gmail.com', 'todor_43@mail.dir.bg.d', 'foo@bar.com']));