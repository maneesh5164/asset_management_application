using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Models.Data
{
    public class Dashboard
    {
        public int TotalAssets { get; set; }
        public int AssignedAssets { get; set; }
        public int AvailableAssets { get; set; }
        public int UnderRepairAssets { get; set; }
        public int RetiredAssets { get; set; }
        public int SpareAssets { get; set; }

        // Assets by type
        
        
        public Dictionary<string, int> AssetsByType { get; set; } = new();
        public Dictionary<string, int> AssetsByStatus { get; set; } = new();
        public Dictionary<string, int> AssetsPerEmployee { get; set; } = new();
        public Dictionary<string, int> AssetsByCondition { get; set; } = new();

        // Latest assets (for table)
        public List<Asset> LatestAssets { get; set; } = new();
    }
}
