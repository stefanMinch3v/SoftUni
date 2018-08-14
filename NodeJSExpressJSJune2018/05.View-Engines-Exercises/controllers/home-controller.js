const Book = require('../data/Book');

module.exports = {
    getIndex: (req, res) => {
        Book
            .countDocuments()
            .then(books => {
                res.render('index', { books });
            });
    }
};