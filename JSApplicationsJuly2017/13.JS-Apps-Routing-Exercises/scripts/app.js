$(() => {
    const app = Sammy('#main', function () {
        // TODO: Define all the routes
        this.use('Handlebars', 'hbs');

        // home page
        this.get('index.html', displayHome);
        this.get('#/home', displayHome);

        // about page
        this.get('#/about', displayAbout);

        // login page
        this.get('#/login', displayLogin);
        this.post('#/login', (context) => sendLoginData(context));
        this.get('#/logout', (context) => logoutAndClearData(context));

        // register page
        this.get('#/register', displayRegister);
        this.post('#/register', (context) => sendRegisterData(context));

        // catalog page
        this.get('#/catalog', (context) => displayCatalog(context));
        this.get('#/create', (context) => displayCreateTeam(context));
        this.post('#/create', (context) => sendCreateTeam(context));

        // team page
        this.get('#/catalog:id', (context) => getTeamDetails(context));

        // join team by id
        this.get('#/join/:id', function (context) {
            let teamId = context.params.id.substr(1);

            teamsService.joinTeam(teamId)
                .then(function (userInfo) {
                    auth.saveSession(userInfo);
                    auth.showInfo('Successfully joined');
                    displayCatalog(context);
                })
                .catch(auth.handleError);
        });

        // leave team
        this.get('#/leave', function (context) {
            teamsService.leaveTeam()
                .then(function (userInfo) {
                    auth.saveSession(userInfo);
                    auth.showInfo('Left...');
                    displayCatalog(context);
                })
                .catch(auth.handleError);
        });

        // edit team
        this.get('#/edit/:id', function (context) {
           let teamId = context.params.id.substr(1);
           teamsService.loadTeamDetails(teamId)
               .then(function (teamInfo) {
                   context.teamId = teamId;
                   context.name = teamInfo.name;
                   context.comment = teamInfo.comment;

                   context.loadPartials({
                       header: './templates/common/header.hbs',
                       footer: './templates/common/footer.hbs',
                       editForm: './templates/edit/editForm.hbs'
                   }).then(function () {
                       this.partial('./templates/edit/editPage.hbs');
                   });
               })
               .catch(auth.handleError);
        });
        this.post('#/edit/:id', function (context) {
            let teamId = context.params.id.substr(1);
            let teamName = context.params.name;
            let teamComment = context.params.comment;

            teamsService.edit(teamId, teamName, teamComment)
                .then(function () {
                    auth.showInfo(`Team ${teamName} edited`);
                    displayCatalog(context);
                })
                .catch(auth.handleError);
        });

        function getTeamDetails(context) {
            let teamId = context.params.id.substr(1);
            
            teamsService.loadTeamDetails(teamId)
                .then(function (teamInfo) {
                    context.loggedIn = sessionStorage.getItem('authtoken') !== null;
                    context.username = sessionStorage.getItem('username');
                    context.teamId = teamId;
                    context.isAuthor = teamInfo._acl.creator === sessionStorage.getItem('userId');
                    context.name = teamInfo.name;
                    context.comment = teamInfo.comment;
                    context.isOnTeam = teamInfo._id === sessionStorage.getItem('teamId');
                    context.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        teamControls: './templates/catalog/teamControls.hbs'
                    }).then(function () {
                        this.partial('./templates/catalog/details.hbs');
                    });
                })
                .catch(auth.handleError);
        }

        function sendCreateTeam(context) {
            let teamName = context.params.name;
            let teamComment = context.params.comment;

            teamsService.createTeam(teamName, teamComment)
                .then(function (teamInfo) {
                    teamsService.joinTeam(teamInfo._id)
                        .then(function (userInfo) {
                            auth.saveSession(userInfo);
                            auth.showInfo(`Team ${teamName} created`);
                            displayCatalog(context);
                        })
                        .catch(auth.handleError)
                })
                .catch(auth.handleError);
        }
        
        function displayCreateTeam(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');
            
            context.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                createForm: './templates/create/createForm.hbs'
            }).then(function () {
                this.partial('./templates/create/createPage.hbs');
            });
        }

        function displayCatalog(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');

            teamsService.loadTeams()
                .then(function (teams) {
                   context.hasNoTeam = sessionStorage.getItem('teamId') === null ||
                       sessionStorage.getItem('teamId') === 'undefined';
                   context.teams = teams;
                   console.log(teams); // check
                })
                .catch(auth.handleError);

            context.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                team: './templates/catalog/team.hbs'
            }).then(function () {
                this.partial('./templates/catalog/teamCatalog.hbs');
            });
        }

        function sendRegisterData(context) {
            let username = context.params.username;
            let password = context.params.password;
            let confirmPassword = context.params.repeatPassword;

            if(password !== confirmPassword) {
                auth.showError('Passwords do not match');
                return;
            }

            auth.register(username, password)
                .then(function (userInfo) {
                    auth.saveSession(userInfo);
                    auth.showInfo('Registered');
                    displayHome(context);
                })
                .catch(auth.handleError);
        }

        function displayRegister(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');

            context.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                registerForm: './templates/register/registerForm.hbs'
            }).then(function () {
                this.partial('./templates/register/registerPage.hbs');
            });
        }

        function logoutAndClearData(context) {
            auth.logout()
                .then(function () {
                    sessionStorage.clear();
                    auth.showInfo('Logged out');
                    displayHome(context);
                })
                .catch(auth.handleError);
        }

        function sendLoginData(context) {
            let username = context.params.username;
            let password = context.params.password;

            auth.login(username, password)
                .then(function (userInfo) {
                    auth.saveSession(userInfo);
                    auth.showInfo('Logged In');
                    displayHome(context);
                })
                .catch(auth.handleError);
        }

        function displayLogin(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');

            context.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                loginForm: './templates/login/loginForm.hbs'
            }).then(function () {
                this.partial('./templates/login/loginPage.hbs');
            });
        }

        function displayAbout(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');

            context.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs'
            }).then(function () {
                this.partial('./templates/about/about.hbs');
            });
        }

        function displayHome(context) {
            context.loggedIn = sessionStorage.getItem('authtoken') !== null;
            context.username = sessionStorage.getItem('username');

            context.loadPartials({
                // partials loaded into the main template
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs'
            }).then(function () {
                // main template
                this.partial('./templates/home/home.hbs');
            });
        }
    });

    app.run();
});