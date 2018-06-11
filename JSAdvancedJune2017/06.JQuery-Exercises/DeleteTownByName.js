function attachEvents() {
    $('#btnDelete').on('click', function () {
        let input = $('#townName').val();
        let towns = $('#towns option');
        let result = $('#result');
        let isDeleted = false;

       towns
           .filter((index, element) => $(element).text() === input)
           .each(function (index, element) {
              $(element).remove();
              isDeleted = true;
           });

        result.text(isDeleted
            ? `${input} deleted.`
            : `${input} not found.`);

        $('#townName').val('');
    });
}