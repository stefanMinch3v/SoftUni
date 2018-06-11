let result = (function () {
    let id = 0;

    return class Extensible {
        constructor(){
            this.id = id++;
        }

        extend(template) {
            for (let prop of template) {
                if(typeof template[prop] === "function"){
                    Extensible.prototype[prop] = template[prop];
                } else {
                    this[prop] = template[prop];
                }
            }
        }
    }
})();

let obj1 = new result();
let obj2 = new result();
let obj3 = new result();

console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);
