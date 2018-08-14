const fs = require('fs');
const mimeTypes = {
    'css': 'text/css',
    'js': 'application/javascript',
    'png': 'image/png'
};

function staticHandler(req, res) {
    if(req.path.startsWith('/static/')) {
        const extension = req.path.split('.').pop();
        res.writeHead(200, {
            "Content-Type": mimeTypes[extension]
        });
        try {
            const read = fs.createReadStream('.' + req.path);
            read.pipe(res);
        } catch(err) {
            console.log(err);
            return true;
        }   
    } else {
        return true;
    }
}

module.exports = staticHandler;