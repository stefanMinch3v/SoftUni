const mongoose = require('mongoose');
const ObjectId = mongoose.Schema.Types.ObjectId;

let rentSchema = new mongoose.Schema({
    user: { type: ObjectId, ref: 'User', required: true }, // ref user can be deleted cuz its not used we mainly use the ref car cuz we create rent based on cars
    car: { type: ObjectId, ref: 'Car', required: true },
    rentedOn: { type: Date, default: Date.now() },
    days: { type: Number, required: true },
    totalPrice: { type: Number, required: true }
});

let Rent = mongoose.model('Rent', rentSchema);

module.exports = Rent;