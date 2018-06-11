class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = Number(innerLength);
        this.initialString = innerString;
    }

    get innerString() {
        return this._innerString;
    }
    set innerString(value) {
        this._innerString = value;
    }

    get innerLength() {
        return this._innerLength;
    }
    set innerLength(value) {
        if(value < 0){
            value = 0;
        }

        this.fixStringLength(value);
        this._innerLength = value;
    }

    fixStringLength(length){
        if(this.innerString.length > length){
            this.innerString = `${this.innerString.substring(0, length)}...`;
        }
    }

    increase(length){
        this.innerLength += length;
    }

    decrease(length){
        this.innerLength -= length;
    }

    toString() {
        return this.innerString.length <= this.innerLength ? this.initialString : this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...

test.increase(4);
console.log(test.toString()); //Test


