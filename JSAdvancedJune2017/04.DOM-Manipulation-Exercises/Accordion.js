function toggle() {
    let btnMore = document.getElementsByClassName('button')[0];
    let textToShow = document.getElementById('extra');

    if(btnMore.textContent === 'More') {
        btnMore.textContent = 'Less';
        textToShow.style.display = 'block';
    } else {
        btnMore.textContent = 'More';
        textToShow.style.display = 'none';
    }

    console.log(document.querySelector('span.button'))
}