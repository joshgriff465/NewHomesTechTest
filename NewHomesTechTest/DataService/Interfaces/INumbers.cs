using NewHomesTechTest.Models;

namespace NewHomesTechTest.DataService.Interfaces
{
    public interface INumbers : IDisposable
    {
        Task<List<NumberModel>> Get();
        Task<NumberModel> Create(NumberModel model);

    }
}
