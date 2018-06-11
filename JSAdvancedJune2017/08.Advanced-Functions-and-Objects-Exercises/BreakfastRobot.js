function () {
    let menu = {
        apple: {carbohydrate: 1, flavour: 2},
        coke: {carbohydrate: 10, flavour: 20},
        burger: {carbohydrate: 5, flavour: 2, fat: 7},
        omelet: {carbohydrate: 5, flavour: 1, fat: 1},
        cheverme: {carbohydrate: 10, flavour: 10, fat: 10, protein: 10},
    };

    let inStock = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0
    };

    return function (inputString) {
        let inputData = inputString.split(' ');
        let command = inputData[0];

        switch(command) {
            case 'restock':
                let menuElement = inputData[1];
                let quantity = Number(inputData[2]);
                inStock[menuElement] += quantity;
                return 'Success';
            case 'prepare':
                let selectedProduct = inputData[1];
                let selectedProductQuantity = Number(inputData[2]);
                let currentProductStats = menu[selectedProduct];
                let canMakeOrder = true;

                for (let microElement in currentProductStats) {
                    if(currentProductStats.hasOwnProperty(microElement)){
                        let microElementQuantity = currentProductStats[microElement];
                        if(inStock[microElement] < microElementQuantity * selectedProductQuantity){
                            canMakeOrder = false;
                            return `Error: not enough ${microElement} in stock`;
                        }
                    }
                }

                if(canMakeOrder){
                    for (let microElement in currentProductStats) {
                        if(currentProductStats.hasOwnProperty(microElement)){
                            let microElementQuantity = currentProductStats[microElement];
                            inStock[microElement] -= microElementQuantity * selectedProductQuantity;
                        }
                    }
                    return 'Success';
                }

                break;
            case 'report':
                return `protein=${inStock.protein} carbohydrate=${inStock.carbohydrate} fat=${inStock.fat} flavour=${inStock.flavour}`;
        }
    };
};

manager('prepare cheverme 1');
manager('restock protein 10');
manager('prepare cheverme 1');
manager('restock carbohydrate 10');
manager('prepare cheverme 1');
manager('restock fat 10');
manager('prepare cheverme 1');
manager('restock flavour 10');
manager('prepare cheverme 1');
manager('report');
