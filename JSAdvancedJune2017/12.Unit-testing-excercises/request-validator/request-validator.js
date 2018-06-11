function validateRequest(httpObj) {
    const allowedMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const allowedVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    if(typeof httpObj !== 'object'){
        throw new Error('Expected argument to be an object');
    }

    if(!httpObj.hasOwnProperty('method') || !allowedMethods.includes(httpObj.method)){
        throw new Error('Invalid request header: Invalid Method');
    }

    const urlPattern = /^(\*|[a-zA-Z0-9\.]+)$/g;
    if(!httpObj.hasOwnProperty('uri') || !urlPattern.exec(httpObj.uri)){
        throw new Error('Invalid request header: Invalid URI');
    }

    if(!httpObj.hasOwnProperty('version') || !allowedVersions.includes(httpObj.version)){
        throw new Error('Invalid request header: Invalid Version');
    }

    const messagePattern = /^([a-zA-Z0-9!@#$%^*()\[\]_\-+?.,~`;:|*\/ {}=]*)$/g;
    if(!httpObj.hasOwnProperty('message') || !messagePattern.exec(httpObj.message)){
        throw new Error('Invalid request header: Invalid Message');
    }

    return httpObj;
}

let obj = {
    method: 'GET',
    uri: 'kkk jjjj',
    version: 'HTTP/0.8',
    message: ''
};

validateRequest(obj);