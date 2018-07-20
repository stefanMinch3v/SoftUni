function startApp() {
    localStorage.clear();
    // constants
    const sections = $('section');
    const infoBox = $('#infoBox');
    const loadingBox = $('#loadingBox');
    const errorBox = $('#errorBox');
    const adsDiv = $('#ads');
    const formEdit = $('#formEditAd');

    // header menu
    $('header').find('a').show();

    // menu navigations consts
    const loggedInUserNav = $('#loggedInUser');
    const linkHome = $('#linkHome');
    const linkLogin = $('#linkLogin');
    const linkRegister = $('#linkRegister');
    const linkLogout = $('#linkLogout');
    const linkListAds = $('#linkListAds');
    const linkCreateAd = $('#linkCreateAd');

    // show default data
    //$('header').find('a[data-target]').on('click', navigateToSection); // multiple event click

    // event handlers
    linkHome.on('click', () => showHideMenuList('home'));
    linkListAds.on('click', () => showHideMenuList('ads'));
    linkLogin.on('click', () => showHideMenuList('login'));
    linkLogout.on('click', logout);
    linkRegister.on('click', () => showHideMenuList('register'));
    linkCreateAd.on('click', () => showHideMenuList('create'));
    $('#buttonLoginUser').on('click', login);
    $('#buttonRegisterUser').on('click', register);
    $('#buttonCreateAd').on('click', createAd);

    // user navigation links
    if(localStorage.getItem('authtoken') !== null &&
        localStorage.getItem('username') !== null){
        userLoggedIn();
    } else {
        userLoggedOut();
    }
    showHideMenuList('home');

    // notifications
    $('.notification').on('click', (e) => {
        $(e.target).hide();
    });

    // handle errors and show notifications
    $(document).on({
        ajaxStart: () => loadingBox.show(),
        ajaxStop: () => loadingBox.fadeOut()
    });

    infoBox.on('click', () => $(this).hide());
    errorBox.on('click', () => $(this).hide());

    function showSuccess(message) {
        infoBox.text(message);
        infoBox.show();
        setTimeout(() => infoBox.fadeOut(), 3000);
    }

    function showError(message) {
        errorBox.text(message);
        errorBox.show();
        setTimeout(() => errorBox.fadeOut(), 3000);
    }

    function handleError(err) {
        showError(err.responseJSON.description);
    }

    // logic
    // function navigateToSection() {
    //     sections.hide();
    //     let targetView = $(this).attr('data-target');
    //     $('#' + targetView).show();
    // }

    // main functions
    async function login() {
        let login = $('#formLogin');
        let username = login.find('input[name="username"]').val();
        let password = login.find('input[name="passwd"]').val();

        try {
            let response = await requester.post('user', 'login', { username, password }, 'basic');
            saveSession(response);
            showSuccess('Logged in');
            showHideMenuList('ads');
        } catch(err) {
            handleError(err);
        }
    }

    async function register() {
        let register = $('#formRegister');
        let username = register.find('input[name="username"]').val();
        let password = register.find('input[name="passwd"]').val();

        try {
            let response = await requester.post('user', '', { username, password }, 'basic');
            saveSession(response);
            showSuccess('Successfully registered');
            showHideMenuList('ads');
        } catch(err) {
            handleError(err);
        }
    }

    async function logout() {
        try {
            await requester.post('user', '_logout', { authtoken: localStorage.getItem('authtoken')});
            userLoggedOut();
            localStorage.clear();
            showSuccess('Logged out');
            showHideMenuList('home');
        } catch(err) {
            handleError(err);
        }
    }

    async function loadAds() {
        try {
            let data = await requester.get('appdata', 'posts');
            adsDiv.empty();
            if(data.length === 0){
                adsDiv.append($('<p>No ads in db.</p>'));
                return;
            }

            for (let ad of data) {
                let div = $('<div>');
                div.addClass('ad-box');

                let title = $(`<div class="ad-title">${ad.title}</div>`);
                if(ad._acl.creator === localStorage.getItem('id')) {
                    let deleteBtn = $('<button>&#10006;</button>').on('click', () => deleteAd(ad._id));
                    deleteBtn.addClass('ad-control');
                    deleteBtn.appendTo(title);

                    let editBtn = $('<button>&#9998;</button>').on('click', () => openEditAd(ad));
                    editBtn.addClass('ad-control');
                    editBtn.appendTo(title);
                }

                div.append(title);
                div.append(`<div><img src="${ad.imageUrl}"/></div>`);
                div.append(`<div>Price: ${ad.price.toFixed(2)} lv | By: ${ad.publisher}</div>`);
                div.appendTo(adsDiv);
            }
        } catch(err) {
            handleError(err);
        }
    }

    async function createAd() {
        let form = $('#formCreateAd');
        let title = form.find('input[name="title"]').val();
        let description = form.find('textarea[name="description"]').val();
        let price = Number(form.find('input[name="price"]').val());
        let imageUrl = form.find('input[name="image"]').val();
        let date = (new Date()).toString('yyyy-MM-dd');
        let publisher = localStorage.getItem('username');

        validateTitleAndPrice(title, price);

        let newAd = { title, description, price: Number(price), imageUrl, date, publisher };

        try {
            await requester.post('appdata', 'posts', newAd);
            showSuccess('Successfully published');
            showHideMenuList('ads');
        } catch (err) {
            handleError(err);
        }
    }
    
    async function deleteAd(id) {
        try {
            await requester.remove('appdata', 'posts/' + id);
            showSuccess('Ad deleted');
            showHideMenuList('ads');
        } catch (err) {
            handleError(err);
        }
    }

    async function editAd(id, date, publisher) {
        let title = formEdit.find('input[name="title"]').val();
        let description = formEdit.find('textarea[name="description"]').val();
        let price = Number(formEdit.find('input[name="price"]').val());
        let imageUrl = formEdit.find('input[name="image"]').val();

        await validateTitleAndPrice(title, price);

        let editedAd = { title, description, price, imageUrl, date, publisher };

        try {
            await requester.update('appdata', `posts/${id}`, editedAd);
            showSuccess('Ad edited.');
            showHideMenuList('ads');
        } catch (err) {
            console.log(err);
            handleError(err);
        }
    }

    function openEditAd(ad) {
        formEdit.find('input[name="title"]').val(ad.title);
        formEdit.find('textarea[name="description"]').val(ad.description);
        formEdit.find('input[name="price"]').val(Number(ad.price));
        formEdit.find('input[name="image"]').val(ad.imageUrl);

        let date = ad.date;
        let publisher = ad.publisher;
        let id = ad._id;

        formEdit.find('#buttonEditAd').on('click', () => editAd(id, date, publisher));
        showHideMenuList('edit');
    }

    function saveSession(data) {
        let username = data.username;
        let userId = data._id;
        let authToken = data._kmd.authtoken;

        localStorage.setItem('username', username);
        localStorage.setItem('id', userId);
        localStorage.setItem('authtoken', authToken);
        userLoggedIn();
    }

    function userLoggedIn() {
        loggedInUserNav
            .text(`Welcome, ${localStorage.getItem('username')}`)
            .show();
        linkLogin.hide();
        linkRegister.hide();
        linkLogout.show();
        linkListAds.show();
        linkCreateAd.show();
    }

    function userLoggedOut() {
        loggedInUserNav
            .text('')
            .hide();
        linkLogin.show();
        linkRegister.show();
        linkLogout.hide();
        linkListAds.hide();
        linkCreateAd.hide();
    }

    function validateTitleAndPrice(title, price) {
        if(title.length === 0) {
            showError('Title cant be empty');
            return;
        }
        if(Number.isNaN(price)) {
            showError('Price cant be empty');
            return;
        }
    }

    // CRUDs
    let requester = (() => {
        const appKey = 'kid_BktjcQRZ7';
        const appSecret = '4472a3d4b66841ecb670b30f7ee9347e';
        const baseUrl = 'https://baas.kinvey.com/';

        // CRUD
        function get(module, url, auth) {
            return $.ajax(makeRequest("GET", module, url, auth));
        }

        function post(module, url, data, auth) {
            let req = makeRequest("POST", module, url, auth);
            req.data = JSON.stringify(data);
            req.headers['Content-Type'] = 'application/json';
            return $.ajax(req);
        }

        function update(module, url, data, auth) {
            let req = makeRequest('PUT', module, url, auth);
            req.data = JSON.stringify(data);
            req.headers['Content-Type'] = 'application/json';
            return $.ajax(req);
        }

        function remove(module, url, auth) {
            return $.ajax(makeRequest("DELETE", module, url, auth));
        }

        function makeRequest(method, module, url, auth) {
            return {
                url: baseUrl + module + '/' + appKey + '/' + url,
                method,
                headers: {
                    'Authorization': createAuth(auth)
                }
            }
        }

        function createAuth(type) {
            if(type === 'basic') {
                return 'Basic ' + btoa(appKey + ":" + appSecret);
            }

            return 'Kinvey ' + localStorage.getItem('authtoken');
        }

        return { get, post, update, remove };
    })();

    function showHideMenuList(view) {
        sections.hide();

        switch (view){
            case 'home':
                $('#viewHome').show();
                break;
            case 'login':
                $('#viewLogin').show();
                break;
            case 'register':
                $('#viewRegister').show();
                break;
            case 'ads':
                $('#viewAds').show();
                loadAds();
                break;
            case 'create':
                $('#viewCreateAd').show();
                break;
            case 'edit':
                $('#viewEditAd').show();
                break;
        }
    }
}