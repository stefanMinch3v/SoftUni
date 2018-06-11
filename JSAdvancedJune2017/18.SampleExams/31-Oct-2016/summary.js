function getSummary(selector) {
    $(selector).on('click', () => {
        // generate elements
        let div = $(`<div id="summary"></div>`);
        let h2 = $(`<h2>Summary</h2>`);
        h2.appendTo(div);

        // take data
        let text = $('#content strong').text();

        // append data and show the result
        div.append($(`<p>${text}</p>`));
        $('#content').parent().append(div);
    });
}