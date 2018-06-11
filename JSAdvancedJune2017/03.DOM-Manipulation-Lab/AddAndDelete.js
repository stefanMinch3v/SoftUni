function addItem() {
    let input = document.getElementById('newText');
    if(input.value.length === 0) {
        return;
    }

    let newElement = document.createElement('li');
    newElement.textContent = input.value + ' ';

    // it can be done with span
    // let span = document.createElement('span');
    // span.innerHTML = '<a href="#">[Delete]</a>';

    let removeLink = document.createElement('a');
    removeLink.textContent = '[Delete]';
    removeLink.href = '#';
    removeLink.addEventListener('click', deleteItem); // deleteItem without parentheses means that we send it through reference, otherwise it will be executed on the same row and there is no reason of doing that

    newElement.appendChild(removeLink);

    document.getElementById('items').appendChild(newElement);

    input.value = '';

    function deleteItem() {
        document.getElementById('items').removeChild(newElement);
    }
}
