
const shoppingList = ["Tomatoes", "Milk", "Potatoes", "Bread", "Olive oil"];
shoppingList.push("Sunflower oil");
shoppingList.pop("Sunflower oil");

const favoriteMovies = [
    {
        title: "The Matrix",
        director: "The Wachowskis",
        release: new Date(1999, 02, 31)
    },
    {
        title: "Guardians of the Galaxy",
        director: "James Gunn",
        release: new Date(2014, 07, 1)
    },
    {
        title: "The Terminator",
        director: "James Cameron",
        release: new Date(1984, 09, 26)
    }
];

const favoriteMoviesAfter2010 = favoriteMovies.filter(movie => movie.release >= new Date(2010, 01, 1));
const favoriteMoviesdirectors = favoriteMovies.map(movie => movie.director);
const favoriteMoviestitles = favoriteMovies.map(movie => movie.title);
const favoriteMoviestitlesAnddirectors = favoriteMoviestitles.concat(favoriteMoviesdirectors);
const favoriteMoviestitlesAnddirectorsUsingSpreadOperator = [...favoriteMoviestitles, ...favoriteMoviesdirectors];


console.log("Favorite movies:");
console.log();
favoriteMovies.forEach(movie => {
    console.log("Title: " + movie.title),
    console.log("Director: " + movie.director),
    console.log("Release: " + movie.release.getFullYear())
    console.log();
});

console.log();
console.log("Favorite movies after January 1st of 2010: ");
console.log();
favoriteMoviesAfter2010.forEach(movie => {
    console.log("Title: " + movie.title),
    console.log("Director: " + movie.director),
    console.log("Release: " + movie.release.getFullYear());
    console.log();
});

console.log("Favorite movies - directors: ");
console.log(favoriteMoviesdirectors);

console.log();
console.log("Favorite movies - titles: ");
console.log(favoriteMoviestitles);

console.log();
console.log("Favorite movies - titles and directors: ");
console.log(favoriteMoviestitlesAnddirectors);

console.log();
console.log("Favorite movies - titles and directors using the spread operator: ");
console.log(favoriteMoviestitlesAnddirectorsUsingSpreadOperator);