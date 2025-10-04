using AssetManager.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Business.Interface
{
    public interface IDashboardService
    {
        Task<Dashboard> GetDashboardAsync(int topAssets = 10);
    }
}
