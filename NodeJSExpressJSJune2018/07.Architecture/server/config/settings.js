const path = require('path');

let rootPath = path.normalize(path.join(__dirname, '/../../'));

// Environment config
module.exports = {
    development: {
        rootPath: rootPath,
        db: 'mongodb://localhost:27017/generictemplate',
        port: 2323
    },
    staging: {
    },
    production: {
        port: process.env.PORT
    }
};