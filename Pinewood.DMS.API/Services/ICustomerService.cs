using Pinewood.DMS.API.DTO;
using Pinewood.DMS.API.DTO.Response;

namespace Pinewood.DMS.API.Services
{
    public interface ICustomerService
    {
        Task<int> CreateCustomerAsync(CreateCustomerRequest request);

        Task<List<GetCustomerListResponse>> GetCustomerListAsync();

        Task<GetCustomerListResponse> GetCustomerById(int customerId);

        Task<int> UpdateCustomerAsync(UpdateCustomerRequest request);
        Task<int> DeleteCustomerAsync(IdDTO request);
    }
}
