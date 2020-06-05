using System.Collections.Generic;
using System.Threading.Tasks;
using car_api_aspnet_core.DataAccess;
using car_api_aspnet_core.Interfaces;
using car_api_aspnet_core.Model;

namespace car_api_aspnet_core.Domain
{
    public class OwnerDomain : IOwnerDomain
    {
        private readonly IOwnerDA _ownerDa;

        public OwnerDomain(IOwnerDA ownerDa)
        {
            _ownerDa = ownerDa;
        }
        public Task<IEnumerable<Owner>> GetAll()
        {
            return _ownerDa.GetAll();
        }

        public Task<IOwnerResponse> Get(int id)
        {
            return _ownerDa.Get(id);
        }

        public Task<IOwnerResponse> Add(Owner owner)
        {
            return _ownerDa.Add(owner);
        }
    }
}