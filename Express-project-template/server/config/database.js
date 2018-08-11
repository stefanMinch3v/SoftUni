const mongoose = require('mongoose');
const User = require('../data/User');

// mongoose.Promise = global.Promise; not needed anymore due to the new updates
module.exports = (settings) => {
    mongoose.connect(settings.db);
    let db = mongoose.connection;

    db.once('open', (err) => {
        if (err) {
            throw err;
        }

        console.log('MongoDB ready!');

        // add administrator if the db is empty
        User.seedAdminUser();
    });

    db.on('error', (err) => console.log(`Database error: ${err}`));
};