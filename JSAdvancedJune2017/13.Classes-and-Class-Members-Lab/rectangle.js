class Rectangle {
    constructor(width, height, color){
        this.width = width;
        this.height = height;
        this.color = color;
    }

    calcArea() {
        return this.height * this.width;
    };
}

let r = new Rectangle(5, 3, 'red');
console.log(r.calcArea());