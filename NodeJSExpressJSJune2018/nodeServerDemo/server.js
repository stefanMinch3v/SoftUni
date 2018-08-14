const http = require('http');
const fs = require('fs');
const url = require('url');
const handlers = require('./handlers');

const server = http.createServer((req, res) => { // frontController
    req.path = url.parse(req.url).pathname;
    res.sendHtml = (path) => {
        fs.readFile(path, "utf8", (err, data) => {
            res.writeHead(200, {
                "Content-Type": "text/html"
            });
            res.write(data);
            res.end();
        });
    };

    if(req.method == 'GET') {
        for(let handler of handlers) {
            if(handler(req, res) !== true) {
                break;
            }
        }
    } else if(req.method == 'POST') {
        let body = '';
        req.on('data', data => {
            body += data;
        });
        req.on('end', () => {
            console.log(body);
            res.end();
        });
    }
});
server.listen(8000);