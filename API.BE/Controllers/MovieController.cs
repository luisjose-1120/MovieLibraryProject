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
    public class MovieController : ControllerBase
    {
        private readonly BibliotecaPeliculasContext dbcontext;
        private readonly IMapper mapper;
        public MovieController(BibliotecaPeliculasContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Movie>>> GetMovie()
        {
            var res = await new BusinessLogic.Movie(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Movie>, IEnumerable<models.Movie>>(res).ToList();

            return mapaux;

        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Movie>> GetMovie(int id)
        {
            var Movie = await new BusinessLogic.Movie(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Movie, models.Movie>(Movie);


            if (Movie == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Movie/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, models.Movie Movie)
        {
            if (id != Movie.IdMovie)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Movie, data.Movie>(Movie);
                new BusinessLogic.Movie(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!MovieExists(id))
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

        // POST: api/Movie
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Movie>> PostMovie(models.Movie Movie)
        {
            var mapaux = mapper.Map<models.Movie, data.Movie>(Movie);
            new BusinessLogic.Movie(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetMovie", new { id = Movie.IdMovie }, Movie);
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Movie>> DeleteMovie(int id)
        {
            var Movie = new BusinessLogic.Movie(dbcontext).GetOneById(id);
            if (Movie == null)
            {
                return NotFound();
            }

            new BusinessLogic.Movie(dbcontext).Delete(Movie);
            var mapaux = mapper.Map<data.Movie, models.Movie>(Movie);
            return mapaux;
        }

        private bool MovieExists(int id)
        {
            return (new BusinessLogic.Movie(dbcontext).GetOneById(id) != null);

        }
    }
}
