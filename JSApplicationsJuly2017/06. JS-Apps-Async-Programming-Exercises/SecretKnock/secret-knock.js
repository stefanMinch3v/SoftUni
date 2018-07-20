$(() => {
    const baseUrl = `https://baas.kinvey.com/appdata/kid_BJXTsSi-e/`;
    const queryString = "knock?query=";
    const username = "guest";
    const password = "guest";
    const base64auth = btoa(`${username}:${password}`);
    const appHeader = {"Authorization": "Basic " + base64auth};
    const btnLoad = $("#btnLoad");
    btnLoad.on('click', loadData);
    let result = $("#result");
    let responseMessage = "Knock Knock.";

    logIn();

    function logIn() {
        btnLoad.attr('disabled', true);
        let credentials = JSON.stringify({ username, password });

        let req = {
            url: baseUrl + "login",
            method:"POST",
            headers : appHeader,
            data: credentials
        };

        $.ajax(req)
            .always(() => btnLoad.attr('disabled', false));
    }

    function loadData() {
        if(responseMessage === undefined){
            result.empty();
            result.append('<h1>End.</h1>');
            return;
        }

        let req = {
            url: baseUrl + queryString + responseMessage,
            method:"GET",
            headers : appHeader
        };

        $.ajax(req)
            .then(displayResults)
            .catch(displayError);
    }

    function displayResults(response) {
        responseMessage = response.message;

        result
            .append($(`<h3>Answer: ${response.answer}</h3>`))
            .append($(`<h3>Message: ${responseMessage === undefined ? 'End': responseMessage}</h3>)`));
    }

    function displayError(err) {
        console.log(err);
    }
});