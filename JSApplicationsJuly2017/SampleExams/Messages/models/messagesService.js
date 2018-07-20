let messagesService = (() => {
    function loadMyMessages(username) {
        return requester.get('appdata', `messages?query={"recipient_username":"${username}"}`, 'Kinvey');
    }

    function loadArchiveMessages(username) {
        let endpoint = `messages?query={"sender_username":"${username}"}`;
        return requester.get('appdata', endpoint, 'Kinvey');
    }

    function deleteMessage(messageId) {
        return requester.remove('appdata', `messages/${messageId}`, 'Kinvey');
    }

    function loadAllUsers() {
        return requester.get('user', '', 'Kinvey');
    }

    function sendMessage(sender_username, sender_name, recipient_username, text) {
        let msgData = {
            sender_username,
            sender_name,
            recipient_username,
            text
        };

        return requester.post('appdata', 'messages', 'Kinvey', msgData);
    }

    return {
        loadMyMessages,
        loadArchiveMessages,
        deleteMessage,
        loadAllUsers,
        sendMessage
    }
})();