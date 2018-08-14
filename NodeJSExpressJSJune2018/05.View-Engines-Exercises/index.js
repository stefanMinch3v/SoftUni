const env = 'development';

const express = require('express');
const settings = require('./config/settings')[env];
const database = require('./config/database');
const server = require('./config/server');
const routes = require('./config/routes');

database(settings);

const app = express();
const port = settings.port;;

// setup middlewares
server(app);

// setup routes
routes(app);

app.listen(port, () => console.log(`Server is listening at port ${port}`));