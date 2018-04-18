function calcBoxes(n, k) {
    if(n <= k){
        return 1;
    }

    return Math.ceil(n / k);
}

console.log(calcBoxes(15, 7));