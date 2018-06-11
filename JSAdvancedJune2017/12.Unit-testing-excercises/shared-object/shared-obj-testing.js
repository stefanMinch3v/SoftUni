let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require('jquery');

document.body.innerHTML = `<body>
    <div id="wrapper">
        <input type="text" id="name"/>
        <input type="text" id="income"/>
    </div>
</body>`;

let sharedObject = {
    name: null,
    income: null,
    changeName: function (name) {
        if (name.length === 0) {
            return;
        }
        this.name = name;
        let newName = $('#name');
        newName.val(this.name);
    },
    changeIncome: function (income) {
        if (!Number.isInteger(income) || income <= 0) {
            return;
        }
        this.income = income;
        let newIncome = $('#income');
        newIncome.val(this.income);
    },
    updateName: function () {
        let newName = $('#name').val();
        if (newName.length === 0) {
            return;
        }
        this.name = newName;
    },
    updateIncome: function () {
        let newIncome = $('#income').val();
        if (isNaN(newIncome) || !Number.isInteger(Number(newIncome)) || Number(newIncome) <= 0) {
            return;
        }
        this.income = Number(newIncome);
    }
};

describe('Shared object unit tests', () => {
    describe('Initial value test', () => {
        it('should return null when instantiate object name', () => {
            expect(sharedObject.name).to.be.null;
        });

        it('should return null when instantiate object income', () => {
            expect(sharedObject.income).to.be.null;
        });
    });

    describe('Change name tests', () => {
        it('should return null with an empty string', () => {
            // act
            sharedObject.changeName('');
            // assert
            expect(sharedObject.name).to.be.null;
        });

        it('should return correct value with non-empty string', () => {
            // act
            sharedObject.changeName('gosho');
            // assert
            expect(sharedObject.name).to.be.equal('gosho', 'Name did`t change correctly.');
        });

        describe('Name input tests', () => {
            it('should return empty with an empty string', () => {
                sharedObject.changeName('mitko');
                sharedObject.changeName('');
                let nameTxtVal = $('#name').val();
                expect(nameTxtVal).to.be.equal('mitko');
            });

            it('should return correct value with non-empty string', () => {
                sharedObject.changeName('gosho');
                let nameTxtVal = $('#name').val();
                expect(nameTxtVal).to.be.equal('gosho', 'Name did`t change correctly.');
            });
        });
    });

    describe('Change income tests', () => {
        it('should return null with a string', () => {
            sharedObject.changeIncome('asd');
            expect(sharedObject.income).to.be.null;
        });

        it('with a floating point', () => {
            sharedObject.changeIncome(5);
            sharedObject.changeIncome(3.41);
            expect(sharedObject.income).to.be.equal(5);
        });

        it('with a negative number', () => {
            sharedObject.changeIncome(5);
            sharedObject.changeIncome(-3);
            expect(sharedObject.income).to.be.equal(5);
        });

        it('with zero', () => {
            sharedObject.changeIncome(5);
            sharedObject.changeIncome(0);
            expect(sharedObject.income).to.be.equal(5);
        });

        it('should return correct result with a positive number', () => {
            sharedObject.changeIncome(100);
            expect(sharedObject.income).to.be.equal(100);
        });

        describe('Income input tests', () => {
            it('should return incorrect result with a string', () => {
                sharedObject.changeIncome(5);
                sharedObject.changeIncome('asd');
                let incomeTxtVal = $('#income').val();
                expect(incomeTxtVal).to.be.equal('5', 'Input did not change correctly');
            });

            it('should return correct result with a positive number', () => {
                sharedObject.changeIncome(5);
                let incomeTxtVal = $('#income').val();
                expect(incomeTxtVal).to.be.equal('5', 'Input did not change correctly');
            });

            it('should return correct result with a negative number', () => {
                sharedObject.changeIncome(5);
                sharedObject.changeIncome(-5);
                let incomeTxtVal = $('#income').val();
                expect(incomeTxtVal).to.be.equal('5', 'Input did not change correctly');
            });

            it('with a floating point number', () => {
                sharedObject.changeIncome(5);
                sharedObject.changeIncome(5.324);
                let incomeTxtVal = $('#income').val();
                expect(incomeTxtVal).to.be.equal('5', 'Input did not change correctly');
            });

            it('with zero', () => {
                sharedObject.changeIncome(5);
                sharedObject.changeIncome(0);
                let incomeTxtVal = $('#income').val();
                expect(incomeTxtVal).to.be.equal('5', 'Input did not change correctly');
            });
        });
    });

    describe('Update name tests', () => {
        it('should not change the name with an empty string', () => {
            sharedObject.changeName('first');
            let nameEl = $('#name');
            nameEl.val('');
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('first');
        });

        it('should change the name with string', () => {
            let nameEl = $('#name');
            nameEl.val('second');
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('second');
        });
    });

    describe('Update income tests', () => {
        it('should not change the result with a string', () => {
            sharedObject.changeIncome(3);
            let incomeEl = $('#income');
            incomeEl.val('asd');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(3);
        });

        it('should not change the result with a floating point number', () => {
            sharedObject.changeIncome(3);
            let incomeEl = $('#income');
            incomeEl.val('3.33');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(3);
        });

        it('should not change the result with a negative number', () => {
            sharedObject.changeIncome(3);
            let incomeEl = $('#income');
            incomeEl.val('-13');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(3);
        });

        it('should not change the result with zero', () => {
            sharedObject.changeIncome(3);
            let incomeEl = $('#income');
            incomeEl.val('0');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(3);
        });

        it('should change the result with positive number', () => {
            sharedObject.changeIncome(3);
            let incomeEl = $('#income');
            incomeEl.val('33');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(33);
        });
    });
});