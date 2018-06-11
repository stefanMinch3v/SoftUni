let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

const expect = require('chai').expect;

describe('Tests for math enforcer', () => {
    describe('test add five functionality', () => {
        it('should return undefined for string as param', () => {
            expect(mathEnforcer.addFive('gosho')).to.be.undefined;
        });

        it('should return undefined for object as param', () => {
            expect(mathEnforcer.addFive({})).to.be.undefined;
        });

        it('should return undefined for array as param', () => {
            expect(mathEnforcer.addFive([])).to.be.undefined;
        });

        it('should return 10 when add number 5 as param', () => {
            expect(mathEnforcer.addFive(5)).to.be.equal(10);
        });

        it('should return 0 when add number -5 as param', () => {
            expect(mathEnforcer.addFive(-5)).to.be.equal(0);
        });

        it('should return 7.5 for 2.5 as param', () => {
            expect(mathEnforcer.addFive(2.5)).to.be.closeTo(7.5, 0.01);
        });
    });

    describe('test subtract ten functionality', () => {
        it('should return undefined for string as param', () => {
            expect(mathEnforcer.subtractTen('gosho')).to.be.undefined;
        });

        it('should return undefined for object as param', () => {
            expect(mathEnforcer.subtractTen({})).to.be.undefined;
        });

        it('should return undefined for array as param', () => {
            expect(mathEnforcer.subtractTen([])).to.be.undefined;
        });

        it('should return 10 when subtract number 20 as param', () => {
            expect(mathEnforcer.subtractTen(20)).to.be.equal(10);
        });

        it('should return -15 when subtract number -5 as param', () => {
            expect(mathEnforcer.subtractTen(-5)).to.be.equal(-15);
        });

        it('should return -7.5 for 2.5 as param', () => {
            expect(mathEnforcer.subtractTen(2.5)).to.be.closeTo(-7.5, 0.01);
        });
    });

    describe('test sum functionality', () => {
        it('should return undefined for string as first param', () => {
            expect(mathEnforcer.sum('gosho', 5)).to.be.undefined;
        });

        it('should return undefined for object as first param', () => {
            expect(mathEnforcer.sum({}, 5)).to.be.undefined;
        });

        it('should return undefined for array as first param', () => {
            expect(mathEnforcer.sum([], 5)).to.be.undefined;
        });

        it('should return undefined for string as second param', () => {
            expect(mathEnforcer.sum(5, 'gosho')).to.be.undefined;
        });

        it('should return undefined for object as second param', () => {
            expect(mathEnforcer.sum(5, {})).to.be.undefined;
        });

        it('should return undefined for array as second param', () => {
            expect(mathEnforcer.sum(5, [])).to.be.undefined;
        });

        it('should return 10 for 5 and 5', () => {
            expect(mathEnforcer.sum(5, 5)).to.be.equal(10);
        });

        it('should return -10 for -5 and -5', () => {
            expect(mathEnforcer.sum(-5, -5)).to.be.equal(-10);
        });

        it('should return 0 for -5 and 5', () => {
            expect(mathEnforcer.sum(-5, 5)).to.be.equal(0);
        });

        it('should return 10.6 for 5.5 and 5.1', () => {
            expect(mathEnforcer.sum(5.5, 5.1)).to.be.closeTo(10.6, 0.01);
        });
    });
});