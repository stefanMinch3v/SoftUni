function extractText() {
    //$('#items>li'); gets only the first li
    //$('#items li'); gets all li if there are any nested will get them too
    //$('#items').find('li');

    // let items = $('li').toArray().map(li=>li.textContent).join(", ");
    // $('#result').text(items);

    let result = [];
    $('#items li').each((index, element) => result.push(element.textContent));
    $('#result').text(result.join(', '));
}