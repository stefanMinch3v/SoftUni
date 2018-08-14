const Product = require('mongoose').model('Product');
const allowedToppings = [
    'pickle', 'tomato', 'onion', 'lettuce', 'hot sauce', 'extra sauce'
];

async function create(data) {
    const category = data.category.trim();
    const imageUrl = data.imageUrl;
    const size = parseInt(data.size);
    const toppings = data.toppings
        .split(',')
        .map(e => e.trim())
        .filter(e => e.length > 0 && allowedToppings.includes(e));

    if (!category || category === '') {
        throw new Error('Invalid category.');
    }

    if (!imageUrl || imageUrl === '') {
        throw new Error('Invalid image url.');
    }

    if (Number.isNaN(size)) {
        throw new Error('Invalid size.');
    }

    if (toppings.length < 1) {
        throw new Error(`Invalid toppings, allowed: ${allowedToppings.join(',')}`);
    }

    try {
        return await Product.create({ category, imageUrl, size, toppings });
    } catch (error) {
        throw new Error('Unable to insert the data into the db!');
    }
}

async function getAll() {
    const products = await Product.find({});
    const chicken = products.filter(p => p.category === 'chicken');
    const beef = products.filter(p => p.category === 'beef');
    const lamb = products.filter(p => p.category === 'lamb');

    return { chicken, beef, lamb };
}

async function findOne(id) {
    if (!id) {
        throw new Error('Invalid id.');
    }

    try {
        return await Product.findById(id);
    } catch (error) {
        throw new Error('No such product!');
    }
}

module.exports = {
    create: create,
    all: getAll,
    getById: findOne
};