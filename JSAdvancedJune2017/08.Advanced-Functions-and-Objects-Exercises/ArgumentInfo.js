function result() {
    let arr = [];
    let argObjectTypes = {};
    let sortedArr = [];

    for (let element of arguments) {
        let type = typeof element;

        arr.push(`${type}: ${element}`);

        if(!argObjectTypes.hasOwnProperty(type)){
            argObjectTypes[type] = 0;
        }

        argObjectTypes[type] += 1;
    }

    for (let type in argObjectTypes) {
        if(argObjectTypes.hasOwnProperty(type)){
            let element = argObjectTypes[type];
            sortedArr.push([type, element]);
        }
    }

    sortedArr = sortedArr.sort((a, b) => {
       return b[1] - a[1];
    });

    console.log(arr.join('\n'));
    sortedArr.forEach(e => console.log(e.join(' = ')));
}

result(42, 'cat', [], undefined, undefined, null, null, null);