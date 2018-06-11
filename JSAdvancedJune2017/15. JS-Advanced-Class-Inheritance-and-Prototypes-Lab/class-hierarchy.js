function solve() {

}
class Figure {
    constructor(){
        if(new.target === Figure){
            throw new Error("An abstract class can't be instantiated.");
        }
    }

    get area() {
        switch (this.constructor) {
            case Circle:
                return Math.PI * Math.pow(this.radius, 2);
            case Rectangle:
                return this.width * this.height;
        }
    }

    toString() {
        let type = this.constructor.name;
        let props = Object.getOwnPropertyNames(this);
        let propsAndValues = `${props.map(p => `${p}: ${this[p]}`).join(', ')}`;
        return `${type} - ${propsAndValues}`;
    }
}

class Circle extends Figure{
    constructor(radius){
        super();
        this.radius = radius;
    }
}

class Rectangle extends Figure {
    constructor(width, height){
        super();
        this.width = width;
        this.height = height;
    }
}


//let f = new Figure();       //Error
let c = new Circle(5);
console.log(c.area);        //78.53981633974483
console.log(c.toString());  //Circle - radius: 5
let r = new Rectangle(3,4);
console.log(r.area);        //12
console.log(r.toString());  //Rectangle - width: 3, height: 4
