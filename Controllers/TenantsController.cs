using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2_restAPI.Models;
using Task2_restAPI.ViewModels;

namespace Task2_restAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IMapper _mapper; // creates mapper instance ? 

        // Assign the object in the constructor for dependency injection (whetever it means ...)

        public TenantsController(ModelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; // initialize mapper
        }

        // GET: api/Tenants
        // Methods get tenants with house id
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TenantVM>>> GetTenants()
        {
            List<TenantVM> resultTenants = new List<TenantVM>(); // initialize empty list
            TenantVM tenantWithHouseId; // define temp variable
            // get tenants list from DB
            var tenantsFromDB = await _context.Tenants
                .Include(x => x.Flat)
                .ThenInclude(x => x.House) // for after flat info getting House info
                .ToListAsync();
            // for each element in list => map it into TenantVM and add to result list
            foreach (Tenant ten in tenantsFromDB) {
               tenantWithHouseId = _mapper.Map<Tenant, TenantVM>(ten);
               resultTenants.Add(tenantWithHouseId);

                }

            return resultTenants;
        }

        // GET: api/Tenants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tenant>> GetTenant(int id)
        {
            var tenant = await _context.Tenants
                .Include(x => x.Flat) // for getting Flat information; this is not neccessary there, but i want to remember this
                .ThenInclude(x => x.House) // for after flat info getting House info
                .FirstOrDefaultAsync(x => x.Id == id) // worse analog FindAsync(id);
            ;

            if (tenant == null)
            {
                return NotFound();
            }

            return tenant;
        }

        // GET: api/Flat/5/Tenants
        // methods get Tenants with house id by Flat id ... :) 
        [HttpGet("/api/Flat/{flatId}/[controller]")]
        public async Task<IEnumerable<TenantVM>> GetTenantsByFlatId(int flatId)
        {
            List<TenantVM> resultTenants = new List<TenantVM>(); // initialize empty list
            TenantVM tenantWithHouseId; // define temp variable
            // get tenants list from DB
            var tenantsFromDB = await _context.Tenants
                .Include(x => x.Flat)
                .ThenInclude(x => x.House) // for after flat info getting House info
                .Where(tenant => tenant.FlatId == flatId).ToListAsync();
            // for each element in list => map it into TenantVM and add to result list
            foreach (Tenant ten in tenantsFromDB)
            {
                tenantWithHouseId = _mapper.Map<Tenant, TenantVM>(ten);
                resultTenants.Add(tenantWithHouseId);

            }

            return resultTenants;
        }

        // PUT: api/Tenants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenant(int id, Tenant tenant)
        {
            if (id != tenant.Id)
            {
                return BadRequest();
            }

            _context.Entry(tenant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // TODO: Replace to return updated tenant
            return Ok(tenant); // CreatedAtAction(nameof(GetTenant), tenant); // instead was noContent()
        }

        // POST: api/Tenants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tenant>> PostTenant(CreateTenantDTO tenantDTO)
        {
            // souce -> https://stackoverflow.com/questions/40275195/how-to-set-up-automapper-in-asp-net-core
            // Instantiate the mapped data transfer object
            // using the mapper you stored in the private field.
            // The type of the source object is the first type argument
            // and the type of the destination is the second.
            // Pass the source object you just instantiated above
            // as the argument to the _mapper.Map<>() method.

            var tenant = _mapper.Map<CreateTenantDTO, Tenant>(tenantDTO); // just this single line
            // which maps TenantDTO to Tenant
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();

            return Ok(tenant);
        }

        // DELETE: api/Tenants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tenant>> DeleteTenant(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }

            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();

            return tenant;
        }

        private bool TenantExists(int id)
        {
            return _context.Tenants.Any(e => e.Id == id);
        }
    }
}
