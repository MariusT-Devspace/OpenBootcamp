
const shoppingList = ["Tomatoes", "Milk", "Potatoes", "Bread", "Olive oil"];
shoppingList.push("Sunflower oil");
shoppingList.pop("Sunflower oil");

const favoriteMovies = [
    {
        Title: "The Matrix",
        Director: "The Wachowskis",
        Release: new Date(1999, 02, 31)
    },
    {
        Title: "Guardians of the Galaxy",
        Director: "James Gunn",
        Release: new Date(2014, 07, 1)
    },
    {
        Title: "The Terminator",
        Director: "James Cameron",
        Release: new Date(1984, 09, 26)
    }
];

const favoriteMoviesAfter2010 = favoriteMovies.filter(movie => movie.Release >= new Date(2010, 01, 1));
const favoriteMoviesDirectors = favoriteMovies.map(movie => movie.Director);
const favoriteMoviesTitles = favoriteMovies.map(movie => movie.Title);
const favoriteMoviesTitlesAndDirectors = favoriteMoviesTitles.concat(favoriteMoviesDirectors);
const favoriteMoviesTitlesAndDirectorsUsingSpreadOperator = [...favoriteMoviesTitles, ...favoriteMoviesDirectors];


console.log("Favorite movies:");
console.log();
favoriteMovies.forEach(movie => {
    console.log("Title: " + movie.Title),
    console.log("Director: " + movie.Director),
    console.log("Release: " + movie.Release.getFullYear())
    console.log();
});

console.log();
console.log("Favorite movies after January 1st of 2010: ");
console.log();
favoriteMoviesAfter2010.forEach(movie => {
    console.log("Title: " + movie.Title),
    console.log("Director: " + movie.Director),
    console.log("Release: " + movie.Release.getFullYear());
    console.log();
});

console.log("Favorite movies - directors: ");
console.log(favoriteMoviesDirectors);

console.log();
console.log("Favorite movies - titles: ");
console.log(favoriteMoviesTitles);

console.log();
console.log("Favorite movies - titles and directors: ");
console.log(favoriteMoviesTitlesAndDirectors);

console.log();
console.log("Favorite movies - titles and directors using the spread operator: ");
console.log(favoriteMoviesTitlesAndDirectorsUsingSpreadOperator);