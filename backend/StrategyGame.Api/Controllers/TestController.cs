using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Bll.DTOs.Epuletek;
using StrategyGame.Bll.DTOs.Fejlesztesek;
using StrategyGame.Bll.Mappers;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Entities.Models.Fejlesztesek;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly StrategyGameContext _context;
        private readonly IMapper _mapper;

        public TestController(StrategyGameContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Test
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fejlesztes>>> GetFejleszteses()
        {
            return await _context.Fejleszteses.ToListAsync();
        }

        // GET: api/Test/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fejlesztes>> GetFejlesztes(Guid id)
        {
            var fejlesztes = await _context.Fejleszteses.FindAsync(id);

            if (fejlesztes == null)
            {
                return NotFound();
            }

            return fejlesztes;
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFejlesztes(Guid id, Fejlesztes fejlesztes)
        {
            if (id != fejlesztes.Id)
            {
                return BadRequest();
            }

            _context.Entry(fejlesztes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FejlesztesExists(id))
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

        // POST: api/Test
        [HttpPost]
        public async Task<ActionResult<Fejlesztes>> PostFejlesztes([FromBody] AlkimiaDTO fejlesztes)
        {
            var alkimia = _mapper.Map<Alkimia>(fejlesztes);
            _context.Fejleszteses.Add(alkimia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFejlesztes", new { id = fejlesztes.Id }, fejlesztes);
        }

        // DELETE: api/Test/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fejlesztes>> DeleteFejlesztes(Guid id)
        {
            var fejlesztes = await _context.Fejleszteses.FindAsync(id);
            if (fejlesztes == null)
            {
                return NotFound();
            }

            _context.Fejleszteses.Remove(fejlesztes);
            await _context.SaveChangesAsync();

            return fejlesztes;
        }
        [HttpPost]
        public async Task<IActionResult> PostAramlasIranyito([FromBody] AramlasIranyitoDTO aramlasIranyitoDTO)
        {
            _context.Orszags.Include(x => x.Epulets).FirstOrDefault(x => x.Id == new Guid("f2072921-3345-45f1-6592-08d6f62eb2b0")).
                Epulets.Add(_mapper.Map<AramlasIranyito>(aramlasIranyitoDTO));
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetEpulets()
        {
            var asd = _context.Epulets.Add(new AramlasIranyito());
            _context.SaveChanges();
            var ep = _mapper.Map<EpuletDTO>(_context.Epulets.FirstOrDefault());
            if(ep is ITermelo)
            {
                return Ok("Termelo vagyok");
            }
            return  Ok(_mapper.Map<IList<EpuletDTO>>(asd));
        }
        [HttpPost]
        public async Task PostSzonar()
        {
            var orszag = new Orszag();
            orszag.Fejleszteses.Add(new SzonarAgyu());
            _context.Orszags.Add(orszag);
            _context.SaveChanges();
            
        }

        private bool FejlesztesExists(Guid id)
        {
            return _context.Fejleszteses.Any(e => e.Id == id);
        }
    }
}
