function triangle(n) {
    function printStar(num) {
        console.log('*'.repeat(num));
    }

    for (let i = 1; i <= n; i++) {
        printStar(i);
    }

    for (let i = n - 1; i >= 1; i--) {
        printStar(i);
    }
}

triangle(5);