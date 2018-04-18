function filterByAge(compareAge, name1, age1, name2, age2) {
    let obj1 = {name: name1, age: age1};
    let obj2 = {name: name2, age: age2};

    if(obj1.age >= compareAge){
        console.log(obj1);
    }
    if(obj2.age >= compareAge){
        console.log(obj2);
    }
}

filterByAge(12, 'Ivan', 15, 'Asen', 9);