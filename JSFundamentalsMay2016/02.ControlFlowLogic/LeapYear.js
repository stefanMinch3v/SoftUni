"use strict";

function isLeap(year) {
    if((year % 4 == 0 &&
    year % 100 != 0) ||
    year % 400 == 0){
        return 'yes';
    }

    return 'no';
}

console.log(isLeap(1900));