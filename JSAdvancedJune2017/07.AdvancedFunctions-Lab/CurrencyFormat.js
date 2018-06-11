function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

function getDollarFormatter(formatter) {
    return function (value) {
        return formatter(',', '$', true, value);
    }
}

function getEuroFormatter(formatter) {
    return function (value) {
        return formatter(',', '€', false, value);
    }
}

let dollars = getDollarFormatter(currencyFormatter);
let euros = getEuroFormatter(currencyFormatter);
console.log(dollars(5345));
console.log(euros(3000));