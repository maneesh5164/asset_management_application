using AssetManager.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Data.Repository
{
    public interface IAssetAssignmentRepository
    {
        Task<List<AssetAssignment>> GetAll();
        Task<AssetAssignment> GetById(int id);
        Task Add(AssetAssignment assignment);
        Task Update(AssetAssignment assignment);
        Task Delete(int id);
    }
}
