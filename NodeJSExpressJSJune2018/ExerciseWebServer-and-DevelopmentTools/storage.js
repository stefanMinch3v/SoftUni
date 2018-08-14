const fs = require('fs');
const filePath = './database/storage.json';
let storage = {};

module.exports = {
    put: (key, value) => {
        if(typeof key !== "string") {
            throw new Error('The key must be string!');
        }
        if(storage[key]) {
            throw new Error('The present key already exists.');
        }
        storage[key] = value;
    },
    get: (key) => {
        if(typeof key !== "string") {
            throw new Error('The key must be string!');
        }
        if(!storage.hasOwnProperty(key)) {
            throw new Error('The present key does not exist.');
        }
        return storage[key];
    },
    getAll: () => {
        if(Object.keys(storage).length == 0) {
            console.log('The storage is empty!');
            return;
        }
        let result = '';
        for(let key in storage) {
            if(storage.hasOwnProperty(key)) {
                result += `${key} - ${storage[key]}\n`;
            }
        }
        return result;
    },
    update: (key, newValue) => {
        if(typeof key !== "string") {
            throw new Error('The key must be string!');
        }
        if(!storage.hasOwnProperty(key)) {
            throw new Error('The present key does not exist.');
        }
        storage[key] = newValue;
        console.log('Successfully updated!');
    },
    delete: (key) => {
        if(typeof key !== "string") {
            throw new Error('The key must be string!');
        }
        if(!storage.hasOwnProperty(key)) {
            throw new Error('The present key does not exist.');
        }
        delete storage[key];
        // storage.delete(key);
        console.log('Entry was successfully deleted!');
    },
    clear: () => {
        storage = {};
        console.log('Storage was successfully deleted!');
    },
    save: () => {
        fs.writeFileSync(filePath, JSON.stringify(storage));
        console.log('Successfully saved!');
    },
    load: () => {
        let result = fs.readFileSync(filePath);
        console.log(JSON.parse(result));
    },
    loadAsync: () => {
        return new Promise((resolve, reject) => {
            let data = fs.readFile(filePath, (err, data) => {
                if(err) {
                    reject(err);
                    console.log(err);
                    return;
                }
                let jsonData = JSON.parse(data);
                for (let key of Object.keys(jsonData)) {
                    storage[key] = jsonData[key];
                }
                resolve();
            });
        });

        
        // fs.readFile(filePath, (err, data) => {
        //     if(err) {
        //         return;
        //     }
        //     let jsonData = JSON.parse(data);
        //     for (let key of Object.keys(jsonData)) {
        //         console.log(key + ' ' + jsonData[key]);
        //         storage[key] = jsonData[key];
        //     }
        // });
    }
};