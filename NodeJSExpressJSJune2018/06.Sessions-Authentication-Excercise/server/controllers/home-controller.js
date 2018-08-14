module.exports = {
    index: (req, res) => {
        const successMsg = req.tempData.get('success');
        const errorMsg = req.tempData.get('error');
        res.render('home/index', { successMsg, errorMsg });
    }
};