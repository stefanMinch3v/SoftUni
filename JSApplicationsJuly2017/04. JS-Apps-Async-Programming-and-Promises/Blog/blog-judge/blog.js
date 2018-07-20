function attachEvents() {
    // connection data
    const url = "https://baas.kinvey.com/appdata/kid_SyqZaH8bQ";
    const username = "peter";
    const password = "p";
    const base64auth = btoa(`${username}:${password}`);
    const appHeaders = {"Authorization": "Basic " + base64auth };

    // dom elements
    const postBody = $('#post-body');
    const postTitle = $('#post-title');
    const postSelect = $('#posts');
    const postComments = $('#post-comments');

    // events
    $('#btnLoadPosts').on('click', loadPosts);
    $("#btnViewPost").on('click', viewPosts);

    function loadPosts() {
        let req = {
            url: url + "/posts",
            method: "GET",
            headers: appHeaders
        };

        $.ajax(req)
            .then(displayPosts)
            .catch(displayError);
    }
    
    function viewPosts() {
        let postId = $('#posts').val();
        let urlComments = url + `/comments?query={"post_id":"${postId}"}`;

        let reqComments = $.ajax({
            url: urlComments,
            method: "GET",
            headers: appHeaders
        });

        let reqPosts = $.ajax({
            url: url + "/posts/" + postId,
            method: "GET",
            headers: appHeaders
        });

        Promise.all([reqComments, reqPosts])
            .then(displayCommentsAndPosts)
            .catch(displayError);
    }

    function displayPosts(data) {
        postSelect.empty();
        for (let post of data) {
            $(`<option>`)
                .text(post.title)
                .val(post._id)
                .appendTo(postSelect);
        }
    }

    function displayCommentsAndPosts([comments, posts]) {
        postComments.empty();
        postTitle.text($("select option:selected").text());
        postBody.text(posts.body);
        if(comments.length > 0){
            for (let comment of comments) {
                $('<li>')
                    .text(comment.text)
                    .appendTo(postComments);
            }
        }
    }

    function displayError(err) {
        let errorDiv = $("<div>")
            .text(`Error: ${err.status} (${err.statusText})`);
        $(document.body).prepend(errorDiv);
        setTimeout(function() {
            $(errorDiv).fadeOut(function() {
                $(errorDiv).remove();
            });
        }, 3000);
    }
}