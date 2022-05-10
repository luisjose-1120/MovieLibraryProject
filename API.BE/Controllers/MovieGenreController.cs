using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using data = DataAccessLayer.DataObject;
using DataAccessLayer.EntityFramework;
using models = API.BE.Models;

namespace API.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenreController : ControllerBase
    {
        private readonly BibliotecaPeliculasContext dbcontext;
        private readonly IMapper mapper;
        public MovieGenreController(BibliotecaPeliculasContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/MovieGenre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.MovieGenre>>> GetMovieGenre()
        {
            var res = await new BusinessLogic.MovieGenre(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.MovieGenre>, IEnumerable<models.MovieGenre>>(res).ToList();

            return mapaux;

        }

        // GET: api/MovieGenre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.MovieGenre>> GetMovieGenre(int id)
        {
            var MovieGenre = await new BusinessLogic.MovieGenre(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.MovieGenre, models.MovieGenre>(MovieGenre);


            if (MovieGenre == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/MovieGenre/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieGenre(int id, models.MovieGenre MovieGenre)
        {
            if (id != MovieGenre.IdMovieGenre)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.MovieGenre, data.MovieGenre>(MovieGenre);
                new BusinessLogic.MovieGenre(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!MovieGenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieGenre
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.MovieGenre>> PostMovieGenre(models.MovieGenre MovieGenre)
        {
            var mapaux = mapper.Map<models.MovieGenre, data.MovieGenre>(MovieGenre);
            new BusinessLogic.MovieGenre(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetMovieGenre", new { id = MovieGenre.IdMovieGenre }, MovieGenre);
        }

        // DELETE: api/MovieGenre/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.MovieGenre>> DeleteMovieGenre(int id)
        {
            var MovieGenre = new BusinessLogic.MovieGenre(dbcontext).GetOneById(id);
            if (MovieGenre == null)
            {
                return NotFound();
            }

            new BusinessLogic.MovieGenre(dbcontext).Delete(MovieGenre);
            var mapaux = mapper.Map<data.MovieGenre, models.MovieGenre>(MovieGenre);
            return mapaux;
        }

        private bool MovieGenreExists(int id)
        {
            return (new BusinessLogic.MovieGenre(dbcontext).GetOneById(id) != null);

        }
    }
}
