const mongoose = require('mongoose');
const User = require('../models/User');

//require('../models/Car'); ?
//require('../models/Rent'); ?

module.exports = settings => {
    mongoose.connect(settings.db, { useNewUrlParser: true }, err => {
        if(err) {
            console.log(err);
            return;
        }

        // seed method here
        User.seedAdministrator();

        console.log('MongoDb is running on port 27017');
    });
};