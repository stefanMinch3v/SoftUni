function attachEvents() {
    // db constants
    const baseUrl = "https://baas.kinvey.com/appdata/kid_S18092wZQ/biggestCatches";
    const username = "fisher";
    const password = "fisher";
    const base64auth = btoa(`${username}:${password}`);
    const appHeaders = {"Authorization": "Basic " + base64auth };

    // dom elements constants
    const angler = $('#addForm>.angler');
    const weight = $('#addForm>.weight'); // number parse
    const species = $('#addForm>.species');
    const location = $('#addForm>.location');
    const bait = $('#addForm>.bait');
    const captureTime = $('#addForm>.captureTime'); // number parse
    const divCatches = $('#catches');
    const readBtn = $('.load');
    const addBtn = $('.add');

    // attach events - update and delete are below in createAndPopulateData
    addBtn.on('click', createFish);
    readBtn.on('click', readAllFishes);
    //.on('click', deleteFish);

    async function createFish() {
        addBtn.attr('disabled', true);
        let isValid = checkForEmptyData([angler.val(), weight.val(), species.val(), location.val(), bait.val(), captureTime.val()]);
        if(!isValid){
            displayError("Invalid");
            addBtn.attr('disabled', false);
            return;
        }

        let data = JSON.stringify({
            angler: angler.val(),
            weight: Number(weight.val()),
            species: species.val(),
            location: location.val(),
            bait: bait.val(),
            captureTime: Number(captureTime.val())
        });

        try {
            await request(baseUrl, "POST", data);
            await readAllFishes();
            clearFields();

        } catch (err) {
            displayError(err);
        } finally {
            addBtn.attr('disabled', false);
        }
    }

    async function readAllFishes() {
        divCatches.empty();
        divCatches.html('Loading...');
        readBtn.attr('disabled', true);

        try {
            let req = await request(baseUrl, "GET", '');
            displayData(req);
        } catch(err) {
            displayError(err);
        } finally {
            readBtn.attr('disabled', false);
        }
    }

    async function updateFish() {
        // btn update
        let btnUpdate = $(this).parent().children('.update');
        btnUpdate.attr('disabled', true);

        // btn delete
        let btnDel = $(this).parent().children('.delete');
        btnDel.attr('disabled', true);

        let domElement = $(this).parent();

        let angler = domElement.children('.angler').val();
        let weight = domElement.children('.weight').val(); // number parse
        let species = domElement.children('.species').val();
        let location = domElement.children('.location').val();
        let bait = domElement.children('.bait').val();
        let captureTime = domElement.children('.captureTime').val(); // number parse

        let isValid = checkForEmptyData([angler, weight, species, location, bait, captureTime]);
        if(!isValid){
            displayError("Invalid");
            btnDel.attr('disabled', false);
            btnUpdate.attr('disabled', false);
            return;
        }

        let id = $(this).parent()[0].attributes[1].value;
        if(id === '' ||
        id === undefined) {
            console.log('invalid');
            return;
        }

        let data = JSON.stringify({
            angler: angler,
            weight: Number(weight),
            species: species,
            location: location,
            bait: bait,
            captureTime: Number(captureTime)
        });

        try {
            await request(`${baseUrl}/${id}`, "PUT", data);
            await readAllFishes();
        } catch(err) {
            displayError(err);
        } finally {
            btnUpdate.attr('disabled', false);
            btnDel.attr('disabled', false);
        }
    }

    async function deleteFish() {
        // btn update
        let btnUpdate = $(this).parent().children('.update');
        btnUpdate.attr('disabled', true);

        // btn delete
        let btnDel = $(this).parent().children('.delete');
        btnDel.attr('disabled', true);

        let id = $(this).parent()[0].attributes[1].value;
        if(id === '' ||
            id === undefined) {
            displayError("Invalid");
            btnUpdate.attr('disabled', false);
            btnDel.attr('disabled', false);
            return;
        }

        try {
            await request(baseUrl + `/${id}`, "DELETE", '');
        } catch (err) {
            displayError(err);
        } finally {
            $(this).parent().detach();
        }
    }

    function request(url, method, dataSend) {
        return $.ajax({
            url: url,
            headers: appHeaders,
            contentType: "application/json",
            method: method,
            data: dataSend
        })
    }

    function displayData(data) {
        divCatches.empty();
        if(data.length < 1) {
            displayError("Error");
            return;
        }

        for (let line of data) {
            let id = line._id;
            let angler = line.angler;
            let weight = line.weight;
            let species = line.species;
            let location = line.location;
            let bait = line.bait;
            let captureTime = line.captureTime;

            createAndPopulateData(id, angler, weight, species, location, bait, captureTime);
        }
    }

    function displayError(err) {
        let error = err.statusText ? err.statusText : "Error";
        alert(error);
    }

    function createAndPopulateData(id, angler, weight, species, location, bait, captureTime) {
        let divCatch = $(`<div class="catch" data-id=${id}>`);
        let labelAngler = $('<label>Angler</label>');
        let anglerInput = $('<input type="text" class="angler"/>').val(angler);
        let labelWeight = $('<label>Weight</label>');
        let weightInput = $('<input type="number" class="weight"/>').val(weight);
        let labelSpecies = $('<label>Species</label>');
        let speciesInput = $('<input type="text" class="species"/>').val(species);
        let labelLocation = $('<label>Location</label>');
        let locationInput = $('<input type="text" class="location"/>').val(location);
        let labelBait = $('<label>Bait</label>');
        let baitInput = $('<input type="text" class="bait"/>').val(bait);
        let labelCapture = $('<label>Capture Time</label>');
        let caputreInput = $('<input type="number" class="captureTime"/>').val(captureTime);
        let btnUpdate = $('<button class="update">Update</button>')
            .on('click', updateFish); // add event update
        let btnDelete = $('<button class="delete">Delete</button>')
            .on('click', deleteFish); // add event delete

        divCatches
            .append(divCatch
                .append(labelAngler)
                .append(anglerInput)
                .append(labelWeight)
                .append(weightInput)
                .append(labelSpecies)
                .append(speciesInput)
                .append(labelLocation)
                .append(locationInput)
                .append(labelBait)
                .append(baitInput)
                .append(labelCapture)
                .append(caputreInput)
                .append(btnUpdate)
                .append(btnDelete));
    }

    function clearFields() {
        angler.val('');
        weight.val(0); // number parse
        species.val('');
        location.val('');
        bait.val('');
        captureTime.val(0); // number parse
    }

    function checkForEmptyData(arr) {
        return arr.filter(e => e === '').length < 1;
    }
}