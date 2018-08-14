// const mongodb = require('mongodb');

// let connection = 'mongodb://localhost:27017/cats';

// mongodb
//     .MongoClient
//     .connect(connection)
//     .then(client => {
//         let db = client.db('cats');
//         let dogs = db.collection('dogs');

//         dogs.insert({
//             name: 'gosho',
//             age: 31,
//             color: 'red',
//             breed: 'some breed'
//         });

//         dogs.find({}).toArray((err, dogs) => console.log(dogs));
//     });

const mongoose = require('mongoose');

let catSchema = new mongoose.Schema({
    name: { type: String, required: true },
    age: { type: Number, required: true },
    color: { type: String }
});

// validation example
catSchema.path('age').validate(function () {
    return this.age >= 1 && this.age <= 20;
}, 'Age must be between 1 and 20!');

// can attach function
catSchema.methods.sayHello = function () {
    return `Hi from ${this.name}`;
};

// can attach property which is not saved in the db
catSchema.virtual('description').get(function () {
    return `${this.name} - ${this.age}`;
});

let Cat = mongoose.model('Cat', catSchema);

// let Owner = mongoose.model('Owner', {
//     firstName: { type: String, required: true },
//     lastName: { type: String, required: true },
//     cats: [Cat.schema],
// });

mongoose
    .connect('mongodb://localhost:27017/cats')
    .then(() => {
        // let newCat = new Cat({
        //     name: 'Ivan',
        //     age: 20,
        //     color: 'red'
        // });

        // newCat.save();

        // Cat.find({}).then(cats => {
        //     console.log(cats);
        // });

        // Cat.find({}).then(cats => {
        //     let owner = new Owner({
        //         firstName: 'Gosho',
        //         lastName: 'Goshev',
        //         cats
        //     });
    
        //     owner.save();
        // });

        //Cat.findOne().then(cat => console.log(cat.description));

        Cat
            .find()
            .where('age').gt(5).lt(10)
            .where('name').equals('Pesho')
            .sort('name')
            .select('name color')
            .limit(10)
            .then(cats => console.log(cats));
    });