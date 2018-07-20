// todo

function attachEvents() {
    const baseUrl = 'https://phonebook-nakov.firebaseio.com/phonebook';
    const list = $('#phonebook');

    $('#btnCreate').on('click', createData);
    $('#btnLoad').on('click', loadData);

    function loadData() {
        let req = {
            url: baseUrl + '.json',
            method: "GET",
            success: displaySuccess,
            error: displayError,
        };

        $.ajax(req);
    }

    function createData() {
        let name = $('#person').val();
        let phone = $('#phone').val();

        if(name === '') {
            return;
        }

        if(phone === '') {
            return;
        }

        let contact = { name, phone };

        let req = {
            url: baseUrl + ".json",
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(contact),
            success: () => {
                $('#person').val('');
                $('#phone').val('');
            },
            error: displayError
        };

        $.ajax(req);
    }

    function deleteContact(contact) {
        let req = {
            url: baseUrl + `/${contact}.json`,
            method: "DELETE",
            contentType: "application/json",
            error: displayError,
        };

        $.ajax(req);
    }

    function displaySuccess(data) {
        list.empty();
        for (let contact in data) {
            let li = $(`<li>${data[contact].name}: ${data[contact].phone}</li>`);
            li.append($(`<button>[Delete]</button>`)
                .on('click', () => deleteContact(contact)));
            list.append(li);
        }
    }

    function displayError(err) {
        alert(`Error: ${err.statusText}`);
    }
}


