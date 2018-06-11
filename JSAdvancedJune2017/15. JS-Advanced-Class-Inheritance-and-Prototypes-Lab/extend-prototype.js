class Person {
    constructor(name, email){
        this.name = name;
        this.email = email;
    }

    toString() {
        let className = this.constructor.name;
        let props = Object.getOwnPropertyNames(this);
        let propsAndValues = `${props.map(p => `${p}: ${this[p]}`).join(', ')}`;
        return `${className} (${propsAndValues})`;
    }
}

class Teacher extends Person {
    constructor(name, email, subject){
        super(name, email);
        this.subject = subject;
    }
}

function extendClass(obj) {
    obj.prototype.species = 'Human';
    obj.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`
    };
}

let p = new Person("Maria", "maria@gmail.com");
let t = new Teacher("Ivanka", "iv@gmail.com", "c#");

Person.prototype.species = 'Human';
Person.prototype.toSpeciesString = function () {
    return `I am a ${this.species}. ${this.toString()}`
};


console.log(p.toSpeciesString());
console.log(t.toSpeciesString());
