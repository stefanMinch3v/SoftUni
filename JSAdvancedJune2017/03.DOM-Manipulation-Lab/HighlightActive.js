function focus() {
    // let allTheDivs = document.querySelectorAll("div div input"); another way

    let elements = document.getElementsByTagName('input');
    let arrayInputs = Array.from(elements);

    arrayInputs.forEach(e => {
        e.addEventListener('focus', onFocus);
        e.addEventListener('blur', onBlur);
    });

    function onBlur(event) {
        event.target.parentNode.className = 'class';
        // same syntax as below
    }

    function onFocus() {
        this.parentNode.className = 'focused';
    }
}