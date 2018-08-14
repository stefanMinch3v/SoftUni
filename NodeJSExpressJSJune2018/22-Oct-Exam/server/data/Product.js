const mongoose = require('mongoose');

const REQUIRED_VALIDATION_MESSAGE = '{PATH} is required';
const SIZE_MIN_MESSAGE = 'Size must be minimum 17';
const SIZE_MAX_MESSAGE = 'Size must be maximum 24';

let productSchema = new mongoose.Schema({
    category: { type: String, enum: ['chicken, beef, lamb'], required: REQUIRED_VALIDATION_MESSAGE },
    imageUrl: { type: String, required: REQUIRED_VALIDATION_MESSAGE },
    size: { type: Number, min: [17, SIZE_MIN_MESSAGE], max: [24, SIZE_MAX_MESSAGE], required: REQUIRED_VALIDATION_MESSAGE },
    toppings: { type: [String], default: [] }
});

let Product = mongoose.model('Product', productSchema);

module.exports = Product;