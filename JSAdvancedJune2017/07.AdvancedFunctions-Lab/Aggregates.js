function aggregate(arr) {
    function reduce(arr, func) {
        let result = arr[0];
        for (let el of arr.slice(1))
            result = func(result, el);
        return result;
    }

    console.log('Sum = ' + reduce(arr, (a, b) => Number(a) + Number(b)));
    console.log('Product = ' + reduce(arr, (a, b) => Number(a) * Number(b)));
    console.log('Join = ' + reduce(arr, (a, b) => '' + a + b));
    console.log('Max = ' + reduce(arr, (a, b) => Number(a) > Number(b) ? a : b));
    console.log('Min = ' + reduce(arr, (a, b) => Number(a) > Number(b) ? b : a));

}

let arr = ['5', '-3', '20', '7', '0.5'];
aggregate(arr);