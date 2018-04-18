function unique(arr) {
    arr = arr
        .map(e => e
            .toLowerCase()
            .split(new RegExp(/\W/, 'g'))
            .filter(e => e !== ''));

    let set = new Set();

    for (let element of arr) {
        for (let el of element) {
            set.add(el);
        }
    }

    return [...set].join(', ');
}

console.log(unique([
    'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui.',
    'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.',
    'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.',
    'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.',
    'Morbi in ipsum varius, pharetra diam vel, mattis arcu.',
    'Integer ac turpis commodo, varius nulla sed, elementum lectus.',
    'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.'
]));