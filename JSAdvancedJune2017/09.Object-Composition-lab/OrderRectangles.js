function createRect(width, height) {
    return {
        width,
        height,
        area: () => this.width * this.height,
        compareTo: function (other) {
            let result = other.area() - this.area();
            return result || (other.width - this.width);
        },
        toString: function () {
            return `[${this.width} x ${this.height}]`;
        }
    };
}

let rect1 = createRect(5, 4);
let rect2 = createRect(12, 12);
let rect3 = createRect(12, 4);
let rectArr = [rect1, rect2, rect3];
console.log(rectArr.map(e => e.toString()));

rectArr.sort((a, b) => a.compareTo(b));

console.log(rectArr.map(e => e.toString()));