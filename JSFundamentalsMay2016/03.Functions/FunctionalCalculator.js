function calculator(a, b, operation) {
    let f = function(a, b, op) {
        switch (op) {
            case '+': return a + b;
            case '-': return a - b;
            case '*': return a * b;
            case '/': return a / b;
            default : return null;
        }
    }

    return f(a, b, operation);
}

console.log(calculator(5, 5, '+'));
console.log(calculator(5, 5, '-'));
console.log(calculator(5, 5, '*'));
console.log(calculator(5, 5, '/'));