using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PractiaApi.Data;
using PractiaApi.Model;

namespace PractiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalServicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HospitalServicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HospitalServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalService>>> GetHospitalServices()
        {
            return await _context.HospitalServices.ToListAsync();
        }

        // GET: api/HospitalServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalService>> GetHospitalService(int id)
        {
            var hospitalService = await _context.HospitalServices.FindAsync(id);

            if (hospitalService == null)
            {
                return NotFound();
            }

            return hospitalService;
        }

        // PUT: api/HospitalServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalService(int id, HospitalService hospitalService)
        {
            if (id != hospitalService.HospitalId)
            {
                return BadRequest();
            }

            _context.Entry(hospitalService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalServiceExists(id))
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

        // POST: api/HospitalServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HospitalService>> PostHospitalService(HospitalService hospitalService)
        {
            _context.HospitalServices.Add(hospitalService);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HospitalServiceExists(hospitalService.HospitalId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHospitalService", new { id = hospitalService.HospitalId }, hospitalService);
        }

        // DELETE: api/HospitalServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospitalService(int id)
        {
            var hospitalService = await _context.HospitalServices.FindAsync(id);
            if (hospitalService == null)
            {
                return NotFound();
            }

            _context.HospitalServices.Remove(hospitalService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospitalServiceExists(int id)
        {
            return _context.HospitalServices.Any(e => e.HospitalId == id);
        }
    }
}
