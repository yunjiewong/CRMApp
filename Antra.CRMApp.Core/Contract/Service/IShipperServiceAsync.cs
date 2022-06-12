using System;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Core.Contract.Service
{
	public interface IShipperServiceAsync
	{
        Task<IEnumerable<ShipperModel>> GetAllAsync();
        Task<int> AddShipperAsync(ShipperModel model);
        Task<ShipperModel> GetByIdAsync(int id);
        Task<int> UpdateShipperAsync(ShipperModel model);
        Task<int> DeleteShipperAsync(int id);
    }
}

