function addRemoveArray(arr) {
    let num = 1;
    let result = [];

    for (let i = 0; i < arr.length; i++) {
        let command = arr[i];

        if(command === 'add'){
            result.push(num);
        } else if(command === 'remove'){
            result.pop();
        }

        num++;
    }

    return result.length == 0 ? 'Empty' : result.join('\n');
}

console.log(addRemoveArray(['add', 'add', 'remove', 'add', 'add']));;
