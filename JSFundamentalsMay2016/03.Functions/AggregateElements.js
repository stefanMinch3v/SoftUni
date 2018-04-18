function aggregate(elements) {
    let sum = function (input) {
        let operation = 0;
        for (let element of input) {
            operation += element;
        }

        console.log(operation);
    };

    let inverse = function (input) {
        let operation = 0;
        for (let element of input) {
            operation += 1/element;
        }

        console.log(operation);
    };

    let concat = function (input) {
        let operation = '';
        for (let element of input) {
            operation += element;
        }

        console.log(operation);
    };

    sum(elements);
    inverse(elements);
    concat(elements);
};

aggregate([2, 4, 8, 16]);

function aggregateElements(elements) {
    function aggregate(arr, initVal, func) {
        let val = initVal;
        for (let i = 0; i < arr.length; i++) {
            val = func(val, arr[i]);
        }

        console.log(val);
    };

    aggregate(elements, 0, (a, b) => a + b);
    aggregate(elements, 0, (a, b) => a + 1 / b);
    aggregate(elements, '', (a, b) => a + b);
};

aggregateElements([1, 2, 3]);
