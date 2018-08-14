let env = process.env.NODE_ENV || "development";
let settings = require('./server/config/settings')[env];

const app = require('express')();

require('./server/config/database')(settings);
require('./server/config/express')(app); // middlewares
require('./server/config/routes')(app);
require('./server/config/passport')();

app.listen(settings.port, () => console.log(`Server is listening on port ${settings.port}`));