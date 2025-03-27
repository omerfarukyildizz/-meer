using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class VtlPackageInfo
{
    [Key]
    public int PackageInfoId { get; set; }

    public int? PackageId { get; set; }

    public string? ConsignmentPackage { get; set; }

    public string? CargoNumber { get; set; }

    public string? CountryOfOrigin { get; set; }

    public double? GrossWeight { get; set; }

    public string? Barcode { get; set; }

    //public virtual VtlPackage? Package { get; set; }
}
