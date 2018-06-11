function calcBmi(name, age, weight, height){
    let obj = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: 0,
        status: ''
    };

    bmiFormula();
    statusFormula();
    recommendations();

    function bmiFormula() {
        let heightF = height;
        let weightF = weight;
        obj['BMI'] = Math.round(weightF / (Math.pow(heightF / 100, 2)));
    }

    function statusFormula() {
        let bmi = obj['BMI'];
        let status = '';

        if(bmi < 18.5){
            status = 'underweight';
        } else if(bmi < 25 && bmi >= 18.5){
            status = 'normal';
        } else if(bmi < 30 && bmi >= 25){
            status = 'overweight';
        } else {
            status = 'obese';
        }

        obj['status'] = status;
    }

    function recommendations() {
        let stats = obj['status'];

        if(stats === 'obese') {
            obj['recommendation'] = 'admission required';
        }
    }

    return obj;
}

console.log(calcBmi('Peter', 27, 91, 187));