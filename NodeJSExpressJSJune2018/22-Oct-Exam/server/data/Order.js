const mongoose = require('mongoose');
const ObjectId = mongoose.Schema.Types.ObjectId;

const REQUIRED_VALIDATION_MESSAGE = '{PATH} is required';

let orderSchema = new mongoose.Schema({
    creatorId: { type: ObjectId, ref: "User", required: REQUIRED_VALIDATION_MESSAGE },
    productId: { type: ObjectId, ref: "Product", required: REQUIRED_VALIDATION_MESSAGE },
    dateOfCreation: { type: Date, default: Date.now },
    status: { type: String, enum: ['Pending', 'In progress', 'In transit', 'Delivered'], default: 'Pending'},
    toppings: { type: [String] }
});

let Order = mongoose.model('Order', orderSchema);

module.exports = Order;