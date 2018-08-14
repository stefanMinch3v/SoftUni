const express = require("express");
const bodyParser = require("body-parser");
const fileUploader = require("express-fileupload");

// DB
const dbConfig = require("./config/dbConfig");

// Controllers
const homeController = require("./controllers/homeController");
const memeController = require("./controllers/memeController");
const apiController = require("./controllers/apiController");

// App
const app = express();
const port = 2323;

// Add Middlewares
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(fileUploader());
app.use("/public", express.static("public")); // all views reference files in the folder /public

// Add Routes
app.use("/", homeController);
app.use("/memes", memeController);
app.use("/api", apiController);

// Works only if Mongo is enabled
dbConfig
    .then(() => {
        app.listen(port, () => console.log(`Express Server is listening on port ${port}`));
    })
    .catch(err => {
        console.log("Failed to load DB");
        console.log(err);
    });
