function isEvenOrOdd(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }

    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

let expect = require('chai').expect;

describe('IsEvenOrOdd', () => {
    it('should return undefined with passing object', () => {
        expect(isEvenOrOdd({pesho: 'pesho'})).to.be.undefined;
    });

    it('should return undefined with passing an array', () => {
        expect(isEvenOrOdd([])).to.be.undefined;
    });

    it('should return undefined with passing a number', () => {
        expect(isEvenOrOdd(51)).to.be.undefined;
    });

    it('should return odd length with string abc', () => {
        expect(isEvenOrOdd('abc')).to.be.equal('odd');
    });

    it('should return even length with string abcd', () => {
        expect(isEvenOrOdd('abcd')).to.be.equal('even');
    });

    it('should return even length with an empty string', () => {
        expect(isEvenOrOdd('')).to.be.equal('even');
    });

    it('with multiple consecutive checks, should return correct value', () => {
        expect(isEvenOrOdd('cat')).to.be.equal('odd', 'Function did not return the correct result!');
        expect(isEvenOrOdd('caveman')).to.be.equal('odd', 'Function did not return the correct result!');
        expect(isEvenOrOdd('is it even')).to.be.equal('even', 'Function did not return the correct result!');
    });
});