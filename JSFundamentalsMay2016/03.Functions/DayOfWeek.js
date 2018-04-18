function dayOfWeek(input) {
    let days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
    let result = days.indexOf(input) + 1;

    return result != 0 ? result : 'error';
}

console.log(dayOfWeek('Friday'));