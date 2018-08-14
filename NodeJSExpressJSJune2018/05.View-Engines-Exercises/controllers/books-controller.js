const Book = require('../data/Book');

module.exports = {
    getAddBook: (req, res) => {
        res.render('books/add');
    },
    postAddBook: (req, res) => {
        let book = req.body; // body appears from body-parser module set up in the server.js

        if(!book.title || !book.imageUrl) {
            book.error = 'Title and image url are required!';
            res.render('books/add', book);
            return;
        }

        book.releaseDate = new Date(book.releaseDate);

        Book.create(book).then(() => {
            req.tempData.set('success', 'Book added.');
            res.redirect('/all');
        });
    },
    getAllBooks: (req, res) => {
        //const page = +req.query.page;

        Book
            .find()
            .sort('-releaseDate')
            //.skip((page - 1) * 10)
            //.limit(10)
            .then(books => {
                let successMsg = req.tempData.get('success');
                res.render('books/all', { books, successMsg });
            });
    },
    getDetails: (req, res) => {
        const id = req.params.id;

        Book
            .findById(id)
            .then(book => {
                res.render('books/details', book);
            });
    }
};