function jsonHtml(json) {
    let html = '<table>\n';

    html += '   <tr><th>name</th><th>score</th></tr>\n';
    let scores = JSON.parse(json);

    for (let element of scores) {
        html += '   <tr>';
        html += `<td>${htmlEscape(element.name)}</td>`;
        html += `<td>${Number(element.score)}</td>`;
        html += `</tr>\n`;
    }

    html += '</table>';

    return html;

    function htmlEscape(text) {
        let map = {
            '"': '&quot;',
            '&': '&amp;',
            "'": '&#39;',
            '<': '&lt;',
            '>': '&gt;'
        };

        return text.replace(/[\"&'<>]/g, e => map[e]);
    }
}

console.log(jsonHtml('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]'));