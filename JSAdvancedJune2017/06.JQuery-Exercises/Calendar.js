function calendar(arr) {
    let day = arr[0];
    let month = arr[1];
    let year = arr[2];
    let date = new Date(year, month, day);
    let numberOfDaysInMonth = new Date(year, month, 0).getDate();

    let weeks = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];
    let months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

    let table = $('<table></table>')
        .append($(`<caption>${months[date.getMonth()]} ${year}</caption>`))
        .append($('<tbody>'));

    let tr = $('<tr></tr>')
        .appendTo(table);

    for (let i = 0; i < 7; i++) {
        switch (i){
            case 0: $(`<th>${weeks[i]}</th>`).appendTo(tr); break;
            case 1: $(`<th>${weeks[i]}</th>`).appendTo(tr); break;
            case 2: $(`<th>${weeks[i]}</th>`).appendTo(tr); break;
            case 3: $(`<th>${weeks[i]}</th>`).appendTo(tr); break;
            case 4: $(`<th>${weeks[i]}</th>`).appendTo(tr); break;
            case 5: $(`<th>${weeks[i]}</th>`).appendTo(tr); break;
            case 6: $(`<th>${weeks[i]}</th>`).appendTo(tr); break;
        }
    }

    let counter = 0;
    let currentTr = $('<tr></tr>');

    for (let i = 1; i <= numberOfDaysInMonth; i++) {
        counter++;
        if(counter === 7) {
            // reset counter
            // change row
        }

        //$(`<td>${i}</td>`).appendTo(`${currentTr}`);
    }

    $('#content')
        .append(table);
}