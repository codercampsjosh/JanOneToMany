using System.Collections.Generic;
using JanOneToMany.Models;

namespace JanOneToMany.Interfaces
{
    public interface IMovieService
    {
        void AddMovie(Movie mov);
        void DeleteMovie(Movie mov);
        void EditMovie(Movie mov);
        Movie GetMovie(int id);
        List<Movie> ListMovies();
    }
}