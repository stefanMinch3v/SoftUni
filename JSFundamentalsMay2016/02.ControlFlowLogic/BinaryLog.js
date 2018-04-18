function binaryLog(number) {
    for(let num of number){
        console.log(Math.log2(num));
    }
}

binaryLog([12, 2, 55, 71, 1]);