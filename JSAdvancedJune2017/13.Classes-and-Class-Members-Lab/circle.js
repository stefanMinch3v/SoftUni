class Circle{
    constructor(radius){
        this.radius = radius;
    }

    get radius() {
        return this._radius;
    }

    set radius(value) {
        this._radius = value;
    }

    get diameter() {
        return this.radius * 2;
    }

    set diameter(value) {
        this.radius = value / 2;
    }

    get area() {
        return Math.PI * Math.pow(this.radius, 2);
    }
}

let r = new Circle(5);
r.diameter = 1.6;
console.log(r.radius);
console.log(r.area);