function solve() {
    class Post {
        constructor(title, content){
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes){
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let baseStr = super.toString();

            let stringComm = [];
            for (let line of this.comments) {
                stringComm.push(` * ${line}`);
            }

            let editComments = this.comments.length < 1 ? '' : `Comments:\n${stringComm.join('\n')}`;
            let finalComments = editComments === '' ? '' : `\n${editComments}`;
            return `${baseStr}\nRating: ${this.likes - this.dislikes}${finalComments}`;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views){
            super(title, content);
            this.views = Number(views);
        }

        view() {
            if(this.views === undefined ||
                this.views === null) {
                this.views = 0;
            }
            this.views++;
            return this;
        }

        toString() {
            let baseStr = super.toString();
            return `${baseStr}\nViews: ${this.views}`;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}

let classes = solve();

let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content
console.log('-----------------------');
let smp = new classes.SocialMediaPost("TestTitle", "TestContent", 5, 10);

smp.addComment("1");
smp.addComment("2");
smp.addComment("3");

console.log(smp.toString());
console.log('-----------------------');

let blog = new classes.BlogPost("TestTitle", "TestContent", 5);

blog.view().view().view();
console.log(blog.toString());
