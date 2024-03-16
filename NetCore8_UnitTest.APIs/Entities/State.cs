using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetCore8_UnitTest.APIs.Entities;

[Table("State")]
public partial class State
{
    [Key]
    public int StateId { get; set; }

    [StringLength(200)]
    public string? StateName { get; set; }

    [Column("StateName_MM")]
    [StringLength(200)]
    public string? StateNameMm { get; set; }
}
