const router = require("express").Router();
const viewHomePath = "./source/views/home.html";

router.get("/", (req, res) => {
    res.sendfile(viewHomePath); // deprecated, change to absolute path with __dirname and path module
});

module.exports = router;
