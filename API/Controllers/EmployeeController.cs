using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class EmployeeController : ControllerBase
{
  private readonly AppDbContext _dbContext;
  public EmployeeController(AppDbContext dbContext)
  {
    _dbContext = dbContext;

  }
  [HttpGet(Name = "GetEmployeesList")]
  public async Task<List<TblEmployee>> GetEmployees()
  {
    return await (from emp in _dbContext.Employees
                  join des in _dbContext.Designations
                  on emp.DesignationId equals des.Id

                  select new TblEmployee
                  {
                    Id = emp.Id,
                    Name = $"{emp.FirstName} {emp.LastName}",
                    Email = emp.Email,
                    Age = emp.Age,
                    DesignationId = emp.DesignationId,
                    Designation = emp.Designation,
                    Dob = emp.Dob,
                    Gender = emp.Gender,
                    IsActive = emp.IsActive,
                    IsMarried = emp.IsMarried
                  }).ToListAsync();
  }
  // // GET: api/Employee/5
  // [HttpGet("{id}")]
  // public async Task<ActionResult<TblEmployee>> GetTblEmployee(int id)
  // {
  //   var tblEmployee = await _dbContext.Employees.FindAsync(id);

  //   if (tblEmployee == null)
  //   {
  //     return NotFound();
  //   }

  //   return tblEmployee;
  // }


  // [HttpPut("{id}")]
  // public async Task<IActionResult> PutTblEmployee(int id, TblEmployee tblEmployee)
  // {
  //   if (id != tblEmployee.Id)
  //   {
  //     return BadRequest();
  //   }

  //   _dbContext.Entry(tblEmployee).State = EntityState.Modified;

  //   try
  //   {
  //     await _dbContext.SaveChangesAsync();
  //   }
  //   catch (DbUpdateConcurrencyException)
  //   {
  //     if (!TblEmployeeExists(id))
  //     {
  //       return NotFound();
  //     }
  //     else
  //     {
  //       throw;
  //     }
  //   }

  //   return NoContent();
  // }

  // [HttpPost]
  // public async Task<ActionResult<TblEmployee>> PostTblEmployee(TblEmployee tblEmployee)
  // {
  //   _dbContext.Employees.Add(tblEmployee);
  //   await _dbContext.SaveChangesAsync();

  //   return CreatedAtAction("GetTblEmployee", new { id = tblEmployee.Id }, tblEmployee);
  // }

  // // DELETE: api/Employee/5
  // [HttpDelete("{id}")]
  // public async Task<ActionResult<TblEmployee>> DeleteTblEmployee(int id)
  // {
  //   var tblEmployee = await _dbContext.Employees.FindAsync(id);
  //   if (tblEmployee == null)
  //   {
  //     return NotFound();
  //   }

  //   _dbContext.Employees.Remove(tblEmployee);
  //   await _dbContext.SaveChangesAsync();

  //   return tblEmployee;
  // }

  // private bool TblEmployeeExists(int id)
  // {
  //   return _dbContext.Employees.Any(e => e.Id == id);
  // }
}
