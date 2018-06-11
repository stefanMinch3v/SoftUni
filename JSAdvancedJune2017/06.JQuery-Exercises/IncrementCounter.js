function increment(div) {
    let index = 1;

    let textArea = $('<textarea class="counter" disabled="disabled">0</textarea>');
    // textArea.attr('disabled','true');
    // textArea.attr('class', 'counter');
    // textArea.attr('value', 0);

    let incrementBtn = $('<button class="btn" id="incrementBtn">Increment</button>').on('click', increment);
    // incrementBtn.text('Increment');
    // incrementBtn.attr('class', 'btn');
    // incrementBtn.attr('id', 'incrementBtn');
    // incrementBtn.on('click', increment);

    let addBtn = $('<button class="btn" id="addBtn">Add</button>').on('click', addLi);
    // addBtn.text('Add');
    // addBtn.attr('class', 'btn');
    // addBtn.attr('id', 'addBtn');
    // addBtn.on('click', addLi);

    let ul = $('<ul class="results"></ul>');
    //ul.attr('class', 'results');

    $(div)
        .append(textArea)
        .append(incrementBtn)
        .append(addBtn)
        .append(ul);

    function increment() {
        textArea.text(index);
        ++index;
    }
    
    function addLi() {
        let li = $(`<li>${index - 1}</li>`);
        ul.append(li);
    }
}