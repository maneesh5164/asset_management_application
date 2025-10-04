using AssetManager.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Models.Data
{
    public class Asset
    {
        public int AssetId { get; set; }  // Auto-generated

        [Required(ErrorMessage = "Asset name is required.")]
        [StringLength(100, ErrorMessage = "Asset name cannot exceed 100 characters.")]
        public string AssetName { get; set; } = null!;

        [Required(ErrorMessage = "Asset type is required.")]
        [StringLength(50, ErrorMessage = "Asset type cannot exceed 50 characters.")]
        public string AssetType { get; set; } = null!;

        [Required(ErrorMessage = "Make/Model is required.")]
        [StringLength(100, ErrorMessage = "Make/Model cannot exceed 100 characters.")]
        public string MakeModel { get; set; } = null!;

        [Required(ErrorMessage = "Serial number is required.")]
        [StringLength(50, ErrorMessage = "Serial number cannot exceed 50 characters.")]
        public string SerialNumber { get; set; } = null!;

        [Required(ErrorMessage = "Purchase date is required.")]
        public DateTime? PurchaseDate { get; set; }

        public DateTime? WarrantyExpiryDate { get; set; }

        [Required(ErrorMessage = "Condition is required.")]
        
        public AssetCondition Condition { get; set; } = AssetCondition.New;

        [Required(ErrorMessage = "Status is required.")]
        
        public AssetStatus Status { get; set; } = AssetStatus.Available; // Available, Assigned, etc.

        public bool? IsSpare { get; set; }

        [StringLength(500, ErrorMessage = "Specifications cannot exceed 500 characters.")]
        public string? Specifications { get; set; } // ✅ made nullable (optional)

        public ICollection<AssetAssignment> AssetAssignments { get; set; } = new List<AssetAssignment>();
    }


    public enum AssetCondition
    {
        None = 0,      // placeholder
        New = 1,
        Good = 2,
        NeedsRepair = 3,
        Damaged = 4
    }

    public enum AssetStatus
    {
        None = 0,      // placeholder
        Available = 1,
        Assigned = 2,
        UnderRepair = 3,
        Retired = 4
    }

}
