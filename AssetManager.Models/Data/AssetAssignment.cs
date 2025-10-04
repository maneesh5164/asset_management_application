using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Models.Data
{
    public class AssetAssignment
    {
        public int AssetAssignmentId { get; set; }

        [Required(ErrorMessage = "Asset is required.")]
        public int AssetId { get; set; }

        [Required(ErrorMessage = "Employee is required.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Assigned date is required.")]
        public DateTime? AssignedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }

        public Asset Asset { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
    }
}
