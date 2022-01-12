using BetCommerce.Entities.Common;
using System.Threading.Tasks;

namespace BetCommerce.Services
{
    public interface ICommonService
    {
        Task<(string, CodeGenerator)> GenerateCode(object[] args);
    }
}