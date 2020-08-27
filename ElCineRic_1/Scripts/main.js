$(document).ready(() => {
    $('#searchForm').on('submit', (e) => {
        let searchText = $('#searchText').val();
        getMovies(searchText);
        e.preventDefault();
    });
});

function getMovies(searchText) {
    axios.get('http://www.omdbapi.com/?apikey=819e143&s=?'
        + searchText)
        .then((response) => {
            console.log(response);
            let movies = response.data.Search;
            let output = '';
            $.each(movies, (index, movie) => {
                output += `
        <div class=" card border-info mb-3" style="margin-left:10px; margin-right:10px">
          <img src="${movie.Poster}" class="card-img-top" alt="...">
          <div class="card-body">
            <h5 class="card-title">${movie.Title}</h5>
            <a href="#" onclick="movieSelected('${movie.imdbID}')" class="btn btn-primary">Ver deatlles</a>
          </div>
        </div>
        `;
            });

            $('#movies').html(output);
        })
        .catch((err) => {
            console.log(err);
        });
}

function movieSelected(id) {
    sessionStorage.setItem('movieId', id);
    window.location = 'movie';
    return false;
}

function getMovie() {
    let movieId = sessionStorage.getItem('movieId');

    axios.get('http://www.omdbapi.com/?apikey=819e143&plot=full&i=' + movieId)
        .then((response) => {
            console.log(response);
            let movie = response.data;

            let output = `
        <div class="row">
          <div class="col-md-4">
            <img src="${movie.Poster}" class="thumbnail">
          </div>
          <div class="col-md-8">
            <h2>${movie.Title}</h2>
            <ul class="list-group">
              <li class="list-group-item"><strong>ID:</strong> ${movie.imdbID}</li>
              <li class="list-group-item"><strong>Genero:</strong> ${movie.Genre}</li>
              <li class="list-group-item"><strong>Lanzamiento:</strong> ${movie.Released}</li>
              <li class="list-group-item"><strong>Calificación:</strong> ${movie.Rated}</li>
              <li class="list-group-item"><strong>IMDB Rating:</strong> ${movie.imdbRating}</li>
              <li class="list-group-item"><strong>Director:</strong> ${movie.Director}</li>
              <li class="list-group-item"><strong>Escritor:</strong> ${movie.Writer}</li>
              <li class="list-group-item"><strong>Actores:</strong> ${movie.Actors}</li>
            </ul>
          </div>
        </div>
        <br/>
        <div class="row">
          <div class="well">
            <h3>Trama</h3>
            ${movie.Plot}
            <hr>
            <a href="http://imdb.com/title/${movie.imdbID}" target="_blank" class="btn btn-primary">Ver info en IMDB</a>
            <a href="/Funciones/db" class="btn btn-default">Buscar otras películas</a>
          </div>
        </div>
      `;

            $('#movie').html(output);
        })
        .catch((err) => {
            console.log(err);
        });
}
