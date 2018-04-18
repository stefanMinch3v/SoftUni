function chessBoard(number) {
    let result = '';
    let blackField = '    <span class="black"></span>';
    let whiteField = '    <span class="white"></span>';

    //console.log('<div class="chessboard">');

    result += '<div class="chessboard">\n';

    for(var i = 0; i < number; i++){
        //console.log('<div>');
        result += '<div>\n';
        if(i % 2 == 0){
            for(var j = 0; j < number; j++){
                if(j % 2 == 0) {
                    //console.log(blackField);
                    result += blackField + '\n';
                } else {
                    //console.log(whiteField);
                    result += whiteField + '\n';
                }
            }

            console.log('</div>');
        } else {
            for(var k = 0; k < number; k++){
                if(k % 2 == 0) {
                    // console.log(whiteField);
                    result += whiteField + '\n';
                } else {
                    // console.log(blackField);
                    result += blackField + '\n';
                }
            }

            // console.log('</div>');
            result += '</div>\n';
        }
    }

    //console.log('</div>');
    result += '</div>\n';

    return result;
}
