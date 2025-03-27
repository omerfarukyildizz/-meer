using Pbk.Entities.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Pbk.Entities.Models
{
    public class OperationClaim : Entity
    {
        [Key]
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
        public bool IsActive { get; set; }
        public int InsUserId { get; set; }
        public DateTime InsDate { get; set; }
    }
}
