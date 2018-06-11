function sum() {
	let rows = document.querySelectorAll('table tr');
	let total = 0;

	for (let i = 1; i < rows.length; i++) {
		let cols = rows[i].children;
		total += Number(cols[cols.length - 1].textContent);
	}

	document.getElementById('sum').textContent = total;
}

function anotherWaySum() {
	let rows = document.querySelectorAll('table tr td:last-child');
	let total = 0;

	for (let i = 0; i < rows.length - 1; i++) {
		total += Number(rows[i].textContent);
	}

	document.getElementById('sum').textContent = total;
}