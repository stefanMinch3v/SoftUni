const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');

// in order to work with tempdata
const cookieParser = require('cookie-parser');
const session = require('express-session');
const tempData = require('tempData');

module.exports = (app) => {
    app.engine('.hbs', handlebars({
        extname: '.hbs',
        layoutsDir: 'views/layouts',
        defaultLayout: 'main'
    }));

    app.set('view engine', '.hbs');

    app.use('/static', express.static('static'));
    app.use(bodyParser.urlencoded({ extended: true }));

    // custom in order to get tempData working
    app.use(cookieParser());
    app.use(session({
        secret: 'cookie_secret',
        name: 'cookie_name',
        proxy: true,
        resave: true,
        saveUninitialized: true
    }));
    app.use(tempData);
};