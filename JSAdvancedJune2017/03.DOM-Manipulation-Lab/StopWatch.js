function stopwatch() {
    let output = document.getElementById('time');

    let startBtn = document.getElementById('startBtn');
    startBtn.addEventListener('click', startCounting);

    let stopBtn = document.getElementById('stopBtn');
    stopBtn.addEventListener('click', stopCounting);

    let timer = null;
    let seconds = 0;

    function startCounting() {
        seconds = 0;
        outputTime(seconds);

        startBtn.disabled = true;
        stopBtn.disabled = false;

        timer = setInterval(tick, 1000);
    }

    function stopCounting() {
        stopBtn.disabled = true;
        startBtn.disabled = false;

        clearInterval(timer);
    }

    function tick() {
        seconds++;
        outputTime(seconds);
    }

    function outputTime(value) {
        output.textContent = ('0' + Math.floor(value / 60)).slice(-2) + ':' + ('0' + value % 60).slice(-2);
    }
}