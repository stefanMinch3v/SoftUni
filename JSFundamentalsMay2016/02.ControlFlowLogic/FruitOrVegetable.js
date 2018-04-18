function fruitOrVegetable(word) {
    let fruit = ['banana', 'apple', 'kiwi', 'cherry', 'lemon', 'grapes', 'peach'];
    let vegetables = ['tomato', 'cucumber', 'pepper', 'onion', 'garlic', 'parsley'];

    if(fruit.includes(word)){
        console.log('fruit');
    } else if(vegetables.includes(word)){
        console.log('vegetable');
    } else {
        console.log('unknown');
    }
}

fruitOrVegetable('apple');