function sortedList() {
    return {
        internalArray: [],
        add: function (element) {
            this.internalArray.push(element);
            this.size++;
            this.internalArray.sort((a, b) => a - b);
        },
        size: 0,
        remove: function (index) {
            if(index >= 0 && index < this.internalArray.length){
                this.internalArray.splice(index, 1);
                this.size--;
            }
        },
        get: function (index) {
            if(index >= 0 && index < this.internalArray.length){
               return this.internalArray[index];
            }
        },
        toString: function () {
            return this.internalArray.join(' ');
        }
    }
}

let list = sortedList();
console.log(`Size: ${list.size}`);
list.add(2);
list.add(-66);
list.add(16);
list.add(121);
list.add(4);
console.log(list.toString());

console.log(`Size: ${list.size}`);

list.remove(2);
console.log(list.toString());
console.log(`Size: ${list.size}`);

console.log(list.get(3));

console.log(`Size: ${list.size}`);