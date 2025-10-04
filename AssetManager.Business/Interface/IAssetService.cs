using AssetManager.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Business.Interface
{
    public interface IAssetService
    {
        Task<List<Asset>> GetAll();
        Task<Asset> GetById(int id);
        Task Add(Asset asset);
        Task Update(Asset asset);
        Task Delete(int id);
    }
}
