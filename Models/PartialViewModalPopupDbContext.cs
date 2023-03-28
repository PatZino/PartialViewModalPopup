using Microsoft.EntityFrameworkCore;

namespace PartialViewModalPopup.Models
{
    public class PartialViewModalPopupDbContext: DbContext
    {
        public PartialViewModalPopupDbContext(DbContextOptions<PartialViewModalPopupDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
