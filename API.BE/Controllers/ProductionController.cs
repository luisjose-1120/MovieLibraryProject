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
    public class ProductionController : ControllerBase
    {
        private readonly BibliotecaPeliculasContext dbcontext;
        private readonly IMapper mapper;
        public ProductionController(BibliotecaPeliculasContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Production
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Production>>> GetProduction()
        {
            var res = new BusinessLogic.Production(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Production>, IEnumerable<models.Production>>(res).ToList();
            return mapaux;
        }

        // GET: api/Production/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Production>> GetProduction(long id)
        {
            var Production = new BusinessLogic.Production(dbcontext).GetOneById(id);

            if (Production == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Production, models.Production>(Production);
            return mapaux;
        }

        // PUT: api/Production/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduction(long id, models.Production Production)
        {
            if (id != Production.IdProduction)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Production, data.Production>(Production);
                new BusinessLogic.Production(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ProductionExists(id))
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

        // POST: api/Production
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Production>> PostProduction(models.Production Production)
        {
            var mapaux = mapper.Map<models.Production, data.Production>(Production);
            new BusinessLogic.Production(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetProduction", new { id = Production.IdProduction }, Production);
        }

        // DELETE: api/Production/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Production>> DeleteProduction(int id)
        {
            var Production = new BusinessLogic.Production(dbcontext).GetOneById(id);
            if (Production == null)
            {
                return NotFound();
            }

            new BusinessLogic.Production(dbcontext).Delete(Production);
            var mapaux = mapper.Map<data.Production, models.Production>(Production);
            return mapaux;
        }

        private bool ProductionExists(long id)
        {
            return (new BusinessLogic.Production(dbcontext).GetOneById(id) != null);
        }
    }
}
