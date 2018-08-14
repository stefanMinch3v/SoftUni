const Order = require('mongoose').model('Order');

async function create(data) {
    const productId = data.productId;
    const creatorId = data.currentUserId;
    const toppings = data.toppings;

    if (!productId) {
        throw new Error('Invalid product');
    }

    if (!creatorId) {
        throw new Error('Invalid user');
    }

    try {
        return await Order.create({ productId, creatorId, toppings });
    } catch (err) {
        throw new Error('Unable to unsert data in the db.');
    }
}

async function getAllByUserId(currentUserId) {  
    try {
        const orders = await Order
            .find({ creatorId: currentUserId })
            .sort('-dateOfCreation')
            .populate('productId');

        let filteredOrders = await filterOrdersDtos(orders);
        
        return filteredOrders;
    } catch (err) {
        throw new Error('No such user/order.');
    }
}

async function getByOrderId(orderId) {  
    // check if the current user is logged in / is admin
    try {
        const orderInfo = await Order
            .findById(orderId)
            .populate('productId');

        let filteredOrder = {};

        filteredOrder.imageUrl = orderInfo.productId.imageUrl;
        filteredOrder.category = orderInfo.productId.category;
        filteredOrder.size = orderInfo.productId.size;
        filteredOrder.dateOfCreation = orderInfo.dateOfCreation.toLocaleString('en-GB', { timeZone: 'Europe/Copenhagen', hour12: false });
        filteredOrder.toppings = orderInfo.toppings;
        filteredOrder.status = orderInfo.status;

        return filteredOrder;
    } catch (err) {
        throw new Error('Invalid order.');
    }
}

async function getAll() { 
    try {
        const orders = await Order
            .find({})
            .sort('-dateOfCreation')
            .populate('productId')
            .populate('creatorId');

        let filteredOrders = await filterOrdersDtos(orders);

        return filteredOrders;
    } catch (err) {
        throw new Error('Error with fetching all orders from the db.');
    }
}

async function filterOrdersDtos(orders) {
    let filteredOrders = [];

    orders.forEach(async o => {
        let orderObj = {};

        if (o.creatorId) {
            orderObj.username = o.creatorId.username;
            
            if (orderObj.username) {
                orderObj.isAdmin = true;
            }
        }

        // .toString().split('(')[0].trim()
        orderObj.id = o._id,
        orderObj.dateOfCreation = o.dateOfCreation.toLocaleString('en-GB', { timeZone: 'Europe/Copenhagen', hour12: false }),
        orderObj.category = o.productId.category,
        orderObj.size = o.productId.size,
        orderObj.status = o.status;
        await filteredOrders.push(orderObj);
    });

    return filteredOrders;
}

async function changeStatusForAdmins(data) {
    try {
        const arrayInfo = data.statusAndId.split('-');
        const status = arrayInfo[0];
        const productId = arrayInfo[1];

        if (!status) {
            throw new Error('Invalid product status.');
        }

        if (!productId) {
            throw new Error('Invalid product id.');
        }

        await Order.findByIdAndUpdate(productId, { $set: { status: status }}, { runValidators: true });
    } catch (err) {
        throw new Error('Unable to change product status.');
    }
}

module.exports = {
    create: create,
    getAllByUserId: getAllByUserId,
    getById: getByOrderId,
    getAll: getAll,
    changeStatus: changeStatusForAdmins
};