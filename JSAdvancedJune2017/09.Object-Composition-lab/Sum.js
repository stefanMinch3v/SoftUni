function getModel() {
    let input1, input2, result;

    function init(num1Selector, num2Selector, resultSelector) {
        input1 = $(num1Selector);
        input2 = $(num2Selector);
        result = $(resultSelector);
    }

    function add() {
        result.val(Number(input1.val()) + Number(input2.val()));
    }

    function subtract() {
        result.val(Number(input1.val()) - Number(input2.val()));
    }

    return{
        init,
        add,
        subtract
    };
}