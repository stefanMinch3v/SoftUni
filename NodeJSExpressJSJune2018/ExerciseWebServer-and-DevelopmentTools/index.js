const storage = require('./storage');

function putMyGDPRSensitiveInfo() {
    storage.put('firstName', 'pesho');
    storage.put('lastName', 'peshev');
    storage.put('age', '33');
    storage.put('hobbies', {
        games: [
            'Warcraft 3',
            'Counter-Strike all versions',
            'Heroes 3',
            'GTA 5',
            'Broken Sword all versions'
        ],
        movies: [
            'Rocky',
            'Rambo',
            'Untouchables'
        ],
        sports: [
            'box',
            'football',
            'swimming'
        ]
    });
}

function getMyGDPRSensitiveInfo() {
    let firstName = storage.get('firstName');
    let lastName = storage.get('lastName');
    let age = storage.get('age');
    let hobbies = storage.get('hobbies');

    console.log(
        'All sensitive data\n',
        `Names: ${firstName} ${lastName}\n`,
        `Age: ${age}\n`,
        'Hobbies :');
        for(let hobby in hobbies) {
            if(hobbies.hasOwnProperty(hobby)) {
                console.log(`--- ${hobby}: ${hobbies[hobby].join(', ')}`);
            }
        }
}

putMyGDPRSensitiveInfo();
getMyGDPRSensitiveInfo();
// storage.loadAsync()
//     .then(() => {
//         console.log(storage.getAll());
//     })
//     .catch((err) => {
//         console.log(err);
//     });