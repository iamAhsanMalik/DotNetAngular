using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

public class Employee
{
  [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  [StringLength(30)]
  public string? FirstName { get; set; }
  [StringLength(30)]
  public string? LastName { get; set; }
  [StringLength(250)]
  public string? Email { get; set; }
  public int Age { get; set; }
  public string? Doj { get; set; }
  [StringLength(250)]
  public string? Gender { get; set; }
  public int IsMarried { get; set; }
  public int IsActive { get; set; }
  [ForeignKey("DesignationId")]
  public int DesignationId { get; set; }
  [NotMapped]
  public string? Designation { get; set; }
  [NotMapped]
  public string? Name { get; set; }
}
