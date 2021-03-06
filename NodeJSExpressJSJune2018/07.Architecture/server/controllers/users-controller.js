const encryption = require('../utilities/encryption');
const User = require('mongoose').model('User');
const constants = require('../utilities/constants');

module.exports = {
    registerGet: (req, res) => {
        res.render('users/register');
    },
    registerPost: (req, res) => {
        let reqUser = req.body;
        // Add validations here!

        let salt = encryption.generateSalt();
        let hashedPassword = encryption.generateHashedPassword(salt, reqUser.password);

        User.create({
            username: reqUser.username,
            firstName: reqUser.firstName,
            lastName: reqUser.lastName,
            salt: salt,
            hashedPass: hashedPassword
        }).then(user => {
            req.logIn(user, (err, user) => {
                if (err) {
                    res.locals.globalError = err;
                    res.render('users/register', user);
                }
                
                req.tempData.set(constants.SUCCESS_MESSAGE, 'Successfully logged in.');
                res.redirect('/');
            });
        });
    },
    loginGet: (req, res) => {
        res.render('users/login');
    },
    loginPost: (req, res) => {
        // first way with with passport.authenticate('local', { failureRedirect: '/users/login' }) added in the route for loginPost and here just add a simple line: res.redirect('/');
        let reqUser = req.body;
        User
            .findOne({ username: reqUser.username }).then(user => {
                // can be done with redirect and tempdata
                if (!user) {
                    res.locals.globalError = 'Invalid user data';
                    res.render('users/login');
                    return;
                }

                if (!user.authenticate(reqUser.password)) {
                    res.locals.globalError = 'Invalid user data';
                    res.render('users/login');
                    return;
                }

                req.logIn(user, (err, user) => {
                    if (err) {
                        res.locals.globalError = err;
                        res.render('users/login');
                    }

                    res.redirect('/');
                });
            });
    },
    logout: (req, res) => {
        req.logout();
        req.tempData.set(constants.SUCCESS_MESSAGE, 'Successfully logged out.');
        res.redirect("/");
    },
    adminPage: (req, res) => {
        res.render('users/example-admin-page');
    }
};