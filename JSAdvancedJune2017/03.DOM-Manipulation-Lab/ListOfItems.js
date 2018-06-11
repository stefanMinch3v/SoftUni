function addItem() {
    let input = document.getElementById('newItemText');
    if(input.value.length === 0) {
        return;
    }

    let newElement = document.createElement('li');
    // it could be done also with document.createTextNode('li');
    newElement.textContent = input.value;

    document.getElementById('items').appendChild(newElement);

    input.value = '';
}

function addItemBeforeOthers() {
    let input = document.getElementById('newItemText');
    if(input.value.length === 0) {
        return;
    }
    let newElement = document.createElement('li');
    newElement.textContent = input.value;

    let items = document.getElementById('items');
    document.getElementById('items').insertBefore(newElement, items.children[0]);

    input.value = '';
}