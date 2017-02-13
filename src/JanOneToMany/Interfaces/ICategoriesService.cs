using System.Collections.Generic;
using JanOneToMany.Models;

namespace JanOneToMany.Interfaces
{
    public interface ICategoriesService
    {
        void AddCategory(Category cat);
        void DeleteCategory(Category cat);
        Category GetCategory(int id);
        Category GetCategoryWithoutMovies(int id);
        List<Category> ListCategories();
        void UpdateCategory(Category cat);
    }
}