function getLastMonthDays(input) {
    // let day = Number(input[0]);
    let month = Number(input[1]);
    let year = Number(input[2]);

    let date = new Date(year, month - 1, 0);

    return date.getDate();
}

console.log(getLastMonthDays([17, 3, 2002]));
