using Pbk.Core.Features.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Carriers.Update
{ 
    public sealed record CarrierUpdateCommand
(
        int CarrierId,
     int DepartmentId,
     string CarrierName,
     string? SAPAccountCode,
     int? PaymentTerms,
     int? DocumentId,
     int TimocomId,
     string? ContactPerson,
     string? Email,
     string? Phone 
  ) : IRequest<APIResponse>;


}
