using System;
using System.Collections.Generic;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Infrastructure.Service
{
	public class ShipperServiceAsync: IShipperServiceAsync
	{
        private readonly IShipperRepositoryAsync repositoryAsync;
        public ShipperServiceAsync(IShipperRepositoryAsync _ship)
		{
            repositoryAsync = _ship;
        }

        public async Task<int> AddShipperAsync(ShipperModel model)
        {
            Shipper shipper = new Shipper();
            shipper.Id = model.Id;
            shipper.Name = model.Name;
            shipper.Phone = model.Phone;
            return await repositoryAsync.InsertAsync(shipper);
        }

        public async Task<int> DeleteShipperAsync(int id)
        {
            return await repositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShipperModel>> GetAllAsync()
        {
            var collection = await repositoryAsync.GetAllAsync();
            if(collection != null)
            {
                List<ShipperModel> shipperModels = new List<ShipperModel>();
                foreach(var item in collection)
                {
                    ShipperModel shipper = new ShipperModel();
                    shipper.Id = item.Id;
                    shipper.Name = item.Name;
                    shipper.Phone = item.Phone;
                    shipperModels.Add(shipper);
                }
                return shipperModels;
            }
            return null;
        }

        public async Task<ShipperModel> GetByIdAsync(int id)
        {
            var item = await repositoryAsync.GetByIdAsync(id);
            if(item != null)
            {
                ShipperModel shipper = new ShipperModel();
                shipper.Id = item.Id;
                shipper.Name = item.Name;
                shipper.Phone = item.Phone;
                return shipper;
            }
            return null;
        }

        public async Task<int> UpdateShipperAsync(ShipperModel item)
        {
            Shipper shipper = new Shipper();
            shipper.Id = item.Id;
            shipper.Name = item.Name;
            shipper.Phone = item.Phone;

            return await repositoryAsync.UpdateAsync(shipper);
        }
    }
}

