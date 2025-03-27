using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

 
public partial class DynamicEmptyKm
{
    [Key]
    public int VehicleId { get; set; }
    public decimal CalculatedKm { get; set; }
    public DateTime InsTime { get; set; }
}

 