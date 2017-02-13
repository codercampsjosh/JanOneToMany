using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JanOneToMany.Data;
using JanOneToMany.Models;
using JanOneToMany.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JanOneToMany.API
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private IGenericRepo _repo;

        [HttpGet]
        public List<Category> Get()
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

        [HttpGet("{id}")]
        public Category Get(int id)
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

        [HttpPost]
        public IActionResult Post([FromBody]Category category)
        {
            //This is the beginning of the conditional logic block
            if(category == null)
            {
                return BadRequest();
            }
            else if (category.Id == 0)
            {
                _repo.Add(category);
                return Ok();
            }
            else
            {
                _repo.Update(category);
                return Ok();
            }
            //This is the end of the conditional logic block
        }
        public CategoriesController(IGenericRepo repo)
        {
            _repo = repo;
        }
    }
}
