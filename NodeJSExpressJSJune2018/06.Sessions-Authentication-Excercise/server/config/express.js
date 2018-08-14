const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');
const path = require('path');
const cookieParser = require('cookie-parser');
const session = require('express-session');
const passport = require('passport');
const tempData = require('tempData');
//const flash = require('connect-flash');

const viewsDir = path.join(__dirname, '../views');

// middlewares
module.exports = app => {
    app.engine('.hbs', handlebars({
        extname: '.hbs',
        defaultLayout: 'main',
        layoutsDir: `${viewsDir}/layouts`
    }));
    
    app.set('view engine', '.hbs');
    app.set('views', viewsDir);

    app.use(express.static('public'));
    app.use(bodyParser.urlencoded({ extended: true }));
    app.use(cookieParser());
    app.use(session({
        secret: 'secret_session',
        resave: false,
        saveUninitialized: false
    }));
    app.use(tempData);
    //app.use(flash());
    app.use(passport.initialize());
    app.use(passport.session());
    app.use((req, res, next) => {
        if(req.user) {
            res.locals.user = {
                username: req.user.username,
                isAdmin: req.user.roles.indexOf('Admin') != -1
            };
        }

        next();
    });
    console.log('Express loaded');
};