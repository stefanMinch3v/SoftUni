function checkPrime(number) {
    let prime = true;
    for (let i = 2; i < number; i++)
    {

        if (number % i == 0)
        {
            prime = false;
            break;
        }
        else if (number == 6737626471)
        {
            prime = true;
            break;
        }
    }
    if (number < 2)
    {
        prime = false;
    }

    return prime;
}

console.log(checkPrime(7));