const controllers = require('../controllers');
const passport = require('passport');
const auth = require('./auth');
const adminRole = 'Admin';

module.exports = app => {
    // anonymous users
    app.get('/', controllers.home.index);

    // authenticated users
    app.get('/users/register', controllers.users.registerGet);
    app.post('/users/register', controllers.users.registerPost);
    app.get('/users/login', controllers.users.loginGet);
    app.get('/users/profile/me', auth.isAuthenticated, controllers.users.profileGet);
    app.post('/users/login', passport.authenticate('local', { failureRedirect: '/users/login' }), controllers.users.loginPost);
    app.get('/users/logout', auth.isAuthenticated, controllers.users.logout);

    // cars
    app.get('/cars/all', controllers.cars.all);
    app.get('/cars/create', auth.isInRole(adminRole), controllers.cars.createGet);
    app.post('/cars/create', auth.isInRole(adminRole), controllers.cars.createPost);
    app.get('/cars/edit/:id', auth.isInRole(adminRole), controllers.cars.editGet);
    app.post('/cars/edit', auth.isInRole(adminRole), controllers.cars.editPost);
    app.get('/cars/details/:id', auth.isAuthenticated, controllers.cars.detailsGet);
    app.post('/cars/rent/:id', auth.isAuthenticated, controllers.cars.rentPost);

    // not found pages
    app.all('*', (req, res) => {
        res.status(404);
        res.send('404 Not Found');
        res.end();
    });
};