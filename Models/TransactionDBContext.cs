using Microsoft.EntityFrameworkCore;

namespace BankTranscation.Models
{
    public class TransactionDBContext : DbContext
    {

        public TransactionDBContext(DbContextOptions<TransactionDBContext> options) :base(options)
        {
            
        }
        public DbSet<Transactions> Transactions { get; set; }


    }
}
