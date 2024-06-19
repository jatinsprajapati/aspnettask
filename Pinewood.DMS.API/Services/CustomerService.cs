using Pinewood.DMS.API.DTO;
using Pinewood.DMS.API.DTO.Response;
using Pinewood.DMS.API.Repository;

namespace Pinewood.DMS.API.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _iCustomerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _iCustomerRepository = customerRepository;
        }
        public async Task<int> CreateCustomerAsync(CreateCustomerRequest request) => await _iCustomerRepository.CreateCustomerAsync(request);

        public async Task<List<GetCustomerListResponse>> GetCustomerListAsync() => await _iCustomerRepository.GetCustomerListAsync();
        public async Task<GetCustomerListResponse> GetCustomerById(int customerId)=>await _iCustomerRepository.GetCustomerById(customerId);
        public async Task<int> UpdateCustomerAsync(UpdateCustomerRequest request) => await _iCustomerRepository.UpdateCustomerAsync(request);
        public async Task<int> DeleteCustomerAsync(IdDTO request) => await _iCustomerRepository.DeleteCustomerAsync(request);
    }
}
