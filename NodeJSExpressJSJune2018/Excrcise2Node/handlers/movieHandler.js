const movies = require('../config/dataBase');
const movieTemplate = require('../config/templates').movieTemplate;
const successTemplate = require('../config/templates').successTemplate;
const errorTemplate = require('../config/templates').errorTemplate;
const movieDetailsTemplate = require('../config/templates').movieDetailsTemplate;;
const statusMoviesTemplate = require('../config/templates').statusMoviesTemplate;

const listAllView = 'views/viewAll.html';
const addView = 'views/addMovie.html';
const detailsView = 'views/details.html';
const listCountAllView = 'views/status.html';

module.exports = (req, res) => {
    let path = req.path;
    let method = req.method;
    if (path === '/viewAllMovies') {
        switch (method) {
            case 'GET':
                let moviesHtml = movies
                    .map(m => movieTemplate(m.moviePoster));
                res.view(listAllView, moviesHtml);
                break;
        }
    } else if (path === '/addMovie') {
        switch (method) {
            case 'GET':
                res.view(addView);
                break;
            case 'POST':
                let movieData = req.bodyData;
                if (!movieData.moviePoster || !movieData.movieTitle) {
                    res.view(addView, errorTemplate);
                    return;
                }

                movies.push(movieData);
                res.view(addView, successTemplate);
                break;
        }
    } else if (path.startsWith('/movies/details/')) {
        switch (method) {
            case 'GET':
                let id = Number(path.split('/').pop()) - 1;
                let movie = movies[id];

                if (!movie) {
                    return res.view(listAllView);
                }

                res.view(detailsView, movieDetailsTemplate(movie.moviePoster));
                break;
        }
    } else if(path === '/movies/full') {
        switch (method) {
            case 'GET':
                let counter = movies.length;
                if (counter < 1) {
                    return res.view(listAllView);
                }

                res.view(listCountAllView, statusMoviesTemplate(counter));
                break;
        }
    } else {
        return true;
    }
};