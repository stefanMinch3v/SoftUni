function create(sentences) {
    let content = document.getElementById('content');
    content.className = 'content';

    for (let element of sentences) {
        let div = document.createElement('div');
        let p = document.createElement('p');

        p.textContent = element;
        p.style.display = 'none';

        div.addEventListener('click', showData);

        div.appendChild(p);
        content.appendChild(div);
    }

    function showData() {
        this.firstChild.style.display = 'inline-block';
    }
}

// or
function create2(sentences) {
    let content = document.getElementById('content');
    content.className = 'content';

    for (let element of sentences) {
        let div = document.createElement('div');
        let p = document.createElement('p');

        p.textContent = element;
        p.style.display = 'none';

        div.addEventListener('click', function () {
            p.style.display = 'inline-block';
        });

        div.appendChild(p);
        content.appendChild(div);
    }
}