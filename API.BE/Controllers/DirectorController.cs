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
    public class DirectorController : ControllerBase
    {
        private readonly BibliotecaPeliculasContext dbcontext;
        private readonly IMapper mapper;
        public DirectorController(BibliotecaPeliculasContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Director
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Director>>> GetDirector()
        {
            var res = new BusinessLogic.Director(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Director>, IEnumerable<models.Director>>(res).ToList();
            return mapaux;
        }

        // GET: api/Director/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Director>> GetDirector(long id)
        {
            var Director = new BusinessLogic.Director(dbcontext).GetOneById(id);

            if (Director == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Director, models.Director>(Director);
            return mapaux;
        }

        // PUT: api/Director/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirector(long id, models.Director Director)
        {
            if (id != Director.IdDirector)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Director, data.Director>(Director);
                new BusinessLogic.Director(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!DirectorExists(id))
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

        // POST: api/Director
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Director>> PostDirector(models.Director Director)
        {
            var mapaux = mapper.Map<models.Director, data.Director>(Director);
            new BusinessLogic.Director(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetDirector", new { id = Director.IdDirector }, Director);
        }

        // DELETE: api/Director/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Director>> DeleteDirector(int id)
        {
            var Director = new BusinessLogic.Director(dbcontext).GetOneById(id);
            if (Director == null)
            {
                return NotFound();
            }

            new BusinessLogic.Director(dbcontext).Delete(Director);
            var mapaux = mapper.Map<data.Director, models.Director>(Director);
            return mapaux;
        }

        private bool DirectorExists(long id)
        {
            return (new BusinessLogic.Director(dbcontext).GetOneById(id) != null);
        }
    }
}
