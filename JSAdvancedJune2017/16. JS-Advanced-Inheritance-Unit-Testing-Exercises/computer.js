function solve() {
    class Manufacturer {
        constructor(manufacturer) {
            if(new.target === Manufacturer){
                throw new Error('Manufacturer is an abstract class.');
            }

            this.manufacturer = manufacturer;
        }
    }

    class Keyboard extends Manufacturer {
        constructor(manufacturer, responseTime) {
            super(manufacturer);
            this.responseTime = responseTime;
        }
    }

    class Monitor extends Manufacturer {
        constructor(manufacturer, width, height) {
            super(manufacturer);
            this.width = width;
            this.height = height;
        }
    }

    class Battery extends Manufacturer {
        constructor(manufacturer, expectedLife) {
            super(manufacturer);
            this.expectedLife = expectedLife;
        }
    }

    class Computer extends Manufacturer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            if(new.target === Computer) {
                throw new Error('Computer is an abstract class.');
            }

            super(manufacturer);
            this.processorSpeed = processorSpeed;
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;
        }
    }

    class Laptop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        get battery() {
            return this._battery;
        }
        set battery(value) {
            if((value instanceof Battery) === false) {
                throw new TypeError('Battery instance is not the correct type of object.');
            }

            this._battery = value;
        }
    }

    class Desktop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get keyboard() {
            return this._keyboard;
        }
        set keyboard(value) {
            if((value instanceof Keyboard) === false) {
                throw new TypeError('Keyboard instance is not the correct type of object.');
            }

            this._keyboard = value;
        }

        get monitor() {
            return this._monitor;
        }
        set monitor(value) {
            if((value instanceof Monitor) === false) {
                throw new TypeError('Monitor instance is not the correct type of object.');
            }

            this._monitor = value;
        }
    }

    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop,
        Manufacturer
    }
}

module.exports = solve;