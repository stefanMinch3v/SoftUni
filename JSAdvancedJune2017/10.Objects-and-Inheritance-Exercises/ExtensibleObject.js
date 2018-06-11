function extendsObj() {
    let obj = {
        extend: function (template) {
            for (let key in template) {
                if(template.hasOwnProperty(key)){
                    let element = template[key];
                    if(typeof element === 'function'){
                        obj.__proto__[key] = element;
                    } else {
                        obj[key] = element;
                    }
                }
            }
        }
    };

    return obj;
}

let obj = extendsObj();
let template = {
      extensionMethod: function () {
          console.log('PEsho');
      },
      extensionProp: 'Ok'
};

obj.extend(template);
console.log(obj);
console.log('\n');
console.log(obj.__proto__);