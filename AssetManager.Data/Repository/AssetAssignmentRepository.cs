using AssetManager.Data.Infrastructure;
using AssetManager.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Data.Repository
{
    public class AssetAssignmentRepository : IAssetAssignmentRepository
    {
        private readonly AppDbContext _db;
        public AssetAssignmentRepository(AppDbContext db) { _db = db; }

        public async Task<List<AssetAssignment>> GetAll() =>
            await _db.AssetAssignments.Include(a => a.Employee).Include(a => a.Asset).ToListAsync();

        public async Task<AssetAssignment> GetById(int id) =>
            await _db.AssetAssignments.Include(a => a.Employee).Include(a => a.Asset)
                .FirstOrDefaultAsync(a => a.AssetAssignmentId == id);

        public async Task Add(AssetAssignment assign) { _db.AssetAssignments.Add(assign); await _db.SaveChangesAsync(); }
        public async Task Update(AssetAssignment assign) { _db.AssetAssignments.Update(assign); await _db.SaveChangesAsync(); }
        public async Task Delete(int id)
        {
            var assign = await _db.AssetAssignments.FindAsync(id);
            if (assign != null) { _db.AssetAssignments.Remove(assign); await _db.SaveChangesAsync(); }
        }
    }
}
