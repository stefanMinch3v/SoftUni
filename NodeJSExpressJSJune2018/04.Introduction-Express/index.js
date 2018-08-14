let express = require('express');
let bodyParser = require('body-parser');
let app = express();
let cats = require('./controllers/cats-controller');

let port = 2323;

// app.user(express.static('static folder'));

app.use(bodyParser.urlencoded({ extended: true }));

let authentication = (req, res, next) => {
    console.log('Authenticated');
    next();
};

app.get('/', authentication, (req, res) => {
    res.send('Hello from express with middleware.');
});

app.get('/home/index', (req, res) => {
    res.send('Hello from express.');
});

app.use('/cats', cats);

app.listen(port, () => console.log(`Listening on port: ${port}`));