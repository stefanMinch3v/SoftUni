function getInfo() {
    $(() => {
        let stopId = $('#stopId').val();
        let stopName = $('#stopName');

        let req = {
            url: `https://judgetests.firebaseio.com/businfo/${stopId}.json`,
            method: "GET",
            success: loadData,
            error: displayError
        };

        $.ajax(req);

        function loadData(data) {
            let buses = $('#buses');

            stopName.empty();
            buses.empty();

            stopName.text(data.name);
            for (let bus in data.buses) {
                let textBus = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;
                let li = $(`<li>${textBus}</li>`);
                buses.append(li);
            }
        };

        function displayError() {
            stopName.text('Error');
        };
    });
}