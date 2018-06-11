(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        if(this.length - 1 >= Number(n)){
            let arr = [];

            for (let i = n; i <= this.length - 1; i++) {
                arr.push(this[i]);
            }

            return arr;
        }

        return this;
    };

    Array.prototype.take = function (n) {
        if(this.length - 1 >= Number(n)){
            let arr = [];

            for (let i = 0; i < n; i++) {
                arr.push(this[i]);
            }

            return arr;
        }

        return this;
    };

    Array.prototype.sum = function () {
        let sum = 0;
        for (let element of this) {
            sum += Number(element);
        }

        return sum;
    };

    Array.prototype.average = function () {
        let sum = this.sum();
        return sum / this.length;
    };
})();

let arr = [10, 20, 30];

console.log(arr.average());
console.log(arr.sum());
console.log(arr.take(2));
console.log(arr.last());
console.log(arr.skip(5));

