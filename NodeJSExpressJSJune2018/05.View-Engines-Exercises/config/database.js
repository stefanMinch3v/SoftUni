const mongoose = require('mongoose');

module.exports = (settings) => 
    mongoose.connect(settings.db, { useNewUrlParser: true }, err => {
        if(err) {
            console.log(err);
            return;
        }

        console.log('MongoDb is running on port 27017...');
    });