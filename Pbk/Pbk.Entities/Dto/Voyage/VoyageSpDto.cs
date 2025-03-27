using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Voyage
{
    public class VoyageSpDto
    {
        public int? VoyageId { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? CarrierId { get; set; }
        public string? CarrierName { get; set; }
        public int? TruckId { get; set; }
        public string? Truck { get; set; }
        public string? Trailer { get; set; }
        public int? TrailerId { get; set; }
        public string? DriverName { get; set; }
        public int? DriverId { get; set; }
        public int? CustomerId { get; set; }
        public string? StatusType { get; set; }
        public string? CustomerName { get; set; } 
        public DateTime? DepartureTime { get; set; }
        public string? DepartureLocationName { get; set; }
        public string? DeparturePostalCode { get; set; }
        public int? DepartureLocationId { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public string? ArrivalLocationName { get; set; }
        public string? ArrivalPostalCode { get; set; }
        public int? ArrivalLocationId { get; set; }
        public string? Description { get; set; }
        public decimal? TransportPrice { get; set; }
        public string? CarrierEmail { get; set; }
        public string? CurrencyCode { get; set; }
        public int? CurrencyId { get; set; }
        public string? BarsisSeferNo { get; set; }
        public decimal? EmptyKM { get; set; }
        public string? ProofofDelivery { get; set; }
        public string? CarrierInvoice { get; set; }
        public string? InsertUser { get; set; }
        public DateTime? InsertTime { get; set; }

    }
}
