using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

[Route("api/[controller]")]
[ApiController]
public class MedicinesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public MedicinesController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ManageMedicine>>> GetMedicines()
    {
        return await _context.ManageMedicines.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ManageMedicine>> GetMedicine(int id)
    {
        var medicine = await _context.ManageMedicines.FindAsync(id);

        if (medicine == null)
        {
            return NotFound();  
        }

        return medicine;
    }

    [HttpPost]
    public async Task<ActionResult<ManageMedicine>> PostMedicine(ManageMedicine medicine)
    {
        _context.ManageMedicines.Add(medicine);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMedicine), new { id = medicine.Id }, medicine);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMedicine(int id, ManageMedicine medicine)
    {
        if (id != medicine.Id)
        {
            return BadRequest();  
        }

        _context.Entry(medicine).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ManageMedicines.Any(e => e.Id == id))
            {
                return NotFound();  
            }
            throw;
        }

        return NoContent(); 
    }
    //delete method
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedicine(int id)
    {
        var medicine = await _context.ManageMedicines.FindAsync(id);
        if (medicine == null)
        {
            return NotFound();
        }
        _context.ManageMedicines.Remove(medicine);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
