const fs = require('fs');
const Image = require('mongoose').model('Image');
const Tag = require('mongoose').model('Tag');
const ObjectId = require('mongoose').Types.ObjectId;
const placeholder = `<div class='replaceMe'></div>`;

module.exports = (req, res) => {
    if (req.pathname === '/search') {
        fs.readFile('./views/results.html', 'utf8', (err, fileHtml) => {
            if(err) {
                throw err;
            }
            const query = req.pathquery;
            const afterDate = query.afterDate || new Date(-8640000000000000);
            const beforeDate = query.beforeDate || Date.now();
            const limit = query.Limit || 10;

            if(query.tagName) {
                const tags = req.pathquery.tagName
                    .split(',')
                    .filter(t => t.length > 0);
                if(tags.length > 0) {
                    Tag.find({name: { $in: tags }}).then(foundedTags => {
                        const tagsIds = foundedTags.map(e => ObjectId(e._id)); // the new version requires to be parsed to Object id
                        Image.find({tags: { $in: tagsIds }})
                            .limit(Number(limit)) // optional
                            .then(images => {
                                responWithCorrectData(images);
                            });
                    });
                }
                return;
            } 

            Image.find({
                creationDate: { $gte: afterDate, $lt: beforeDate }
            })
                .limit(Number(limit))
                .then(data => {
                    responWithCorrectData(data);
                });

            function responWithCorrectData(data) {       
                let imgHtml = '';
                for(let image of data) {
                    imgHtml += imageTemplate(image);
                }
                fileHtml = fileHtml.toString().replace(placeholder, imgHtml);
        
                res.writeHead(200, {
                    'Content-Type': 'text/html'
                });
                res.write(fileHtml);
                res.end();
            }
        });
    } else {
        return true;
    }
};

function imageTemplate(image) { 
    return `
    <fieldset id="${image._id}"
        <img src="${image.url}"/>
        <p>${image.description}<p/>
        <button onclick='location.href="/delete?id=${image._id}"'class='deleteBtn'>Delete</button> 
    </fieldset>`;
}