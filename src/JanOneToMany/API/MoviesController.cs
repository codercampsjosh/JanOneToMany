using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JanOneToMany.Data;
using JanOneToMany.Models;
using Microsoft.EntityFrameworkCore;
using JanOneToMany.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JanOneToMany.API
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private IMovieService _movService;
        [HttpGet]
        public List<Movie> Get()
        {
            return _movService.ListMovies();
        }
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _movService.GetMovie(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Movie mov)
        {
                if(mov == null)
            {
                return BadRequest();
            } else if (mov.Id == 0)
            {
                _movService.AddMovie(mov);
                return Ok();
            } else
            {
                _movService.EditMovie(mov);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Movie mov)
        {
            _movService.DeleteMovie(mov);

            return Ok();
        }
        public MoviesController(IMovieService movService)
        {
            _movService = movService;
        }
    }
}
