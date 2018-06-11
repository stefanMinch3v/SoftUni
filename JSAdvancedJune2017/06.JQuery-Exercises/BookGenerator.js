let createBook = (function createBook() {
    let index = 1;

    return function (selector, title, author, isbn) {
        let div = $(`<div id="book${index}"></div>`);

        let titleP = $(`<p class="title">${title}</p>`);
        let authorP = $(`<p class="author">${author}</p>`);
        let isbnP = $(`<p class="isbn">${isbn}</p>`);

        let button1 = $(`<button>Select</button>`);
        button1.on('click', () => div.css('border', '2px solid blue'));

        let button2 = $(`<button>Deselect</button>`);
        button2.on('click', () => div.css('border', ''));

        div
            .append(titleP)
            .append(authorP)
            .append(isbnP)
            .append(button1)
            .append(button2);

        $(`${selector}`).append(div);

        index++;
    }
}());