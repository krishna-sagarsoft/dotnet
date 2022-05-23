using Microsoft.EntityFrameworkCore;

namespace TrainingService.Models
{
    public class ContactsDBContext : DbContext
    {
        private static bool created = false;

        public ContactsDBContext(DbContextOptions<ContactsDBContext> options) : base(options)
        {
            if (!created)
            {
                created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
