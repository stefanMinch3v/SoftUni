function countdown(startTime) {
	let time = startTime;
	let output = document.getElementById('time');

	let timer = setInterval(tick, 1000); //in millsec
	
	function tick() {
		time--;
		if(time <= 0){
			clearInterval(timer);
		}

		output.value = `${Math.floor(time / 60)}:${('0' + time % 60).slice(-2)}`;
	}
}