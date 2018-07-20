function solve() {
    let currentId = 'depot';
    let stationName = $('.info');
    let currentDataName = 'Depo';
    let arriveBtn = $('#arrive');
    let departBtn = $('#depart');

    function depart() {
        departBtn.attr('disabled', true);
        arriveBtn.attr('disabled', false);

        let req = {
            url: `https://judgetests.firebaseio.com/schedule/${currentId}.json`,
            method: "GET",
            success: loadData
        };

        $.ajax(req);
    }
    
    function arrive() {
        arriveBtn.attr('disabled', true);
        departBtn.attr('disabled', false);

        stationName.text('Arriving at ' + currentDataName);
    }

    function loadData(data) {
        currentId = data.next;
        currentDataName = data.name;
        stationName.text('Next stop ' + currentDataName);
    };

    return {
        depart,
        arrive
    };
}
let result = solve();