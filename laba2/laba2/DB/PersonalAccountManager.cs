using laba2.Models;
using System.Data.Entity;

namespace laba2.DB
{
    public class PersonalAccountManager : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<Cost> Costs { get; set; }
    }
}
