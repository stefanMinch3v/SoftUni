function attachEvents() {
    const appdataRoute = "appdata/";
    const rpcRoute = "rpc/";
    const appKey = "kid_BJ_Ke8hZg";
    const baseUrl = "https://baas.kinvey.com/";
    const username = "guest";
    const password = "pass";
    const base64auth = btoa(`${username}:${password}`);
    const appHeaders = {"Authorization": "Basic " + base64auth};

    // button events
    let btnGetVenues = $('#getVenues');
    btnGetVenues.on('click', loadData);

    function loadData() {
        let date = $('#venueDate').val();

        let req = {
            url: baseUrl + rpcRoute + appKey + `/custom/calendar?query=${date}`,
            method: "POST",
            headers: appHeaders
        };

        $.ajax(req)
            .then(displayData)
            .catch(displayError);
    }

    function displayData(data) {
        for (let line of data) {
            let req = {
                url: baseUrl + appdataRoute + appKey + `/venues/${line}`,
                method: "GET",
                headers: appHeaders
            };

            $.ajax(req)
                .then(getAvailableVenues)
                .catch(displayError);
        }
    }

    function displayError(err) {
        console.log(err);
    }

    function getAvailableVenues(venue) {
        // create and attach dom from jicata
        $(`<div class="venue" id="${venue._id}">`)
            .append($(`<span class="venue-name">`)
                .append($(`<input class="info" type="button" value="More info">`)
                    .on('click', showHideDetails))
                .append(`${venue.name}`))
            .append($(`<div class="venue-details" style="display: none">`)
                .append($(`<table>`)
                    .append($(`<tr>`)
                        .append($(`<th>Ticket Price</th>`))
                        .append($(`<th>Quantity</th>`)))
                    .append($(`<tr>`)
                        .append($(`<td class="venue-price">${venue.price}</td>`))
                        .append($(`<td>`)
                            .append($(`<select class="quantity">`)
                                .append($(`<option value="1">1</option>`))
                                .append($(`<option value="2">2</option>`))
                                .append($(`<option value="3">3</option>`))
                                .append($(`<option value="4">4</option>`))
                                .append($(`<option value="5">5</option>`))))
                        .append($(`<td>`)
                            .append($(`<input class="purchase" type="button" value="Purchase">`)
                                .on('click', purchaseItem)))))
                .append($(`<span class="head">Venue description:</span>`))
                .append($(`<p class="description">${venue.description}</p>`))
                .append($(`<p class="description">Starting time: ${venue.startingHour}</p>`)))
            .appendTo($("#venue-info"));
    }

    function showHideDetails() {
        let parentDiv = $(this).parent().parent();
        let parentDivId = $(parentDiv).attr("id");
        let venueDetailsDiv = $(`#${parentDivId}`).find('.venue-details');
        let displayValue = $(venueDetailsDiv).prop("style")["display"];
        if (displayValue === 'none') {
            $(venueDetailsDiv).css('display', 'inline-block');
        }
        else {
            $(venueDetailsDiv).css('display', 'none');
        }
    }

    function purchaseItem() {
        $("#venue-info").empty();
        let parentDiv = $(this).parents("div:first");
        let venueId = $(this).parents("div:last").attr("id");
        let venueName = $(parentDiv).prev().text();
        let qty = Number($(parentDiv).find(".quantity option:selected").val());
        let price = Number($(parentDiv).find(".venue-price").text());

        $(`<span class="head">Confirm purchase</span>`)
            .append($(`<div class="purchase-info">`)
                .append($(`<span>${venueName}</span>`))
                .append($(`<span>${qty} x ${price}</span>`))
                .append($(`<span>Total: ${qty * price} lv</span>`))
                .append($(`<input type="button" value="Confirm">`)
                    .on('click', finalizePurchase)))
            .appendTo($("#venue-info"));

        function finalizePurchase() {
            let purchaseUrl = `${baseUrl}${rpcRoute}${appKey}/custom/purchase?venue=${venueId}&qty=${qty}`;
            let purchaseRequest = {
                type: 'POST',
                url: purchaseUrl,
                headers: appHeaders
            };

            $.ajax(purchaseRequest)
                .then(displayFinalStatement)
                .catch(displayError);

            function displayFinalStatement(response) {
                $("#venue-info").empty();
                $("#venue-info").append("You may print this page as your ticket");
                $("#venue-info").append(response.html);
            }
        }
    }
}