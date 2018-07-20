function attachEvents() {
    const baseUrl = "https://messenger-softuni.firebaseio.com/messenger.json";
    $('#refresh').on('click', refreshData);
    $('#submit').on('click', insertDataInToDb);

    function refreshData() {
        let req = {
            url: baseUrl,
            method: "GET",
            success: insertData,
            error: displayError
        };

        $.ajax(req);
    }

    function insertData(data) {
        let textLine = '';

        for (let line in data) {
            textLine += `${data[line].author}: ${data[line].content}\n`;
        }

        $('#messages').text(textLine);
    }

    function insertDataInToDb() {
        let name = $('#author');
        let message = $('#content');

        if(name.val() === '' ||
        message.val() === '') {
            return;
        }

        let objData = {
            author: name.val(),
            content: message.val(),
            timestamp: Date.now()
        };

        let req = {
            url: baseUrl,
            method: "POST",
            data: JSON.stringify(objData),
            error: displayError,
            complete: () => message.val('')
        };

        $.ajax(req);
    }

    function displayError(err) {
        alert('Something went wrong: ' + err.statusText)
    }
}