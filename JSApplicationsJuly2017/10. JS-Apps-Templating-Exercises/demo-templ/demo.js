$(() => {
    const main = $('#main');
    const contacts = [
        {firstName: "Ivan", lastName: "Vankov", phone: "2222222 22 2", email: "asd@abv.bg"},
        {firstName: "Gosho", lastName: "Georgiev", phone: "111 22 2", email: "bga@abv.bg"},
        {firstName: "PEtio", lastName: "PEtkov", phone: "5555 22 2", email: "rt@abv.bg"},
    ];

    getTemplate();

    async function getTemplate() {
        let source = await $.get('greeting.html');
        let template = compile(source);
        
        for (let contact of contacts) {
            main[0].innerHTML += template(contact);
        }
    }

    function parse(htmlAsString, context) {
        return htmlAsString.replace(/{{\s*(\w+)\s*}}/g, (m, gr) => {
            if(context.hasOwnProperty(gr)) {
                return context[gr];
            }

            return m;
        });
    }
    
    function compile(htmlAsString) {
        return (context) => parse(htmlAsString, context);
    }
});