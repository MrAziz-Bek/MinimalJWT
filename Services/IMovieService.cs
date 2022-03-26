using MinimalJWT.Models;

namespace MinimalJWT.Services;

public interface IMovieService
{
    Movie Create(Movie movie);
    Movie Get(int id);
    List<Movie> List();
    Movie Update(Movie newMovie);
    bool Delete(int id);
}