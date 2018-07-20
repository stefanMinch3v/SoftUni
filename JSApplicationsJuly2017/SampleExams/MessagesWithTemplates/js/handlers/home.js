handlers.home = function () {
    let content = {};
    if (auth.isAuthed()) {
        this.username = localStorage.getItem('username');
        content = util.getPartials('userHome');
    } else {
        // redirect cuz unlogged user can access the routes
        content = util.getPartials('appHome');
    }

    this.loadPartials(content).then(function () {
        this.partial('./templates/common/main.hbs');
    });
};