using Microsoft.EntityFrameworkCore;
using SampleCrudApplication.Models.Entities;

namespace SampleCrudApplication.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {   
        }

        public DbSet<Movies> Movies { get; set; }
    }
}
