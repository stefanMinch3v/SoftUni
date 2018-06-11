function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

const expect = require('chai').expect;

describe('Test lookup char func', () => {
    it('should return undefined with first param number', () => {
        expect(lookupChar(3, 3)).to.be.undefined;
    });

    it('should return undefined with second param string', () => {
        expect(lookupChar('test', 'gosho')).to.be.undefined;
    });

    it('should return undefined with float number as second param', () => {
        expect(lookupChar('asd', 3.5)).to.be.undefined;
    });

    it('should return "Incorrect index" for index -1', () => {
        let actual = lookupChar('a', -1);
        let expected = 'Incorrect index';
        expect(actual).to.be.equal(expected);
    });

    it('should return "Incorrect index" for index out of range', () => {
        let actual = lookupChar('a', 50);
        let expected = 'Incorrect index';
        expect(actual).to.be.equal(expected);
    });

    it('should return "a" for index 0', () => {
        let actual = lookupChar('a', 0);
        let expected = 'a';
        expect(actual).to.be.equal(expected);
    });

    it('should return "f" for index 5', () => {
        let actual = lookupChar('abcdef', 5);
        let expected = 'f';
        expect(actual).to.be.equal(expected);
    });
});


