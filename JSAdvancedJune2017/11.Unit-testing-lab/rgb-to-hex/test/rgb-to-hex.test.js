const rgbToHexColor = require('../rgb-to-hex').rgbToHexColor;
const expect = require('chai').expect;

describe('Check symmetry', () => {
    describe('General tests', () => {
        it('should be a function', () => {
            expect(typeof rgbToHexColor).to.equal('function');
        });
    });

    describe('Value tests', () => {
        it('should return FF9EAA for (255, 158, 170)', () => {
            expect(rgbToHexColor(255, 158, 170)).to.be.equal('#FF9EAA');
        });

        it('should return 0C0D0E for (12, 13, 14)', () => {
            expect(rgbToHexColor(12, 13, 14)).to.be.equal('#0C0D0E');
        });

        it('should return 000000 for (0, 0, 0)', () => {
            expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000');
        });

        it('should return FFFFFF for (255, 255, 255)', () => {
            expect(rgbToHexColor(255, 255, 255)).to.be.equal('#FFFFFF');
        });

        it('should return undefined for (-1, 0, 0)', () => {
            expect(rgbToHexColor(-1, 0, 0)).to.be.equal(undefined);
        });

        it('should return undefined for (0, -1, 0)', () => {
            expect(rgbToHexColor(0, -1, 0)).to.be.equal(undefined);
        });

        it('should return undefined for (0, 0, -1)', () => {
            expect(rgbToHexColor(0, 0, -1)).to.be.equal(undefined);
        });

        it('should return undefined for (256, 0, 0)', () => {
            expect(rgbToHexColor(256, 0, 0)).to.be.equal(undefined);
        });

        it('should return undefined for (0, 256, 0)', () => {
            expect(rgbToHexColor(0, 256, 0)).to.be.equal(undefined);
        });

        it('should return undefined for (0, 0, 256)', () => {
            expect(rgbToHexColor(0, 0, 256)).to.be.equal(undefined);
        });

        it('should return undefined for (3.14, 0, 0)', () => {
            expect(rgbToHexColor(3.14, 0, 0)).to.be.equal(undefined);
        });

        it('should return undefined for (0, 3.14, 0)', () => {
            expect(rgbToHexColor(0, 3.14, 0)).to.be.equal(undefined);
        });

        it('should return undefined for (0, 0, 3.14)', () => {
            expect(rgbToHexColor(0, 0, 3.14)).to.be.equal(undefined);
        });

        it('should return undefined for ("5", [3], {8:9})', () => {
            expect(rgbToHexColor("5", [3], {8:9})).to.be.equal(undefined);
        });

        it('should return undefined for ()', () => {
            expect(rgbToHexColor()).to.be.equal(undefined);
        });

        it('should accept 3 params', () => {
            expect(rgbToHexColor.length).to.be.equal(3);
        });
    });
});