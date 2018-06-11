function solve(a, b) {
    return recursive(a, b);

    function recursive(a, b){
        if(b == 0){
            return a;
        } else {
            return recursive(b, a % b);
        }
    }
}

console.log(solve(252, 105));
