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

        public TenantsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Tenants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tenant>>> GetTenants()
        {
            return await _context.Tenants.ToListAsync();
        }

        // GET: api/Tenants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tenant>> GetTenant(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);

            if (tenant == null)
            {
                return NotFound();
            }

            return tenant;
        }

        //GET: api/Tenants/Flats/5
        [HttpGet("Flats/{flatId}")]
        public async Task<IEnumerable<Tenant>> GetTenantsByFlatId(int flatId)
        {
            var rezult = await _context.Tenants.AsQueryable().Where(tenant => tenant.FlatId.Equals(flatId)).ToListAsync();
            return rezult; // returns Tenant list filtered by necessary flat id
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
        public async Task<ActionResult<Tenant>> PostTenant(createTenantDTO tenantDTO)
        {
            var config = new MapperConfiguration(cfg => // for DTO
            {
                cfg.CreateMap<createTenantDTO, Tenant>();
            });
            IMapper iMapper = config.CreateMapper();
            var tenantDestination = iMapper.Map<createTenantDTO, Tenant>(tenantDTO);
            _context.Tenants.Add(tenantDestination);
            await _context.SaveChangesAsync();

            return Ok(tenantDestination);
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
