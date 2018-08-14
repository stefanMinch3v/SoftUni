const productApi = require('../api/product');
const constants = require('../utilities/constants');

module.exports = {
    index: async (req, res) => {
        const successMsg = req.tempData.get(constants.SUCCESS_MESSAGE);
        const errorMsg = req.tempData.get(constants.ERROR_MESSAGE);

        try {
            let doners = await productApi.all();
            return res.render('home/index', { doners, successMsg, errorMsg });
        } catch (err) {
            console.log(err);
            req.locals.globalError = 'error', 'Unexpected error with fetching from the db.';
            return res.render('/home/index');
        }
    }
};