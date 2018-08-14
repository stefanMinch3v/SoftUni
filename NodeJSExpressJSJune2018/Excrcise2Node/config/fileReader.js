const fs = require("fs");
const path = require("path");
const placeHolder = require("./templates").placeHolderTemplate;

function readFile(response, pathName, dynamicContent, contentType) {
        if (!pathName) {
            throw new ReferenceError("Pathname is missing!");
        }

        if (!contentType) {
            contentType = "text/html";
        }
    
        pathName = path.join(__dirname, `../${pathName}`); // absolute path
    
        fs.readFile(pathName, (err, data) => {
            if (err) {
                console.log(err);
                generateStatusCode500();
                return;
            }
    
            if(dynamicContent) {
                data = data.toString().replace(placeHolder, dynamicContent);
            }
    
            generateStatusCode200(data);
        });

    function generateStatusCode500() {
        response.writeHead(500, {
            "Content-Type": "text/plain"
        });
        response.end(`Cannot read file with path: ${pathName}`);
    }
    
    function generateStatusCode200(data) {
        response.writeHead(200, {
            "Content-Type": contentType
        });
        response.write(data);
        response.end();
    }
}

module.exports = (response) => {
    response.view = (path, dynamicContent) => {
        readFile(response, path, dynamicContent, undefined);
    };

    response.staticFile = (path, contentType) => {
        readFile(response, path, undefined, contentType);
    };
};