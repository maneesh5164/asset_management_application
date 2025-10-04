using AssetManager.Business.Interface;
using AssetManager.Data.Infrastructure;
using AssetManager.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Business.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dashboard> GetDashboardAsync(int topAssets = 10)
        {
            var dashboard = new Dashboard();

            // Overview counts
            dashboard.TotalAssets = await _context.Assets.CountAsync();
            dashboard.AssignedAssets = await _context.Assets.CountAsync(a => a.Status == AssetStatus.Assigned);
            dashboard.AvailableAssets = await _context.Assets.CountAsync(a => a.Status == AssetStatus.Available);
            dashboard.UnderRepairAssets = await _context.Assets.CountAsync(a => a.Status == AssetStatus.UnderRepair);
            dashboard.RetiredAssets = await _context.Assets.CountAsync(a => a.Status == AssetStatus.Retired);
            dashboard.SpareAssets = await _context.Assets.CountAsync(a => a.IsSpare == true);

            // Assets by Type
            dashboard.AssetsByType = await _context.Assets
                .GroupBy(a => a.AssetType)
                .Select(g => new { Type = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Type, x => x.Count);

            // Assets by Status
            dashboard.AssetsByStatus = await _context.Assets
                .GroupBy(a => a.Status)
                .Select(g => new { Status = g.Key.ToString(), Count = g.Count() })
                .ToDictionaryAsync(x => x.Status, x => x.Count);

            // Assets per Employee (assigned)
            dashboard.AssetsPerEmployee = await _context.AssetAssignments
                .Include(aa => aa.Employee)
                .GroupBy(aa => aa.Employee.FullName)
                .Select(g => new { Employee = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Employee, x => x.Count);

            // Assets by Condition
            dashboard.AssetsByCondition = await _context.Assets
                .GroupBy(a => a.Condition)
                .Select(g => new { Condition = g.Key.ToString(), Count = g.Count() })
                .ToDictionaryAsync(x => x.Condition, x => x.Count);

            // Latest assets for table
            dashboard.LatestAssets = await _context.Assets
                .Include(a => a.AssetAssignments)
                    .ThenInclude(aa => aa.Employee)
                .OrderByDescending(a => a.AssetId)
                .Take(topAssets)
                .ToListAsync();

            return dashboard;
        }
    }
    
}
