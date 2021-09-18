using System.Collections.Generic;
using System.Threading.Tasks;
using TestReal.Services.Interfaces.Dtos;
using TestReal.Services.Interfaces.ViewModels;

namespace TestReal.Services.Interfaces
{
    public interface IUserRegistrationService
    {
        Task Create(CreateUserRegistrationViewModel viewModel);
        Task Update(UpdateUserRegistrationViewModel viewModel);
        Task<IEnumerable<UserRegistrationDto>> GetAll();
        Task<UserRegistrationDto> GetDetail(int userId);
        Task Delete(int userId);
    }
}