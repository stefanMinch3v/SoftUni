const encryption = require('../infrastructure/encryption');
const User = require('../models/User');
const Rent = require('../models/Rent');

module.exports = {
    registerGet: (req, res) => {
        return res.render('users/register');
    },
    registerPost: (req, res) => {
        const username = req.body.username.trim();
        const firstName = req.body.firstName.trim();
        const lastName = req.body.lastName.trim();
        const password = req.body.password;

        if((username === undefined || !username) ||
            (firstName === undefined || !firstName) ||
            (lastName === undefined || !lastName) ||
            password === undefined) {
            res.locals.errorMsg = "Invalid user data";
            return res.render('users/register');
        }

        const salt = encryption.generateSalt();
        const hashedPassword = encryption.generateHashedPassword(password, salt);

        User.create({
            username,
            firstName,
            lastName,
            salt,
            hashedPassword
        }).then(user => {
            // first way with req.logIn and second way is with passport.authenticate('local', { failureRedirect: '/users/login' }) added in the route
            // user below is always undefined
            req.logIn(user, (err, user) => {
                if(err) {
                    res.locals.errorMsg = err;
                    return res.render('users/register', user);
                }

                req.tempData.set('success', 'Successfully logged in.');
                res.redirect('/');
            });
        }).catch(err => {
            console.log(err);
            res.locals.errorMsg = 'Username is taken';
            res.render('users/register');
        });
    },
    loginGet: (req, res) => {
        return res.render('users/login');
    },
    loginPost: (req, res) => {
        return res.redirect('/');
    },
    logout: (req, res) => {
        req.logout();
        res.redirect('/');
    },
    profileGet: (req, res) => {
        let username = res.locals.user ? res.locals.user.username : 'no logged in user';
        let userId = req.user._id;

        Rent
            .find({ user: userId })
            .sort('-rentedOn')
            .populate('car')
            .then(rentedCars => {
                res.render('users/profile', { rentedCars, username });
            })
            .catch(err => {
                console.log(err);
                req.tempData.errorMsg = 'Unexpected error with fetching';
                res.redirect('/');
            });
    }
};