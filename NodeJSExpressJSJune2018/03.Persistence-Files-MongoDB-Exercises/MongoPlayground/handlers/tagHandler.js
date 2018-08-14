const formidable = require('formidable');
const Tag = require('mongoose').model('Tag');
const util = require('util');

module.exports = (req, res) => {
    if (req.pathname === '/generateTag' && req.method === 'POST') {
        const form = new formidable.IncomingForm();

        form.parse(req, function(err, fields, files) {
            res.writeHead(200, {
                'Content-Type': 'text/plain'
            });

            const name = fields.tagName;
            Tag.create({
                name,
                images: []
            }).then(tag => {
                res.writeHead(302, {
                    location: '/'
                });
                res.end();
            }).catch(err => {
                res.writeHead(500, {
                    'Content-Type': 'text/plain'
                });
                res.write('500 Server error');
                res.end();
            });
            // display info
            // res.end(util.inspect({
            //     fields,
            //     files
            // }));
        });
    } else {
        return true;
    }
};


// // circular reference solution
// const cache = [];
// res.write(JSON.stringify(req, function (key, value) {
//     if(typeof value === 'object' && value !== null) {
//         if(cache.indexOf(value) !== -1) {
//             // Duplicate reference found
//             try {
//                 // If this value does not reference a parent it can be deduped
//                 return JSON.parse(JSON.stringify(value));
//             } catch(err) {
//                 // discard key if value cannot be deduped
//                 return;
//             }
//         }
//         // Store value in the collection
//         cache.push(value);
//     }
//     return value;
// }));
