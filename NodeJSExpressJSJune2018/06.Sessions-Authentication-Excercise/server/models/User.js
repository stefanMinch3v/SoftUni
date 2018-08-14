const mongoose = require('mongoose');
const encryption = require('../infrastructure/encryption');

let userSchema = new mongoose.Schema({
    username: { type: String, required: true, unique: true },
    firstName: { type: String, required: true },
    lastName: { type: String, required: true },
    salt: { type: String },
    hashedPassword: { type: String },
    roles: [{ type: String }],
    rentedCars: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Car', default: [] }] // this field can be deleted
});

userSchema.method({
    authenticate: function (password) { 
        return encryption.generateHashedPassword(password, this.salt) === this.hashedPassword;
    }
});

let User = mongoose.model('User', userSchema);

module.exports = User;
module.exports.seedAdministrator = () => {
    User.find({}).then(users => {
        if(users.length > 0) {
            return;
        }

        let salt = encryption.generateSalt();
        let hashedPassword = encryption.generateHashedPassword('admin12', salt);

        User.create({
            username: 'admin',
            firstName: 'admin',
            lastName: 'admin',
            salt: salt,
            hashedPassword: hashedPassword,
            roles: ['Admin'],
            rentedCars: []
        }).then(console.log('Admin added to db!'));
    });
};