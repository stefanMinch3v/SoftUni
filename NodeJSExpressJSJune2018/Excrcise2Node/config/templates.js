module.exports = {
    movieTemplate: (posterUrl) => `
        <div class='movie'>
            <img class='moviePoster' src=${decodeURIComponent(posterUrl)}/>
        </div>
    `,
    successTemplate: `
        <div id='succssesBox'>
            <h2 id='succssesMsg'>Successfully added</h2>
        </div>
    `,
    errorTemplate: `
        <div id='errorBox'>
            <h2 id='errMsg'>Please fill all fields</h2>
        </div>
    `,
    movieDetailsTemplate: (posterUrl) => `
        <div class='content'>
            <img src=${decodeURIComponent(posterUrl)}/>
        </div>
    `,
    placeHolderTemplate: '<div id="replaceMe">{{replaceMe}}</div>',
    statusMoviesTemplate: (counter) => `
        <div>
            <h1>${counter}</h1>
        </div>
    `
};