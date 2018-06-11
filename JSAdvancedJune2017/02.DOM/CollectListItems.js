function extractText() {
	let area = document.getElementById('result');
	area.value = '';

	let elements = document.getElementById('items');
	for (let i = 0; i < elements.children.length; i++) {
		area.value += elements.children[i].textContent + '\n';
	}
}