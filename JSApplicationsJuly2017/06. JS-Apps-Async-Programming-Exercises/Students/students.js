$(() => {
    const baseUrl = "https://baas.kinvey.com/apdata/kid_BJXTsSi-e/students";
    const username = "guest";
    const password = "guest";
    const base64auth = btoa(`${username}:${password}`);
    const appHeaders = {"Authorization": "Basic " + base64auth };

    let createData = JSON.stringify({
        ID: 2020,
        FirstName: "Aide gogo",
        LastName: "Lud si",
        FacultyNumber: "14141414",
        Grade: 12
    });

    let reqPost = {
        url: baseUrl,
        method: "POST",
        headers: appHeaders,
        contentType: "application/json",
        data: createData
    };

    let reqGet = {
        url: baseUrl,
        method: "GET",
        headers: appHeaders,
        contentType: "application/json",
    };

    $.ajax(reqPost)
        .catch(displayError);

    $.ajax(reqGet)
        .then(displayStudents)
        .catch(displayError);

    function displayStudents(data) {
        for(let student of data) {
            let facultyId = student.FacultyNumber;
            let firstName = student.FirstName;
            let grade = student.Grade;
            let id = student.ID;
            let lastName = student.LastName;
            $(`<tr>`)
                .append($(`<td>${id}</td>`))
                .append($(`<td>${firstName}</td>`))
                .append($(`<td>${lastName}</td>`))
                .append($(`<td>${facultyId}</td>`))
                .append($(`<td>${grade}</td>`))
                .appendTo($("#results"));
        }
    }

    function displayError(err) {
        console.log(err);
    }
});