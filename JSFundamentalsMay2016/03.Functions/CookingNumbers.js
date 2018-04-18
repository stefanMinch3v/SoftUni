function cookingNums(input) {
    let number = Number(input[0]);

    let chop = function () {
        console.log(number /= 2);
    };

    let dice = function () {
        console.log(number = Math.sqrt(number));
    };

    let spice = function () {
        console.log(++number);
    };

    let bake = function () {
        console.log(number *= 3);
    };

    let fillet = function () {
        console.log(number = number - (number * 0.2));
    };

    for (let i = 1; i < input.length; i++) {
        switch (input[i]){
            case 'chop': chop(); continue;
            case 'dice': dice(); continue;
            case 'spice': spice(); continue;
            case 'bake': bake(); continue;
            case 'fillet': fillet(); continue;
        }
    }
}

cookingNums([32, 'chop', 'chop', 'chop', 'chop', 'chop']);


function cookingNumsSeconds(input) {
    let number = Number(input[0]);

    let chop = (n) => n / 2;

    let dice = (n) => Math.sqrt(n);

    let spice = (n) => ++n;

    let bake = (n) => n * 3;

    let fillet = (n) => n -= n * 0.2;

    for (let i = 1; i < input.length; i++) {
        switch (input[i]){
            case 'chop':
                number = chop(number);
                break;
            case 'dice':
                number = dice(number);
                break;
            case 'spice':
                number = spice(number);
                break;
            case 'bake':
                number = bake(number);
                break;
            case 'fillet':
                number = fillet(number);
                break;
        }

        console.log(number);
    }
}

cookingNumsSeconds([32, 'chop', 'chop', 'chop', 'chop', 'chop']);