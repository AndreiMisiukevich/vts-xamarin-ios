using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epam.Vts.Xamarin.Core.CrossCutting.Entities;

namespace Epam.Vts.Xamarin.Core.Data.DAC.Person
{
    public interface IPersonAccessComponent
    {
        Task<IEnumerable<PersonTransferModel>> GetAllAsync();
        Task<PersonTransferModel> GetByIdAsync(string id);
    }

    public class PersonAccessComponent: IPersonAccessComponent
    {
        public Task<IEnumerable<PersonTransferModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonTransferModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
