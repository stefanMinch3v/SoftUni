function domSearch(selector, isCaseInsensitive) {
    // add operations
    let addDiv = $('<div class="add-controls"></div>');
    let labelInput = $('<label>Enter text:</label>');
    let addInput = $('<input/>');
    let addBtn = $('<a class="button">Add</a>');

    // results operations
    let resultsDiv = $('<div class="result-controls"></div>');
    let ul = $('<ul class="items-list"></ul>');

    // search operations
    let searchDiv = $('<div class="search-controls"></div>');
    let searchLabel = $('<label>Search:</label>');
    let searchInput = $('<input/>');

    addBtn.on('click', function () {
        let li = $('<li class="list-item"></li>');
        li.append($('<a class="button">X</a>').on('click', deleteRow));
        li.append($(`<strong>${addInput.val()}</strong>`));
        li.appendTo(ul);

        addInput.val('');
    });

    searchInput.on('change', matchData);

    addDiv
        .append(labelInput)
        .append(addInput)
        .append(addBtn);

    searchDiv
        .append(searchLabel)
        .append(searchInput);

    resultsDiv.append(ul);

    $(selector)
        .append(addDiv)
        .append(searchDiv)
        .append(resultsDiv);

    function matchData() {
        let search = searchInput.val();
        let listItems = $('strong');

        if (search === "") {
            listItems.each(function (index, element) {
                $(element).parent().css("display", "block")
            });
        } else {
            listItems.each(function (index, element) {
                let li = $(element).text();

                if(!isCaseInsensitive){
                    li = li.toLowerCase();
                    search = search.toLowerCase();
                }

                if(li.includes(search)){
                    $(element).parent().css('display', 'block');
                } else {
                    $(element).parent().css('display', 'none');
                }
            });
        }
    }

    function deleteRow() {
        $(this).parent().remove();
    }
}