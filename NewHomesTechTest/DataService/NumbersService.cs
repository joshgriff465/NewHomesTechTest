using NewHomesTechTest.Models;
using NewHomesTechTest.DataService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NewHomesTechTest.DataService
{
    public class NumbersService : INumbers
    {
        private readonly dbContext _context;
        private bool disposedValue1;

        public NumbersService(dbContext context)
        {
            _context = context;
        }

        //standard dispose methods, not implemented properly due to time restrictions but set up for future use
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue1)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue1 = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~NumbersService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task<NumberModel> Create(NumberModel model)
        {
            await _context.Numbers.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<NumberModel>> Get()
        {
            return await _context.Numbers.OrderByDescending(b => b.CreatedDate).ToListAsync();
        }

    }
}
