(function () {
    String.prototype.ensureStart = function (str) {
        if(!this.includes(str)){
            return `${str} ${this}`;
        }

        return this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if(!this.includes(str)){
            return `${this} ${str}`;
        }

        return this.toString();
    };

    String.prototype.isEmpty = function () {
        return !this.toString(); // empty string returns true otherwise false. Weird :D
    };

    // does not work properly
    String.prototype.truncate = function (n) {
        if (n < 4) {
            return '.'.repeat(n)
        }

        if (n >= this.length) {
            return this.toString()
        }

        let lastIndexOfSpaceBeforeN = -1;
        let currentIndex = -1;
        currentIndex = this.indexOf(' ', currentIndex + 1);
        while (currentIndex !== -1 && currentIndex <= n - 3) {
            lastIndexOfSpaceBeforeN = currentIndex;
            currentIndex = this.indexOf(' ', currentIndex + 1)
        }

        if (lastIndexOfSpaceBeforeN !== -1) {
            return this.substr(0, lastIndexOfSpaceBeforeN) + '...';
        } else {
            return this.substr(0, n - 3) + '...';
        }
    };

    String.format = function (str) {
        let placeHolder = /({\d+})/g;
        let match = placeHolder.exec(str);
        let replaceIndex = 1;

        while(match) {
            str = str.replace(match[1], arguments[replaceIndex]);

            replaceIndex++;
            match = placeHolder.exec(str);
        }

        return str;
    };
})();

let str = 'my string';
console.log(str = str.ensureStart('my'));
console.log(str = str.ensureStart('hello '));
str = String.format('The {0} {1} fox', 'quick', 'brown');
console.log(str);

