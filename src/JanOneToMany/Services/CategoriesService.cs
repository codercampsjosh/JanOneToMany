using JanOneToMany.Interfaces;
using JanOneToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JanOneToMany.Services
{
    public class CategoriesService : ICategoriesService
    {
        private IGenericRepo _repo;
        public List<Category> ListCategories()
        {
            List<Category> cats = (from c in _repo.Query<Category>()
                                   select new Category
                                   {
                                       Id = c.Id,
                                       Name = c.Name,
                                       Movies = c.Movies
                                   }).ToList();
            return cats;
        }
        public Category GetCategory(int id)
        {
            Category cat = (from c in _repo.Query<Category>()
                            where c.Id == id
                            select new Category
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Movies = c.Movies
                            }).FirstOrDefault();
            return cat;
        }
        public Category GetCategoryWithoutMovies(int id)
        {
            Category cat = (from c in _repo.Query<Category>()
                            where c.Id == id
                            select c).FirstOrDefault();
            return cat;
        }
        public void AddCategory(Category cat)
        {
            _repo.Add(cat);
        }
        public void UpdateCategory(Category cat)
        {
            _repo.Update(cat);
        }
        public void DeleteCategory(Category cat)
        {
            _repo.Delete(cat);
        }

        public CategoriesService(IGenericRepo repo)
        {
            _repo = repo;
        }
    }
}
