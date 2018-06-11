function carFactory(car) {
    let engine;
    let carriage;
    let wheelArr = [];

    if(car.power <= 90){
        engine = { power: 90, volume: 1800 };
    } else if(car.power <= 120){
        engine = { power: 120, volume: 2400 };
    } else{
        engine = { power: 200, volume: 3500 };
    }

    if(car.carriage === 'hatchback'){
        carriage = { type: car.carriage, color: car.color};
    } else if(car.carriage === 'coupe'){
        carriage = { type: car.carriage, color: car.color};
    }

    if(car.wheelsize % 2 === 0){
        car.wheelsize--;
    }

    for (let i = 0; i < 4; i++) {
        wheelArr.push(car.wheelsize);
    }

    return {
        model: car.model,
        engine: engine,
        carriage: carriage,
        wheels: wheelArr
    };
}

console.log(carFactory({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}));