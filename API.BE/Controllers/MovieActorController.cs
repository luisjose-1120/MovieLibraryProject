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
    public class MovieActorController : ControllerBase
    {
        private readonly BibliotecaPeliculasContext dbcontext;
        private readonly IMapper mapper;
        public MovieActorController(BibliotecaPeliculasContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/MovieActor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.MovieActor>>> GetMovieActor()
        {
            var res = await new BusinessLogic.MovieActor(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.MovieActor>, IEnumerable<models.MovieActor>>(res).ToList();

            return mapaux;

        }

        // GET: api/MovieActor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.MovieActor>> GetMovieActor(int id)
        {
            var MovieActor = await new BusinessLogic.MovieActor(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.MovieActor, models.MovieActor>(MovieActor);


            if (MovieActor == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/MovieActor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieActor(int id, models.MovieActor MovieActor)
        {
            if (id != MovieActor.IdMovieActor)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.MovieActor, data.MovieActor>(MovieActor);
                new BusinessLogic.MovieActor(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!MovieActorExists(id))
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

        // POST: api/MovieActor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.MovieActor>> PostMovieActor(models.MovieActor MovieActor)
        {
            var mapaux = mapper.Map<models.MovieActor, data.MovieActor>(MovieActor);
            new BusinessLogic.MovieActor(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetMovieActor", new { id = MovieActor.IdMovieActor }, MovieActor);
        }

        // DELETE: api/MovieActor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.MovieActor>> DeleteMovieActor(int id)
        {
            var MovieActor = new BusinessLogic.MovieActor(dbcontext).GetOneById(id);
            if (MovieActor == null)
            {
                return NotFound();
            }

            new BusinessLogic.MovieActor(dbcontext).Delete(MovieActor);
            var mapaux = mapper.Map<data.MovieActor, models.MovieActor>(MovieActor);
            return mapaux;
        }

        private bool MovieActorExists(int id)
        {
            return (new BusinessLogic.MovieActor(dbcontext).GetOneById(id) != null);

        }
    }
}
