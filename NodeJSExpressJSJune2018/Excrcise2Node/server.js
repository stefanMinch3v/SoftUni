const http = require("http");
const url = require("url");
const port = 8000;

const attachFileReader = require("./config/fileReader");
const postParserMiddleware = require("./config/postParser");
const handlers = require("./handlers"); // by default looks for index.js file otherwise cant iterate thr handlers

http.createServer(mainController).listen(port);
console.log(`Server listening on port ${port}`);

function mainController(req, res) {
    console.log(req.url);
    
    req.path = url.parse(req.url).pathname;
    attachFileReader(res);

    postParserMiddleware(req, res)
        .then(postData => {
            for (let handler of handlers) {
                if (handler(req, res) !== true) {
                    break;
                }
            }
        });
}