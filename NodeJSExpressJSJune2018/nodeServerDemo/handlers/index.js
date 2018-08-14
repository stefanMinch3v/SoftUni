const staticHandler = require('./static');
const homeHandler = require('./home');
const errorHandler = require('./error');
const aboutHandler = require('./about');
const dataHandler = require('./data');

module.exports = [
    staticHandler,
    homeHandler,
    aboutHandler,
    dataHandler,
    errorHandler
];