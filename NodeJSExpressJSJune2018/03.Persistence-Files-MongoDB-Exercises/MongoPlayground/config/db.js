const mongoose = require('mongoose');
const connectionString = 'mongodb://localhost:27017/mongoplayground';

require('../models/TagSchema');
require('../models/ImageSchema');

mongoose.Promise = global.Promise; // in order to use the same promise all over the app

module.exports = mongoose.connect(connectionString, { useNewUrlParser: true });;