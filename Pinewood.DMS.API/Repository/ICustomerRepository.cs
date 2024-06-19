using Pinewood.DMS.API.DTO;
using Pinewood.DMS.API.DTO.Response;

namespace Pinewood.DMS.API.Repository
{
    public interface ICustomerRepository
    {
        Task<int> CreateCustomerAsync(CreateCustomerRequest request);
        Task<GetCustomerListResponse> GetCustomerById(int customerId);
        Task<List<GetCustomerListResponse>> GetCustomerListAsync();
        Task<int> UpdateCustomerAsync(UpdateCustomerRequest request);
        Task<int> DeleteCustomerAsync(IdDTO request);
    }
}
