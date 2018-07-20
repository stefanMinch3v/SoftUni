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
    postSelect.on('change', viewPosts);

    // load auto data
    loadPosts();

    function request(endpoint) {
        return $.ajax({
            url: url + endpoint,
            headers: appHeaders
        });
    }

    // only the function that handles the promise should be async - await
    async function loadPosts() {
        postSelect.attr('disabled', true);
        postSelect.append($('<option>Loading...</option>'));

        try {
            let data = await request("/posts");
            postSelect.attr('disabled', false);
            postSelect.empty();
            postSelect.prepend($('<option disabled selected>---SELECT---</option>'));

            for (let post of data) {
                $(`<option>`)
                    .text(post.title)
                    .val(post._id)
                    .appendTo(postSelect);
            }
        } catch (err) {
            displayError(err);
        } finally {
            postSelect.attr('disabled', false);
        }
    }

    async function viewPosts() {
        postSelect.attr('disabled', true);
        //let postId = $('#posts').val();
        // or
        let postId = $('#posts').find('option:selected').val();

        let urlComments = `/comments?query={"post_id":"${postId}"}`;

        let postPr = request("/posts/" + postId);
        let commentsPr = request(urlComments);

        try {
            let [data, comments] = await Promise.all([postPr, commentsPr]);

            postComments.empty();
            postTitle.text($("select option:selected").text());
            postBody.text(data.body);
            if(comments.length > 0){
                for (let comment of comments) {
                    $('<li>')
                        .text(comment.text)
                        .appendTo(postComments);
                }
                return;
            }
            postComments.append($('<li>').text('no comments!'));
        } catch(err) {
            displayError(err);
        } finally {
            postSelect.attr('disabled', false)
        }
    }

    function displayError(err) {
        let errorDiv = $("<div>")
            .text(`Error: ${err.status} (${err.statusText})`)
            .css('background-color', 'red');
        $(document.body).prepend(errorDiv);
        setTimeout(function() {
            $(errorDiv).fadeOut(function() {
                $(errorDiv).remove();
            });
        }, 3000);
    }
}