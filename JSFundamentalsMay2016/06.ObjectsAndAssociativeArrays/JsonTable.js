function parseToHtmlTable(json) {
    let html = '<table>\n';

    for (let line of json) {
        let obj = JSON.parse(line);

        html += '\t<tr>\n';
        html += `		<td>${obj.name}</td>\n`;
        html += `		<td>${obj.position}</td>\n`;
        html += `		<td>${obj.salary}</td>\n`;
        html += '\t</tr>\n';
    }

    html += '</table>';
    return html;
}

console.log(parseToHtmlTable([
    '{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}'
]));