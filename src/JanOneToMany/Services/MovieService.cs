using JanOneToMany.Interfaces;
using JanOneToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JanOneToMany.Services
{
    public class MovieService :IMovieService
    {
        private IGenericRepo _repo;
        private ICategoriesService _cService;
        public List<Movie> ListMovies()
        {
            List<Movie> movs = (from m in _repo.Query<Movie>()
                                select new Movie
                                {
                                    Id = m.Id,
                                    Title = m.Title,
                                    Director = m.Director,
                                    Category = m.Category
                                }).ToList();

            return movs;
        }
        public Movie GetMovie(int id)
        {
            Movie mov = (from m in _repo.Query<Movie>()
                         where m.Id == id
                         select new Movie
                         {
                             Id = m.Id,
                             Title = m.Title,
                             Director = m.Director,
                             Category = m.Category
                         }).FirstOrDefault();

            return mov;
        }
        public void AddMovie(Movie mov)
        {
            Category cat = _cService.GetCategoryWithoutMovies(mov.Category.Id);
            mov.Category.Name = cat.Name;
            _repo.Add(mov);


        }
        public void EditMovie(Movie mov)
        {
            Category cat = _cService.GetCategoryWithoutMovies(mov.Category.Id);
            mov.Category = cat;
            _repo.Update(mov);
        }
        public void DeleteMovie(Movie mov)
        {
            _repo.Delete(mov);
        }

        public MovieService(IGenericRepo repo, ICategoriesService cService)
        {
            _repo = repo;
            _cService = cService;
        }
    }
}
