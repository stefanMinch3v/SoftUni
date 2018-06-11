let classesFunc = require('./computer');

function createMixins() {
    function styleMixin(classToExtend) {
        classToExtend.prototype.isFullSet = function () {
            return this.manufacturer === this.keyboard.manufacturer && this.manufacturer === this.monitor.manufacturer;
        };

        classToExtend.prototype.isClassy = function () {
            if(this.battery.expectedLife >= 3 &&
                (this.color === 'Silver' || this.color === 'Black') &&
                this.weight < 3) {
                return true;
            }

            return false;
        }
    }

    function computerQualityMixin(classToExtend) {
        classToExtend.prototype.getQuality = function () {
            return (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;
        };

        classToExtend.prototype.isFast = function () {
            return this.processorSpeed > (this.ram / 4);
        };

        classToExtend.prototype.isRoomy = function () {
            return this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed);
        }
    }

    return {
        computerQualityMixin,
        styleMixin
    }
}

//test
let obj = classesFunc();
let mixins = createMixins();

let Battery = obj.Battery;
Battery = new Battery('nak', 5);

let Laptop = obj.Laptop;
mixins.computerQualityMixin(Laptop);

Laptop = new Laptop('asd', 3, 8, 500, 2.2, 'white', Battery);


console.log(Laptop.getQuality());


