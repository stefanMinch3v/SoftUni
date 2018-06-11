function search() {
    let pattern = $('#searchText').val();
    let matched = $(`ul#towns li:contains(${pattern})`);
    matched.css('font-weight', 'bold');
    $(`ul#towns li:not(:contains(${pattern}))`).css('font-weight', '');
    $('#result').text(`${matched.length} matches found.`);
}