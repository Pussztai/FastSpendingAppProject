using FastSpendingApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace FastSpendingApp.Data {
    public class FastSpendingDbContext:DbContext {
        public FastSpendingDbContext(DbContextOptions<FastSpendingDbContext> options) : base(options) {

        }

        public DbSet<Expense> Expenses { get; set; }
    }
}
