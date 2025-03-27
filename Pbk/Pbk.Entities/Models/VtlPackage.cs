using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models;

public partial class VtlPackage
{
    [Key]
    public int PackageId { get; set; }

    public int ShipmentId { get; set; }

    public string? ConsignmentPackage { get; set; }

    public string? NumberOfPackages { get; set; }

    public string? PackageType { get; set; }

    public string? CargoContents { get; set; }

    public string? Identifier { get; set; }

    public double? ActualWeight { get; set; }

    public double? Length { get; set; }

    public double? Width { get; set; }

    public double? Height { get; set; }

    public double? Volume { get; set; }

    public double? Lademetre { get; set; }

    public bool? Adr { get; set; }

    //public virtual Shipment Shipment { get; set; } = null!;

    //public virtual ICollection<VtlPackageADR> VtlPackageADRs { get; set; } = new List<VtlPackageADR>();

    //public virtual ICollection<VtlPackageInfo> VtlPackageInfos { get; set; } = new List<VtlPackageInfo>();
}
