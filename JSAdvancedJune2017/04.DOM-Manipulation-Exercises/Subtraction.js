function subtract() {
    let numberA = Number(document.getElementById('firstNumber').value);
    let numberB = Number(document.getElementById('secondNumber').value);
    //let result = numberA - numberB;

    document.getElementById('result').textContent = numberA - numberB;
        //result % 1 != 0 ? result.toFixed(2) : result;
}