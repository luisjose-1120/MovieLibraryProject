using AutoMapper;
using data = DataAccessLayer.DataObject;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = API.BE.Models;

namespace API.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly BibliotecaPeliculasContext dbcontext;
        private readonly IMapper mapper;
        public GenreController(BibliotecaPeliculasContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Genre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Genre>>> GetGenre()
        {
            var res = new BusinessLogic.Genre(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Genre>, IEnumerable<models.Genre>>(res).ToList();
            return mapaux;
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Genre>> GetGenre(long id)
        {
            var Genre = new BusinessLogic.Genre(dbcontext).GetOneById(id);

            if (Genre == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Genre, models.Genre>(Genre);
            return mapaux;
        }

        // PUT: api/Genre/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(long id, models.Genre Genre)
        {
            if (id != Genre.IdGenre)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Genre, data.Genre>(Genre);
                new BusinessLogic.Genre(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!GenreExists(id))
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

        // POST: api/Genre
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Genre>> PostGenre(models.Genre Genre)
        {
            var mapaux = mapper.Map<models.Genre, data.Genre>(Genre);
            new BusinessLogic.Genre(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetGenre", new { id = Genre.IdGenre }, Genre);
        }

        // DELETE: api/Genre/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Genre>> DeleteGenre(int id)
        {
            var Genre = new BusinessLogic.Genre(dbcontext).GetOneById(id);
            if (Genre == null)
            {
                return NotFound();
            }

            new BusinessLogic.Genre(dbcontext).Delete(Genre);
            var mapaux = mapper.Map<data.Genre, models.Genre>(Genre);
            return mapaux;
        }

        private bool GenreExists(long id)
        {
            return (new BusinessLogic.Genre(dbcontext).GetOneById(id) != null);
        }
    }
}
