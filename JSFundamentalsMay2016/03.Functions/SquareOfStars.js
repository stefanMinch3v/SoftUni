function square(n = 5) {
    function printStars(counter = n) {
        console.log('*' + ' *'.repeat(counter - 1))
    }

    for (let i = 1; i <= n; i++) {
        printStars();
    }
}

square();