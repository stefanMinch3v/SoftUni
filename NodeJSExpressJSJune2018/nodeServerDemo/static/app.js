function fire() {
    $.get('/data/messages').then(data => {
        console.log(data);
    });
}