﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epam.Vts.Xamarin.Core.CrossCutting.Entities;

namespace Epam.Vts.Xamarin.Core.Data.DAC.Vacation
{
    internal class HttpVacationState : IVacationAccessComponent
    {
        private readonly IRestService _restService;

        public HttpVacationState(IRestService restService)
        {
            _restService = restService;
        }

        public Task<IEnumerable<VacationInfoTransferModel>> GetAllAsync()
        {
            return _restService.GetAllVacations();
        }

        public async Task<VacationInfoTransferModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(VacationInfoTransferModel transferModel)
        {
            return _restService.UpdateVacation(transferModel);
        }

        public Task DeleteAsync(VacationInfoTransferModel transferModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(VacationInfoTransferModel transferModel)
        {
            return _restService.AddVacation(transferModel);
        }
    }
}
