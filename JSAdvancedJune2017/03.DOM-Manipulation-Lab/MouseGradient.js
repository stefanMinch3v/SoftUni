function attachGradientEvents() {
    let gradient = document.getElementById('gradient');
    gradient.addEventListener('mousemove', onMove);
    gradient.addEventListener('mouseout', onOut);

    function onOut(event) {
        this.textContent = '';
    }

    function onMove(event) {
        let x = event.offsetX;
        let percent = (x / this.clientWidth) * 100; // keyword this can be replace with event.target which points the 'gradient' doc over
        document.getElementById('result').textContent = percent.toFixed(0) + '%';
    }
}