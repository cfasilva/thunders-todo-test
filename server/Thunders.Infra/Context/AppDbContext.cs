using Microsoft.EntityFrameworkCore;
using Thunders.Domain.Models;

namespace Thunders.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<TaskModel> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
