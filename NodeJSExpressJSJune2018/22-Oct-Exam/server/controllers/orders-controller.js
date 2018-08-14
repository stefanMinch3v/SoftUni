const productApi = require('../api/product');
const orderApi = require('../api/order');

function getOrderStatus(status) {
    let pending, progress, transit, delivered;
    switch (status) {
    case 'Pending':
        pending = true;    
        break;
    case 'In progress':
        progress = true;    
        break;
    case 'In transit':
        transit = true;    
        break;
    case 'Delivered':
        delivered = true;
        break;
    default:
        break;
    }

    return { pending, progress, transit, delivered };
}

module.exports = {
    placeGet: async (req, res) => {
        try {
            const productId = req.params.id;
            let product = await productApi.getById(productId);

            return res.render('orders/place', product);            
        } catch (err) {
            console.log(err);
            req.tempData.set('error', `${err}`);
            return res.redirect('/');
        }
    },
    placePost: async (req, res) => {
        try {
            let data = req.body;
            data.currentUserId = req.user._id;
            await orderApi.create(data);
            req.tempData.set('success', 'Your order was successfully placed.');
            return res.redirect('/');
        } catch (err) {
            console.log(err);
            req.tempData.set('error', `${err}`);
            return res.redirect(`/orders/place/${req.body.productId}`);
        }
    },
    status: async (req, res) => {
        try {
            const orders = await orderApi.getAllByUserId(req.user._id);

            return res.render('orders/status', { orders });
        } catch (err) {
            console.log(err);
            req.tempData.set('error', `${err}`);
            return res.redirect('/');
        }
    },
    details: async (req, res) => {
        try {
            const orderId = req.params.id;
            const order = await orderApi.getById(orderId);

            order.status = getOrderStatus(order.status);

            return res.render('orders/details', order);
        } catch (err) {
            console.log(err);
            req.tempData.set('error', `${err}`);
            return res.redirect('/');
        }
    },
    all: async (req, res) => {
        try {
            const orders = await orderApi.getAll();

            const successMsg = req.tempData.get('success');
            const errorMsg = req.tempData.get('error');

            return res.render('orders/status', { orders, successMsg, errorMsg });
        } catch (err) {
            console.log(err);
            req.tempData.set('error', `${err}`);
            return res.redirect('/');
        }
    },
    changeStatus: async (req, res) => {
        try {
            const data = req.body;
            await orderApi.changeStatus(data);

            req.tempData.set('success', 'The product was successfully changed.');
            return res.redirect('/orders/admins-status');
        } catch (err) {
            console.log(err);
            req.tempData.set('error', `${err}`);
            return res.redirect('/orders/admins-status');
        }
    }
};