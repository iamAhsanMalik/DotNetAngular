using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DesignationController : ControllerBase
{
  private readonly AppDbContext _dbContext;
  public DesignationController(AppDbContext dbContext)
  {
    _dbContext = dbContext;

  }
  // GET: api/Employees
  [HttpGet]
  public async Task<List<Designation>> GetDesignations()
  {
    List<Designation>? designations = await (from des in _dbContext.Designations
                                             select new Designation()
                                             {
                                               Id = des.Id,
                                               DesignationName = des.DesignationName
                                             }).ToListAsync();
    return designations;
  }
  // GET: api/Employee/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Designation>> GetDesignations(int id)
  {
    var designation = await _dbContext.Designations.FindAsync(id);

    if (designation == null)
    {
      return NotFound();
    }
    return designation;
  }


  [HttpPut("{id}")]
  public async Task<IActionResult> PutDesignation(int id, Designation desModel)
  {
    if (id != desModel.Id)
    {
      return BadRequest();
    }

    _dbContext.Entry(desModel).State = EntityState.Modified;

    try
    {
      await _dbContext.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!DesignationExists(id))
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

  [HttpPost]
  public async Task<ActionResult<Designation>> PostDesignation(Designation emplModel)
  {
    await _dbContext.Designations.AddAsync(emplModel);
    await _dbContext.SaveChangesAsync();

    return CreatedAtAction(nameof(GetDesignations), new { id = emplModel.Id }, emplModel);
  }

  // DELETE: api/Employee/5
  [HttpDelete("{id}")]
  public async Task<ActionResult<Designation>> DeleteDesignation(int id)
  {
    var designation = await _dbContext.Designations.FindAsync(id);
    if (designation == null)
    {
      return NotFound();
    }

    _dbContext.Designations.Remove(designation);
    await _dbContext.SaveChangesAsync();

    return designation;
  }

  private bool DesignationExists(int id)
  {
    return _dbContext.Designations.Any(e => e.Id == id);
  }
}
