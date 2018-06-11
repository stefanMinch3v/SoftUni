let list = require('../list-operations').createList;
let expect = require('chai').expect;

describe('Test list functionality', () => {
    let myList;
    beforeEach(() => {
        // arrange
        myList = list();
    });
    describe('Test general functionality', () => {
        it('Should be a func', () => {
            expect(typeof list).to.equal('function');
        });
    });
    describe('Test add func', () => {
        it('Should add correctly numbers', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add('Ivan');
            // assert
            expect(myList.toString()).to.equal('1, 2, Ivan');
        });
    });
    describe('Test swap func', () => {
        it('Should swap correctly numbers', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add('Ivan');
            myList.swap(0, 2);
            // assert
            expect(myList.toString()).to.equal('Ivan, 2, 1');
        });
        it('Should return false for negative index', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add('Ivan');
            // assert
            expect(myList.swap(-1, 2)).to.be.false;
        });
        it('Should return false for bigger index than the collection size', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add('Ivan');
            // assert
            expect(myList.swap(0, 5)).to.be.false;
        });
        it('Should return false for equal indexes', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add('Ivan');
            // assert
            expect(myList.swap(0, 0)).to.be.false;
        });
        it('Should return false for string index', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add('Ivan');
            // assert
            expect(myList.swap('0', 1)).to.be.false;
        });
        it('Should return false for obj index', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add('Ivan');
            // assert
            expect(myList.swap(0, [])).to.be.false;
        });
    });
    describe('Test shiftleft func', () => {
        it('Should return the correct result', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add('Ivan');
            myList.add(3);
            myList.shiftLeft();
            // assert
            expect(myList.toString()).to.be.equal('2, Ivan, 3, 1');
        });
        it('Should return the correct result with multiple shifts', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add(3);
            myList.add(4);
            myList.shiftLeft();
            myList.shiftLeft();
            myList.shiftLeft();
            // assert
            expect(myList.toString()).to.be.equal('4, 1, 2, 3');
        });
        it('Should stay the same collection with 1 element', () => {
            // act
            myList.add(1);
            myList.shiftLeft();
            // assert
            expect(myList.toString()).to.be.equal('1');
        });
    });
    describe('Test shiftright func', () => {
        it('Should return the correct result', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add('Ivan');
            myList.add(3);
            myList.shiftRight();
            // assert
            expect(myList.toString()).to.be.equal('3, 1, 2, Ivan');
        });
        it('Should stay the same collection with 1 element', () => {
            // act
            myList.add(1);
            myList.shiftRight();
            // assert
            expect(myList.toString()).to.be.equal('1');
        });
        it('Should return the correct result with multiple shifts', () => {
            // act
            myList.add(1);
            myList.add(2);
            myList.add(3);
            myList.add(4);
            myList.shiftRight();
            myList.shiftRight();
            myList.shiftRight();
            // assert
            expect(myList.toString()).to.be.equal('2, 3, 4, 1');
        });
    });
    describe('Test toString func', () => {
        it('Should get the correct result', () => {
            // act
            myList.add(1);
            myList.add(2);
            // assert
            expect(myList.toString()).to.be.equal('1, 2');
        });
        it('Should get empty result', () => {
            // assert
            expect(myList.toString()).to.be.equal('');
        });
    });
});