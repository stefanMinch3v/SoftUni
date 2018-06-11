function initializeTable() {
    //$('#createLink').on('click', addCountry);
    $('#createLink').click(addCountry); // deprecated

    createCountry('Bulgaria', 'Sofia');
    createCountry('Germany', 'Berlin');
    createCountry('Russia', 'Moscow');
    fixLinks();

    function fixLinks() {
        $('tr a').show(); // show is the opposite of display none
        $('tr:last-child a:contains(Down)').hide(); // hide is display none

        //$('tr:nth-child(3) a:contains(Up)').hide(); another way
        $('tr:eq(2) a:contains(Up)').hide();
    }

    function addCountry() {
        let country = $('#newCountryText');
        let capital = $('#newCapitalText');

        createCountry(country.val(), capital.val());
        country.val('');
        capital.val('');
        fixLinks();
    }
    
    function createCountry(country, capital) {
        let row = $('<tr>')
            .append($(`<td>${country}</td>`)) // append to this file some childr
            .append($(`<td>${capital}</td>`))
            .append($(`<td>`)
                .append($('<a href="#">[Up]</a>').click(moveUp))
                .append($('<a href="#">[Down]</a>').click(moveDown))
                .append($('<a href="#">[Delete]</a>').click(deleteRow)));
        row.css('display', 'none');
        row.appendTo($('#countriesTable')); // append this file to some parent
        row.fadeIn();
    }
    
    function moveUp() {
        let currentRow = $(this).parent().parent();
        currentRow.fadeOut(() =>  {
            currentRow.insertBefore(currentRow.prev());
            currentRow.fadeIn();
            fixLinks();
        });
    }
    
    function moveDown() {
        let currentRow = $(this).parent().parent();
        currentRow.fadeOut(() => {
            currentRow.insertAfter(currentRow.next());
            currentRow.fadeIn();
            fixLinks();
        });
    }
    
    function deleteRow() {
        //this.parentNode.parentNode.remove(); works without jquery
        let currentRow = $(this).parent().parent();
        currentRow.fadeOut(() => {
            $(this).parent().parent().remove();
            fixLinks();
        });
    }
}