using System.Threading.Tasks;
using TestReal.Services.Interfaces.Dtos;

namespace TestReal.Services.Interfaces
{
    public interface ICalculationService
    {
        Task<CalculationDto> Calculate(int rollingRetentionDay);
    }
}