using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessionalListBlazor.Shared;
using System;
using System.Xml.Linq;

namespace ProfessionalListBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalListController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfessionalListController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
            public async Task<ActionResult<List<ProfessionalList>>> GetProfessionalLists()
            {
            var lists = await _context.ProfessionalLists.Include(sh => sh.Style).ToListAsync();
            return Ok(lists);
            }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessionalList>> GetSingleList(int id)
        {
            var list = await _context.ProfessionalLists
                .Include(h => h.Style)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (list == null)
            {
                return NotFound("Professional Not Found. :/");
            }
            return Ok(list);
        }

        [HttpGet("styles")]
        public async Task<ActionResult<Style>>GetStyles()
        {
            var styles = await _context.Styles.ToListAsync();
            return Ok(styles);
        }

        [HttpPost]
        public async Task<ActionResult<ProfessionalList>> CreateProfissionalList(ProfessionalList list)
        {
            list.Style = null;
            _context.ProfessionalLists.Add(list);
            await _context.SaveChangesAsync();
            return Ok(await GetDbLists());
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProfessionalList>> UpdateProfissionalList(ProfessionalList list, int id)
        {
            var dbList = await _context.ProfessionalLists
          .Include(sh => sh.Style)
          .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbList == null)
                return NotFound("Sorry Professional Not Found. :/");

            dbList.Name = list.Name;
            dbList.Position = list.Position;
            dbList.StyleId = list.StyleId;

            await _context.SaveChangesAsync();
            return Ok(await GetDbLists());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfessionalList>> DeleteProfessionalList(int id)
        {
            var dbList = await _context.ProfessionalLists
          .Include(sh => sh.Style)
          .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbList == null)
                return NotFound("Sorry Professional Not Found. :/");

            _context.ProfessionalLists.Remove(dbList);

            await _context.SaveChangesAsync();
            return Ok(await GetDbLists());

        }

        private async Task<List<ProfessionalList>> GetDbLists()
        {
          return await _context.ProfessionalLists.Include(sh => sh.Style).ToListAsync();
        }    

}

}
