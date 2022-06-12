﻿using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IRegionServiceAsync
    {
        Task<IEnumerable<RegionModel>> GetAllAsync();
        Task<int> AddRegionAsync(RegionModel model);
        Task<int> DeleteRegionAsync(int id);
        Task<int> UpdateRegionAsync(RegionModel model);
        Task<RegionModel> GetByIdAsync(int id);
    }
}
