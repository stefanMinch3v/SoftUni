function negativePositive(arr) {
    let result = [];
    arr.map(e => e < 0 ? result.unshift(e) : result.push(e));

    return result;
}

console.log(negativePositive([3, -2, 0, -1]));