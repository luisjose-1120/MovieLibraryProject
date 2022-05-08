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
    public class ActorController : ControllerBase
    {
        private readonly BibliotecaPeliculasContext dbcontext;
        private readonly IMapper mapper;
        public ActorController(BibliotecaPeliculasContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Actor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Actor>>> GetActor()
        {
            var res = new BusinessLogic.Actor(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Actor>, IEnumerable<models.Actor>>(res).ToList();
            return mapaux;
        }

        // GET: api/Actor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Actor>> GetActor(long id)
        {
            var Actor = new BusinessLogic.Actor(dbcontext).GetOneById(id);

            if (Actor == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Actor, models.Actor>(Actor);
            return mapaux;
        }

        // PUT: api/Actor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(long id, models.Actor Actor)
        {
            if (id != Actor.IdActor)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Actor, data.Actor>(Actor);
                new BusinessLogic.Actor(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ActorExists(id))
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

        // POST: api/Actor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Actor>> PostActor(models.Actor Actor)
        {
            var mapaux = mapper.Map<models.Actor, data.Actor>(Actor);
            new BusinessLogic.Actor(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetActor", new { id = Actor.IdActor }, Actor);
        }

        // DELETE: api/Actor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Actor>> DeleteActor(int id)
        {
            var Actor = new BusinessLogic.Actor(dbcontext).GetOneById(id);
            if (Actor == null)
            {
                return NotFound();
            }

            new BusinessLogic.Actor(dbcontext).Delete(Actor);
            var mapaux = mapper.Map<data.Actor, models.Actor>(Actor);
            return mapaux;
        }

        private bool ActorExists(long id)
        {
            return (new BusinessLogic.Actor(dbcontext).GetOneById(id) != null);
        }
    }
}
