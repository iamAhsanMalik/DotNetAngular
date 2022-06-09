using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities;

public class TblEmployee
{
  [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public Guid Id { get; set; }
  [StringLength(30)]
  public string? FirstName { get; set; }
  [StringLength(30)]
  public string? LastName { get; set; }
  [StringLength(250)]
  public string? Email { get; set; }
  public int Age { get; set; }
  public DateTime? Dob { get; set; }
  [StringLength(250)]
  public string? Gender { get; set; }
  public int IsMarried { get; set; }
  public int IsActive { get; set; }
  [ForeignKey("DesignationId")]
  public Guid DesignationId { get; set; }
  [NotMapped]
  public string? Designation { get; set; }
  [NotMapped]
  public string? Name { get; set; }
}
