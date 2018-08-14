const Car = require('../models/Car');
const Rent = require('../models/Rent');

function isValidCarData(make, model, price, imageUrl){
    if((make === undefined || !make) ||
        (model === undefined || !model) ||
        (Number.isNaN(price) || price < 0) ||
        (imageUrl === undefined || !imageUrl)) {
        return false;
    }

    return true;
};

module.exports = {
    all: (req, res) => {
        let pageSize = 2;
        let page = parseInt(req.query.page) || 1;
        let search = req.query.search;

        let query = Car.find({});

        if(search) {
            query = query.where('make').regex(new RegExp(search, 'i'));
            // query = query.or([{make : new RegExp(search, 'i')}, {model : new RegExp(search, 'i')}]);
        }

        query
            .skip((page - 1) * pageSize)
            .limit(pageSize)
            .then(allCars => {
                let successMsg = req.tempData.get('success');
                let errorMsg = req.tempData.get('error');
                let hasPrevPage = page > 1;
                let hasNextPage = allCars.length > 0;
                let prevPage = page - 1;
                let nextPage = page + 1;
                res.render('cars/all', 
                    { allCars, hasPrevPage, hasNextPage, prevPage, nextPage, search, successMsg, errorMsg }
                );
            })
            .catch(err => {
                console.log(err);
                res.redirect('/');
            });
    },
    createGet: (req, res) => {
        res.render('cars/create');
    },
    createPost: (req, res) => {
        let make = req.body.make.trim();
        let model = req.body.model.trim();
        let price = Number(req.body.price);
        let imageUrl = req.body.imageUrl.trim();
        let color = req.body.color;

        if(!isValidCarData(make, model, price, imageUrl)) {
            res.locals.errorMsg = 'Invalid car data';
            let formData = { make, model, price, imageUrl, color };
            return res.render('cars/create', formData);
        }

        Car.create({
            make,
            model,
            price,
            imageUrl,
            color
        }).then(() => {
            req.tempData.set('success', 'Car successfully added');
            return res.redirect('/cars/all');
        }).catch(err => {
            console.log(err);
            res.locals.errorMsg = 'Invalid car data';
            return res.render('cars/create');
        });
    },
    editGet: async (req, res) => {
        try {
            const carId = req.params.id;
            let car = await Car.findById(carId);
            let errorMsg = req.tempData.get('error');
            res.render('cars/edit', { car, errorMsg });
        } catch(err) {
            console.log(err);
            res.render('cars/all');
        }
        // Car.findById(carId)
        //     .then(car => {
        //         res.render('cars/edit', { car });
        //     })
        //     .catch(err => {
        //         console.log(err);
        //         res.render('cars/all');
        //     });
    },
    editPost: async (req, res) => {
        let carId = req.body.id;
        let make = req.body.make.trim();
        let model = req.body.model.trim();
        let price = Number(req.body.price);
        let imageUrl = req.body.imageUrl.trim();
        let color = req.body.color;

        if(!isValidCarData(make, model, price, imageUrl)) {
            req.tempData.set('error', 'Invalid car data.');
            return res.redirect(`/cars/edit/${carId}`);
        }

        try {
            let car = await Car.findById(carId);
            if(car === null) {
                req.tempData.set('error', 'Error with car data.');
                return res.redirect('/cars/all');
            }

            car.make = make;
            car.model = model;
            car.price = price;
            car.imageUrl = imageUrl;
            car.color = color;
            await car.save();

            req.tempData.set('success', 'Car data successfully changed.');
            return res.redirect('/cars/all');
        } catch(err) {
            console.log(err);
            req.tempData.set('error', 'Error with car data.');
            return res.redirect('/cars/all');
        }
    },
    detailsGet: async (req, res) => {
        try {
            const carId = req.params.id;
            let car = await Car.findById(carId);
            let errorMsg = req.tempData.get('error');
            res.render('cars/details', { car, errorMsg });
        } catch(err) {
            console.log(err);
            res.render('cars/all');
        }
    },
    rentPost: (req, res) => {
        let userId = req.user._id;
        let carId = req.params.id;
        let days = parseInt(req.body.days);

        if(Number.isNaN(days) ||
             days < 1 || 
             days > 7) {
            res.locals.errorMsg = 'Invalid days';
            return res.render('cars/all');
        }

        Car
            .findById(carId)
            .then(car => {
                if(car.isRented) {
                    res.locals.errorMsg = 'This car is already rented.';
                    return res.render('cars/all');
                }

                Rent
                    .create({
                        user: userId,
                        car: carId,
                        days: days,
                        totalPrice: car.price * days
                    }).then(() => {
                        car.isRented = true;
                        car.timesRented += 1;
                        car
                            .save()
                            .then(() => {
                                req.tempData.set('success', 'Car was successfully rented.');
                                res.redirect('/cars/all');
                            });
                    }).catch(err => {
                        console.log(err);
                        res.locals.errorMsg = err;
                        res.render('cars/all');
                    });
            })
            .catch(err => {
                console.log(err);
                res.locals.errorMsg = err;
                res.render('cars/all');
            });
    }
};