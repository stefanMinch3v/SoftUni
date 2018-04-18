function getBill(arr) {
    let products = [];
    let sum = 0;

    products.push(arr
        .filter((e, i) => i % 2 == 0)
        .join(', '));

    sum = arr
        .filter((e, i) => i % 2 == 1)
        .reduce((a, b) => Number(a) + Number(b));

    return `You purchased ${products.join(', ')} for a total sum of ${sum}`;
}

console.log(getBill(['Beer Zagorka', '2.65', 'Tripe soup', '7.80', 'Lasagna', '5.69']));