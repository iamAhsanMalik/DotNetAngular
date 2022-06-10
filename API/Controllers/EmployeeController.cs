using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
  private readonly AppDbContext _dbContext;
  public EmployeeController(AppDbContext dbContext)
  {
    _dbContext = dbContext;

  }
  // GET: api/Employees
  [HttpGet]
  public async Task<List<Employee>> GetEmployees()
  {
    var employees = await (from emp in _dbContext.Employees
                           join des in _dbContext.Designations on emp.Id equals des.Id
                           select new Employee()
                           {
                             Id = emp.Id,
                             FirstName = emp.FirstName,
                             LastName = emp.LastName,
                             Name = $"{emp.FirstName} {emp.LastName}",
                             Age = emp.Age,
                             Doj = emp.Doj,
                             Email = emp.Email,
                             Gender = emp.Gender,
                             IsActive = emp.IsActive,
                             IsMarried = emp.IsMarried,
                             DesignationId = emp.DesignationId,
                             Designation = des.DesignationName,
                           }).ToListAsync();
    return employees;
  }
  // GET: api/Employee/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Employee>> GetEmployees(int id)
  {
    var employee = await _dbContext.Employees.FindAsync(id);

    if (employee == null)
    {
      return NotFound();
    }
    return employee;
  }


  [HttpPut("{id}")]
  public async Task<IActionResult> PutEmployee(int id, Employee empModel)
  {
    if (id != empModel.Id)
    {
      return BadRequest();
    }

    _dbContext.Entry(empModel).State = EntityState.Modified;

    try
    {
      await _dbContext.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!EmployeeExists(id))
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
  public async Task<ActionResult<Employee>> PostEmployee(Employee emplModel)
  {
    await _dbContext.Employees.AddAsync(emplModel);
    await _dbContext.SaveChangesAsync();

    return CreatedAtAction(nameof(GetEmployees), new { id = emplModel.Id }, emplModel);
  }

  // DELETE: api/Employee/5
  [HttpDelete("{id}")]
  public async Task<ActionResult<Employee>> DeleteEmployee(int id)
  {
    var employee = await _dbContext.Employees.FindAsync(id);
    if (employee == null)
    {
      return NotFound();
    }

    _dbContext.Employees.Remove(employee);
    await _dbContext.SaveChangesAsync();

    return employee;
  }

  private bool EmployeeExists(int id)
  {
    return _dbContext.Employees.Any(e => e.Id == id);
  }
}
