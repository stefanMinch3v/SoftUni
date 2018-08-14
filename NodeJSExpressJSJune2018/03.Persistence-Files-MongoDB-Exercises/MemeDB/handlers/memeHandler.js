const fs = require('fs-extra');
const db = require('./../config/dataBase');
const qs = require('querystring');
const url = require('url');
const formidable = require('formidable');
const shortid = require('shortid');
const path = require('path');

const placeholderTemplate = '<div id="replaceMe">{{replaceMe}}</div>';
const viewAllPath = './views/viewAll.html';
const viewAddPath = './views/addMeme.html';
const viewDetailsPath = './views/details.html';

let viewAll = (req, res) => {
  let memes = db.getDb();
  memes = memes
    .sort((a, b) => { return b.dateStamp - a.dateStamp; })
    .filter(m => m.privacy === 'on');

  let memeString = '';
  for (let meme of memes) {
    memeString += `
    <div class="meme">
      <a href="/getDetails?id=${meme.id}">
      <img class="memePoster" src="${meme.memeSrc}"/>          
    </div>`;
  }

  fs.readFile(viewAllPath, 'utf8', (err, data) => {
    if (err) {
      console.log(err);
      generateStatusCode500(res, viewAllPath);
      return;
    }

    data = replaceDataWithDynamicContent(data, memeString);

    generateStatusCode200(res, data);
  });
};

let viewAddMeme = (req, res) => {
  fs.readFile(viewAddPath, 'utf8', (err, data) => {
    if (err) {
      console.log(err);
      generateStatusCode500(res, viewAddPath);
      return;
    }

    generateStatusCode200(res, data);
  });
};

let addMeme = (req, res) => {
  let form = new formidable.IncomingForm();
  let dbLength = Math.ceil(db.getDb().length / 10);
  let fileName = shortid.generate() + '.jpg';
  let memePath = `./public/memeStorage/${dbLength}`;
  let memeAbsolutePath = path.join(__dirname, `../${memePath}/`);
  let oldPath = '';

  form.on('error', (err) => {
    console.log(err);
  }).on('fileBegin', (name, file) => {
    fs.access(memePath, (err) => {
      // check if the directory does not exist then create it
      if (err) {
        console.log(err);
        fs.mkdirSync(memePath);
      }

      oldPath = file.path;
      file.path = memePath + "/" + fileName;
    });
  });

  form.parse(req, function (err, fields, files) {
    if (err) {
      console.log(err);
      generateStatusCode500(res, 'Error with uploading');
      return;
    }

    let id = shortid.generate();
    let title = fields.memeTitle;
    let description = fields.memeDescription;
    let privacy = fields.status;
    
    //console.log(files.meme.path);
    let memeSrc = `${memePath}/${fileName}`;
    let newMeme = memeGenerator(id, title, description, memeSrc, privacy);

    db.add(newMeme);
    db.save().then(generateStatusCode200(res, 'successfully added!'));
  }).on('end', function(fields, files) {
    // fs extra allowes to move files from one partition to another - for example from (ssd)C:/ to (hdd)D:/
    fs.move(oldPath, memeAbsolutePath + fileName, function (err) {
      if (err) {
        console.log("FS error/n" + err);
        return;
      }

      console.log('img saved in meme storage');
    });
  });
};

let getDetails = (req, res) => {
  let id = qs.parse(url.parse(req.url).query).id;
  if (id === undefined || id === null) {
    console.log('Error with meme id');
    // todo send internal error or whatever
    generateStatusCode500(res, id);
    return;
  }

  let meme = db.getDb().find(m => m.id === id);
  if (meme === undefined || meme === null) {
    console.log('Error with memes');
    // todo send internal error or whatever
    generateStatusCode500(res, id);
    return;
  }

  let memeString = `
  <div class="content">
    <img src="${meme.memeSrc}" alt=""/>
    <h3>Title  ${meme.title}</h3>
    <p> ${meme.description}</p>
    <button><a href="${meme.memeSrc}" download="${meme.title}.jpg">Download Meme</a></button>
  </div>`;

  fs.readFile(viewDetailsPath, 'utf8', (err, data) => {
    if (err) {
      console.log(err);
      generateStatusCode500(res, viewDetailsPath);
      return;
    }

    data = replaceDataWithDynamicContent(data, memeString);

    generateStatusCode200(res, data);
  });
};

function generateStatusCode200(res, data) {
  res.writeHead(200, {
    "Content-Type": 'text/html'
  });
  res.write(data);
  res.end();
};

function generateStatusCode500(res, pathName) {
  res.writeHead(500, {
    "Content-Type": "text/plain"
  });
  res.end(`Cannot read file with path: ${pathName}`);
}

function memeGenerator(id, title, description, memeSrc, privacy) {
  return {
    id: id,
    title: title,
    description: description,
    memeSrc: memeSrc,
    dateStamp: Date.now(),
    privacy: privacy
  };
}

function replaceDataWithDynamicContent(data, dynamicContent) {
  return data.toString().replace(placeholderTemplate, dynamicContent);
}

module.exports = (req, res) => {
  if (req.pathname === '/viewAllMemes' && req.method === 'GET') {
    viewAll(req, res);
  } else if (req.pathname === '/addMeme' && req.method === 'GET') {
    viewAddMeme(req, res);
  } else if (req.pathname === '/addMeme' && req.method === 'POST') {
    addMeme(req, res);
  } else if (req.pathname.startsWith('/getDetails') && req.method === 'GET') {
    getDetails(req, res);
  } else {
    return true;
  }
};
