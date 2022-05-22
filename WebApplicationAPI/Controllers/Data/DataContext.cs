using Microsoft.EntityFrameworkCore;

namespace WebApplicationAPI.Controllers.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<EmployesDetail> Employes { get; set; }

    }
}
