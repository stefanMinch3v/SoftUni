let SortedList = require('../sorted-list');
let expect = require('chai').expect;

describe('Test SortedList', () => {
    let myList;
    beforeEach(() => {
        // arrange
        myList = new SortedList();
    });
    describe('Test Numeric elements', () => {
        describe('Test general functionality', () => {
            it('Should have add func', () => {
                expect(SortedList.prototype.hasOwnProperty('add')).to.equal(true);
            });
            it('Should have get func', () => {
                expect(SortedList.prototype.hasOwnProperty('get')).to.equal(true);
            });
            it('Should have sort func', () => {
                expect(SortedList.prototype.hasOwnProperty('sort')).to.equal(true);
            });
            it('Should have remove func', () => {
                expect(SortedList.prototype.hasOwnProperty('remove')).to.equal(true);
            });
            it('Should have vrfyRange func', () => {
                expect(SortedList.prototype.hasOwnProperty('vrfyRange')).to.equal(true);
            });
            it('Should sort elements correctly', () => {
                // act
                myList.add(5);
                myList.add(1);
                myList.add(11);
                myList.remove(1);
                myList.add(10);
                // assert
                expect(myList.get(0)).equals(1);
                expect(myList.get(1)).equals(10);
                expect(myList.get(2)).equals(11);
            });
            it('Should return the correct size', () => {
                // act
                myList.add(5);
                myList.add(1);
                myList.add(11);
                // assert
                expect(myList.size).equals(3);
            });
        });

        describe('Test func add', () => {
            it('Should add one element correctly', () => {
                // act
                myList.add(5);
                // assert
                expect(myList.size).to.equal(1);
                expect(myList.get(0)).to.equal(5);
            });
            it('Should add 3 elements and sort them correctly', () => {
                // act
                myList.add(5);
                myList.add(1);
                myList.add(55);
                // assert
                expect(myList.size).to.equal(3);
                expect(myList.get(0)).to.equal(1);
                expect(myList.get(1)).to.equal(5);
                expect(myList.get(2)).to.equal(55);
            });
        });

        describe('Test func remove', () => {
            it('Should remove 1 element correctly', () => {
                // act
                myList.add(5);
                myList.remove(0);
                // assert
                expect(myList.size).to.equal(0);
            });
            it('Should throw an exception if remove element with bigger index than the collection', () => {
                // act
                myList.add(5);
                // assert
                expect(function() { myList.remove(2);} ).throw("Index was outside the bounds of the collection.");
            });
            it('Should throw an exception if remove element from empty collection', () => {
                // assert
                expect(function() { myList.remove(2);} ).throw("Collection is empty.");
            });
            it('Should throw an exception if remove element with negative index', () => {
                // act
                myList.add(5);
                // assert
                expect(function() { myList.remove(-5);} ).throw("Index was outside the bounds of the collection.");
            });
            it('Should throw an exception if remove element with equal index to the collection`s length', () => {
                // act
                myList.add(5);
                // assert
                expect(function() { myList.remove(1);} ).throw("Index was outside the bounds of the collection.");
            });
        });

        describe('Test func get', () => {
            it('Should return correct result', () => {
                // act
                myList.add(5);
                // assert
                expect(myList.get(0)).to.equal(5);
                expect(myList.size).to.equal(1);
            });
            it('Should return an error for empty collection', () => {
                // assert
                expect(function() { myList.get(1);} ).throw("Collection is empty.");
            });
            it('Should return an error for unexisting index', () => {
                // act
                myList.add(5);
                // assert
                expect(function() { myList.get(2);} ).throw("Index was outside the bounds of the collection.");
            });
            it('Should return an error for getting negative index', () => {
                // act
                myList.add(5);
                // assert
                expect(function() { myList.get(-2);} ).throw("Index was outside the bounds of the collection.");
            });
            it('Should return an error for getting index equal to collection`s length', () => {
                // act
                myList.add(5);
                // assert
                expect(function() { myList.get(1);} ).throw("Index was outside the bounds of the collection.");
            });
        });
    });
});