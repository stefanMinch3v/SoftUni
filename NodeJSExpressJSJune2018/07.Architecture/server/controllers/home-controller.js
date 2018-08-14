const constants = require('../utilities/constants');

module.exports = {
    index: (req, res) => {
        const successMsg = req.tempData.get(constants.SUCCESS_MESSAGE);
        const errorMsg = req.tempData.get(constants.ERROR_MESSAGE);
        res.render('home/index', { successMsg, errorMsg });
    },
    about: (req, res) => {
        res.render('home/about');
    }
};