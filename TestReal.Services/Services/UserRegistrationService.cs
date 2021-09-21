using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TestReal.Persistence;
using TestReal.Persistence.Domain;
using TestReal.Services.Interfaces;
using TestReal.Services.Interfaces.Dtos;
using TestReal.Services.Interfaces.ViewModels;

namespace TestReal.Services.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        public UserRegistrationService(IAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task Create(CreateUserRegistrationViewModel viewModel)
        {
            var userRegistration = mapper.Map<UserRegistration>(viewModel);

            userRegistration.DateLastActivity = viewModel.DateRegistration;

            await dbContext.AddAsync(userRegistration);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(UpdateUserRegistrationViewModel viewModel)
        {
            var userRegistration = await dbContext.Set<UserRegistration>()
                .FirstOrDefaultAsync(p => p.UserId == viewModel.UserId);

            if (userRegistration.DateRegistration > viewModel.DateLastActivity)
            {
                throw new Exception("Дата последней активности не может быть раньше даты регистрации");
            }

            userRegistration.DateLastActivity = viewModel.DateLastActivity;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRegistrationDto>> GetAll()
        {
            return await Task.FromResult(dbContext.Set<UserRegistration>()
                .ProjectTo<UserRegistrationDto>(mapper.ConfigurationProvider));
        }

        public async Task<UserRegistrationDto> GetDetail(int userId)
        {
            var userRegistration = await dbContext.Set<UserRegistration>()
                .FirstOrDefaultAsync(p => p.UserId == userId);
            return mapper.Map<UserRegistrationDto>(userRegistration);
        }

        public async Task Delete(int userId)
        {
            var user = await dbContext.Set<UserRegistration>().FirstOrDefaultAsync(p => p.UserId == userId);

            dbContext.Set<UserRegistration>().Remove(user);
            await dbContext.SaveChangesAsync();
        }
    }
}