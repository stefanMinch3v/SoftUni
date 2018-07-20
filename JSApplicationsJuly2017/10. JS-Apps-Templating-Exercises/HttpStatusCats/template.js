$(() => {
    renderCatTemplate();

    async function renderCatTemplate() {
        let context = window.cats;
        let source = await $.get('catTemplate.hbs');
        let template = Handlebars.compile(source);
        let html = template({ cats: context });
        $('#allCats').append(html);

        $('.btn').on('click', renderCode);

        function renderCode() {
            let btn = $(this);
            let msgAndStatusCode = $(this).next();
            let display = msgAndStatusCode.css('display');

            if(display === 'none') {
                msgAndStatusCode.css('display', 'inline');
                btn.text("Hide status code");
            } else {
                msgAndStatusCode.css('display', 'none');
                btn.text("Show status code");
            }
        }
    }
});
