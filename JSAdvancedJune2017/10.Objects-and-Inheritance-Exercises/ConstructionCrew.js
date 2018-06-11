function solve(obj) {
    if(obj.hasOwnProperty('handsShaking')){
        if(obj.handsShaking){
            obj.bloodAlcoholLevel += 0.1 * obj.weight * obj.experience;
            obj.handsShaking = false;
        }

        return obj;
    }
}

console.log(solve({
    weight: 120, // kg
    experience: 20, // years
    bloodAlcoholLevel: 200, // ml
    handsShaking: true
}));