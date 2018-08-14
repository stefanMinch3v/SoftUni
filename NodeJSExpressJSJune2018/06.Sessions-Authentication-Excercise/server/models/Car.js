const mongoose = require('mongoose');

// mongoose validate messages can be customized with 
const REQUIRED_VALIDATION_MESSAGE = '{PATH} is required';

let carSchema = new mongoose.Schema({
    make: { type: String, required: true, REQUIRED_VALIDATION_MESSAGE },
    model: { type: String, required: true },
    price: { type: Number, required: true },
    imageUrl: { type: String, required: true },
    color: { type: String, default: 'random color' },
    isRented: { type: Boolean, default: false },
    timesRented: { type: Number, default: 0 }
});

let Car = mongoose.model('Car', carSchema);

module.exports = Car;