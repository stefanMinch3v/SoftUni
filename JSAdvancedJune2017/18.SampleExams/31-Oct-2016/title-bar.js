class TitleBar {
    constructor(title) {
        this.title = title;
        this.elements = [];
    }

    addLink(href, name) {
        //this.elements.push($(`<a class="menu-link" href="${href}">${name}</a>`));
        let aElement = $('<a>')
            .addClass('menu-link')
            .attr('href', href)
            .text(name);
        this.elements.push(aElement);
    }

    appendTo(selector) {
        // create elements
        let headerElement = $('<header>').addClass('header');
        let divHeaderRow = $('<div>').addClass('header-row');
        let aButton = $('<a>')
            .addClass('button')
            .html('&#9776;')
            .on('click', () => $('div.drawer').toggle());
        let spanTitle = $('<span>')
            .addClass('title')
            .text(this.title);
        let divDrawer = $('<div>')
            .addClass('drawer')
            .css('display', 'none');
        let divMenu = $('<nav>').addClass('menu');

        // append elements
        this.elements.forEach(e => e.appendTo(divMenu));
        divHeaderRow.append(aButton);
        divHeaderRow.append(spanTitle);
        divHeaderRow.appendTo(headerElement);
        divDrawer.append(divMenu);
        divDrawer.appendTo(headerElement);
        $(selector).append(headerElement);
    }
}