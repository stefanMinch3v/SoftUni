function attachEvents() {
    $('#btnLoadTowns').on('click', printData);
    
    function printData() {
        let data = $('#towns').val().split(', ');
        let context = { towns: [] };

        for (let line of data) {
            context.towns.push({ town: line });
        }

        let source = $("#towns-template").html();
        let template = Handlebars.compile(source);
        let html = template(context);

        $('#root').append(html);
    }
}