const Image = require('mongoose').model('Image');
const formidable = require('formidable');
const ObjectId = require('mongoose').Types.ObjectId;

module.exports = (req, res) => {
    if (req.pathname === '/addImage' && req.method === 'POST') {
        addImage(req, res);
    } else if (req.pathname === '/delete' && req.method === 'GET') {
        deleteImg(req, res);
    } else {
        return true;
    }
};

function addImage(req, res) { 
    const form = new formidable.IncomingForm();

    form.parse(req, (err, fields, files) => {
        if(err) {
            throw err;
        }

        const tags = Array.from(new Set(fields.tagsId.split(',')))
            .filter(e => e != '')
            .map(ObjectId);

        const image = {
            url: fields.imageUrl,
            description: fields.description,
            tags
        };

        Image.create(image)
            .then(img => {
                res.writeHead(302, {
                    location: '/'
                });
                res.end();
            })
            .catch(err => {
                res.writeHead(500, {
                    'Content-Type': 'text/plain'
                });
                res.write('500 Server error');
                res.end();
            });
    });
};

function deleteImg(req, res) { 
    // possible fixes - check if the user is authorized to delete and check if the id exists in db
    Image.deleteOne({_id: req.pathquery.id})
        .then(() => {
            res.writeHead(302, {
                location: '/'
            });
            res.end();
        })
        .catch(() => {
            res.writeHead(500, {
                'Content-Type': 'text/plain'
            });
            res.write('500 Server error');
            res.end();
        });
};