const controlles = require('../controllers');
const auth = require('./auth');

module.exports = (app) => {
    // home page
    app.get('/', controlles.home.index);
    app.get('/index', controlles.home.index);

    // users page
    app.get('/users/register', controlles.users.registerGet);
    app.post('/users/register', controlles.users.registerPost);
    app.get('/users/login', controlles.users.loginGet);
    app.post('/users/login', controlles.users.loginPost); // passport.authenticate('local', { failureRedirect: '/users/login' }) / another way
    app.get('/users/logout', auth.isAuthenticated, controlles.users.logout); // get/post

    // admins page
    app.get('/orders/admins-status', auth.isInRole('Admin'), controlles.orders.all);
    app.post('/orders/admins-status', auth.isInRole('Admin'), controlles.orders.changeStatus);
    app.get('/products/create', auth.isInRole('Admin'), controlles.products.createGet);
    app.post('/products/create', auth.isInRole('Admin'), controlles.products.createPost);

    // orders page
    app.get('/orders/place/:id', auth.isAuthenticated, controlles.orders.placeGet);
    app.post('/orders/place', auth.isAuthenticated, controlles.orders.placePost);
    app.get('/orders/status', auth.isAuthenticated, controlles.orders.status);
    app.get('/orders/details/:id', auth.isAuthenticated, controlles.orders.details);
    
    // not found pages
    app.all('*', (req, res) => {
        res.status(404);
        res.send('404 Not Found');
        res.end();
    });
};