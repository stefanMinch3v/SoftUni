const path = require('path');

//let rootPath = path.normalize(path.join(__dirname, "/../../"));

module.exports = {
    development: {
        // rootPath
        db: "mongodb://localhost:27017/carRentingSystem",
        port: 2323
    },
    staging: {},
    production: {
        port: process.env.PORT
    }
};