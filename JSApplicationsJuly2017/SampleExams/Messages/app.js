function startApp() {
    if(sessionStorage.getItem('authtoken') === null) {
        userLoggedOut();
    } else {
        userLoggedIn();
    }

    showView('AppHome');

    // attach events
    (() => {
        $('header').find('a[data-target]').on('click', navigateTo);
        $('#formLogin').on('submit', loginData);
        $('#formRegister').on('submit', registerData);
        $('#formSendMessage').on('submit', sendMessage);
        $('#linkMenuLogout').on('click', logOutData);

        $('#linkUserHomeMyMessages').on('click', loadUserReceivedMessages);
        $('#linkMenuMyMessages').on('click', loadUserReceivedMessages);

        $('#linkUserHomeSendMessage').on('click', loadAllUsers);
        $('#linkMenuSendMessage').on('click', loadAllUsers);

        $('#linkMenuArchiveSent').on('click', loadUserSentMessages);
        $('#linkUserHomeArchiveSent').on('click', loadUserSentMessages);

        $('.notification').on('click', function () {
            $(this).hide();
        });
    })();

    // functionality
    function sendMessage(e) {
        e.preventDefault();
        let senderName = sessionStorage.getItem('name');
        let senderUsername = sessionStorage.getItem('username');
        let recipientUsername = $('#msgRecipientUsername').val();
        let msgText = $('#msgText').val();

        messagesService.sendMessage(senderUsername, senderName, recipientUsername, msgText)
            .then(() => {
                showInfo('Message sent');
                showView('ArchiveSent');
                loadUserSentMessages();
            })
            .catch(handleError);
    }

    function loadAllUsers() {
        messagesService.loadAllUsers()
            .then((users) => displayUsersInList(users))
            .catch(handleError);
    }

    function displayUsersInList(users) {
        let usersContainer = $('#msgRecipientUsername');
        usersContainer.empty();

        for (let user of users) {
            let username = user.username;
            let fullName = formatSender(user.name, username);

            if(username !== sessionStorage.getItem('username')){
                usersContainer.append($(`<option value="${username}">${fullName}</option>`));
            }
        }
    }

    function deleteMessage() {
        let msgId = $(this).val();

        messagesService.deleteMessage(msgId)
            .then(() => {
                showInfo('Message deleted.');
                loadUserSentMessages();
            })
            .catch(handleError);
    }

    function loadUserSentMessages() {
        let username = sessionStorage.getItem('username');
        messagesService.loadArchiveMessages(username)
            .then((messages) => displayArchiveMessages(messages))
            .catch(handleError);
    }
    
    function displayArchiveMessages(messages) {
        let messagesContainer = $('#sentMessages');
        messagesContainer.empty();
        let messageTable = $('<table>');
        messageTable
            .append($('<thead>')
                .append($('<tr>')
                    .append('<th>To</th>')
                    .append('<th>Message</th>')
                    .append('<th>Date Sent</th>')
                    .append('<th>Actions</th>')
                ));

        let tBody = $('<tbody>');
        for (let msg of messages) {
            let recipient = msg.recipient_username;
            let msgText = msg.text;
            let msgDate = formatDate(msg._kmd.lmt);

            let deleteBtn = $(`<button value="${msg._id}">Delete</button>`)
                .on('click', deleteMessage);
            let tRow = $('<tr>');
            tRow.append($('<td>').text(recipient));
            tRow.append($('<td>').text(msgText));
            tRow.append($('<td>').text(msgDate));
            tRow.append($('<td>').append(deleteBtn));

            tBody.append(tRow);
        }

        messageTable.append(tBody);
        messagesContainer.append(messageTable);
    }
    
    function loadUserReceivedMessages() {
        let username = sessionStorage.getItem('username');
        messagesService.loadMyMessages(username)
            .then((messages) => displayAllMessages(messages))
            .catch(handleError);
    }

    function displayAllMessages(messages) {
        let messagesContainer = $('#myMessages');
        messagesContainer.empty();
        let messageTable = $('<table>');
        messageTable
            .append($('<thead>')
                .append($('<tr>')
                    .append('<th>From</th>')
                    .append('<th>Message</th>')
                    .append('<th>Date Received</th>')
                ));

        let tBody = $('<tbody>');
        for (let msg of messages) {
            let sender = formatSender(msg.sender_name, msg.sender_username);
            let msgText = msg.text;
            let msgDate = formatDate(msg._kmd.lmt);

            let tRow = $('<tr>');
            tRow.append($('<td>').text(sender));
            tRow.append($('<td>').text(msgText));
            tRow.append($('<td>').text(msgDate));

            tBody.append(tRow);
        }

        messageTable.append(tBody);
        messagesContainer.append(messageTable);
    }
    
    function registerData(e) {
        e.preventDefault();
        let username = $('#registerUsername');
        let name = $('#registerName');
        let password = $('#registerPasswd');
        let confirmPassword = $('#registerConfirmPasswd');

        if(password.val() !== confirmPassword.val()) {
            showError('Passwords don`t match');
            return;
        }

        auth.register(username.val(), password.val(), name.val())
            .then(function () {
                showInfo('User registration successful.');
                auth.login(username.val(), password.val())
                    .then(function (userInfo) {
                        username.val('');
                        name.val('');
                        password.val('');
                        confirmPassword.val('');
                        showInfo('Login successful.');
                        saveSession(userInfo);
                    })
                    .catch(handleError);
            })
            .catch(handleError);
    }

    function logOutData() {
        auth.logout()
            .then(function () {
                showInfo('Logout successful.');
                sessionStorage.clear();
                userLoggedOut();
            })
            .catch(handleError);
    }

    function loginData(e) {
        e.preventDefault();
        let username = $('#loginUsername');
        let password = $('#loginPasswd');

        auth.login(username.val(), password.val())
            .then(function (userInfo) {
                username.val('');
                password.val('');
                showInfo('Login successful.');
                saveSession(userInfo);
            })
            .catch(handleError);
    }

    function userLoggedIn() {
        $('.anonymous').hide();
        $('.useronly').show();
        let username = sessionStorage.getItem('username');
        let welcomeMsg = 'Welcome, ' + username + '!';
        $('#spanMenuLoggedInUser').text(welcomeMsg);
        $('#viewUserHomeHeading').text(welcomeMsg);
        showView('UserHome');
    }

    function userLoggedOut() {
        $('.anonymous').show();
        $('.useronly').hide();
        $('#spanMenuLoggedInUser').text('');
        showView('AppHome');
    }

    function navigateTo() {
        let viewName = $(this).attr('data-target');
        showView(viewName);
    }

    function showView(viewName) {
        $('section').hide();
        $('#view' + viewName).show();
    }

    function handleError(reason) {
        showError(reason.responseJSON.description);
    }

    function showInfo(message) {
        let infoBox = $('#infoBox');
        infoBox.text(message);
        infoBox.show();
        setTimeout(() => infoBox.fadeOut(), 3000);
    }

    function showError(message) {
        let errorBox = $('#errorBox');
        errorBox.text(message);
        errorBox.show();
        setTimeout(() => errorBox.fadeOut(), 3000);
    }

    function saveSession(userInfo) {
        let userAuth = userInfo._kmd.authtoken;
        sessionStorage.setItem('authtoken', userAuth);
        let userId = userInfo._id;
        sessionStorage.setItem('userId', userId);
        let username = userInfo.username;
        sessionStorage.setItem('username', username);
        sessionStorage.setItem('name', userInfo.name);
        userLoggedIn();
    }

    $(document).on({
        ajaxStart: () => $('#loadingBox').show(),
        ajaxStop: () => $('#loadingBox').fadeOut()
    });

    // part of skeleton below
    function formatDate(dateISO8601) {
        let date = new Date(dateISO8601);
        if (Number.isNaN(date.getDate()))
            return '';
        return date.getDate() + '.' + padZeros(date.getMonth() + 1) +
            "." + date.getFullYear() + ' ' + date.getHours() + ':' +
            padZeros(date.getMinutes()) + ':' + padZeros(date.getSeconds());

        function padZeros(num) {
            return ('0' + num).slice(-2);
        }
    }

    function formatSender(name, username) {
        if (!name)
            return username;
        else
            return username + ' (' + name + ')';
    }
}