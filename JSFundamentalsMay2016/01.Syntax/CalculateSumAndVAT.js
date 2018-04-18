function sumVat(arr) {
    let sum = 0;

    for(let i = 0; i < arr.length; i++){
        sum += arr[i];
    }

    console.log(`sum = ${sum}`);
    console.log(`VAT = ${sum * 0.20}`);
    console.log(`total = ${sum * 1.20}`);
}

sumVat([1.20, 2.60, 3.50]);