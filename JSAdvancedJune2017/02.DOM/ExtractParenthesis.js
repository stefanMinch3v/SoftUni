let match = extract('content');
document.getElementById('result').textContent = match;

function extract(elementId) {
	let elements = document.getElementById(elementId).textContent;
	let regexPattern = /\(([^)]+)\)/g;
	let result = [];

	let match = regexPattern.exec(elements);
	while (match != null){
		result.push(match[1]);

		match = regexPattern.exec(elements);
	}

	return result.join('; ');
}