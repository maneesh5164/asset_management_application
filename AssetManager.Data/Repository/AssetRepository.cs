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
    public class AssetRepository : IAssetRepository
    {
        private readonly AppDbContext _db;
        public AssetRepository(AppDbContext db) { _db = db; }

        public async Task<List<Asset>> GetAll()
        {
            try
            {
                return await _db.Assets.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error retrieving assets.", ex);
            }
        }

        public async Task<Asset> GetById(int id)
        {
            try
            {
                return await _db.Assets.FindAsync(id);
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException($"Error retrieving asset with ID {id}.", ex);
            }
        }

        public async Task Add(Asset asset)
        {
            try
            {
                _db.Assets.Add(asset);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error adding asset.", ex);
            }
        }

        public async Task Update(Asset asset)
        {
            try
            {
                _db.Assets.Update(asset);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error updating asset.", ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var asset = await _db.Assets.FindAsync(id);
                if (asset != null)
                {
                    _db.Assets.Remove(asset);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException($"Error deleting asset with ID {id}.", ex);
            }
        }
    }
}
