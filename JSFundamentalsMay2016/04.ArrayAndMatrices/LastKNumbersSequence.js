function lastK(n, k) {
    let result = [1];
    for (let i = 1; i < n; i++) {
        let nextNumber = 0;
        let startNumber = i - k;

        if(startNumber < 0){
            startNumber = 0;
        }

        for (let j = startNumber; j < i; j++) {
            nextNumber += result[j];
        }

        result[i] = (nextNumber);
    }

    console.log(result.join(' '));
}

lastK(6, 3);