function sum(arr) {
    let sum = 0;
    for (num of arr) {
        sum += Number(num);
    }

    return sum;
}

let expect = require('chai').expect;

    describe('Test simulator', function () {
        it('Should return 0 for []', function () {
            // arrange
            let expected = 0;
            // act
            let actual = sum([]);
            // assert
            expect(actual).to.equal(expected);
        });

        it('Should return 3 for [1,2]', function () {
            expect(sum([1, 2])).to.equal(3);
        });

        it('Should return NaN', function () {
            expect(sum(['pesho', 2, 3])).to.be.NaN;
        });

        it('Should return 3.3 for [1.1, 1.1, 1.1]', function () {
            expect(sum([1.1, 1.1, 1.1])).to.be.closeTo(3.3, 0.0001);
        });

        it('Should return 1 for [1]', function () {
            expect(sum([1])).to.be.equal(1);
        });

        it('Should work with negative nums', function () {
            expect(sum([-1, -2, 5])).to.be.equal(2);
        });

        it('Should return NaN', function () {
            expect(sum(['pesho'])).to.be.NaN;
        });
});