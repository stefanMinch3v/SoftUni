const express = require('express');
const handlebars = require('express-handlebars');
const app = express();

app.engine('.hbs', handlebars({
    extname: '.hbs'
}));
app.set('view engine', '.hbs');

app.use('/', (req, res) => {
    res.render('home', {
        title: 'raboti'
    });
});

app.listen(2323);