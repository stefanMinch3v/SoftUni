const productApi = require('../api/product');
const constants = require('../utilities/constants');

module.exports = {
    createGet: (req, res) => {
        res.render(constants.URL_CREATE_PRODUCT);
    },
    createPost: async (req, res) => {
        try {
            await productApi.create(req.body);
            req.tempData.set('success', 'Product successfully added');
            return res.redirect('/');  
        } catch (err) {
            console.log(err);
            res.locals.errorMsg = err.message;
            let formData = { imageUrl: req.body.imageUrl, size: req.body.size, toppings: req.body.toppings };
            return res.render(constants.URL_CREATE_PRODUCT, formData);
        }
    },
    editGet: (req, res) => {

    },
    editPost: (req, res) => {

    }
};