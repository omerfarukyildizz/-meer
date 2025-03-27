using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class VtlPackageInfo
{
    public int PackageInfoId { get; set; }

    public int? PackageId { get; set; }

    public string? ConsignmentPackage { get; set; }

    public string? CargoNumber { get; set; }

    public string? CountryOfOrigin { get; set; }

    public double? GrossWeight { get; set; }

    public string? Barcode { get; set; }

    public virtual VtlPackage? Package { get; set; }
}
