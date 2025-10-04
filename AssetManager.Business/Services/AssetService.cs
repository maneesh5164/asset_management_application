using AssetManager.Business.Interface;
using AssetManager.Data.Repository;
using AssetManager.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Business.Services
{
    public class AssetService: IAssetService
    {
        private readonly IAssetRepository _repo;

        public AssetService(IAssetRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Asset>> GetAll()
        {
            try
            {
                return await _repo.GetAll();
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
                return await _repo.GetById(id);
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
                await _repo.Add(asset);
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
                await _repo.Update(asset);
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
                await _repo.Delete(id);
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException($"Error deleting asset with ID {id}.", ex);
            }
        }
    }
}
