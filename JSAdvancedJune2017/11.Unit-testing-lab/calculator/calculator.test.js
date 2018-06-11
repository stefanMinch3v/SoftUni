const createCalculator = require('./calculator').createCalculator;
const expect = require('chai').expect;

describe('Check calculator', () => {
    describe('General tests', () => {
        it('should return an object', () => {
            expect(typeof createCalculator()).to.be.equal('object');
        });
    });

    describe('Value tests', () => {
        let calc;
        beforeEach(() => {
            // arrange
            calc = createCalculator();
        });

        it('should have 0 value when created', () => {
            expect(calc.get()).to.be.equal(0);
        });

        it('should return 10 when execute add(5) twice', () => {
            // act
            calc.add(5);
            calc.add(5);
            // assert
            expect(calc.get()).to.be.equal(10);
        });

        it('should return -10 when execute subtract(5) twice', () => {
            // act
            calc.subtract(5);
            calc.subtract(5);
            // assert
            expect(calc.get()).to.be.equal(-10);
        });

        it('should work with fractions', () => {
            // act
            calc.add(3.14);
            calc.subtract(1.13);
            // assert
            expect(calc.get()).to.be.closeTo(2.01, 0.001);
        });

        it('should work with negative nums', () => {
            // act
            calc.add(-4);
            calc.subtract(-3);
            // assert
            expect(calc.get()).to.be.equal(-1);
        });

        it('should not add NaNs', () => {
            // act
            calc.add('random');
            // assert
            expect(calc.get()).to.be.NaN;
        });

        it('should not subtract NaNs', () => {
            // act
            calc.subtract('random2');
            // assert
            expect(calc.get()).to.be.NaN;
        });

        it('should work with string numbers', () => {
            // act
            calc.add('5');
            calc.add(5);
            // assert
            expect(calc.get()).to.be.equal(10);
        });
    });
});