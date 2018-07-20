function attachEvents() {
    // const
    const baseUrl = "https://judgetests.firebaseio.com/";
    const divForecast = $('#forecast');
    const divCurrent = $('#current');
    const divUpcoming = $('#upcoming');
    const weatherElements = {
        "Sunny": "&#x2600", // ☀
        "Partly sunny": "&#x26C5", // ⛅
        "Overcast":	"&#x2601", // ☁
        "Rain":	"&#x2614", // ☂
        "Degrees": "&#176"   // °
    };

    // events
    $('#submit').on('click', loadWeather);

    function loadWeather() {
        let req = {
            url: baseUrl + "locations.json",
            method: "GET"
        };

        $.ajax(req)
            .then(getLocations)
            .catch(displayErrors);
    }

    function getLocations(data) {
        // clear previous data
        divUpcoming.empty();
        divCurrent.empty();

        // adjust display
        let inputText = $('#location').val();
        divForecast.css('display', 'inline-block');

        // add titles
        divCurrent.append($('<div class="label">Current conditions</div>'));
        divUpcoming.append('<div class="label">Three-day forecast</div>');

        // filter the data
        let result = data.filter(e => e.name === inputText);
        if(result.length < 1){
            displayErrors();
            return;
        }

        // async queries
        let reqConditions = $.ajax(baseUrl + `forecast/today/${result[0].code}.json`);
        let reqThreeDays = $.ajax(baseUrl + `forecast/upcoming/${result[0].code}.json`);

        // change func to async
        // and try catch in order to catch the error
        //let reqConditions = await $.ajax(baseUrl + `forecast/today/${result[0].code}.json`);
        //let reqThreeDays = await $.ajax(baseUrl + `forecast/upcoming/${result[0].code}.json`);
        // displayWeather(reqConditions, reqThreeDays);

        Promise.all([reqConditions, reqThreeDays])
            .then(displayWeather)
            .catch(displayErrors);
    }

    function displayWeather([conditions, threeDays]) {
        // current weather elements
        let cityName = conditions.name;
        let symbol = conditions.forecast.condition;
        let high = conditions.forecast.high;
        let low = conditions.forecast.low;

        // create current dom elements
        let currentSymbol = $('<span>')
            .html(weatherElements[symbol])
            .addClass('condition symbol');
        let currentName = $('<span>')
            .text(cityName)
            .addClass('forecast-data');
        let currentTemperature = $('<span>')
            .html(`${low}${weatherElements.Degrees}/${high}${weatherElements.Degrees}`)
            .addClass('forecast-data');
        let weatherType = $('<span>')
            .text(symbol)
            .addClass('forecast-data');

        // attach current elements to dom
        let spanConditions = $('<span>').addClass('condition');
        divCurrent
            .append(currentSymbol)
            .append(spanConditions);
        spanConditions
            .append(currentName)
            .append(currentTemperature)
            .append(weatherType);

        // create upcoming weather elements and attach them to dom
        for (let line of threeDays.forecast) {
            // get elements
            let condition = line.condition;
            let high = line.high;
            let low = line.low;
            let upcomingSymbol = weatherElements[condition];
            let upcomingDegrees = weatherElements.Degrees;

            // create dom elements and attach them to dom
            let upcomingSpan = $('<span>')
                .addClass('upcoming')
                .append($('<span class="symbol">').html(upcomingSymbol))
                .append($('<span class="forecast-data">').html(`${low}${upcomingDegrees}/${high}${upcomingDegrees}`))
                .append($('<span class="forecast-data">').text(condition));
            divUpcoming.append(upcomingSpan);
        }
    }

    function displayErrors() {
        divForecast.css('display', 'inline-block');
        divCurrent.append($('<p>Error</p>'));
        divUpcoming.append($('<p>Error</p>'));
    }
}