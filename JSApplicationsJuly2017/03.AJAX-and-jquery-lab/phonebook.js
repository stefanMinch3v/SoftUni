$(() => { // === document.ready
    const baseUrl = "https://phonebook-softuni-357c1.firebaseio.com/";
    const list = $('#list');

    list.text('Loading...');
    $('#btnCreate').on('click', createData);

    loadData();

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
        let name = $('#crName').val();
        let phone = $('#crPhone').val();

        if(name === '') {
            notify('Empty name', 'error');
            return;
        }

        if(phone === '') {
            notify('Empty phone', 'error');
            return;
        }

        let contact = { name, phone };

        $('#btnCreate').prop('disabled', true);

        let req = {
            url: baseUrl + ".json",
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(contact),
            success: () => {
                $('#crName').val('');
                $('#crPhone').val('');
                notify("Created", "success");
                loadData()
            },
            error: displayError,
            complete: () => $('#btnCreate').prop('disabled', false)
        };

        $.ajax(req);
    }

    function deleteContact(contact) {
        let req = {
            url: baseUrl + `/${contact}.json`,
            method: "DELETE",
            contentType: "application/json",
            success: () => { notify("Deleted", "info"); loadData() },
            error: displayError,
        };

        $.ajax(req);
    }

    function displaySuccess(data) {
        list.empty();
        for (let contact in data) {
            let li = $(`<li><span>${data[contact].name}: ${data[contact].phone}</span></li>`);
            li.append($(`<button>Delete</button>`)
                .on('click', () => deleteContact(contact)));
            list.append(li);
        }
    }

    function displayError(err) {
        notify(`Error: ${err.statusText}`, 'error');
    }

    function notify(message, type) {
        let notification = document.getElementById('notification');
        notification.textContent = message;
        notification.style.display = 'block';

        switch (type) {
            case "error": notification.style.background = "#ff0000"; break;
            case "success": notification.style.background = "#00ff00"; break;
            case "info": notification.style.background = "#0000ff"; break;
        }

        setTimeout(() => notification.style.display = 'none', 3000)
    }
});


