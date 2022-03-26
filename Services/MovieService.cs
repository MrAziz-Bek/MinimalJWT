using MinimalJWT.Models;
using MinimalJWT.Repositories;

namespace MinimalJWT.Services;
public class MovieService : IMovieService
{
    public Movie Create(Movie movie)
    {
        movie.Id = MovieRepository.Movies.Count + 1;
        MovieRepository.Movies.Add(movie);

        return movie;
    }

    public bool Delete(int id)
    {
        var oldMovie = MovieRepository.Movies.FirstOrDefault(m => m.Id == id);
        if (oldMovie is null)
            return false;

        MovieRepository.Movies.Remove(oldMovie);
        return true;
    }

    public Movie Get(int id)
        => MovieRepository.Movies.FirstOrDefault(m => m.Id == id);

    public List<Movie> List()
        => MovieRepository.Movies.ToList();

    public Movie Update(Movie newMovie)
    {
        var oldMovie = MovieRepository.Movies.FirstOrDefault(m => m.Id == newMovie.Id);
        if (oldMovie is null)
        {
            return null;
        }
        oldMovie.Title = newMovie.Title ?? oldMovie.Title;
        oldMovie.Description = newMovie.Description ?? oldMovie.Description;
        oldMovie.Rating = newMovie.Rating == default(int) ? oldMovie.Rating : newMovie.Rating;
        return oldMovie;
    }
}