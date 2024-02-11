using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewHomesTechTest.Models
{
    public class dbContext : DbContext
    {

        public DbSet<NumberModel>

        Numbers { get; set; }

        public dbContext(DbContextOptions<dbContext> options)

        : base(options)

        {

        }
    }
}