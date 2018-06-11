function sortArr(arr, order) {

    let ascOrder = function (a, b) {
        return a - b;
    };

    let descOrder = function (a, b) {
        return b - a;
    };

    let sortingOrder = {
        'asc': ascOrder,
        'desc': descOrder
    };

    return arr.sort(sortingOrder[order]);
}

console.log(sortArr2([14, 7, 17, 6, 8], 'asc'));

function sortArr2(arr, order) {
    if(order === 'asc'){
        return (arr.sort((a, b) => {
            return a - b;
        }));
    } else {
        return (arr.sort((a, b) => {
            return b - a;
        }));
    }
}