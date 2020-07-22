using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2_restAPI.Models;
using Task2_restAPI.ViewModels;

namespace Task2_restAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IMapper _mapper; // creates mapper instance ? 

        // Assign the object in the constructor for dependency injection (whetever it means ...)
        public FlatsController(ModelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; // initialize mapper
        }

        // GET: api/Flats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flat>>> GetFlats()
        {
            return await _context.Flats.ToListAsync();
        }

        // GET: api/Flats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flat>> GetFlat(int id)
        {
            var flat = await _context.Flats.FindAsync(id);

            if (flat == null)
            {
                return NotFound();
            }

            return flat;
        }

        //GET: /api/House/5/flats
        [HttpGet("/api/House/{houseId}/[controller]")]
        public async Task<IEnumerable<Flat>> GetFlatsByHouseId(int houseId)
        {
            var rezult = await _context.Flats.Where(flat => flat.HouseId == houseId).ToListAsync();
            return rezult; // должно возвращать нужные квартиры или пустой список
        }
        // PUT: api/Flats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlat(int id, Flat flat)
        {
            if (id != flat.Id)
            {
                return BadRequest();
            }

            _context.Entry(flat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(flat); //CreatedAtAction(nameof(GetFlat), flat); //instaed was NoContent()
        }

        // POST: api/Flats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Flat>> PostFlat(CreateFlatDTO flatDTO)
        {
            // souce -> https://stackoverflow.com/questions/40275195/how-to-set-up-automapper-in-asp-net-core
            // Instantiate the mapped data transfer object
            // using the mapper you stored in the private field.
            // The type of the source object is the first type argument
            // and the type of the destination is the second.
            // Pass the source object you just instantiated above
            // as the argument to the _mapper.Map<>() method.

            var flat = _mapper.Map<CreateFlatDTO, Flat>(flatDTO); // just this single line
            // which maps FlatDTO to Flat
            _context.Flats.Add(flat);
            await _context.SaveChangesAsync();

            return Ok(flat);
        }

        // DELETE: api/Flats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flat>> DeleteFlat(int id)
        {
            var flat = await _context.Flats.FindAsync(id);
            if (flat == null)
            {
                return NotFound();
            }

            _context.Flats.Remove(flat);
            await _context.SaveChangesAsync();

            return flat;
        }

        private bool FlatExists(int id)
        {
            return _context.Flats.Any(e => e.Id == id);
        }
    }
}
