using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class VtlPackageADR
{
    [Key]
    public int PackageADRId { get; set; }

    public int? PackageId { get; set; }

    public bool ADR { get; set; }

    public string? ADRUn { get; set; }

    public int ADRNumberOfPackages { get; set; }

    public string? ADRPackageType { get; set; }

    public decimal? ADRNem { get; set; }

    public string? ADRNag { get; set; }

    public bool ADRLq { get; set; }

    public bool ADREq { get; set; }

    public bool ADRRuUg { get; set; }

    public int? edpAdrTypeId { get; set; }

    public decimal? AdrActualWeight { get; set; }

    //public virtual VtlPackage? Package { get; set; }
}
