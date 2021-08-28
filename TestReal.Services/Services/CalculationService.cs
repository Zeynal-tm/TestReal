using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestReal.Persistence;
using TestReal.Persistence.Domain;
using TestReal.Services.Interfaces;
using TestReal.Services.Interfaces.Dtos;

namespace TestReal.Services.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        public CalculationService(IAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CalculationDto> Calculate(int rollingRetentionDay)
        {
            var activatedUsers = dbContext.Set<UserRegistration>()
                .Where(p => p.DateLastActivity >= DateTime.Now.AddDays(-rollingRetentionDay))
                .ToListAsync().Result.Count;

            double registratedUsers = dbContext.Set<UserRegistration>()
                .Where(p => p.DateRegistration <= DateTime.Now.AddDays(-rollingRetentionDay))
                .ToListAsync().Result.Count;

            double result = (activatedUsers / registratedUsers) * 100;

            var calculationDto = new CalculationDto()
            {
                RollingRetentionDays = $"Rolling Retention {rollingRetentionDay} day",
                RollingRetention = result
            };

            return calculationDto;
        }
    }
}