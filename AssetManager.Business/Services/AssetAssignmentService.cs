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
    public class AssetAssignmentService: IAssetAssignmentService
    {
        private readonly IAssetAssignmentRepository _repo;

        public AssetAssignmentService(IAssetAssignmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<AssetAssignment>> GetAll()
        {
            try
            {
                return await _repo.GetAll();
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error retrieving asset assignments.", ex);
            }
        }

        public async Task<AssetAssignment> GetById(int id)
        {
            try
            {
                return await _repo.GetById(id);
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException($"Error retrieving asset assignment with ID {id}.", ex);
            }
        }

        public async Task Add(AssetAssignment assign)
        {
            try
            {
                await _repo.Add(assign);
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error adding asset assignment.", ex);
            }
        }

        public async Task Update(AssetAssignment assign)
        {
            try
            {
                await _repo.Update(assign);
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error updating asset assignment.", ex);
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
                
                throw new ApplicationException($"Error deleting asset assignment with ID {id}.", ex);
            }
        }
    }
}
