function attachEvents() {
    $('ul li').on('click', selectTowns);
    $('#showTownsButton').on('click', printTowns);

    function printTowns() {
        let selected = $('[data-selected=true]') // select the attribute with [name]
            .toArray()
            .map(e => e.textContent)
            .join(', ');

        $('#selectedTowns').text(selected);
    }

    function selectTowns() {
        let li = $(this);

        if(li.attr('data-selected')){
            li.removeAttr('data-selected');
            li.css('background-color', '');
        } else {
            li.attr('data-selected', 'true');
            li.css('background-color', '#DDD');
        }
    }
}

function attachEventsBetter() {
    $('ul li').on('click', selectTowns);
    $('#showTownsButton').on('click', printTowns);

    function printTowns() {
        let selected = $('.data-selected')
            .toArray()
            .map(e => e.textContent)
            .join(', ');

        $('#selectedTowns').text(selected);
    }

    function selectTowns() {
        let li = $(this);

        if(li.hasClass('data-selected')){
            li.removeAttr('class');
        } else {
            li.attr('class', 'data-selected');
        }
    }
}